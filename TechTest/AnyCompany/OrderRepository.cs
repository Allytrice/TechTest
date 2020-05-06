using System.Data.SqlClient;

namespace AnyCompany
{
    internal class OrderRepository
    {
        private static string ConnectionString = @"Server=26X61Z2;Database=Customers;Trusted_Connection=True;"; //Can use the same Database, using different table

        public void Save(Order order)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            SqlCommand command = new SqlCommand("INSERT INTO Orders VALUES (@CustomerId, @Amount, @VAT)", connection);  //Removed OrderId, This will be auto-generated & Incremented by SQL SERVER

            command.Parameters.AddWithValue("@CustomerId", order.CustomerId);               //Link the order to a customer
            command.Parameters.AddWithValue("@Amount", order.Amount);
            command.Parameters.AddWithValue("@VAT", order.VAT);

            command.ExecuteNonQuery();

            connection.Close();
        }
    }
}
