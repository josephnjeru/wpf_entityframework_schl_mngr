using System.Collections.Generic;

namespace Datalayer
{
    public class Parent
    {
        public Parent() { }
        public int parentId { get; set; }
        public string Name { get; set; }
        public string phone_No { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}