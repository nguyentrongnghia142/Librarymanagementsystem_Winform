using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;  // thu vien du lieu server
using Thuvien.Server;
using Thuvien.Object;

namespace Thuvien
{
    internal partial class Login : Form
    {
        public static User userlogin;
        public Login()
        {
            InitializeComponent();
            //this.StartPosition = FormStartPosition.Manual; // thiet lap toa do mac dinh
            this.CenterToScreen();  // Form hien thi tai trung tam
            
        }
        
        //public String userName;
        

        private void button1_Click(object sender, EventArgs e)
        {
            userlogin = Check();
            if (userlogin != null)
            {
                  // an form dang nhap
                Form1 bk = new Form1();  // khoi tao Form1
                bk.Show();
                this.Hide();
            }
        }
      
        
        public User Check()
        {
            // ket noi database
            SqlConnection connect = QueryData.Connect_Server();
            
            // mo Database va viet cau truy van  , co dau cach nen co dong ngoac [User Name]
            String query = "Select * from Account where UseName = '" + textBox1.Text.Trim() + "' and passwordID = '" + textBox2.Text.Trim() + "'";
            DataTable dt = QueryData.Queryresult(connect, query); // tra ra du lieu cua cau truy van
            User userlog = null;
            if (dt.Rows.Count == 1)  // neu chi co 1 mau du lieu khop
            {
                
                userlog  = new User(Int32.Parse(dt.Rows[0][0].ToString()), dt.Rows[0][1].ToString().Trim(), dt.Rows[0][2].ToString().Trim(), dt.Rows[0][3].ToString().Trim(), dt.Rows[0][4].ToString().Trim());
                
               
                return userlog;// lay hang [0][0] cua Rows la UserName
            }
            else
            {
                MessageBox.Show("Username or password incorrect");  // thong bao khi dang nhap ko thanh coong
                return userlog;
            }
        }


        private void textBox1_Click(object sender, EventArgs e)  // click vao xoa text user
        {
            textBox1.Clear();
        }

        private void textBox2_Click(object sender, EventArgs e)  // click vao xoa password
        {
            textBox2.Clear();
            textBox2.PasswordChar = '*';   // convert password sang *
        }

        private void label1_Click(object sender, EventArgs e)
        {
            FormRegister reg = new FormRegister();   // hien thi form dang ky
            reg.Show();
        }

        private void label2_Click(object sender, EventArgs e)  // close FOrm
        {
            this.Close();
            Environment.Exit(1);
        }

        private void Login_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }
    }
}
