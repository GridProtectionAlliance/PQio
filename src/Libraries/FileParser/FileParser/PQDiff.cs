//******************************************************************************************************
//  PQDiff.cs - Gbtc
//
//  Copyright © 2020, Grid Protection Alliance.  All Rights Reserved.
//
//  Licensed to the Grid Protection Alliance (GPA) under one or more contributor license agreements. See
//  the NOTICE file distributed with this work for additional information regarding copyright ownership.
//  The GPA licenses this file to you under the MIT License (MIT), the "License"; you may
//  not use this file except in compliance with the License. You may obtain a copy of the License at:
//
//      http://www.opensource.org/licenses/MIT
//
//  Unless agreed to in writing, the subject software distributed under the License is distributed on an
//  "AS-IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. Refer to the
//  License for the specific language governing permissions and limitations.
//
//  Code Modification History:
//  ----------------------------------------------------------------------------------------------------
//  03/18/2020 - C. Lackner
//       Original version of source code generated.
//
//******************************************************************************************************


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using GSF.Data;
using GSF.PQDIF.Logical;
using PQio.Model;

namespace FileParser
{
    /// <summary>
    /// Class that parses a PQDSIF File for the PQDS software tool.
    /// </summary>
    public class PQDIFFparser
    {

        #region[properties]
        private IProgress<int> mProgress;
        private int m_previousProgress;

        private string connectionstring;
        private const string dataprovider = "AssemblyName={System.Data.SQLite, Version=1.0.109.0, Culture=neutral, PublicKeyToken=db937bc2d44ff139}; ConnectionType=System.Data.SQLite.SQLiteConnection; AdapterType=System.Data.SQLite.SQLiteDataAdapter";


        #endregion[properties]

        #region[methods]

        /// <summary>
        /// creates a new Instance of a <see cref="PQDIFFparser"/>.
        /// </summary>
        public PQDIFFparser ()
        {
            this.m_previousProgress = 0;
            string localAppData = $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}{Path.DirectorySeparatorChar}PQio{Path.DirectorySeparatorChar}DataBase.db";
            this.connectionstring = $"Data Source={localAppData}; Version=3; Foreign Keys=True; FailIfMissing=True";
        }

        /// <summary>
        /// Parses a single PQDIF File.
        /// </summary>
        /// <param name="filename"> Name of the PQDIF File</param>
        /// <param name="progress"> <see cref="IProgress{T}"/> provides interface to Progress</param>
        /// <returns>task that return true when successfull or false if failed </returns>
        public Task<bool> ParsePQDIFFile(string filename, IProgress<int> progress)
        {
            this.mProgress = progress;
            Task<bool> result = Task.Run<bool>(() =>
            {
                try
                {
                    Parse(filename);
                    return true;
                }
                catch
                {
                    return false;
                }
            });

            return result;

        }

        /// <summary>
        /// Parses multiple PQDIF File.
        /// </summary>
        /// <param name="filenames"> Name of the PQDIF Files</param>
        /// <param name="progress"> <see cref="IProgress{T}"/> provides interface to Progress</param>
        /// <returns>task that returns number of successfully read files </returns>
        public Task<int> ParsePQDIFFiles(string[] filenames, IProgress<int> progress)
        {

            this.mProgress = progress;

            Task<int> result = Task<int>.Run(() =>
            {
                int nSuccess = 0;
                for (int i = 0; i < filenames.Count(); i++)
                {
                    try
                    {
                        Parse(filenames[i]);
                        nSuccess++;
                    }
                    catch
                    { }
                }
                return nSuccess;

            });

            return result;
        }

