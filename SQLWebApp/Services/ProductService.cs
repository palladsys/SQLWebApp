using SQLWebApp.Models;
using System.Data.SqlClient;

namespace SQLWebApp.Services
{
    public class ProductService
    {
        private static string db_source = "palladsysappdb.database.windows.net";
        private static string db_username = "palladsys";
        private static string db_password = "M@1Business1187";
        private static string db_database = "appdb";
        
        private SqlConnection GetConnection()
        {
            var _builder = new SqlConnectionStringBuilder();
            _builder.DataSource = db_source;
            _builder.UserID = db_username;
            _builder.Password = db_password;
            _builder.InitialCatalog = db_database;
            return new SqlConnection(_builder.ConnectionString);
        }

        public List<Product> GetProducts()
        {
            SqlConnection conn = GetConnection();
            List<Product> _product_lst = new List<Product>();
            string statement = "select ProductId,ProductName,Quantity from Products";
            conn.Open();
            SqlCommand cmd = new SqlCommand(statement, conn);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Product product = new Product()
                    {
                        ProductID = reader.GetInt32(0),
                        ProductName = reader.GetString(1),
                        Quantity = reader.GetInt32(2)
                    };
                    _product_lst.Add(product);
                }

            }
            conn.Close();
            return _product_lst;
        }
    }
}
