using System;
using System.Data;
using System.Data.SqlClient;
using ConfigLibrary;
using LoggerLibrary.Abstract;

namespace LoggerLibrary.ConcreteLoggers
{

    public class DbLogger: LoggerBase
    {
        protected override void WriteCore(string baslik, string mesaj)
        {
            base.Baslik = baslik;
            base.Mesaj = mesaj;
            Core();
        }
        protected override void WriteCore(Exception mesaj)
        {
            base.Baslik = mesaj.Message.ToString();
            base.Mesaj = mesaj.ToString();
            Core();
        }
        protected override void WriteCore(string baslik, Exception mesaj)
        {
            base.Baslik = baslik;
            base.Mesaj = mesaj.ToString();
            Core();
        }

        protected override void Core()
        {
         
            using (SqlConnection baglan = new SqlConnection(ConfigHelper.GetConnectionString()))
            {
                baglan.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = baglan;
                    cmd.CommandText = "sp_HataMesajiEkle";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@baslik", SqlDbType.NVarChar);
                    cmd.Parameters["@baslik"].Value = base.Baslik;
                    cmd.Parameters.Add("@mesaj", SqlDbType.NVarChar);
                    cmd.Parameters["@mesaj"].Value = base.Mesaj;
                    cmd.Parameters.Add("@retValue", SqlDbType.Bit);
                    cmd.Parameters["@retValue"].Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();


                }

            }
        }

    }
}
