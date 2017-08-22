using System.Collections.Generic;
using System;


namespace Datalayer
{
    public class Stream
    { 
        public Stream() { }

        public int StreamId { get; set; }
        public string form { get; set; }
        public string year { get; set; }
        public int capacity { get; set; }
        public string stream { get; set; }
        public string teacher { get; set; }
        public string cp { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}