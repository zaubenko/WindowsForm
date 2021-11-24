using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class removestudent : Form
    {
        public delegate void Send();
        public static event Send SendRemoveS;

        public removestudent()
        {
            InitializeComponent();
            InitialCombobox();

        }
        public void InitialCombobox()
        {
            for (int index = 0; index < TeacherList.teacherlist.Count(); index++)
            {
                List<Student> students = TeacherList.teacherlist[index].studentlist;
                for (int jindex = 0; jindex < students.Count(); jindex++)
                {
                    comboBox1.Items.Add(students[jindex].Surname + " " +  students[jindex].Name);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string number = comboBox1.SelectedItem.ToString();
            for (int index = 0; index < TeacherList.teacherlist.Count(); index++)
            {
                List<Student> students= TeacherList.teacherlist[index].studentlist;
                for (int jindex = 0; jindex < students.Count(); jindex++)
                {
                    if (number == students[jindex].Surname + " " + students[jindex].Name)
                    {
                        TeacherList.teacherlist[index].RemoveStudent(jindex);
                        MessageBox.Show($"Student is {number} removed");
                        this.Close();
                        SendRemoveS?.Invoke();
                    }
                }
            }
        }
        public void removestudent_Load(object sender, EventArgs e)
        {

        }
    }
}
