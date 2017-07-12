using Datalayer;
using System;

namespace School_Manager
{
    public class DbOperations
    {
        public void registerStud(int id, string name, string indexno, int k_marks, DateTime dob, string gender)
        {
            using (var ctx=new DataContext()){
                Student stud = new Student()
                {
                    studentId=id,
                    studentName=name,
                    kcpe_index_No=indexno,
                    kcpe_marks=k_marks,
                    dateofbirth=dob,
                    gender=gender,
                    joiningdate=DateTime.Now,
                    disability=""
                };
                ctx.Students.Add(stud);
                ctx.SaveChanges();
            }
        }
    }
}
