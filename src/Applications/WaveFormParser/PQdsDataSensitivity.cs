//******************************************************************************************************
//  PQioDataSensitivity.cs - Gbtc
//
//  Copyright © 2013, Grid Protection Alliance.  All Rights Reserved.
//
//  Licensed to the Grid Protection Alliance (GPA) under one or more contributor license agreements. See
//  the NOTICE file distributed with this work for additional information regarding copyright ownership.
//  The GPA licenses this file to you under the Eclipse Public License -v 1.0 (the "License"); you may
//  not use this file except in compliance with the License. You may obtain a copy of the License at:
//
//      http://www.opensource.org/licenses/eclipse-1.0.php
//
//  Unless agreed to in writing, the subject software distributed under the License is distributed on an
//  "AS-IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. Refer to the
//  License for the specific language governing permissions and limitations.
//
//  Code Modification History:
//  ----------------------------------------------------------------------------------------------------
//  09/05/2019 - Christoph Lackner
//       Generated original version of source code.
//
//******************************************************************************************************

using GSF.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PQio
{
    public partial class PQdsDataSensitivity : Form
    {
        #region [Properties]

        private string connectionstring;
        private const string dataprovider = "AssemblyName={System.Data.SQLite, Version=1.0.109.0, Culture=neutral, PublicKeyToken=db937bc2d44ff139}; ConnectionType=System.Data.SQLite.SQLiteConnection; AdapterType=System.Data.SQLite.SQLiteDataAdapter";

        #endregion [Properties]

        #region [Methods]


        public PQdsDataSensitivity()
        {
            string localAppData = $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}{Path.DirectorySeparatorChar}PQio{Path.DirectorySeparatorChar}DataBase.db";
            connectionstring = $"Data Source={localAppData}; Version=3; Foreign Keys=True; FailIfMissing=True";

            InitializeComponent();
        }

        private void Cncl_Btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MetaData_Load(object sender, EventArgs e)
        {
            DataSensitivityCombo.Items.AddRange(Model.DataSensitivityCode.DisplayOptions());

            using (AdoDataConnection connection = new AdoDataConnection(connectionstring, dataprovider))
            {
                GSF.Data.Model.TableOperations<PQio.Model.DataSensitivity> dataSensitivityTable = new GSF.Data.Model.TableOperations<PQio.Model.DataSensitivity>(connection);
                
                if (PQio.Model.DataSensitivity.CodeisGlobal())
                {
                    int? dataSensitivity = null;
                    dataSensitivity = dataSensitivityTable.QueryRecords().First().DataSensitivityCode;

                    if (dataSensitivity != null)
                    {
                        DataSensitivityCombo.SelectedIndex = Array.FindIndex(Model.DataSensitivityCode.DisplayOptions(),
                            item => item == Model.DataSensitivityCode.ToDisplay((int)dataSensitivity));
                    }
                    else
                    {
                        DataSensitivityCombo.SelectedIndex = Array.FindIndex(Model.DataSensitivityCode.DisplayOptions(),
                            item => item == Model.DataSensitivityCode.ToDisplay(-1));
                    }
                }
                else
                {
                    DataSensitivityCombo.Enabled = false;
                }

                if (PQio.Model.DataSensitivity.NoteisGlobal())
                {
                    string dataSensitivityNote = null;
                    dataSensitivityNote = dataSensitivityTable.QueryRecordsWhere("Note <> ''").First().Note;

                    DataSensitivityNoteText.Text = dataSensitivityNote;
                }
                else
                {
                    DataSensitivityNoteText.Enabled = false;
                }
            }
            this.MouseDown += new MouseEventHandler(OnClick);
        }

        private void WarnCodeOverride()
        {
            DialogResult result = MessageBox.Show("This will overwrite the Data Sensitivity Code on all Channels. Are you sure you want to continue?", "Data Sensitivity",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                DataSensitivityCombo.Enabled = true;
                GenereateDataSensitivities("", 0);
                return;
            }
        }

        private void GenereateDataSensitivities(string note, int code)
        {
            // If we overwrite we need to create a set of Asset and event IDs that need to create a Data Sesitivity Code
            List<Tuple<int, int>> combinations = new List<Tuple<int, int>>();

            using (AdoDataConnection connection = new AdoDataConnection(connectionstring, dataprovider))
            {
                GSF.Data.Model.TableOperations<PQio.Model.Channel> channelTbl = new GSF.Data.Model.TableOperations<PQio.Model.Channel>(connection);
                GSF.Data.Model.TableOperations<PQio.Model.Asset> assetTbl = new GSF.Data.Model.TableOperations<PQio.Model.Asset>(connection);
                GSF.Data.Model.TableOperations<PQio.Model.DataSeries> seriesTbl = new GSF.Data.Model.TableOperations<PQio.Model.DataSeries>(connection);
                GSF.Data.Model.TableOperations<PQio.Model.DataSensitivity> sensitivityTbl = new GSF.Data.Model.TableOperations<PQio.Model.DataSensitivity>(connection);

                foreach (int assetID in assetTbl.QueryRecords().Select(item => item.ID))
                {
                    foreach (int channelID in channelTbl.QueryRecordsWhere("AssetID = {0}", assetID ).Select(item => item.ID))
                    {
                        foreach (int evtID in seriesTbl.QueryRecordsWhere("ChannelID = {0}", channelID).Select(item => item.EventID))
                            combinations.Add(new Tuple<int, int>(assetID, evtID));
                    }
                }
            

                combinations = combinations.Distinct().ToList();

                foreach (Tuple<int,int> item in combinations)
                {
                    if (sensitivityTbl.QueryRecordCountWhere("Event = {0} AND Asset = {1}", item.Item2, item.Item1) == 0)
                        sensitivityTbl.AddNewRecord(new Model.DataSensitivity()
                        {
                            Asset = item.Item1,
                            Event = item.Item2,
                            DataSensitivityCode = code,
                            Note = note
                        });

                }

            }
        }

        private void WarnNoteOverride()
        {
            DialogResult result = MessageBox.Show("This will overwrite the Data Sensitivity Note on all Channels. Are you sure you want to continue?", "Data Sensitivity",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                DataSensitivityNoteText.Enabled = true;
                GenereateDataSensitivities("", 0);
                return;
            }
        }

        private void OnClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && !this.DataSensitivityCombo.Enabled)
            {
                if (e.X > DataSensitivityCombo.Location.X && e.X < DataSensitivityCombo.Location.X + DataSensitivityCombo.Width
                    && e.Y > DataSensitivityCombo.Location.Y && e.Y < DataSensitivityCombo.Location.Y + DataSensitivityCombo.Height)
                {
                    this.WarnCodeOverride();
                    return;
                }

            }
            else if (e.Button == MouseButtons.Left && !this.DataSensitivityNoteText.Enabled)
            {
                if (e.X > DataSensitivityNoteText.Location.X && e.X < DataSensitivityNoteText.Location.X + DataSensitivityNoteText.Width
                   && e.Y > DataSensitivityNoteText.Location.Y && e.Y < DataSensitivityNoteText.Location.Y + DataSensitivityNoteText.Height)
                {
                    this.WarnNoteOverride();
                    return;
                }
            }
        }
             
        private void Save_BTN_Click(object sender, EventArgs e)
        {
            using (AdoDataConnection connection = new AdoDataConnection(connectionstring, dataprovider))
            {
                GSF.Data.Model.TableOperations<PQio.Model.DataSensitivity> dataSensitivityTable = new GSF.Data.Model.TableOperations<PQio.Model.DataSensitivity>(connection);

                if (DataSensitivityCombo.Enabled)
                {
                    int? dataSensitivity = null;

                    if (PQio.Model.DataSensitivityCode.ToValue((string)DataSensitivityCombo.SelectedItem) != -1)
                    {
                        dataSensitivity = PQio.Model.DataSensitivityCode.ToValue((string)DataSensitivityCombo.SelectedItem);
                    }

                    connection.ExecuteScalar("UPDATE DataSensitivity SET DataSensitivityCode = {0}", dataSensitivity);
                }

                if (DataSensitivityNoteText.Enabled)
                    connection.ExecuteScalar("UPDATE DataSensitivity SET Note = {0}", new object[1] { DataSensitivityNoteText.Text.Trim() });
                
                this.Close();
            }
        }

        #endregion[Methods]

    }

}
