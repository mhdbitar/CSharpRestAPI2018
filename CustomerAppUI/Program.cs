using CustomerAppBLL;
using CustomerAppBLL.BusinessObjects;
using System;

namespace CustomerAppUI
{
    class Program
    {
        static BLLFacade bllFacade = new BLLFacade();

        static void Main(string[] args)
        {
            var customer1 = new CustomerBO()
            {
                FirstName = "Mohammad",
                LastName = "Bitar",
                Address = "Turkey, Istanbul"
            };

            bllFacade.CustomerService.Create(customer1);

            bllFacade.CustomerService.Create(new CustomerBO()
            {
                FirstName = "Killua",
                LastName = "Zoldic",
                Address = "Hunter x Hunter World"
            });

            string[] menuItems = {
                "List All Customers",
                "Add Customer",
                "Delete Customer",
                "Edit Customer",
                "Exit"
            };

            var selection = ShowMenu(menuItems);

            while (selection != 5)
            {
                switch (selection)
                {
                    case 1:
                        ListCustomers();
                        break;
                    case 2:
                        AddCustomer();
                        break;
                    case 3:
                        DeleteCustomer();
                        break;
                    case 4:
                        EditCustomer();
                        break;
                    default:
                        break;
                }
                selection = ShowMenu(menuItems);
            }
            Console.WriteLine("Bye bye!");
            Console.ReadLine();
        }

        private static void EditCustomer()
        {
            CustomerBO customer = FindCustomerById();
            if (customer != null)
            {
                Console.WriteLine("First Name: ");
                customer.FirstName = Console.ReadLine();
                Console.WriteLine("Last Name: ");
                customer.LastName = Console.ReadLine();
                Console.WriteLine("Address: ");
                customer.Address = Console.ReadLine();

                bllFacade.CustomerService.Update(customer);
            }
            else
            {
                Console.WriteLine("Customer not Found!");
            }
        }

        private static CustomerBO FindCustomerById()
        {
            Console.WriteLine("Insert Customer Id: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Please insert a number");
            }

            return bllFacade.CustomerService.Get(id);
        }

        private static void DeleteCustomer()
        {
            var customerFound = FindCustomerById();
            if (customerFound != null)
            {
                bllFacade.CustomerService.Delete(customerFound.Id);
                Console.WriteLine("Customer was Deleted");
            }
            else
            {
                Console.WriteLine("Customer not Found!");
            }

        }

        private static void AddCustomer()
        {
            Console.WriteLine("First Name: ");
            var firstName = Console.ReadLine();

            Console.WriteLine("Last Name: ");
            var lastName = Console.ReadLine();

            Console.WriteLine("Address: ");
            var address = Console.ReadLine();

            bllFacade.CustomerService.Create(new CustomerBO()
            {
                FirstName = firstName,
                LastName = lastName,
                Address = address
            });
        }

        private static void ListCustomers()
        {
            Console.WriteLine("\nList of Customers");
            foreach (var customer in bllFacade.CustomerService.GetAll())
            {
                Console.WriteLine($"Id: {customer.Id} Name: {customer.FullName} " + 
                    $"Address: {customer.Address}");

                Console.WriteLine("\n");
            }
        }

        private static int ShowMenu(string[] menuItems)
        {
            Console.WriteLine("Select What you want to do:\n");

            for (int i = 0; i < menuItems.Length; i++)
            {
                //Console.WriteLine((i + 1) + ":" + menuItems[i]);
                Console.WriteLine($"{(i + 1)}: {menuItems[i]}");
            }

            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection)
                || selection < 1
                || selection > 5)
            {
                Console.WriteLine("Please select a number between 1-5");
            }

            return selection;
        }
    }
}
