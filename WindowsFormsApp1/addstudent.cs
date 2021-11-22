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
    public partial class addstudent : Form
    {
        public delegate void Send();
        public static event Send SendS;
        public addstudent()
        {
            InitializeComponent();
            InitialCombobox();
        }

        public void InitialCombobox()
        {
            comboBox1.Items.Clear();
            for (int index = 0; index < TeacherList.teacherlist.Count; index++)
            {
                if (TeacherList.teacherlist[index].studentlist.Count < TeacherList.teacherlist[index].maxcount)
                    comboBox1.Items.Add(TeacherList.teacherlist[index].Surname + " " + TeacherList.teacherlist[index].Name);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string surname = textBox2.Text;
            int age = int.Parse(textBox3.Text);
            string city = textBox4.Text;
            string street = textBox5.Text;
            int nHouse = int.Parse(textBox6.Text);
            int scores = int.Parse(textBox7.Text);
            Adress addres = new Adress(city, street, nHouse);
            Student student = new Student(name, surname, age, addres, scores);
            if (comboBox1.SelectedItem.ToString() == comboBox1.SelectedItem.ToString())
            {
                string number = comboBox1.SelectedItem.ToString();
                for (int index = 0; index < TeacherList.teacherlist.Count; index++)
                {
                    string count = TeacherList.teacherlist[index].Surname + " " + TeacherList.teacherlist[index].Name;
                    if (number == count)
                    {
                        TeacherList.teacherlist[index].AddStudent(student);
                        MessageBox.Show("Student is added");
                        this.Close();
                    }
                }
                SendS?.Invoke();
            }
            else
            {
                MessageBox.Show("Number is not int, please retry");
                this.Close();
            }
        }
        private void addstudent_Load(object sender, EventArgs e)
        {

        }


    }
}
