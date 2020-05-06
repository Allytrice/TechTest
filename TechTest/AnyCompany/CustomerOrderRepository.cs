using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany
{
    public class CustomerOrderRepository
    {
        private static string ConnectionString = @"Server=26X61Z2;Database=Customers;Trusted_Connection=True;"; //Can use the same Database, using different table
        public List<Customer> LoadAllCustomers()
        {
            List<Customer> customers = new List<Customer>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConnectionString;
                conn.Open();

                SqlCommand sqlCmd = new SqlCommand("SELECT * FROM Customer", conn);
                

                using (SqlDataReader read = sqlCmd.ExecuteReader())
                {
                    while (read.Read())
                    {
                        customers.Add(new Customer
                        {
                            Name = read["Name"].ToString(),
                            CustomerId = (int)read["CustomerId"],
                            Country = read["Country"].ToString()

                        });
                    }
                }

            }
            return customers;
        }
        public List<Order> LoadAllOrders(int customerId)
        {
            List<Order> orders = new List<Order>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConnectionString;
                conn.Open();

                SqlCommand sqlCmd = new SqlCommand("SELECT * FROM Orders WHERE CustomerId = @customerId", conn);
                sqlCmd.Parameters.Add(new SqlParameter("customerId", customerId));

                using (SqlDataReader read = sqlCmd.ExecuteReader())
                {
                    while(read.Read())
                    {
                        orders.Add(new Order {
                            OrderId = (int)read["OrderId"],
                            Amount =(double) read["Amount"]

                        });
                    }
                }

            }

                return orders;

        }
    }
}
