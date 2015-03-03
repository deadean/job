using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using ADGLOB;
using Model.Entity;

namespace Model.DASqliteLayer
{
    public class DASqliteLayer:IDaLayer,IDisposable
    {
        private SQLiteConnection sqlConnection = null;

        public DASqliteLayer()
        {
            SQLiteFactory factory = (SQLiteFactory)DbProviderFactories.GetFactory(ConfigurationManager.AppSettings[CommonConstants.csProviderName]);
            sqlConnection = (SQLiteConnection)factory.CreateConnection();
            sqlConnection.ConnectionString = "Data Source = " + ConfigurationManager.AppSettings[CommonConstants.csDataBaseName];
            sqlConnection.Open();
        }

        public static void CreateDB()
        {
            SQLiteConnection.CreateFile(ConfigurationManager.AppSettings[CommonConstants.csDataBaseName]);
        }

        public bool InitializeDb()
        {
            bool result = false;

            try
            {
                this.PerformCommand(Constants.csCreatePressRealiseTable, this.sqlConnection);
                this.PerformCommand(Constants.csCreateSitesTable,this.sqlConnection);
                result = true;
            }
            catch (Exception ex)
            {
                CLog.Log("InitializeDB",ex.Message);
            }
            return result;
        }

        public void FillDB()
        {
            try
            {
                this.PerformCommand(Constants.csFillPressRealiseTable, this.sqlConnection);
                this.PerformCommand(Constants.csFillSitesTable, this.sqlConnection);
            }
            catch (Exception ex)
            {
                CLog.Log("FillDb",ex.Message);
            }
        }

        public void Dispose()
        {
            this.sqlConnection.Close();
        }

        public void PerformCommand(string command, DbConnection connection)
        {
            using (SQLiteCommand com = new SQLiteCommand(command, connection as SQLiteConnection))
            {
                com.ExecuteNonQuery();
            }
        }

        public DbDataReader GetReader(string command, DbConnection connection)
        {
            DbDataReader reader = null;
            using (SQLiteCommand com = new SQLiteCommand(command, connection as SQLiteConnection))
            {
                reader = com.ExecuteReader();
            }
            return reader;
        }

        #region CPressRealise Services

        public List<CPressRealise> GetAllPressRealises()
        {
            List<CPressRealise> results = new List<CPressRealise>();
            try
            {
                DbDataReader reader = this.GetReader(Constants.csSelectAllPressRealises, this.sqlConnection);
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        results.Add(new CPressRealise
                        {
                           ID = reader.GetInt32(0).ToString(),
                           Header = (string)reader["header"],
                           Paragraph = (string)reader["paragraph"],
                           FullText = (string)reader["fulltext"],
                           Category = "3"
                        });
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                CLog.Log("GetAllPressRealises", ex.Message);
            }
            return results;
        }

        public List<CSite> GetAllSites()
        {
            var results = new List<CSite>();
            try
            {
                DbDataReader reader = this.GetReader(Constants.csSelectAllSites, this.sqlConnection);
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        results.Add(new CSite()
                        {
                            ID = reader.GetInt32(0).ToString(CultureInfo.InvariantCulture),
                            Href = (string)reader["href"]
                        });
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                CLog.Log("GetAllPressRealises", ex.Message);
            }
            return results;
        }

        #endregion

        public bool UpdatePressRealise(CPressRealise pressRealise)
        {
            try
            {
                this.PerformCommand(String.Format(Constants.csUpdatePressRealiseTable,pressRealise.Header,pressRealise.Paragraph,pressRealise.FullText,pressRealise.PublicHref,pressRealise.ID),this.sqlConnection);
            }
            catch (Exception ex)
            {
                CLog.Log("UpdatePressRealise",ex.Message);
                return false;
            }
            return true;
        }
    }
}
