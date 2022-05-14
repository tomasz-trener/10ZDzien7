using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02AplikacjaZawodnicy.Tools
{
    class PolaczenieZBaza
    {
        string connectionString = "Data Source=.;Initial Catalog=a_zawodnicy;user id=sa;password=alx";


        public PolaczenieZBaza()
        {

        }

        public PolaczenieZBaza(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public object[][] WyslijPolecenieSQL(string sql)
        {
            SqlConnection connection; // służy do komunikacji z baza 
            SqlCommand command; // przechowuje polecenia SQL
            SqlDataReader dataReader; // czytanie wynikow z bazy 

            // string connectionString = "Data Source=.;Initial Catalog=a_zawodnicy;integrated security=true"; // windows auth

            connection = new SqlConnection(connectionString);
            command = new SqlCommand(sql, connection);

            connection.Open();
            dataReader = command.ExecuteReader();

            int liczbaKolumn = dataReader.FieldCount;

            List<object[]> listaWierszy = new List<object[]>();

            while (dataReader.Read())
            {
                object[] komorki = new object[liczbaKolumn];
                for (int i = 0; i < liczbaKolumn; i++)
                    komorki[i] = dataReader.GetValue(i);

                listaWierszy.Add(komorki);
            }
            connection.Close();
            return listaWierszy.ToArray();
        }


    }
}
