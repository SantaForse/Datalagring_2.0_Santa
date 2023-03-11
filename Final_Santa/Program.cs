using Final_Santa.Services;

var menu = new MenuService();

while (true)
{
    Console.Clear();
    Console.WriteLine("1. I am a client and I want to create an errand or look/change my errand");
    Console.WriteLine("2. I am an employee and I want to look at one/look at all/change an errand");
    Console.Write("Choose one of the alternatives abover (1-2): ");

    switch (Console.ReadLine())
    {
        case "1":
            Console.Clear();
            Console.WriteLine("1. Create an errand");
            Console.WriteLine("2. Look at my errand");
            Console.WriteLine("3. Change my errand");
            Console.Write("Choose one of the alternatives abover (1-3): ");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    await menu.CreateNewErrandAsync();
                    Console.WriteLine("\nYou have created a new errand!");
                    break;

                case "2":
                    Console.Clear();
                    await menu.ListSpecificErrandAsync();
                    break;

                case "3":
                    Console.Clear();
                    await menu.UpdateSpecificErrandAsync();
                    Console.WriteLine("\nNow the errand you chose is updated!");
                    break;

                default:
                    Console.WriteLine("\nNot a valid choice");
                    Console.ReadKey();
                    break;
            }
            break;

        case "2":
            Console.Clear();
            Console.WriteLine("1. Change an errand status");
            Console.WriteLine("2. Look at an errand");
            Console.WriteLine("3. Look at all errands");
            Console.WriteLine("4. Delete an errand");
            Console.Write("Choose one of the alternatives abover (1-4): ");

            switch (Console.ReadLine())
            {

                case "1":
                    Console.Clear();
                    await menu.UpdateErrandStatusAsync();
                    Console.WriteLine("\nNow the errand status is updated!");
                    break;


                case "2":
                    Console.Clear();
                    await menu.ListSpecificErrandAsync();
                    break;

                case "3":
                    Console.Clear();
                    await menu.ListAllErrandsAsync();
                    break;

                case "4":
                    Console.Clear();
                    await menu.DeleteSpecificErrandAsync();
                    Console.WriteLine("\nNow the errand you chose is deleted!");
                    break;

                default:
                    Console.WriteLine("\nNot a valid choice");
                    Console.ReadKey();
                    break;

            }
            break;
    }

    Console.WriteLine("\nPress any button to continue..");
    Console.ReadKey();
}