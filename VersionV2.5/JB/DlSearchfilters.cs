using System.Data;
using MySql.Data.MySqlClient;

namespace JB
{
    public class DlSearchfilters
    {
        public int Getalljobcount()
        {
            //store rec details
            var arrayrec = string.Empty;
            var connreader = new MySqlConnection { ConnectionString = Dlconnect.Makeconn() };
            
            using (connreader)
            {
                var command = new MySqlCommand(@"select count(*) as total from aggregatedmpage;", connreader);
                connreader.Open();

                var reader = command.ExecuteReader();
            
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        return reader.GetInt32(0);
                    }
                }

                reader.Close();
            }

            return 0;
        }

        //get customized job counts
        public int Getalljobcount(string qry)
        {
            //store rec details
            var arrayrec = string.Empty;
            var connreader = new MySqlConnection { ConnectionString = Dlconnect.Makeconn() };
            
            using (connreader)
            {
                var command = new MySqlCommand(qry, connreader);
                connreader.Open();

                var reader = command.ExecuteReader();
            
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        return reader.GetInt32(0);
                    }
                }

                reader.Close();
            }

            return 0;
        }

        //simple single job
        public DataSet GetJobssingle(int lowlimit, int highlimit)
        {
            var ds = new DataSet();
            var myconstring = Dlconnect.Makeconn();
            var mycon = new MySqlConnection { ConnectionString = myconstring };
            var myda = new MySqlDataAdapter(@"select * from Aggregatedmpage limit "+lowlimit+","+highlimit+";", mycon);

            mycon.Open();

            myda.Fill(ds, "Aggregatedmpage");

            mycon.Close();

            return ds;
        }

        //get filtered / searched values
        public DataSet QuerySearch(string qry)
        {
            var ds = new DataSet();
            var myconstring = Dlconnect.Makeconn();
            var mycon = new MySqlConnection { ConnectionString = myconstring };

            var myda = new MySqlDataAdapter(qry, mycon);

            mycon.Open();
            myda.Fill(ds, "aggregatedmulti");

            mycon.Close();

            return ds;
        }
    }
}