        private void Parse(string filename)
        {

            List<ObservationRecord> observationRecords;
            List<DataSourceRecord> dataSourceRecords;

            using (LogicalParser logicalParser = new LogicalParser(filename))
            {
                observationRecords = new List<ObservationRecord>();
                logicalParser.Open();

                while (logicalParser.HasNextObservationRecord())
                    observationRecords.Add(logicalParser.NextObservationRecord());

                dataSourceRecords = logicalParser.DataSourceRecords;
            }

            this.m_previousProgress = this.m_previousProgress + 50;
            this.mProgress.Report(this.m_previousProgress);

            if (observationRecords.Count == 0) { return; }
            if (dataSourceRecords.Count != 1) { return; }

            //create Meter Definition
            //For now assume a single meter
            Meter meter = new Meter();

            meter.DeviceName = dataSourceRecords[0].DataSourceName;
            meter.Owner = dataSourceRecords[0].DataSourceOwner;
            meter.DeviceAlias = GSF.PQDIF.Logical.Equipment.ToString(dataSourceRecords[0].EquipmentID);
            meter.DeviceLocation = dataSourceRecords[0].DataSourceLocation;
            if (dataSourceRecords[0].Latitude < uint.MaxValue)
            {
                meter.Latitude = dataSourceRecords[0].Latitude;
            }
            if (dataSourceRecords[0].Longitude < uint.MaxValue)
            {
                meter.Longitude = dataSourceRecords[0].Longitude;
            }

            meter.AccountName = GSF.PQDIF.Logical.Vendor.ToString(dataSourceRecords[0].VendorID);

            using (TransactionScope scope = new TransactionScope())
            {
                AdoDataConnection connection = new AdoDataConnection(connectionstring, dataprovider);
                
                GSF.Data.Model.TableOperations<Meter> meterTable = new GSF.Data.Model.TableOperations<Meter>(connection);

                meterTable.AddNewRecord(meter);
                meter.ID = ModelID.GetID<Meter>(connection);
                

                //create Channel Definitions
                List<PQio.Model.Channel> channels = dataSourceRecords[0].ChannelDefinitions.Select(channel => ParseChannel(meter, channel, connection)).ToList();
                List<PQio.Model.Event> events = new List<Event>();
                //create Event Definitions
                foreach (ObservationRecord record in observationRecords)
                {
                    //Create Event
                    Event evt = ParseObservationRecord(record, connection);

                    //create DataSeries objects
                    foreach (ChannelInstance channelInstance in record.ChannelInstances)
                    {
                        ParseSeries(channelInstance, channels[(int)channelInstance.ChannelDefinitionIndex], evt, connection);
                    }
                    events.Add(evt);
                }

                // Remove Channels whithout data
                channels = channels.FindAll(item => RemoveEmptyChannel(item, connection)).ToList();
                events = events.FindAll(item => RemoveEmptyEvents(item, connection)).ToList();

                // Remove Channels whithout data
                channels = channels.FindAll(item => RemoveEmptyChannel(item, connection)).ToList();

                // If only one set of data it's easy to keep only single line
                int nVa = channels.Count(channel => channel.MeasurementType.ToLower() == MeasurementType.VoltageA);
                int nVb = channels.Count(channel => channel.MeasurementType.ToLower() == MeasurementType.VoltageB);
                int nVc = channels.Count(channel => channel.MeasurementType.ToLower() == MeasurementType.VoltageC);
                int nIa = channels.Count(channel => channel.MeasurementType.ToLower() == MeasurementType.CurrentA);
                int nIb = channels.Count(channel => channel.MeasurementType.ToLower() == MeasurementType.CurrentB);
                int nIc = channels.Count(channel => channel.MeasurementType.ToLower() == MeasurementType.CurrentC);

                if (nVa == 1 && nVb == 1 && nVc == 1)
                {
                    //Create new asset
                    Asset asset = new Asset() { AssetKey = String.Format("Asset 1 ({0})", meter.AccountName) };

                    
                        GSF.Data.Model.TableOperations<Asset> assetTable = new GSF.Data.Model.TableOperations<Asset>(connection);
                        assetTable.AddNewRecord(asset);
                        asset.ID = ModelID.GetID<Asset>(connection);

                        GSF.Data.Model.TableOperations<Channel> channelTable = new GSF.Data.Model.TableOperations<Channel>(connection);

                        Channel Va = channels.Find(item => item.MeasurementType.ToLower() == MeasurementType.VoltageA);
                        Channel Vb = channels.Find(item => item.MeasurementType.ToLower() == MeasurementType.VoltageB);
                        Channel Vc = channels.Find(item => item.MeasurementType.ToLower() == MeasurementType.VoltageC);

                        Va.AssetID = asset.ID;
                        Vb.AssetID = asset.ID;
                        Vc.AssetID = asset.ID;

                        channelTable.UpdateRecord(Va);
                        channelTable.UpdateRecord(Vb);
                        channelTable.UpdateRecord(Vc);

                        if (nIa == 1 && nIb == 1 && nIc == 1)
                        {
                            Channel Ia = channels.Find(item => item.MeasurementType.ToLower() == MeasurementType.CurrentA);
                            Channel Ib = channels.Find(item => item.MeasurementType.ToLower() == MeasurementType.CurrentB);
                            Channel Ic = channels.Find(item => item.MeasurementType.ToLower() == MeasurementType.CurrentC);

                            Ia.AssetID = asset.ID;
                            Ib.AssetID = asset.ID;
                            Ic.AssetID = asset.ID;

                            channelTable.UpdateRecord(Ia);
                            channelTable.UpdateRecord(Ib);
                            channelTable.UpdateRecord(Ic);

                        }
                    
                }

                scope.Complete();
            }
            this.m_previousProgress = this.m_previousProgress + 50;
            this.mProgress.Report(this.m_previousProgress);
        }

