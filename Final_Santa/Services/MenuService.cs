using Final_Santa.Models;
using Final_Santa.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Santa.Services
{
    internal class MenuService
    {
        public async Task CreateNewErrandAsync()
        {
            var errand = new ErrandModel();

            Console.Write("Name: ");
            errand.FirstName = Console.ReadLine() ?? "";

            Console.Write("Surname: ");
            errand.LastName = Console.ReadLine() ?? "";

            Console.Write("E-mail: ");
            errand.Email = Console.ReadLine() ?? "";

            Console.Write("Phone number: ");
            errand.PhoneNumber = Console.ReadLine() ?? "";

            Console.Write("Errand description: ");
            errand.ErrandDescription = Console.ReadLine() ?? "";

            Console.Write("Errand title: ");
            errand.Title = Console.ReadLine() ?? "";

            errand.ErrandDate = DateTime.Now;

            errand.ErrandStatus = 1;


            //save customer to database
            await ErrandService.SaveAsync(errand);

        }

        public async Task ListAllErrandsAsync()
        {
            //get all customers+address from database
            var errands = await ErrandService.GetAllAsync();

            if (errands.Any())
            {

                foreach (ErrandModel errand in errands)
                {
                    Console.WriteLine($"ErrandNumber: {errand.Id}");
                    Console.WriteLine($"FullName: {errand.FirstName} {errand.LastName}");
                    Console.WriteLine($"E-mail: {errand.Email}");
                    Console.WriteLine($"PhoneNumber: {errand.PhoneNumber}");
                    Console.WriteLine($"Errand title: {errand.Title},\nErrand description: {errand.ErrandDescription},\nErrand creation date:  {errand.ErrandDate}");
                    if (errand.ErrandStatus == 1)
                    {
                        Console.WriteLine($"Errand status: not started");
                    }
                    else if (errand.ErrandStatus == 2)
                    {
                        Console.WriteLine($"Errand status: ongoing");
                    }
                    else if (errand.ErrandStatus == 3)
                    {
                        Console.WriteLine($"Errand status: finished");
                    }
                    Console.WriteLine("");
                }
            }
            else
            {
                Console.WriteLine("Could not find an errand.");
                Console.WriteLine("");
            }

        }

        public async Task ListSpecificErrandAsync()
        {
            Console.Write("Write in errands title: ");
            var title = Console.ReadLine();

            if (!string.IsNullOrEmpty(title))
            {
                //get specific customer+address from database
                var customer = await ErrandService.GetAsync(title);

                if (customer != null)
                {
                    Console.WriteLine($"\nCustomerNumber: {customer.Id}");
                    Console.WriteLine($"FullName: {customer.FirstName} {customer.LastName}");
                    Console.WriteLine($"E-mail: {customer.Email}");
                    Console.WriteLine($"PhoneNumber: {customer.PhoneNumber}");
                    Console.WriteLine($"Errand title: {customer.Title},\nErrand description: {customer.ErrandDescription},\nErrand creation date:  {customer.ErrandDate}");
                    if (customer.ErrandStatus == 1)
                    {
                        Console.WriteLine($"Errand status: not started");
                    }
                    else if (customer.ErrandStatus == 2)
                    {
                        Console.WriteLine($"Errand status: ongoing");
                    }
                    else if (customer.ErrandStatus == 3)
                    {
                        Console.WriteLine($"Errand status: finished");
                    }
                    Console.WriteLine("");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"No customer with this email {title} was found.");
                    Console.WriteLine("");
                }
            }
            else
            {
                Console.WriteLine($"No e-mail stated.");
                Console.WriteLine("");
            }

        }

        public async Task UpdateSpecificErrandAsync()
        {
            Console.Write("Write in the title of the errand: ");
            var title = Console.ReadLine();

            if (!string.IsNullOrEmpty(title))
            {

                var errand = await ErrandService.GetAsync(title);
                if (errand != null)
                {
                    Console.WriteLine("Write in the information in the categories you wish to change. \n");

                    Console.Write("Name: ");
                    errand.FirstName = Console.ReadLine() ?? null!;

                    Console.Write("Surname: ");
                    errand.LastName = Console.ReadLine() ?? null!;

                    Console.Write("E-mail: ");
                    errand.Email = Console.ReadLine() ?? null!;

                    Console.Write("Phone number: ");
                    errand.PhoneNumber = Console.ReadLine() ?? null!;

                    Console.Write("Errand Description: ");
                    errand.ErrandDescription = Console.ReadLine() ?? null!;


                    await ErrandService.UpdateAsync(errand);
                }
                else
                {
                    Console.WriteLine($"Could not find the errand with a gicen title.");
                    Console.WriteLine("");
                }

            }
            else
            {
                Console.WriteLine($"No title stated.");
                Console.WriteLine("");
            }

        }


        public async Task DeleteSpecificErrandAsync()
        {
            Console.Write("Write in the errands title: ");
            var title = Console.ReadLine();

            if (!string.IsNullOrEmpty(title))
            {
                //delete specific customer from database
                await ErrandService.DeleteAsync(title);
            }
            else
            {
                Console.WriteLine($"No title stated.");
                Console.WriteLine("");
            }

        }


        public async Task UpdateErrandStatusAsync()
        {
            Console.Write("Write in the title of the errand: ");
            var title = Console.ReadLine();

            if (!string.IsNullOrEmpty(title))
            {

                var errand = await ErrandService.GetAsync(title);
                if (errand != null)
                {
                    Console.Clear();
                    Console.WriteLine("1. Not started");
                    Console.WriteLine("2. Ongoing");
                    Console.WriteLine("3. Finished");
                    Console.WriteLine("What status is the errend (1-3):  \n");
                    var status = Console.ReadLine();

                    switch (status)
                    {
                        case "1":
                            errand.ErrandStatus = 1;
                            break;

                        case "2":
                            errand.ErrandStatus = 2;
                            break;

                        case "3":
                            errand.ErrandStatus = 3;
                            break;

                        default:
                            Console.WriteLine("Not a valid choice");
                            Console.ReadKey();
                            break;

                    }

                    await ErrandService.UpdateAsync(errand);
                }
                else
                {
                    Console.WriteLine($"Could not find the errand with a given title.");
                    Console.WriteLine("");
                }

            }
            else
            {
                Console.WriteLine($"No title stated.");
                Console.WriteLine("");
            }

        }
    }
}
