using GSF.Data;
using System;
using System.IO;
using System.Windows.Forms;

namespace PQio
{
    public partial class PQdsAddCustom : Form
    {
        int m_eventid;
        int m_assetid;
        private const string dataprovider = "AssemblyName={System.Data.SQLite, Version=1.0.109.0, Culture=neutral, PublicKeyToken=db937bc2d44ff139}; ConnectionType=System.Data.SQLite.SQLiteConnection; AdapterType=System.Data.SQLite.SQLiteDataAdapter";


        public PQdsAddCustom(int AssetID, int EventID)
        {
            InitializeComponent();
            this.m_assetid = AssetID;
            this.m_eventid = EventID;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PQioAddCustom_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string localAppData = $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}{Path.DirectorySeparatorChar}PQio{Path.DirectorySeparatorChar}DataBase.db";
            string connectionstring = $"Data Source={localAppData}; Version=3; Foreign Keys=True; FailIfMissing=True";
            
            using (AdoDataConnection connection = new AdoDataConnection(connectionstring, dataprovider))
            {
                GSF.Data.Model.TableOperations<PQio.Model.CustomField> customFldTbl = new GSF.Data.Model.TableOperations<PQio.Model.CustomField>(connection);

                if (this.textBox1.Text.Length < 1)
                {
                    MessageBox.Show("A Domain name has to be selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (customFldTbl.QueryRecordCountWhere("domain = {0}", this.textBox1.Text) > 0)
                {
                    MessageBox.Show("This domain already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    PQio.Model.CustomField fld = new Model.CustomField() { EventID = m_eventid, AssetID = m_assetid, key = "Key", Value = "Value", Type = "T", domain = this.textBox1.Text };
                    customFldTbl.AddNewRecord(fld);
                }


            }

            this.Close();
        }
    }
}
