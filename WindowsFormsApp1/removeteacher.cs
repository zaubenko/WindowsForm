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
    public partial class removeteacher : Form
    {
        public delegate void Send();

        public static event Send SendRemoveT;

        public removeteacher()
        {
            InitializeComponent();
            InitialCombobox();
        }
        private void InitialCombobox()
        {
            comboBox1.Items.Clear();
            for (int i=0; i<TeacherList.teacherlist.Count;i++)
            {
                comboBox1.Items.Add(TeacherList.teacherlist[i].Surname + " " + TeacherList.teacherlist[i].Name);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string number = comboBox1.SelectedItem.ToString();
            for (int index= 0; index < TeacherList.teacherlist.Count(); index++)
            {
                if (number == TeacherList.teacherlist[index].Surname + " " + TeacherList.teacherlist[index].Name)
                {
                    TeacherList.teacherlist.RemoveAt(index);
                    MessageBox.Show($"Teacher is {number} removed");
                    this.Close();
                    SendRemoveT?.Invoke();
                }
            }
        }
        public void removeteacher_Load(object sender, EventArgs e)
        {

        }
    }
}
