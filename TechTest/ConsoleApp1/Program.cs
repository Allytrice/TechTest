using System;
using System.Collections.Generic;
using AnyCompany;

namespace AnyCompanyUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //NB: There is already customerId 1 , 2 , 3 defined in the Database

            Console.WriteLine("Welcome to AnyCompany \n Please provide a Customer ID or Alternatively Key in X to display all  orders: ");
            String customerID = Console.ReadLine();

            if (customerID.ToLower() != "x")
            {
                Customer customer = new Customer();
                Order order = new Order();
                OrderService PlaceOrder = new OrderService();


                customer = CustomerRepository.Load(Int32.Parse(customerID));

                Console.WriteLine("Hello " + customer.Name + " Please provide Amount : ");
                String orderAmount = Console.ReadLine();


                order.Amount = float.Parse(orderAmount);
                if (PlaceOrder.PlaceOrder(order, Int32.Parse(customerID)))
                {
                    Console.WriteLine("You have succefully Placed an Order");
                }
                else
                {
                    Console.WriteLine("There was an issue creating the order");
                }
            }
            else
            {
                DisplayOrders();
            }
            //Console.WriteLine(customer.Name);

            

            Console.ReadLine();
        
        }

        public static void DisplayOrders()
        {
            List<Customer> customers = new List<Customer>();
            CustomerOrder customerOrder = new CustomerOrder();
            
            CustomerOrderRepository customerOrderRepository = new CustomerOrderRepository();

            customers = customerOrderRepository.LoadAllCustomers();

            foreach (var cust in customers)
            {
                customerOrder.orders = customerOrderRepository.LoadAllOrders(cust.CustomerId);
                Console.WriteLine("***************************************************");
                Console.WriteLine("Customer Name : " + cust.Name);
                Console.WriteLine("Orders: ");
                foreach (var order in customerOrder.orders)
                {
                    Console.WriteLine("\tOrder ID: " + order.OrderId);
                    Console.WriteLine("\tOrder Amount:" + order.Amount);
                }                    
            }
        }
    }
}
