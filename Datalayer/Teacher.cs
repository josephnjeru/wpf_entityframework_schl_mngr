using System.ComponentModel.DataAnnotations;

namespace Datalayer
{
    public class Teacher
    {
        public Teacher(){ }
        
        [Key]
        public int national_Id { get; set; }
        public string fullName { get; set; }
        public string teacherName { get; set; }
        public string phone_No { get; set; }
        public string email { get; set; }
        public string gender { get; set; }
        public string imagepath { get; set; }
        public string role { get; set; }
        public string employer { get; set; }
    }
}