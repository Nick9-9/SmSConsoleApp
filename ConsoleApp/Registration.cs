using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    static class Registration
    {
        public static UserContext userContext = new UserContext();
        public static User Curentuser;
        public static void Enroll()
        {
            Curentuser = new User();
            do
            {
                Console.Write("Name: ");
                Curentuser.Name = Console.ReadLine();
            } while (Curentuser.Name == null);

            do
            {
                Console.WriteLine("Phone: ");
                Curentuser.PhoneUser = Console.ReadLine();
                User userAutorization = userContext.Users.FirstOrDefault(t => t.PhoneUser == Curentuser.PhoneUser);
                if (userAutorization != null)
                {
                    Console.Clear();
                    Console.WriteLine("User exist !!!");
                    Autorization();
                    Console.ReadKey();
                    return;
                }
            } while (Curentuser.PhoneUser == null);

            do
            {
                Console.WriteLine("Password: ");
                Curentuser.Password = Console.ReadLine();
            } while (Curentuser.Password == null);

            userContext.Users.Add(Curentuser);
            userContext.SaveChanges();
            Console.WriteLine("Plus new user!!!");
            Console.ReadKey();
        }

        public static void Autorization()
        {
            string phoneNumber;
            string password;
            do
            {
                Console.WriteLine("Phone: ");
                phoneNumber = Console.ReadLine();
                Curentuser = userContext.Users.FirstOrDefault(t => t.PhoneUser == phoneNumber);
                if (Curentuser == null)
                {
                    Console.Clear();
                    Console.WriteLine("Undifine Number");
                    Console.ReadKey();
                    return;
                }
            } while (Curentuser.PhoneUser == null);

            Console.Write("Password: ");
            password = Console.ReadLine();
            if (password == Curentuser.Password)
            {
                Console.Clear();
                Console.WriteLine("Your Account!");
                InterfaceMessagge();
            }
            else
            {
                Console.ReadKey();
                return;
            }

        }
        public static void Messagge()
        {
            Recepient recepientCurent = new Recepient();
            Messager messager = new Messager();

            do
            {
                Console.WriteLine("Phone: ");
                recepientCurent.PhoneRecepient = Console.ReadLine();

            } while ((recepientCurent.PhoneRecepient == null) && (recepientCurent.PhoneRecepient != Curentuser.PhoneUser));

            Recepient recepient = userContext.Recepients.FirstOrDefault(t => t.PhoneRecepient == recepientCurent.PhoneRecepient);
            if (recepient == null)
            {
                Console.Write("Name: ");
                recepientCurent.Name = Console.ReadLine();
            }
            userContext.Recepients.Add(recepientCurent);



            Console.WriteLine("Text message:");
            messager.TextMessage = Console.ReadLine();
            messager.RecepientId = recepientCurent.RecepientId;
            messager.UserId = Curentuser.UserId;
            userContext.Messagers.Add(messager);
            userContext.SaveChanges();
            Messager[] messageArray = new Messager[1];
            messageArray[0] = messager;
            SaveInFileJson("Test1", messageArray);

            Console.WriteLine("Messege are sended.");
            Console.ReadKey();
        }

        public static void SaveInFileJson<T>(string FileName, T[] data)
        {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(T[]));

            using (FileStream fs = new FileStream(FileName, FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(fs, data);
            }
        }
        public static void InterfaceMessagge()
        {

            int tmp;

            do
            {
                tmp = Cursor("Messagge", "Exit");

                switch (tmp)
                {
                    case 0: { Messagge(); break; }
                    case 1: { Console.ReadKey(); break; }

                }
            } while (true);
        }

        public static void Interface()
        {

            int tmp;

            do
            {
                tmp = Cursor("Add User", "Autorization", "Exit");

                switch (tmp)
                {
                    case 0: { Enroll(); break; }
                    case 1: { Autorization(); break; }
                    case 2: { Console.ReadKey(); break; }

                }
            } while (true);
        }
        public static int Cursor(params string[] menuItems)
        {
            short curItem = 0, c;
            ConsoleKeyInfo key;
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
                    if (curItem > menuItems.Length - 1)
                        curItem = 0;
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

            return curItem;
        }




    }
}