        private Channel ParseChannel(Meter meter, GSF.PQDIF.Logical.ChannelDefinition channeldef, AdoDataConnection connection)
        {
            Channel channel = new Channel();

            channel.MeterID = meter.ID;
            channel.Name = channeldef.ChannelName;

            GSF.PQDIF.Logical.QuantityMeasured quantity = channeldef.QuantityMeasured;
            Guid quantityType = channeldef.QuantityTypeID;
            GSF.PQDIF.Logical.Phase phase = channeldef.Phase;

                if (isRMS(quantityType))
                { channel.SignalType = SignalType.RMS; }
                else if (isPOW(quantityType))
                { channel.SignalType = SignalType.PointOnWave; }
                else
                { channel.SignalType = SignalType.other; }

            Boolean isV = quantity == QuantityMeasured.Voltage;
            Boolean isI = quantity == QuantityMeasured.Current;

            Boolean isA = (phase == Phase.AN)|| (phase == Phase.AB);
            Boolean isB = (phase == Phase.BN) || (phase == Phase.BC);
            Boolean isC = (phase == Phase.CN) || (phase == Phase.CA);
            Boolean isN = phase == Phase.Residual;



                            
            string measurementname = MeasurementType.other;
            if (isV && isA)
            { measurementname = MeasurementType.VoltageA; }
            else if (isV && isB)
            { measurementname = MeasurementType.VoltageB; }
            else if (isV && isC)
            { measurementname = MeasurementType.VoltageC; }
            else if (isI && isA)
            { measurementname = MeasurementType.CurrentA; }
            else if (isI && isB)
            { measurementname = MeasurementType.CurrentB; }
            else if (isI && isC)
            { measurementname = MeasurementType.CurrentC; }
            else if (isV && isN)
            { measurementname = MeasurementType.other; }
            else if (isI && isN)
            { measurementname = MeasurementType.other; }

            GSF.Data.Model.TableOperations<Channel> channelTable = new GSF.Data.Model.TableOperations<Channel>(connection);

            channel.MeasurementType = measurementname;

            channelTable.AddNewRecord(channel);
            channel.ID = ModelID.GetID<Channel>(connection);
            

            return channel;
        }

        private PQio.Model.Event ParseObservationRecord(GSF.PQDIF.Logical.ObservationRecord record, AdoDataConnection connection)
        {
            Event evt = new Event();
            evt.EventTime = record.StartTime;
            evt.Name = record.Name;
            evt.GUID = new Guid().ToString();

            //Add Disturbance Category record in GSF
            
            GSF.Data.Model.TableOperations<Event> evtTable = new GSF.Data.Model.TableOperations<Event>(connection);
            evtTable.AddNewRecord(evt);
            evt.ID = ModelID.GetID<Event>(connection);
            

            return evt;
        }

