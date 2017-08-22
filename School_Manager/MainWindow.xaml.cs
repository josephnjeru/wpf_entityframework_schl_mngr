using System.Windows;
using MahApps.Metro.Controls;
using System;
using System.Linq;
using Datalayer;
using System.Collections.Generic;

namespace School_Manager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        DbOperations Dbo = new DbOperations();
        
        public MainWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.WindowStyle = WindowStyle.SingleBorderWindow;

            load_Comboclass();
            fetch_classes();
            
          }
      

        private void btn_login_Click(object sender, RoutedEventArgs e) { 
            tabControl1.SelectedIndex = 1;
        }

        private void tileStudents_Click(object sender, RoutedEventArgs e)
        {
            tabControl2.SelectedIndex = 1;
            tabControlManage.SelectedIndex = 1;
            tabControlStudent.SelectedIndex = 0;
        }

        private void tileClass_Click(object sender, RoutedEventArgs e)
        {
            tabControl2.SelectedIndex = 1;
            tabControlManage.SelectedIndex = 0;
            tabControlClasses.SelectedIndex = 0;
        }
        private void tileExams_Click(object sender, RoutedEventArgs e)
        {
            tabControl2.SelectedIndex = 1;
            tabControlManage.SelectedIndex = 3;
            tabCtrlExams.SelectedIndex = 0;
        }
        private void tileStaff_Click(object sender, RoutedEventArgs e)
        {
            tabControl2.SelectedIndex = 1;
            tabControlManage.SelectedIndex = 2;
        }

        private void button_saverec_Click(object sender, RoutedEventArgs e)
        {
            string stud_name;
            string kcpe_indexNo;
            string k_marks;
            int admNo;
            if (txt_admno.Text.Length<=0||txt_name.Text.Length<=0||txt_kcpemarks.Text.Length<=0||txt_kcpeindexno.Text.Length<=0 || txt_admno.Text.Any(Char.IsLetter))
            {
                MessageBox.Show(this, "Oops! an error has occured. Check your input and try again", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }else
            {
                admNo = Convert.ToInt32(txt_admno.Text);
                stud_name = txt_name.Text;
                kcpe_indexNo = txt_kcpeindexno.Text;
                k_marks = txt_kcpemarks.Text;
            }

            //CHECK THE VALIDATION
            
            if (dateTimePicjerDOB.SelectedDate == null)
            {
                MessageBox.Show(this, "Select a valid date of birth");
                return;
            }
            
            
               DateTime dob = dateTimePicjerDOB.SelectedDate.Value;
            
            
            string g=null;
            string d = null;
            if (radioButtonMale.IsChecked == true)
            {
                g = "male";
            }
            else if (radioButtonF.IsChecked == true)
            {
                g = "female";
            }

            
            //save to db
            try
            {
                using (var ctx = new DataContext())
                {
                    //check if student already exists
                    bool studentExistAlready = ctx.Students.Any(c => c.adm_no == admNo);
                    if (studentExistAlready)
                    {
                        MessageBox.Show(this, "The admission number already exists in the syatem. Try using a differrent admission number", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    else {
                        Student stud = new Student()
                        {
                            adm_no = admNo,
                            studentName = stud_name,
                            kcpe_index_No = kcpe_indexNo,
                            kcpe_marks = k_marks,
                            dateofbirth = dob,
                            gender = g,
                            joiningdate = DateTime.Now,
                            disability = ""
                        };
                        ctx.Students.Add(stud);
                        ctx.SaveChanges();
                    } }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
                return;
            }
            MessageBox.Show(this, "Record saved to the system succesifully", "St. Benedict's SMS Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }




        private void homeBtn_Click(object sender, RoutedEventArgs e)
        {
            tabControl1.SelectedIndex = 1;
            tabControl2.SelectedIndex = 0;
        }

        private void Tile_Click(object sender, RoutedEventArgs e)
        {
            tabControlClasses.SelectedIndex = 1;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            tabControlClasses.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            //CHECK IF THE COMBO BOX OPTION ID VALID
            string _form="";
            if (comboBox_form.SelectedIndex == 0)
            {
                MessageBox.Show(this, "Select a valid option for Form field", "Warning", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                return;
            }
            else if (comboBox_form.SelectedIndex == 1)
            {
                _form = "Form 1";
            }
            else if (comboBox_form.SelectedIndex == 2)
            {
                _form = "Form 2";
            }
            else if (comboBox_form.SelectedIndex == 3)
            {
                _form = "Form 3";
            }
            else if (comboBox_form.SelectedIndex == 4)
            {
                _form = "Form 4";
            }
            //get the user input for new class
            string form = _form;
            string year = txt_year.Text;
            string teacher = txt_classteacher.Text;
            int capacity = Convert.ToInt32(txt_capacity.Text);

            //call add class method and pass the arguments use the return value to sjhow the user what just happened
            if (Dbo.addClass(form, year, teacher, capacity) == true)
            {
                MessageBox.Show(this, "Class saved successifully", "Success Info!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (Dbo.addClass(form, year, teacher, capacity) == false)
            {
                MessageBox.Show(this, "Something  went wrong, try again", "Error Information!", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }

        private void homeBtn1_Click(object sender, RoutedEventArgs e)
        {
            tabControl1.SelectedIndex = 1;
            tabControl2.SelectedIndex = 0;
        }

      
        private void regback_std_home_Click(object sender, RoutedEventArgs e)
        {
            tabControlStudent.SelectedIndex = 0;
        }

        private void Tile_Click_1(object sender, RoutedEventArgs e)
        {
            tabControlStudent.SelectedIndex = 1;
        }

        private void Tile_Click_2(object sender, RoutedEventArgs e)
        {
            tabControlStudent.SelectedIndex = 2;
            fetch_students();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            tabControlStudent.SelectedIndex = 0;
        }

        public void fetch_students()
        {
            using(var ctx=new DataContext())
            {
                //System.Windows.Forms.BindingSource bi = new System.Windows.Forms.BindingSource();
                //bi.DataSource = ctx.Students;
                //dataGrid_students.DataContext = bi;

                try
                {
                    List<Student> tableData = ctx.Students.ToList();
                    dataGrid_students.ItemsSource = tableData;
                    
                }catch(Exception e)
                {
                    MessageBox.Show(this, e.Message);
                }
            }
        }
        //select a list of classes
        public void load_Comboclass()
        {
            using(var context=new DataContext())
            {
                //get allsudents
                var streams = (from s in context.Streams select s).ToList<Stream>();
                foreach(var st in streams)
                {
                    string strm = st.stream;
                    comboBoxClass.Items.Add(strm);
                }
            }
        }

        public void clear()
        {
            txt_admno.Clear();
           // txt_admno.Text = null;
            txt_name.Text = null;
            comboBoxClass.SelectedIndex = -1;
            txt_kcpeindexno.Text = null;
            txt_kcpemarks.Text = null;

        }

        public void fetch_classes()
        {
            using (var context=new DataContext())
            {
                //get a list of all teachers and their details
                List<Stream> tchr = context.Streams.ToList();
                dataGrid_teachers.ItemsSource = tchr;
                
            }
        }

        private void Tile_Click_3(object sender, RoutedEventArgs e)
        {
            tabControlClasses.SelectedIndex = 2;
            
        }
        
        private void button_clear_Click(object sender, RoutedEventArgs e)
        {
            //clear fileds when clear btmn is pressed
            clear();
            
        }
    }

  

    
}
