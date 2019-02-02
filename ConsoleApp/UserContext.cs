using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class UserContext : DbContext
    {
        public UserContext()
            : base("DbConnection")
    { }

    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Messager> Messagers { get; set; }
    public virtual  DbSet<Recepient> Recepients { get; set; }
}
}
