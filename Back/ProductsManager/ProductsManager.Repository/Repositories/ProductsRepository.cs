using ProductsManager.Core.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;
using ProductsManager.Core.Entites;


namespace ProductsManager.Repository.Repositories
{
    public class ProductsRepository: IProductsRepository
    {
        private readonly string connectionString = "";

        public ProductsRepository()
        {
            connectionString = @"data source=DESKTOP-TT88BLP; Initial Catalog=prueba; integrated security=SSPI; Trust Server Certificate=true";
        }


        public List<Product> GetProducts()
        {

           List<Product> response = new List<Product>() ;

            try
            {
                
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlDataAdapter da = new SqlDataAdapter("select * from Products", connection);

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count>0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            Product prod = new Product();
                            prod.Id = Convert.ToInt32(row["Id"]);
                            prod.Name = Convert.ToString(row["Name"]);
                            prod.Type = Convert.ToString(row["Type"]);
                            prod.Description = Convert.ToString(row["Description"]);
                            prod.EntryDate = Convert.ToString(row["EntryDate"]);
                            prod.Cost = Convert.ToInt32(row["Cost"]);
                            prod.Units = Convert.ToInt32(row["Units"]);
                            prod.StoreNumber = Convert.ToInt32(row["StoreNumber"]);
                            prod.Dispatcher = Convert.ToString(row["Dispatcher"]);

                            response.Add(prod);
                        }

                    }                   

                }
            }
            catch (SqlException e)
            {
                
            }


            return response;
        }


        public string InsertProducts(Product prod)
        {            
            string? response = "";

            try
            {                
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    String query = "INSERT INTO Products (Name, Type, Description, EntryDate, Cost, Units, StoreNumber, Dispatcher)" +
                        " VALUES (@Name, @Type, @Description, @EntryDate, @Cost, @Units, @StoreNumber, @Dispatcher)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", prod.Name);
                        command.Parameters.AddWithValue("@Type", prod.Type);
                        command.Parameters.AddWithValue("@Description", prod.Description);
                        command.Parameters.AddWithValue("@EntryDate", prod.EntryDate);
                        command.Parameters.AddWithValue("@Cost", prod.Cost);
                        command.Parameters.AddWithValue("@Units", prod.Units);
                        command.Parameters.AddWithValue("@StoreNumber", prod.StoreNumber);
                        command.Parameters.AddWithValue("@Dispatcher", prod.Dispatcher);

                        connection.Open();
                        int result = command.ExecuteNonQuery();

                        // Check Error
                        if (result < 0)
                        {
                            response = "0";
                        }
                        else
                        {
                            response = "1";
                        }
                            
                    }

                }
            }
            catch (SqlException e)
            {
                response = e.Message;
            }


            return response;
        }

        public string DeleteProducts(int id)
        {
            string? response = "";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    String query = "DELETE FROM Products WHERE Id=@Id";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);                        

                        connection.Open();
                        int result = command.ExecuteNonQuery();

                        // Check Error
                        if (result < 0)
                        {
                            response = "0";
                        }
                        else
                        {
                            response = "1";
                        }

                    }

                }
            }
            catch (SqlException e)
            {
                response = e.Message;
            }


            return response;
        }


    }
}
