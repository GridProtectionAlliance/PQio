using GSF.Data;
using System;
using System.Windows.Forms;
using System.IO;

namespace PQio
{
    public partial class PQdsDevice : Form
    {

        #region[Properties]

        private PQio.Model.Meter m_device;
        private string connectionstring;
        private const string dataprovider = "AssemblyName={System.Data.SQLite, Version=1.0.109.0, Culture=neutral, PublicKeyToken=db937bc2d44ff139}; ConnectionType=System.Data.SQLite.SQLiteConnection; AdapterType=System.Data.SQLite.SQLiteDataAdapter";

        #endregion[Properties]

        public PQdsDevice(int id)
        {
            string localAppData = $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}{Path.DirectorySeparatorChar}PQio{Path.DirectorySeparatorChar}DataBase.db";
            connectionstring = $"Data Source={localAppData}; Version=3; Foreign Keys=True; FailIfMissing=True";

            if (id == -1)
            {
                m_device = new PQio.Model.Meter();
            }
            else
            {
                using (AdoDataConnection connection = new AdoDataConnection(connectionstring, dataprovider))
                {

                    GSF.Data.Model.TableOperations<PQio.Model.Meter> deviceTable = new GSF.Data.Model.TableOperations<PQio.Model.Meter>(connection);
                    m_device = deviceTable.QueryRecordWhere("ID = {0}", id);
                    this.Text = string.Format("PQds {0} MetaData", m_device.DeviceAlias);
                }
            }

            InitializeComponent();
        }

        private void PQioDevice_Load(object sender, EventArgs e)
        {

            NameTxtBox.Text = m_device.DeviceName;
            AliasTxtBox.Text = m_device.DeviceAlias;

            LocationTxtBox.Text = m_device.DeviceLocation;
            LocationAliasTxtBox.Text = m_device.DeviceLocationAlias;

            if (!(m_device.Latitude == 0 ))
            {
                LatTxtBox.Text = Convert.ToString(m_device.Latitude);
            }
            if (!(m_device.Longitude == 0))
            {
                LongTxtBox.Text = Convert.ToString(m_device.Longitude);
            }

            ActAliasTxtBox.Text = m_device.AccountAlias;
            ActTxtBox.Text = m_device.AccountName;

            OwnerTxtBox.Text = m_device.Owner;

            if (!(m_device.DistanceToXFR == 0))
            {
                XFRTxtBox.Text = Convert.ToString(m_device.DistanceToXFR);
            }

            connBox.Items.AddRange(Model.ConnectionType.DisplayOptions());

            if (m_device.ConnectionType != null)
            {
                connBox.SelectedIndex = Array.FindIndex(Model.ConnectionType.DisplayOptions(),
                    item => item == Model.ConnectionType.ToDisplay((int)m_device.ConnectionType));
            }
            else
            {
                connBox.SelectedIndex = Array.FindIndex(Model.ConnectionType.DisplayOptions(),
                    item => item == Model.ConnectionType.ToDisplay(-1));
            }

        }

        private void CxnBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            using (AdoDataConnection connection = new AdoDataConnection(connectionstring, dataprovider))
            {
                GSF.Data.Model.TableOperations<PQio.Model.Meter> deviceTable = new GSF.Data.Model.TableOperations<PQio.Model.Meter>(connection);
                PQio.Model.Meter device = deviceTable.QueryRecordWhere("ID = {0}", m_device.ID);
                if (device is null)
                {
                    device = new PQio.Model.Meter();
                }

                device.DeviceName = NameTxtBox.Text;

                device.DeviceAlias = AliasTxtBox.Text;


                device.DeviceLocation = LocationTxtBox.Text;
                device.DeviceLocationAlias = LocationAliasTxtBox.Text;


                if (LatTxtBox.Text != "")
                {
                    try
                    {
                        if (!(Convert.ToDouble(LatTxtBox.Text) == 0))
                        {
                            device.Latitude = Convert.ToDouble(LatTxtBox.Text);
                        }
                    }
                    catch { MessageBox.Show("Latitude has to be a number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                }

                if (LongTxtBox.Text != "")
                {
                    try
                    {
                        if (!(Convert.ToDouble(LongTxtBox.Text) == 0))
                        {
                            device.Longitude = Convert.ToDouble(LongTxtBox.Text);
                        }
                    }
                    catch { MessageBox.Show("Longitude has to be a number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                }

                device.AccountAlias = ActAliasTxtBox.Text;
                device.AccountName = ActTxtBox.Text;

                device.Owner = OwnerTxtBox.Text;

                if (XFRTxtBox.Text != "")
                {
                    try
                    {
                        if (!(Convert.ToDouble(XFRTxtBox.Text) == 0))
                        {
                            device.DistanceToXFR = Convert.ToDouble(XFRTxtBox.Text);
                        }
                    }
                    catch { MessageBox.Show("Distance to XFMR has to be a number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                }


                if ((string)connBox.SelectedItem == "")
                {
                    device.ConnectionType = null;
                }
                else
                {
                    device.ConnectionType = Model.ConnectionType.ToValue((string)connBox.SelectedItem);
                }

                deviceTable.AddNewOrUpdateRecord(device);

            }
            this.Close();

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
