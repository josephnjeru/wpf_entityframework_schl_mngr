using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Datalayer
{
    public class Student
    {
        public Student() { }

    //student properties
     
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]      
        public int adm_no { get; set; }
        public string studentName { get; set; }
        public string kcpe_index_No { get; set; }
        public string kcpe_marks { get; set; }
        public DateTime? dateofbirth { get; set; }
        public string gender { get; set; }
        public DateTime? joiningdate { get; set; }
        public string disability { get; set; }
        public string activities { get; set; }
        public string imagepath { get; set; }
        public Stream stream { get; set; }
        public Parent Parent { get; set; }
    }
}
