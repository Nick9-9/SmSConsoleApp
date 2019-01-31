using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    static class Registration
    {
        public static void Enroll(UserContext userContext)
        {
            User userRegistration = new User();
            do
            {
                Console.Write("Name: ");
                userRegistration.Name = Console.ReadLine();
            } while (userRegistration.Name == null);

            do
            {
                Console.WriteLine("Phone: ");
                userRegistration.PhoneUser = Console.ReadLine();

            } while (userRegistration.PhoneUser == null);

            do
            {
                Console.WriteLine("Password: ");
                userRegistration.Password = Console.ReadLine();
            } while (userRegistration.Password == null);

            userContext.Users.Add(userRegistration);
            userContext.SaveChanges();
            Console.WriteLine("Plus new user!!!");
            Console.ReadKey();
        }


    }
    class Program
    {
        public static void Interface()
        {
            UserContext db = new UserContext();
            short curItem = 0, c;
            ConsoleKeyInfo key;
            string[] menuItems = { "Add User", "Add new Recepient" };

            do
            {
                Console.Clear();
                Console.WriteLine("Pick an option . . .");

                for (c = 0; c < menuItems.Length; c++)
                {

                    if (curItem == c)
                    {
                        Console.Write(">>");
                        Console.WriteLine(menuItems[c]);
                    }
                    else
                    {
                        Console.WriteLine(menuItems[c]);
                    }
                }
                Console.WriteLine("Select your choice with the arrow keys.");

                key = Console.ReadKey(true);

                if (key.Key.ToString() == "DownArrow")
                {
                    curItem++;
                    if (curItem > menuItems.Length - 1) curItem = 0;
                }
                else
                {
                    if (key.Key.ToString() == "UpArrow")
                    {
                        curItem--;
                        if (curItem < 0) curItem = Convert.ToInt16(menuItems.Length - 1);
                    }
                }
            } while (key.KeyChar != 13);

            do
            {
                switch (curItem)
                {
                    case 0: { Registration.Enroll(db); break; }
                    case 1: { Console.WriteLine("`123456yi"); break; }

                }
            } while (true);
            
          
        }
        static void Main(string[] args)
        {

            Interface();

                

                Console.ReadKey();

            

           // Console.ReadKey();
        }

        //User user = new User();
        //user.UserId = 3;
        //db.Users.Add(user);
        //db.SaveChanges();
        //Console.WriteLine("Объекты успешно сохранены");

            }
        }
    