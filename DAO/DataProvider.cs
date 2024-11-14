using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace ASM1_Database_QLMIXUE.DAO
{
    public class DataProvider
    {
        //tạo thành lớp Singleton
        private static DataProvider instance;//crtl+R+E

        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return DataProvider.instance; }
            private set {DataProvider.instance = value; }
        }

        private DataProvider() { }

        private string connectionSTR = "Data Source=HOANGLUAN;Initial Catalog=HethongquanliMixue;Integrated Security=True;Encrypt=False";


        public DataTable ExcuteQuery(String query, object[] parameter = null)

        {
            DataTable data = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {

                connection.Open();

                SqlCommand conmand = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            conmand.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(conmand);

                adapter.Fill(data);

                connection.Close();

                return data;
            }

        }
        public int ExcuteNonQuery(String query, object[] parameter = null)
        {
            int data = 0;
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {

                connection.Open();

                SqlCommand conmand = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            conmand.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                data = conmand.ExecuteNonQuery();

                connection.Close();

                return data;
            }
        }
        public object ExcuteScalar(String query, object[] parameter = null)
        {
            object data = 0;
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {

                connection.Open();

                SqlCommand conmand = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            conmand.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                data = conmand.ExecuteScalar();

                connection.Close();

                return data;
            }
        }
    }
}