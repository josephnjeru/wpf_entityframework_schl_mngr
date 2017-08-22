using Datalayer;
using System;

namespace School_Manager
{
    public class DbOperations
    {
        public void registerStud(int admNo, string name, string indexno, string k_marks, DateTime dob, string gender)
        {
            try
            {
                using (var ctx = new DataContext())
                {
                    Student stud = new Student()
                    {
                        adm_no = admNo,
                        studentName = name,
                        kcpe_index_No = indexno,
                        kcpe_marks = k_marks,
                        dateofbirth = dob,
                        gender = gender,
                        joiningdate = DateTime.Now,
                        disability = ""
                    };
                    ctx.Students.Add(stud);
                    ctx.SaveChanges();
                }
            }catch(Exception e)
            {
                return;
            }
        }

        public bool addClass(string form, string year, string teacher, int capacity)
        {
            try
            {
                using (var ctx = new DataContext())
                {
                    Stream stream = new Stream()
                    {
                        form = form,
                        year = year,
                        teacher = teacher,
                        capacity = capacity,
                        stream = form + "_" + year
                    };
                    ctx.Streams.Add(stream);
                    ctx.SaveChanges();
                    return true;
                }
            }catch(Exception e)
            {
                return false;
            }
        }
        public void register_teacher(int _id, string fullnames, string teachername, string phone_no, string email, string gender, string imgpath, string roles, string employer)
        {
            using(var ctx= new DataContext())
            {
                Teacher _teacher = new Teacher()
                {
                    national_Id = _id,
                    fullName = fullnames,
                    teacherName = teachername,
                    phone_No = phone_no,
                    email = email,
                    gender = gender,
                    imagepath = imgpath,
                    role = roles,
                    employer = employer
                };
                ctx.Teachers.Add(_teacher);
                ctx.SaveChanges();
            }
        }
    }
}
