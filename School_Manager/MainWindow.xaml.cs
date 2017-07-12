using System.Windows;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using Datalayer;

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
          }

        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
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
            tabControlManage.SelectedIndex = 1;
            tabControlClasses.SelectedIndex = 0;
        }

        private void button_saverec_Click(object sender, RoutedEventArgs e)
        {
            string g=null;
            string d = null;
            if (radioButtonMale.IsChecked==true)
            {
                g = "male";
            }else if (radioButtonF.IsChecked == true)
            {
                g = "female";
            }

            //get the value of disability

            //int id, string name, int indexno, int k_marks, DateTime dob, string gender, string disability, string activities, string imagepath
            Dbo.registerStud(Convert.ToInt32(txt_admno.Text), txt_name.Text, txt_kcpeindexno.Text, Convert.ToInt32(txt_kcpemarks.Text), dateTimePicjerDOB.SelectedDate.Value, g);
        }
    }



    
}
