using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Contexts;
using System.Data.Entity;


namespace OstatokSklad
{
    public class UserContext : DbContext
    {
        public UserContext():base("appConnection")
        {
        }

        public DbSet<Ostatok> Ostatki { get; set; }
    }

}
