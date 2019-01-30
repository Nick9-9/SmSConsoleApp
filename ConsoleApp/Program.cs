using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (UserContext db = new UserContext())
            {
                User user = new User();
                user.IdSender = 1;
                db.Users.Add(user);
                db.SaveChanges();
                Console.WriteLine("Объекты успешно сохранены");
                Console.ReadKey();

            }
        }
    }
}