        private void ParseSeries(GSF.PQDIF.Logical.ChannelInstance channelInstance, Channel channel, Event evt, AdoDataConnection connection)
        {
            DataSeries dataSeries = new DataSeries();
            dataSeries.EventID = evt.ID;
            dataSeries.ChannelID = channel.ID;


            Guid quantityType = channelInstance.Definition.QuantityTypeID;

            SeriesInstance timeSeries = null;
            SeriesInstance valuesSeries = null;

            if (isPOW(quantityType))
            {
                timeSeries = channelInstance.SeriesInstances.Single(series => series.Definition.ValueTypeID == SeriesValueType.Time);
                valuesSeries = channelInstance.SeriesInstances.Single(series => series.Definition.ValueTypeID == SeriesValueType.Val);
            }
            else { return; }


            List<double> values = valuesSeries.OriginalValues.Select(val => Convert.ToDouble(val)).ToList();
            List<DateTime> timeStamps = new List<DateTime>();

            if (timeSeries.Definition.QuantityUnits == QuantityUnits.Seconds)
            {
                // If time series is in seconds from start time of the observation record,
                // TimeValues must be calculated by adding values to start time
                timeStamps = timeSeries.OriginalValues
                    .Select(Convert.ToDouble)
                    .Select(seconds => (long)(seconds * TimeSpan.TicksPerSecond))
                    .Select(TimeSpan.FromTicks)
                    .Select(timeSpan => channelInstance.ObservationRecord.StartTime + timeSpan)
                    .ToList();
            }
            else if (timeSeries.Definition.QuantityUnits == QuantityUnits.Timestamp)
            {
                // If time series is a collection of absolute time, seconds from start time
                // must be calculated by subtracting the start time of the observation record
                timeStamps = timeSeries.OriginalValues.Cast<DateTime>().ToList();
            }

            dataSeries.Series = timeStamps.Select((item, index) => new DataPoint()
            {
                Time = item,
                Value = values[index]
            }).ToList();

            
                GSF.Data.Model.TableOperations<DataSeries> dataSeriesTable = new GSF.Data.Model.TableOperations<DataSeries>(connection);
                dataSeriesTable.AddNewRecord(dataSeries);
            
        }

        private Boolean RemoveEmptyChannel(Channel channel, AdoDataConnection connection)
        {
            
                GSF.Data.Model.TableOperations<DataSeries> dataSeriesTable = new GSF.Data.Model.TableOperations<DataSeries>(connection);
                GSF.Data.Model.TableOperations<Channel> channelTable = new GSF.Data.Model.TableOperations<Channel>(connection);
                
                int nEvents = dataSeriesTable.QueryRecordCountWhere("ChannelID = {0} ",channel.ID);

                if (nEvents == 0)
                {
                    //remove corresponsing MeasurmentID
                    channelTable.DeleteRecord(channel);
                    return false;
                }
                else
                { return true; }
            
        }

        private Boolean RemoveEmptyEvents(Event evt, AdoDataConnection connection)
        {
            GSF.Data.Model.TableOperations<DataSeries> dataSeriesTable = new GSF.Data.Model.TableOperations<DataSeries>(connection);
            GSF.Data.Model.TableOperations<Event> evtTable = new GSF.Data.Model.TableOperations<Event>(connection);

            int nEvents = dataSeriesTable.QueryRecordCountWhere("EventID = {0} ", evt.ID);

            if (nEvents == 0)
            {
                evtTable.DeleteRecord(evt);
                return false;
            }
            else
            { return true; }
            
        }

        // The following 2 functions need to be updated to be compatible with the standard < 1.5
        // This requires some changes in the gsf library
        private bool isRMS(Guid quantityType)
        {
            return (quantityType == GSF.PQDIF.Logical.QuantityType.Phasor);
        }

        private bool isPOW(Guid quantityType)
        {
            return (quantityType == GSF.PQDIF.Logical.QuantityType.WaveForm);
        }

        #endregion[methods]

    }
}