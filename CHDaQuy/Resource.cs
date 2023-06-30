using System.Data.SqlClient;

namespace CHDaQuy
{
    internal class Resource
    {
        public Resource()
        {

        }

        public static string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=QUAN_LY_SHOP_DA_QUY;Integrated Security=True";

        public static string GetFieldValues(string SQL)
        {
            string result = "";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(SQL, connection); 
            SqlDataReader reader;

            connection.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
                result = reader.GetValue(0).ToString();
            reader.Close();
            connection.Close();

            return result;
        }
    }
}