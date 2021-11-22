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
    public partial class addteacher : Form
    {
        public delegate void Send();
        public static event Send SendT;

        public addteacher()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string surname = textBox2.Text;
            int age = int.Parse(textBox3.Text);
            string city = textBox4.Text;
            string street = textBox5.Text;
            int nHouse = int.Parse(textBox6.Text);
            int maxcount = int.Parse(textBox7.Text);
            Adress addres = new Adress(city, street, nHouse);
            Teacher teacher = new Teacher(name, surname, age, addres ,maxcount);
            TeacherList.teacherlist.Add(teacher);
            MessageBox.Show("Teacher is added");
            this.Close();
            SendT?.Invoke();
        }
        public void addteacher_Load(object sender, EventArgs e)
        {

        }
    }
}
