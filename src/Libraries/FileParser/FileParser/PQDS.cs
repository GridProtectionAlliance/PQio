//******************************************************************************************************
//  PQDS.cs - Gbtc
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
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GSF.Data;
using PQio.Model;
using PQDS;

namespace FileParser
{
    /// <summary>
    /// Class that parses a PQDS File for the PQDS software tool.
    /// This won't work for the openXDA
    /// </summary>
    public class PQDSParser
    {

        #region[properties]
        private string m_logilename;
        private int m_prevProgress;
        private IProgress<int> mProgress;
        #endregion[properties]

        #region[Constructor]

        /// <summary>
        /// creates a new Instance of a <see cref="PQDSParser"/>.
        /// </summary>
        /// <param name="logfile"> Name of the PQDS log file</param>
        public PQDSParser(string logfile)
        {
            this.m_logilename = logfile;
            this.m_prevProgress = 0;
        }

        /// <summary>
        /// creates a new Instance of a <see cref="PQDSParser"/> without logging.
        /// </summary>
        public PQDSParser()
        {
            this.m_logilename = null;
            this.m_prevProgress = 0;
        }

        #endregion[Constructor]

        #region[methods]

        /// <summary>
        /// Parses a single PQDS File.
        /// </summary>
        /// <param name="filename"> Name of the PQDS File</param>
        /// <param name="progress"> <see cref="IProgress{T}"/> provides interface to Progress</param>
        /// <returns>task that return true when successfull or false if failed </returns>
        public Task<bool> ParsePQDSFile(string filename, IProgress<int> progress)
        {
            this.mProgress = progress;
            Task<bool> result = Task.Run<bool>(() =>
            {
                try
                {
                    ParseFromPQDS(filename);
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
        /// Parses multiple PQDS File.
        /// </summary>
        /// <param name="filenames"> Name of the PQDS Files</param>
        /// <param name="progress"> <see cref="IProgress{T}"/> provides interface to Progress</param>
        /// <returns>task that returns number of successfully read files </returns>
        public Task<int> ParsePQDSFiles(string[] filenames, IProgress<int> progress)
        {
            
            this.mProgress = progress;

            Task<int> result = Task<int>.Run(() =>
            {
                int nSuccess = 0;
                for (int i = 0; i < filenames.Count(); i++)
                {
                    try
                    {
                        ParseFromPQDS(filenames[i]);
                        nSuccess++;
                    }
                    catch
                    { }
                }
                return nSuccess;

            });

            return result;
        }

        /// <summary>
        /// Create a single PQDS File.
        /// </summary>
        /// <param name="asset"> Asset used to get Asset Meta data. </param>
        /// <param name="evt"> Event used to get Event Meta data. </param>
        /// <param name="FileName"> File name of the PQDS file. </param>
        /// <param name="includeAssetMetaData"> Flag determines whether asset metadata is included. </param>
        /// <param name="includeCustomMetaData"> Flag that determines if custom meta data is included. </param>
        /// <param name="includeDeviceMetaData"> Flag that determines if device meta data is included. </param>
        /// <param name="includeTimingMetaData"> Flag that determines if timing meta data is included. </param>
        /// <param name="includeEventMetaData"> Flag that determines if event meta data is included. </param>
        /// <param name="includeWaveFormMetaData"> Flag that determines if waveform meta data is included. </param>
        /// <param name="includeWaveFormMetaData"> Flag that determines if waveform meta data is included. </param>
        /// <param name="startTime"> Overrides start time from event if selected. </param>
        /// <param name="includeAuthorMetaData"> Flag that determines if Author meta data is included. </param>
        /// <returns>task where .Result() return true when successfull or false if failed </returns>
        public Task<bool> WritePQDSFile(IProgress<int> progress, PQio.Model.Asset asset, PQio.Model.Event evt, string FileName, Boolean includeDeviceMetaData = false, Boolean includeAssetMetaData = false, Boolean includeTimingMetaData = false,
            Boolean includeEventMetaData = false, Boolean includeWaveFormMetaData = false, Boolean includeCustomMetaData = false, Boolean includeAuthorMetaData = false, Boolean includeGUID = false, DateTime? startTime = null)
        {

            this.mProgress = progress;
            Task<bool> result = Task<bool>.Run(() =>
            {
                try
                {
                    ParseToPQDS(asset, evt, includeDeviceMetaData, includeAssetMetaData, includeTimingMetaData, includeEventMetaData, includeWaveFormMetaData, includeCustomMetaData, includeAuthorMetaData, includeGUID,  startTime, FileName);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            });

            return result;
        }

        /// <summary>
        /// Create multiple PQDS File.
        /// </summary>
        /// <param name="asset"> Assets used to get Asset Meta data. </param>
        /// <param name="evt"> Events used to get Event Meta data. </param>
        /// <param name="FileName"> File names of the PQDS files. </param>
        /// <param name="includeAssetMetaData"> Flag determines whether asset metadata is included. </param>
        /// <param name="includeCustomMetaData"> Flag that determines if custom meta data is included. </param>
        /// <param name="includeDeviceMetaData"> Flag that determines if device meta data is included. </param>
        /// <param name="includeTimingMetaData"> Flag that determines if timing meta data is included. </param>
        /// <param name="includeEventMetaData"> Flag that determines if event meta data is included. </param>
        /// <param name="includeWaveFormMetaData"> Flag that determines if waveform meta data is included. </param>
        /// <param name="includeAuthorMetaData"> Flag that determines if Author meta data is included. </param>
        /// <param name="startTime"> Overrides start time from event if selected. </param>
        /// <param name="progress"> <see cref="IProgress{T}"/> provides interface to Progress</param>
        /// <returns>task where .Result() return true when successfull or false if failed </returns>
        public Task<int> WritePQDSFiles(IProgress<int> progress, List<PQio.Model.Asset> asset, List<PQio.Model.Event> evt, List<string> FileName, Boolean includeDeviceMetaData = false, Boolean includeAssetMetaData = false, Boolean includeTimingMetaData = false,
            Boolean includeEventMetaData = false, Boolean includeWaveFormMetaData = false, Boolean includeCustomMetaData = false, Boolean includeAuthorMetaData = false, Boolean includeGUID = false, DateTime? startTime = null)
        {

            this.mProgress = progress;
            Task<int> result = Task<int>.Run(() =>
            {
                int nSuccess = 0;

                for (int i=0; i < asset.Count(); i++)
                try
                {
                    ParseToPQDS(asset[i], evt[i], includeDeviceMetaData, includeAssetMetaData, includeTimingMetaData, includeEventMetaData, includeWaveFormMetaData, includeCustomMetaData, includeAuthorMetaData, includeGUID,  startTime, FileName[i]);
                    nSuccess++;
                }
                catch (Exception ex)
                { }

                return nSuccess;
            });

            return result;
        }




        private void UpdateIOProgress(double i)
        {
            // 50% is reading File
            this.mProgress.Report(this.m_prevProgress + (int)(i * 50.0D));
            //other 50% is spend in here based on testing
        }

        /// <summary>
        /// Parses the PQDS file into the Temporary SQLLite DataBase.
        /// </summary>
        /// <param name="filename"> Name of the PQDS File</param>
        private void ParseFromPQDS(string filename )
        {
            PQDSFile file = new PQDSFile();
            file.ReadFromFile(filename, new Progress<double>(UpdateIOProgress));
            this.m_prevProgress = this.m_prevProgress + 50;

            using (AdoDataConnection connection = new AdoDataConnection("systemSettings"))
            {


                GSF.Data.Model.TableOperations<PQio.Model.Asset> assetTbl = new GSF.Data.Model.TableOperations<PQio.Model.Asset>(connection);
                GSF.Data.Model.TableOperations<PQio.Model.Meter> deviceTbl = new GSF.Data.Model.TableOperations<PQio.Model.Meter>(connection);
                GSF.Data.Model.TableOperations<PQio.Model.Event> evtTbl = new GSF.Data.Model.TableOperations<PQio.Model.Event>(connection);

                GSF.Data.Model.TableOperations<PQio.Model.Channel> channelTbl = new GSF.Data.Model.TableOperations<PQio.Model.Channel>(connection);
                GSF.Data.Model.TableOperations<PQio.Model.DataSeries> dataSeriesTbl = new GSF.Data.Model.TableOperations<PQio.Model.DataSeries>(connection);

                GSF.Data.Model.TableOperations<PQio.Model.CustomField> customFldTbl = new GSF.Data.Model.TableOperations<PQio.Model.CustomField>(connection);

                //Create Asset from Meta Data
                PQio.Model.Asset asset = MetadataToAsset(file.MetaData);

                // if Asset already exists rename it
                if (assetTbl.QueryRecordCountWhere("AssetKey = {0}", asset.AssetKey) > 0)
                {
                    PQio.Model.Asset original = assetTbl.QueryRecordWhere("AssetKey = {0}", asset.AssetKey);

                    //check to make sure they are the same
                    bool nominalV = (original.NominalVoltage == asset.NominalVoltage)||(original.NominalVoltage == null) || (asset.NominalVoltage == null);
                    bool nominalf = (original.NominalFrequency == asset.NominalFrequency) || (original.NominalFrequency == null) || (asset.NominalFrequency == null);
                    bool upstreamXFR = (original.UpstreamXFMR == asset.UpstreamXFMR) || (original.UpstreamXFMR == null) || (asset.UpstreamXFMR == null);
                    bool length = (original.Length == asset.Length) || (original.Length == null) || (asset.Length == null);

                    if (nominalV && nominalf && upstreamXFR && length)
                    {
                        asset = MergeAssets(original, asset);
                        assetTbl.UpdateRecord(asset);
                    }
                    else
                    {
                        int i = 1;
                        string assetkey = asset.AssetKey;

                        while(assetTbl.QueryRecordCountWhere("AssetKey = {0}", assetkey) > 0)
                        {
                            assetkey = String.Format("{0} {1}", asset.AssetKey, i);
                            i++;
                        }
                        asset.AssetKey = assetkey;
                        assetTbl.AddNewRecord(asset);
                        asset.ID = PQio.Model.ModelID.GetID<Asset>(connection);

                    }

                   
                }
                else
                {
                    assetTbl.AddNewRecord(asset);
                    asset.ID = PQio.Model.ModelID.GetID<Asset>(connection);
                }


                //create Device from Meta Data
                PQio.Model.Meter device = MetadataToDevice(file.MetaData);
                if (CheckMeterDuplicates(device) != null)
                {
                    device = MergeDevices(CheckMeterDuplicates(device),device);
                    deviceTbl.UpdateRecord(device);
                }
                else
                {
                    deviceTbl.AddNewRecord(device);
                    device.ID = PQio.Model.ModelID.GetID<Meter>(connection);
                }

                //create Event from Meta Data
                PQio.Model.Event evt = MetadataToEvent(file.MetaData);
                evtTbl.AddNewRecord(evt);
                evt.ID = PQio.Model.ModelID.GetID<Event>(connection);

                //assume it is point on wave
                List<string> Tags = file.MetaData.Select(item => item.Key.ToLower()).ToList();

                int signalType;
                if (Tags.Contains("waveformdatatype"))
                { signalType = ((MetaDataTag<int>)file.MetaData.Find(item => item.Key.ToLower() == "waveformdatatype")).Value; }
                else
                { signalType = SignalType.PointOnWave; }

                int? datasensitivityid;
                string datasensitivityNote;
                if (Tags.Contains("waveformsensitivitycode"))
                { datasensitivityid = ((MetaDataTag<int>)file.MetaData.Find(item => item.Key.ToLower() == "waveformsensitivitycode")).Value; }
                else
                { datasensitivityid = null; }

                if (Tags.Contains("waveformsensitivitynote"))
                { datasensitivityNote = ((MetaDataTag<string>)file.MetaData.Find(item => item.Key.ToLower() == "waveformsensitivitynote")).Value; }
                else
                { datasensitivityNote = ""; }

                Dictionary<String, PQio.Model.DataSeries> data = file.Data.Select(item => new Tuple<string, PQDS.DataSeries>(item.Label, item)).ToDictionary(item => item.Item1, item => PQio.Model.DataSeries.FromPQDS(item.Item2)); ;

                //Based on estimation we are at 75% of the work done
                this.m_prevProgress = this.m_prevProgress + 25;
                this.mProgress.Report(this.m_prevProgress);

                String[] possibleChannels = new string[] { "va", "vb", "vc", "ia", "ib", "ic", "f" };

                foreach(string key in data.Keys)
                {
                    if (possibleChannels.Contains(key.ToLower()))
                    {
                        PQio.Model.Channel channel = new Channel();
                        channel.MeasurementType = key.ToLower();
                        channel.MeterID = device.ID;
                        channel.Name = MeasurementType.ToDisplay(channel.MeasurementType);
                        channel.SignalType = signalType;
                        channel.AssetID = asset.ID;

                        //Merge Channels if channel already exists
                        int nDuplicates = channelTbl.QueryRecordCountWhere("MeasurementType = {0} AND AssetID = {1} AND SignalType = {2} AND MeterID = {3}", key.ToLower(), asset.ID, signalType, device.ID);
                        if (nDuplicates > 0 )
                        {
                            PQio.Model.Channel original = channelTbl.QueryRecordWhere("MeasurementType = {0} AND AssetID = {1} AND SignalType = {2} AND MeterID = {3}", key.ToLower(), asset.ID, signalType, device.ID);
                            channel = MergeChannel(original, channel);
                            channelTbl.UpdateRecord(channel);
                        }
                        else
                        {
                            channelTbl.AddNewRecord(channel);
                            channel.ID = PQio.Model.ModelID.GetID<Channel>(connection);
                        }

                        data[key].ChannelID = channel.ID;
                        data[key].EventID = evt.ID;

                        dataSeriesTbl.AddNewRecord(data[key]);
                    }
                }

                //Add DataSensitivity
                if (datasensitivityid != null)
                {
                    PQio.Model.DataSensitivity dataSensitivity = new DataSensitivity() { Event = evt.ID, Asset = asset.ID, DataSensitivityCode = datasensitivityid, Note = datasensitivityNote };
                    (new GSF.Data.Model.TableOperations<PQio.Model.DataSensitivity>(connection)).AddNewRecord(dataSensitivity);
                }

                List<MetaDataTag> customTags = file.MetaData.FindAll(item => item.Key.Contains(".")).ToList();

                foreach (MetaDataTag custom in customTags)
                {
                    CustomField fld = new CustomField();

                    switch(custom.Type())
                    {
                        case PQDSMetaDataType.Numeric:
                            fld.Type = "N";
                            fld.Value = Convert.ToString(((MetaDataTag<double>)custom).Value);
                            break;
                        case PQDSMetaDataType.Binary:
                            fld.Type = "B";
                            fld.Value = Convert.ToString(((MetaDataTag<Boolean>)custom).Value);
                            break;
                        case PQDSMetaDataType.Enumeration:
                            fld.Type = "E";
                            fld.Value = Convert.ToString(((MetaDataTag<int>)custom).Value);
                            break;
                       default:
                            fld.Type = "T";
                            fld.Value = ((MetaDataTag<string>)custom).Value;
                            break;
                    }

                    int index = custom.Key.IndexOf('.');
                    fld.domain = custom.Key.Substring(0, index);
                    fld.key = custom.Key.Substring(index + 1);

                    fld.AssetID = asset.ID;
                    fld.EventID = evt.ID;
                    customFldTbl.AddNewRecord(fld);
                }

                this.m_prevProgress = this.m_prevProgress + 25;
                this.mProgress.Report(this.m_prevProgress);
            }
        }

        /// <summary>
        /// Parses the data from the temporary SQLLite DataBase into a PQDS File.
        /// </summary>
        /// <param name="asset"> Asset used to get Asset Meta data. </param>
        /// <param name="evt"> Event used to get Event Meta data. </param>
        /// <param name="includeAssetMetaData"> Flag determines whether asset metadata is included. </param>
        /// <param name="includeCustomMetaData"> Flag that determines if custom meta data is included. </param>
        /// <param name="includeDeviceMetaData"> Flag that determines if device meta data is included. </param>
        /// <param name="includeTimingMetaData"> Flag that determines if timing meta data is included. </param>
        /// <param name="includeEventMetaData"> Flag that determines if event meta data is included. </param>
        /// <param name="includeWaveFormMetaData"> Flag that determines if waveform meta data is included. </param>
        /// <param name="startTime"> Overrides start time from event if selected. </param>
        /// <param name="filename"> File name of the PQDS file. </param>
        private void ParseToPQDS(PQio.Model.Asset asset, PQio.Model.Event evt, Boolean includeDeviceMetaData, Boolean includeAssetMetaData, Boolean includeTimingMetaData, 
            Boolean includeEventMetaData, Boolean includeWaveFormMetaData, Boolean includeCustomMetaData, Boolean includeAuthor, Boolean includeGUID, DateTime? startTime, string filename)
        {

            List<MetaDataTag> metaData = new List<MetaDataTag>();
            List<MetaDataTag> fullMetaData = new List<MetaDataTag>();

            PQio.Model.Meter device;
            List<PQio.Model.Channel> channels;
            List<PQio.Model.DataSeries> data;
            data = new List<PQio.Model.DataSeries>();
            List<PQio.Model.CustomField> customMetaData = new List<CustomField>();
            int? lowestDataSensitivity;
            string dataSensitivityNote = null;

            using (AdoDataConnection connection = new AdoDataConnection("systemSettings"))
            {


                GSF.Data.Model.TableOperations<PQio.Model.Channel> channelTbl = new GSF.Data.Model.TableOperations<PQio.Model.Channel>(connection);
                channels = channelTbl.QueryRecordsWhere("(SELECT COUNT(DataSeries.ID) FROM DataSeries WHERE EventID = {0} AND ChannelID = Channel.ID) > 0  AND (AssetID = {1})", evt.ID, asset.ID).ToList();

                if (channels.Count() == 0)
                { throw new Exception("No channels Found"); }

                GSF.Data.Model.TableOperations<PQio.Model.Meter> deviceTbl = new GSF.Data.Model.TableOperations<PQio.Model.Meter>(connection);
                device = deviceTbl.QueryRecordWhere("ID = {0}", channels[0].MeterID);

                if (device is null)
                { throw new Exception("No device Found"); ; }

                GSF.Data.Model.TableOperations<PQio.Model.CustomField> customFieldTbl = new GSF.Data.Model.TableOperations<PQio.Model.CustomField>(connection);
                customMetaData = customFieldTbl.QueryRecordsWhere("AssetID = {0} AND EventID = {1}", asset.ID, evt.ID).ToList();

                GSF.Data.Model.TableOperations<PQio.Model.Setting> settingTbl = new GSF.Data.Model.TableOperations<PQio.Model.Setting>(connection);

                if (includeAuthor)
                {
                    metaData.Add(new MetaDataTag<string>("Utility", settingTbl.QueryRecordWhere("Name = {0}", "contact.utility").value));
                    metaData.Add(new MetaDataTag<string>("ContactEmail", settingTbl.QueryRecordWhere("Name = {0}", "contact.email").value));
                }

                fullMetaData.Add(new MetaDataTag<string>("Utility", settingTbl.QueryRecordWhere("Name = {0}", "contact.utility").value));
                fullMetaData.Add(new MetaDataTag<string>("ContactEmail", settingTbl.QueryRecordWhere("Name = {0}", "contact.email").value));

                GSF.Data.Model.TableOperations<PQio.Model.DataSensitivity> dataSensitivityTbl = new GSF.Data.Model.TableOperations<PQio.Model.DataSensitivity>(connection);

                lowestDataSensitivity = dataSensitivityTbl.QueryRecordsWhere("Asset = {0} AND Event = {1}",new object[2] { asset.ID, evt.ID }).Select(item => item.DataSensitivityCode).Min();

                List<string> notes = dataSensitivityTbl.QueryRecordsWhere("Asset = {0} AND Event = {1} AND Note NOT NULL AND Note <> ''", new object[2] { asset.ID, evt.ID }).Select(item => item.Note.ToLower()).ToList();
                if (notes.Distinct().Count() == 1)
                {
                    dataSensitivityNote = notes[0];
                }
                else if (notes.Count() > 1)
                {
                    //Attempt to string all Data Sensitivity notes together
                    dataSensitivityNote = String.Join(";", notes);
                    if (dataSensitivityNote.Length > 250)
                    {
                        dataSensitivityNote = dataSensitivityNote.Substring(0, 247) + "...";
                    }
                }

            }

            data = channels.Select(item => GetData(item, evt)).ToList();

            // Figure out inital start Time
            DateTime initalTimeStamp;

            if (evt.EventTime is null)
            {
                initalTimeStamp = data.Select(item => item.Series[0].Time).Min();
            }
            else
            {
                initalTimeStamp = (DateTime)evt.EventTime;
            }

            if (!(startTime is null))
            {
                evt.EventTime = startTime;
            }

            //Include all MetaData in Log File
            fullMetaData.AddRange(DeviceMetaData(device));
            fullMetaData.AddRange(AssetMetaData(asset));
            fullMetaData.AddRange(EventMetaData(evt));
            fullMetaData.AddRange(TimingMetaData(evt));


           
            if (lowestDataSensitivity != null)
            {
                fullMetaData.Add(new MetaDataTag<int>("WaveFormSensitivityCode", (int)lowestDataSensitivity));
            }
            if (dataSensitivityNote != null)
            {
                fullMetaData.Add(new MetaDataTag<string>("WaveFormSensitivityNote", dataSensitivityNote));
            }

            fullMetaData.AddRange(customMetaData.Select(item => ChannelMetaData(item)).ToList());

            //Based on estimation we are at 25% of the work done
            this.m_prevProgress = this.m_prevProgress + 25;
            this.mProgress.Report(this.m_prevProgress);



            //Deal with MetaData
            if (includeDeviceMetaData)
            {
                //Try to get Meta Data From Meter
                metaData.AddRange(DeviceMetaData(device));
            }
            if (includeAssetMetaData)
            {
                // Get MetaData from Asset
                metaData.AddRange(AssetMetaData(asset));
            }
            if (includeEventMetaData)
            {
                // Get MetaData from event
                metaData.AddRange(EventMetaData(evt));
            }
            if (includeTimingMetaData)
            {
                // Get MetaData from Timing
                metaData.AddRange(TimingMetaData(evt));
            }
            if (includeWaveFormMetaData)
            {
                if (lowestDataSensitivity != null)
                {
                    metaData.Add(new MetaDataTag<int>("WaveFormSensitivityCode", (int)lowestDataSensitivity));
                }

                if ((dataSensitivityNote != null) && (dataSensitivityNote != ""))
                {
                    metaData.Add(new MetaDataTag<string>("WaveFormSensitivityNote", dataSensitivityNote));
                }
            }
            if (includeCustomMetaData)
            {
                metaData.AddRange(customMetaData.Select(item => ChannelMetaData(item)).ToList());
            }
            if (!includeEventMetaData && includeGUID)
            {
                if (evt.GUID != null)
                {
                    metaData.Add(new MetaDataTag<string>("EventGUID", evt.GUID));
                }
            }

            // Get Meta Data from channel

            //Based on estimation we are at 50% of the work done
            this.m_prevProgress = this.m_prevProgress + 25;
            this.mProgress.Report(this.m_prevProgress);


            //Create PQDSModel
            PQDSFile file = new PQDSFile(metaData, PQDSData(data).Select(pair => pair.Value.ToPQDSSeries(pair.Key)).ToList(), initalTimeStamp);
            PQDSLogFile logfile = new PQDSLogFile(fullMetaData, evt.GUID, PQDSData(data).Keys.ToList());

            //Write PQDSModel to File
            file.WriteToFile(filename, new Progress<double>(UpdateIOProgress));
            this.m_prevProgress = this.m_prevProgress + 50;

            logfile.Write(this.m_logilename); 
        }

        #region[MetaData]
        private List<MetaDataTag> DeviceMetaData(PQio.Model.Meter device)
        {
            List<MetaDataTag> results = new List<MetaDataTag>();

            if (device.DeviceName != null)
            {
                results.Add(new MetaDataTag<string>("DeviceName", device.DeviceName));
            }
            if (device.DeviceAlias != null)
            {
                results.Add(new MetaDataTag<string>("DeviceAlias", device.DeviceAlias));
            }
            if (device.DeviceLocation != null)
            {
                results.Add(new MetaDataTag<string>("DeviceLocation", device.DeviceLocation));
            }
            if (device.DeviceLocationAlias != null)
            {
                results.Add(new MetaDataTag<string>("DeviceLocationAlias", device.DeviceLocationAlias));
            }
            if (device.Latitude != null)
            {
                results.Add(new MetaDataTag<string>("Latitude", Convert.ToString(device.Latitude)));
            }
            if (device.Longitude != null)
            {
                results.Add(new MetaDataTag<string>("Longitude", Convert.ToString(device.Longitude)));
            }
            if (device.AccountName != null)
            {
                results.Add(new MetaDataTag<string>("AccountName", device.AccountName));
            }
            if (device.AccountAlias != null)
            {
                results.Add(new MetaDataTag<string>("AccountNameAlias", device.AccountAlias));
            }

            if (device.DistanceToXFR != null)
            {
                results.Add(new MetaDataTag<double>("DeviceDistanceToXFMR", (double)device.DistanceToXFR));
            }
            if (device.ConnectionType != null)
            {
                    results.Add(new MetaDataTag<int>("DeviceConnectionTypeCode", (int)device.ConnectionType));
            }
        
            if (device.Owner != null)
            {
                results.Add(new MetaDataTag<string>("DeviceOwner", device.Owner));
            }


            return results;
        }

        private List<MetaDataTag> AssetMetaData(PQio.Model.Asset asset)
        {
            List<MetaDataTag> results = new List<MetaDataTag>();

            if (asset.NominalVoltage != null)
            {
                results.Add(new MetaDataTag<double>("NominalVoltage-LG", (double)asset.NominalVoltage));
            }
            if (asset.NominalFrequency != null)
            {
                results.Add(new MetaDataTag<double>("NominalFrequency", (double)asset.NominalFrequency));
            }
            if (asset.UpstreamXFMR != null)
            {
                results.Add(new MetaDataTag<double>("UpstreamXFMR-kVA", (double)asset.UpstreamXFMR));
            }
            if (asset.Length != null)
            {
                results.Add(new MetaDataTag<double>("LineLength", (double)asset.Length));
            }
            if (asset.AssetKey != null)
            {
                results.Add(new MetaDataTag<string>("AssetName", asset.AssetKey));
            }

            return results;
        }

        private List<MetaDataTag> EventMetaData(PQio.Model.Event evt)
        {
            List<MetaDataTag> results = new List<MetaDataTag>();

            if (evt.GUID != null)
            {
                results.Add(new MetaDataTag<string>("EventGUID", evt.GUID));
            }
            if (evt.Name != null)
            {
                results.Add(new MetaDataTag<string>("EventID", evt.Name));
            }

            if (evt.EventType != null)
            {
                results.Add(new MetaDataTag<int>("EventTypeCode", (int)evt.EventType));
            }
            if (evt.FaultType != null)
            {
                results.Add(new MetaDataTag<int>("EventFaultTypeCode", (int)evt.FaultType));
            }

            if (evt.PeakCurrent != null)
            {
                results.Add(new MetaDataTag<double>("EventPeakCurrent", (double)evt.PeakCurrent));
            }
            if (evt.PeakVoltage != null)
            {
                results.Add(new MetaDataTag<double>("EventPeakVoltage", (double)evt.PeakVoltage));
            }

            if (evt.MaxVA != null)
            {
                results.Add(new MetaDataTag<double>("EventMaxVA", (double)evt.MaxVA));
            }
            if (evt.MaxVB != null)
            {
                results.Add(new MetaDataTag<double>("EventMaxVB", (double)evt.MaxVB));
            }
            if (evt.MaxVC != null)
            {
                results.Add(new MetaDataTag<double>("EventMaxVC", (double)evt.MaxVC));
            }

            if (evt.MinVA != null)
            {
                results.Add(new MetaDataTag<double>("EventMinVA", (double)evt.MinVA));
            }
            if (evt.MinVB != null)
            {
                results.Add(new MetaDataTag<double>("EventMinVB", (double)evt.MinVB));
            }
            if (evt.MinVC != null)
            {
                results.Add(new MetaDataTag<double>("EventMinVC", (double)evt.MinVC));
            }

            if (evt.MaxIA != null)
            {
                results.Add(new MetaDataTag<double>("EventMaxIA", (double)evt.MaxIA));
            }
            if (evt.MaxIB != null)
            {
                results.Add(new MetaDataTag<double>("EventMaxIB", (double)evt.MaxIB));
            }
            if (evt.MaxIC != null)
            {
                results.Add(new MetaDataTag<double>("EventMaxIC", (double)evt.MaxIC));
            }

            if (evt.PreEventCurrent != null)
            {
                results.Add(new MetaDataTag<double>("EventPreEventCurrent", (double)evt.PreEventCurrent));
            }
            if (evt.PreEventVoltage != null)
            {
                results.Add(new MetaDataTag<double>("EventPreEventVoltage", (double)evt.PreEventVoltage));
            }
            if (evt.Duration != null)
            {
                results.Add(new MetaDataTag<double>("EventDuration", (double)evt.Duration));
            }

            if (evt.FaultI2T != null)
            {
                results.Add(new MetaDataTag<double>("EventFaultI2T", (double)evt.FaultI2T));
            }
            if (evt.DistanceToFault != null)
            {
                results.Add(new MetaDataTag<double>("DistanceToFault", (double)evt.DistanceToFault));
            }

            if (evt.FaultCause != null)
            {
                results.Add(new MetaDataTag<int>("EventCauseCode", (int)evt.FaultCause));
            }

            return results;
        }

        private List<MetaDataTag> TimingMetaData(PQio.Model.Event evt)
        {
            List<MetaDataTag> results = new List<MetaDataTag>();

            if (!(evt.EventTime is null))
            {
                results.Add(new MetaDataTag<int>("EventYear", ((DateTime)evt.EventTime).Year));

                results.Add(new MetaDataTag<int>("EventMonth", ((DateTime)evt.EventTime).Month));
                results.Add(new MetaDataTag<int>("EventDay", ((DateTime)evt.EventTime).Day));
                results.Add(new MetaDataTag<int>("EventHour", ((DateTime)evt.EventTime).Hour));
                results.Add(new MetaDataTag<int>("EventMinute", ((DateTime)evt.EventTime).Minute));
                results.Add(new MetaDataTag<int>("EventSecond", ((DateTime)evt.EventTime).Second));
                results.Add(new MetaDataTag<int>("EventNanoSecond", Get_nanoseconds((DateTime)evt.EventTime)));

                String date = String.Format("{0:D2}/{1:D2}/{2:D4}", ((DateTime)evt.EventTime).Month, ((DateTime)evt.EventTime).Day, ((DateTime)evt.EventTime).Year);
                String time = String.Format("{0:D2}:{1:D2}:{2:D2}", ((DateTime)evt.EventTime).Hour, ((DateTime)evt.EventTime).Minute, ((DateTime)evt.EventTime).Second);
                results.Add(new MetaDataTag<string>("EventDate", date));
                results.Add(new MetaDataTag<string>("EventTime", time));
            }

            return results;
        }

        private MetaDataTag ChannelMetaData(PQio.Model.CustomField tag)
        {
            string key = tag.domain + "." +  tag.key;

            switch(tag.Type)
            {
                case ("T"):
                    return new MetaDataTag<string>(key, tag.Value);
                case ("N"):
                    return new MetaDataTag<double>(key, Convert.ToDouble(tag.Value));
                default:
                    return new MetaDataTag<string>(key, tag.Value);
            }
        }

        private int Get_nanoseconds(DateTime date)
        {
            TimeSpan day = date.TimeOfDay;
            long result = day.Ticks;
            result = result - (long)day.Hours * (60L * 60L * 10000000L);
            result = result - (long)day.Minutes * (60L * 10000000L);
            result = result - (long)day.Seconds * 10000000L;


            return ((int)result * 100);
        }

        private PQio.Model.DataSeries GetData(PQio.Model.Channel channel, PQio.Model.Event evt)
        {
            using (AdoDataConnection connection = new AdoDataConnection("systemSettings"))
            {
                GSF.Data.Model.TableOperations<PQio.Model.DataSeries> dataSeriesTbl = new GSF.Data.Model.TableOperations<PQio.Model.DataSeries>(connection);
                return dataSeriesTbl.QueryRecordWhere("ChannelID = {0} AND EventID = {1}", channel.ID, evt.ID);
            }
        }

        private Dictionary<string, PQio.Model.DataSeries> PQDSData(List<PQio.Model.DataSeries> dataSeries)
        {
            Dictionary<string, PQio.Model.DataSeries> result = new Dictionary<string, PQio.Model.DataSeries>();

            using (AdoDataConnection connection = new AdoDataConnection("systemSettings"))
            {
                GSF.Data.Model.TableOperations<PQio.Model.Channel> channelTbl = new GSF.Data.Model.TableOperations<PQio.Model.Channel>(connection);

                foreach (PQio.Model.DataSeries ds in dataSeries)
                {
                    PQio.Model.Channel channel = channelTbl.QueryRecordWhere("ID = {0}", ds.ChannelID);
                    ;

                    if (result.Keys.Contains(channel.MeasurementType.ToLower()))
                    {
                        // This is an issue since 2 measurements of the same type should not exist
                        continue;
                    }
                    else
                    {

                        result.Add(channel.MeasurementType.ToLower(), ds);
                    }
                }
            }

            return result;
        }

        private PQio.Model.Meter CheckMeterDuplicates(PQio.Model.Meter device)
        {
            using (AdoDataConnection connection = new AdoDataConnection("systemSettings"))
            {
                GSF.Data.Model.TableOperations<PQio.Model.Meter> deviceTbl = new GSF.Data.Model.TableOperations<PQio.Model.Meter>(connection);

                foreach (PQio.Model.Meter duplicate in deviceTbl.QueryRecordsWhere("Devicename = {0}", device.DeviceName))
                {
                    bool devicealias = (device.DeviceAlias == duplicate.DeviceAlias) || (device.DeviceAlias == null) || (duplicate.DeviceAlias == null);
                    bool devicelocation = (device.DeviceLocation == duplicate.DeviceLocation) || (device.DeviceLocation == null) || (duplicate.DeviceLocation == null);
                    bool devicelocationalias = (device.DeviceLocationAlias == duplicate.DeviceLocationAlias) || (device.DeviceLocationAlias == null) || (duplicate.DeviceLocationAlias == null);
                    bool latitude = (device.Latitude == duplicate.Latitude) || (device.Latitude == null) || (duplicate.Latitude == null);
                    bool longitude = (device.Longitude == duplicate.Longitude) || (device.Longitude == null) || (duplicate.Longitude == null);
                    bool accountname = (device.AccountName == duplicate.AccountName) || (device.AccountName == null) || (duplicate.AccountName == null);
                    bool accountnamealias = (device.AccountAlias == duplicate.AccountAlias) || (device.AccountAlias == null) || (duplicate.AccountAlias == null);
                    bool devicedistancetoxfmr = (device.DistanceToXFR == duplicate.DistanceToXFR) || (device.DistanceToXFR == null) || (duplicate.DistanceToXFR == null);
                    bool deviceowner = (device.Owner == duplicate.Owner) || (device.Owner == null) || (duplicate.Owner == null);

                    if (devicealias && devicelocation && devicelocationalias && latitude && longitude && accountname && accountnamealias && devicedistancetoxfmr && deviceowner)
                    {
                        return duplicate;
                    }
                }
            }


            return null;
        }

        private PQio.Model.Meter MetadataToDevice(List<MetaDataTag> metaData)
        {
            PQio.Model.Meter device= new Meter();
            List<string> Tags = metaData.Select(item => item.Key.ToLower()).ToList();

            if (Tags.Contains("devicename"))
            {
                device.DeviceName = ((MetaDataTag<String>)metaData.Find(item => item.Key.ToLower() == "devicename")).Value;
            }
            else
            {
                device.DeviceName = "PQDS File";
            }

            if (Tags.Contains("devicealias"))
            {
                device.DeviceAlias = ((MetaDataTag<String>)metaData.Find(item => item.Key.ToLower() == "devicealias")).Value;
            }

            if (Tags.Contains("devicelocation"))
            {
                device.DeviceLocation = ((MetaDataTag<String>)metaData.Find(item => item.Key.ToLower() == "devicelocation")).Value;
            }
            if (Tags.Contains("devicelocationalias"))
            {
                device.DeviceLocationAlias = ((MetaDataTag<String>)metaData.Find(item => item.Key.ToLower() == "devicelocationalias")).Value;
            }

            if (Tags.Contains("latitude"))
            {
                try
                {
                    device.Latitude = Convert.ToInt32(((MetaDataTag<String>)metaData.Find(item => item.Key.ToLower() == "latitude")).Value);
                }
                catch { }
                }
            if (Tags.Contains("longitude"))
            {
                try
                {
                    device.Longitude = Convert.ToInt32(((MetaDataTag<String>)metaData.Find(item => item.Key.ToLower() == "longitude")).Value);

                }
                catch { }
            }

            if (Tags.Contains("accountname"))
            {
                device.AccountName = ((MetaDataTag<String>)metaData.Find(item => item.Key.ToLower() == "accountname")).Value;
            }
            if (Tags.Contains("accountnamealias"))
            {
                device.AccountAlias = ((MetaDataTag<String>)metaData.Find(item => item.Key.ToLower() == "accountnamealias")).Value;
            }

            if (Tags.Contains("devicedistancetoxfmr"))
            {
                device.DistanceToXFR = ((MetaDataTag<double>)metaData.Find(item => item.Key.ToLower() == "devicedistancetoxfmr")).Value;
            }

            if (Tags.Contains("deviceowner"))
            {
                device.Owner = ((MetaDataTag<String>)metaData.Find(item => item.Key.ToLower() == "deviceowner")).Value;
            }
            //skip Connection Type for now

             return device;
        }

        private PQio.Model.Asset MetadataToAsset(List<MetaDataTag> metaData)
        {
            PQio.Model.Asset asset = new Asset();
            List<string> Tags = metaData.Select(item => item.Key.ToLower()).ToList();

            if (Tags.Contains("assetname"))
            {
                asset.AssetKey = ((MetaDataTag<String>)metaData.Find(item => item.Key.ToLower() == "assetname")).Value;
            }
            else
            {

                using (AdoDataConnection connection = new AdoDataConnection("systemSettings"))
                {
                    asset.AssetKey = "PQDS File";
                    int i = 0;

                    GSF.Data.Model.TableOperations<PQio.Model.Asset> assetTbl = new GSF.Data.Model.TableOperations<PQio.Model.Asset>(connection);
                    while (assetTbl.QueryRecordCountWhere("AssetKey = {0}", asset.AssetKey) > 0)
                    {
                        i++;
                        asset.AssetKey = String.Format("PQDS File {0}",i);
                    }
                    
                }
            }

            if (Tags.Contains("nominalvoltage-lg"))
            {
                asset.NominalVoltage = ((MetaDataTag<double>)metaData.Find(item => item.Key.ToLower() == "nominalvoltage-lg")).Value;
            }
            if (Tags.Contains("nominalfrequency"))
            {
                asset.NominalFrequency = ((MetaDataTag<double>)metaData.Find(item => item.Key.ToLower() == "nominalfrequency")).Value;
            }
            if (Tags.Contains("linelength"))
            {
                asset.Length = ((MetaDataTag<double>)metaData.Find(item => item.Key.ToLower() == "linelength")).Value;
            }
            if (Tags.Contains("upstreamxfmr-kva"))
            {
                asset.UpstreamXFMR = ((MetaDataTag<double>)metaData.Find(item => item.Key.ToLower() == "upstreamxfmr-kva")).Value;
            }

            return asset;
        }

        private PQio.Model.Event MetadataToEvent(List<MetaDataTag> metaData)
        {
            PQio.Model.Event evt = new Event();
            List<string> Tags = metaData.Select(item => item.Key.ToLower()).ToList();


            if (Tags.Contains("eventguid"))
            {
                evt.GUID = ((MetaDataTag<String>)metaData.Find(item => item.Key.ToLower() == "eventguid")).Value;
            }
            else
            {
                evt.GUID = (Guid.NewGuid()).ToString();
            }
            if (Tags.Contains("eventid"))
            {
                evt.Name = ((MetaDataTag<String>)metaData.Find(item => item.Key.ToLower() == "eventid")).Value;
            }
            else
            {
                evt.Name = "PQDS File";
            }
            if (Tags.Contains("eventtypecode"))
            {
                evt.EventType = ((MetaDataTag<int>)metaData.Find(item => item.Key.ToLower() == "eventtypecode")).Value;
            }
            if (Tags.Contains("eventfaulttypecode"))
            {
                evt.FaultType = ((MetaDataTag<int>)metaData.Find(item => item.Key.ToLower() == "eventfaulttypecode")).Value;
            }

            if (Tags.Contains("eventpeakcurrent"))
            {
                evt.PeakCurrent = ((MetaDataTag<double>)metaData.Find(item => item.Key.ToLower() == "eventpeakcurrent")).Value;
            }
            if (Tags.Contains("eventpeakvoltage"))
            {
                evt.PeakVoltage = ((MetaDataTag<double>)metaData.Find(item => item.Key.ToLower() == "EventPeakVoltage")).Value;
            }

            if (Tags.Contains("eventmaxva"))
            {
                evt.MaxVA = ((MetaDataTag<double>)metaData.Find(item => item.Key.ToLower() == "eventmaxva")).Value;
            }
            if (Tags.Contains("eventmaxvb"))
            {
                evt.MaxVB = ((MetaDataTag<double>)metaData.Find(item => item.Key.ToLower() == "eventmaxvb")).Value;
            }
            if (Tags.Contains("eventmaxvc"))
            {
                evt.MaxVC = ((MetaDataTag<double>)metaData.Find(item => item.Key.ToLower() == "eventmaxvc")).Value;
            }

            if (Tags.Contains("eventminva"))
            {
                evt.MinVA = ((MetaDataTag<double>)metaData.Find(item => item.Key.ToLower() == "eventminva")).Value;
            }
            if (Tags.Contains("eventminvb"))
            {
                evt.MinVB = ((MetaDataTag<double>)metaData.Find(item => item.Key.ToLower() == "eventminvb")).Value;
            }
            if (Tags.Contains("eventminvc"))
            {
                evt.MinVC = ((MetaDataTag<double>)metaData.Find(item => item.Key.ToLower() == "eventminvc")).Value;
            }

            if (Tags.Contains("eventmaxia"))
            {
                evt.MaxIA = ((MetaDataTag<double>)metaData.Find(item => item.Key.ToLower() == "eventmaxia")).Value;
            }
            if (Tags.Contains("eventmaxib"))
            {
                evt.MaxIB = ((MetaDataTag<double>)metaData.Find(item => item.Key.ToLower() == "eventmaxib")).Value;
            }
            if (Tags.Contains("eventmaxic"))
            {
                evt.MaxIC = ((MetaDataTag<double>)metaData.Find(item => item.Key.ToLower() == "eventmaxic")).Value;
            }



            if (Tags.Contains("eventpreeventcurrent"))
            {
                evt.PreEventCurrent = ((MetaDataTag<double>)metaData.Find(item => item.Key.ToLower() == "eventpreeventcurrent")).Value;
            }
            if (Tags.Contains("eventpreeventvoltage"))
            {
                evt.PreEventVoltage = ((MetaDataTag<double>)metaData.Find(item => item.Key.ToLower() == "eventpreeventvoltage")).Value;
            }
            if (Tags.Contains("eventduration"))
            {
                evt.Duration = ((MetaDataTag<double>)metaData.Find(item => item.Key.ToLower() == "eventduration")).Value;
            }


            if (Tags.Contains("eventfaulti2t"))
            {
                evt.FaultI2T = ((MetaDataTag<double>)metaData.Find(item => item.Key.ToLower() == "eventfaulti2t")).Value;
            }
            if (Tags.Contains("distancetofault"))
            {
                evt.DistanceToFault = ((MetaDataTag<double>)metaData.Find(item => item.Key.ToLower() == "distancetofault")).Value;
            }

            if (Tags.Contains("faultcause"))
            {
                evt.FaultCause = ((MetaDataTag<int>)metaData.Find(item => item.Key.ToLower() == "faultcause")).Value;
            }
            
            return evt;
        }

        private PQio.Model.Asset MergeAssets(PQio.Model.Asset asset1, PQio.Model.Asset asset2)
        {
            PQio.Model.Asset result = asset1;

            if ((result.Length == null) && (asset2.Length != null))
                result.Length = asset2.Length;
            if ((result.UpstreamXFMR == null) && (asset2.UpstreamXFMR != null))
                result.UpstreamXFMR = asset2.UpstreamXFMR;
            if ((result.NominalFrequency == null) && (asset2.NominalFrequency != null))
                result.NominalFrequency = asset2.NominalFrequency;
            if ((result.NominalVoltage == null) && (asset2.NominalVoltage != null))
                result.NominalVoltage = asset2.NominalVoltage;
            return result;
        }

        private PQio.Model.Channel MergeChannel(PQio.Model.Channel channel1, PQio.Model.Channel channel2)
        {
            PQio.Model.Channel result = channel1;
            
            return result;
        }

        private PQio.Model.Meter MergeDevices(PQio.Model.Meter device1, PQio.Model.Meter device2)
        {
            PQio.Model.Meter result = device1;

            if (device2.DeviceAlias != null)
            {
                result.DeviceAlias = device2.DeviceAlias;
            }

            if (device2.DeviceLocation != null)
            {
                result.DeviceLocation = device2.DeviceLocation;
            }
            if (device2.DeviceLocationAlias != null)
            {
                result.DeviceLocationAlias = device2.DeviceLocationAlias;
            }
            if (device2.Latitude != null)
            {
                result.Latitude = device2.Latitude;
            }
            if (device2.Longitude != null)
            {
                result.Longitude = device2.Longitude;
            }
            if (device2.AccountName != null)
            {
                result.AccountName = device2.AccountName;
            }
            if (device2.AccountAlias != null)
            {
                result.AccountAlias = device2.AccountAlias;
            }
            if (device2.DistanceToXFR != null)
            {
                result.DistanceToXFR = device2.DistanceToXFR;
            }
            if (device2.Owner != null)
            {
                result.Owner = device2.Owner;
            }

            return result;
        }
        #endregion[MetaData]

        #endregion[methods]

    }

    public class PQDSLogFile
    {
        #region[Properties]
        private List<MetaDataTag> m_metaData;
        private DateTime m_created;
        private string m_FileGuid;
        private List<string> m_data;
        #endregion[Properties]

        #region[Methods]
        public PQDSLogFile(List<MetaDataTag> metadata, string FileGUID, List<string> measurements)
        {
            this.m_metaData = metadata;
            this.m_created = DateTime.Now;
            this.m_data = measurements;

        }

        public void Write(string filename)
        {
            bool includeSeperator = true;

            if (!File.Exists(filename))
            {
                using (File.Create(filename))
                includeSeperator = false;
            }

            using (StreamWriter sw = File.AppendText(filename))
            {
                if (includeSeperator)
                {
                    sw.WriteLine(new String('-', 45));
                }

                //Write LogFile Header (FileID, Date Created)
                sw.WriteLine(Header());

                List<string> lines = this.m_metaData.Select(item => item.Write()).ToList();

                foreach (string line in lines)
                    sw.WriteLine(line);

                sw.WriteLine("waveform-data," + String.Join(",", this.m_data));
            }

        }

        private string Header()
        {
            return String.Format("\"{0:d/M/yyyy HH:mm:ss}\",{1}",this.m_created,this.m_FileGuid);
        }

        #endregion[Methods]
    }
}