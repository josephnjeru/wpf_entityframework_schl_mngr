using System.Collections.Generic;
using System;


namespace Datalayer
{
    public class Standard
    { 
        public Standard() { }

        public int standardId { get; set; }
        public string form { get; set; }
        public int year { get; set; }
        public Teacher teacher { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}