using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Thuvien.Server;

namespace Thuvien
{
    public partial class FormRegister : Form
    {
        
        public FormRegister()
        {
            InitializeComponent();
            this.CenterToScreen();
        }


        private void textBox3_Click(object sender, EventArgs e)  // xoa hien thi
        {
            textBox3.Clear();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox2.PasswordChar = '*';
        }

        private void button2_Click(object sender, EventArgs e)  // Show form login
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)  // close
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)  // them du lieu dang ky vao Database
        {
            label2.Text = null;
            label3.Text = null;
            label4.Text = null;
            if (textBox1.Text == "Username" || textBox1.Text == "")
            {
                label2.Text = "Please, enter username!";
            }
            if (textBox2.Text == "Password" || textBox2.Text == "")
            {
                label3.Text = "Please, enter pasword!";
            }
            if (textBox3.Text == "Email" || textBox3.Text == "")
            {
                label4.Text = "Please, enter email!";
            }
            else if(!isEmail())
            {
                label4.Text = "Email is invalid";
            }
            if (label2.Text == "" && label3.Text == "" && label4.Text == "" )
            {
                SqlConnection connect = QueryData.Connect_Server();
                String permiss = "User";
                String query = "INSERT INTO Account (UseName,PasswordID,Email,Permission) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "' ,'" + permiss + "')";
                bool kq = QueryData.ExecuteNonQueryUser(connect, query);  // luu tai khoan nguoi dung
                if (kq)
                {
                    MessageBox.Show("Resgister successfully !!!!");
                    label2.Text = null;
                    label3.Text = null;
                    label4.Text = null;
                }
            }
        }
        public bool isEmail()
        {
            if (textBox3.Text.LastIndexOf("@")== -1)
            {
                return false;
            }
            string[] arr = textBox3.Text.Split('@');
            if (arr[1] != "gmail.com" && arr[1] != "yahoo.com")
            {
                return false;
            }
            return true;
        }
     
    }
}
