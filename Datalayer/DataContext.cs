using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datalayer
{
    public class DataContext : DbContext
    {
        public DataContext() : base("School")
        {
            if (!Database.Exists("School"))
                Database.SetInitializer(new DropCreateDatabaseAlways<DataContext>());
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Stream> Streams { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Staff> Staffs { get; set; }
    }
}
