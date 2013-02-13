using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;

namespace JB
{
    public class ClJobs
    {
        //this is to populate the selections after the editjobs 
        //form has loaded...
        public int[] getmutitexts(int jobid)
        {
            //store rec details
            int[] arrayrec = new int[250];

            MySqlConnection connreader = new MySqlConnection();
            //Clconnect kenect = new Clconnect();
            connreader.ConnectionString =  Clconnect.makeconn();

            using (connreader)
            {
                MySqlCommand command = new MySqlCommand("select termid from jobtable where idJobs = '" + jobid + "' ; ", connreader);
                connreader.Open();

                MySqlDataReader reader = command.ExecuteReader();

                int i = 0;

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {                        
                        arrayrec[i] = reader.GetInt16("termid");
                        i++;
                    }
                }

                else
                {
                    return null;                    
                }
                reader.Close();
            }

            return arrayrec;

        }


      
    }
}