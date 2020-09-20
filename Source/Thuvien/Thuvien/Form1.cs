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
using Thuvien.Object;

namespace Thuvien
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.CenterToScreen();
        }
        SqlConnection connect = QueryData.Connect_Server();
        

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(textBox4.Text) > 0)
                {
                    String query = "INSERT INTO Book (IDBook,Title,Author,Category,Publisher,Amount) VALUES('" + textBox6.Text.Trim() + "',N'" + textBox1.Text.Trim() + "',N'" + textBox2.Text.Trim() + "',N'" + textBox3.Text.Trim() + "',N'" + textBox5.Text.Trim() + "','" + textBox4.Text.Trim() + "')";
                    bool kq = QueryData.ExecuteNonQueryBook(connect, query); // thuc thi luu du lieu
                    if (kq)
                    {
                        MessageBox.Show("Inserted successfully !!!");
                        textBox1.Text = null;
                        textBox2.Text = null;
                        textBox3.Text = null;
                        textBox4.Text = null;
                        textBox5.Text = null;
                        textBox6.Text = null;
                    }
                    this.View();
                }
                else
                {
                    MessageBox.Show("Amount is invalid");
                }
            }
            catch
            {
                MessageBox.Show("Amount is invalid");
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            String query = "SELECT *FROM Book";
            DataTable dt = QueryData.Queryresult(connect, query);

            label6.Text = "Hi: " + Login.userlogin.Usernametext;
            this.View();
            if (Login.userlogin.Permissiontext == "User")  // an cac thao tac user ko the dung
            {
                Bt_Save.Dispose();
                Bt_Update.Dispose();
                Bt_Delete.Dispose();
            }
            else button2.Dispose();
            comboBox2.Items.Add("Name");
            comboBox3.Items.Add("Category");
            comboBox4.Items.Add("Author");
            foreach (DataRow dr in dt.Rows)  //  loc lay thuoc tinh cho combobox tu database
            {
                String textb2 = dr["Title"].ToString().Trim();
                String textb3 = dr["Category"].ToString().Trim();
                String textb4 = dr["Author"].ToString().Trim();
                int i = comboBox2.FindString(textb2);  // kiem tra trung lap 
                if (comboBox2.Text != "" && i < 0)
                {
                    comboBox2.Items.Add(textb2);
                }
                i= comboBox3.FindString(textb3);
                if (comboBox2.Text != "" && i < 0)
                {
                    comboBox3.Items.Add(textb3);
                }
                i = comboBox4.FindString(textb4);
                if (comboBox2.Text != "" && i < 0)
                {
                    comboBox4.Items.Add(textb4);
                }

            }

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            comboBox1.Text = null;
        }
      

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)  // hien thi loc neu combobox thay doi lua chon
        {
            String query= null;
            if (comboBox2.Text != "Name")
            {
                if (comboBox4.Text == "Author" && comboBox3.Text == "Category")
                {
                    query = "SELECT *FROM Book where Title = N'" + comboBox2.Text + "'";
                }
                else if (comboBox4.Text != "Author" && comboBox3.Text != "Category")
                {
                    query = "SELECT *FROM Book where Title = N'" + comboBox2.Text + "'and Author = N'" + comboBox4.Text + "'and Category = N'" + comboBox3.Text + "'";
                }
                else if (comboBox4.Text != "Author")
                {
                    query = "SELECT *FROM Book where Title = N'" + comboBox2.Text + "'and Author = N'" + comboBox4.Text + "'";
                }
                else query = "SELECT *FROM Book where Title = N'" + comboBox2.Text + "'and Category = N'" + comboBox3.Text + "'";
                

            }
            else
            {
                if (comboBox4.Text == "Author" && comboBox3.Text == "Category")
                {
                    query = "SELECT *FROM Book";
                }
                else if (comboBox4.Text != "Author" && comboBox3.Text != "Category")
                {
                    query = "SELECT *FROM Book where Author = N'" + comboBox4.Text + "'and Category = N'" + comboBox3.Text + "'";
                }
                else if (comboBox4.Text != "Author")
                {
                    query = "SELECT *FROM Book where Author = N'" + comboBox4.Text + "'";
                }
                else query = "SELECT *FROM Book where Category = N'" + comboBox3.Text + "'";
            }
            DataTable dt = QueryData.Queryresult(connect, query);
            dataGridView1.DataSource = dt;

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            String query = null;
            if (comboBox4.Text != "Author")
            {
                if (comboBox2.Text == "Name" && comboBox3.Text == "Category")
                {
                    query = "SELECT *FROM Book where Author = N'" + comboBox4.Text + "'";
                }
                else if (comboBox2.Text != "Name" && comboBox3.Text != "Category")
                {
                    query = "SELECT *FROM Book where Title = N'" + comboBox2.Text + "'and Author = N'" + comboBox4.Text + "'and Category = N'" + comboBox3.Text + "'";
                }
                else if (comboBox2.Text != "Name")
                {
                    query = "SELECT *FROM Book where Title = N'" + comboBox2.Text + "'and Author = N'" + comboBox4.Text + "'";
                }
                else query = "SELECT *FROM Book where Author = N'" + comboBox4.Text + "'and Category = N'" + comboBox3.Text + "'";
          
            }
            else
            {
                if (comboBox2.Text == "Name" && comboBox3.Text == "Category")
                {
                    query = "SELECT *FROM Book ";
                }
                else if (comboBox2.Text != "Name" && comboBox3.Text != "Category")
                {
                    query = "SELECT *FROM Book where Title = N'" + comboBox2.Text + "'and Category = N'" + comboBox3.Text + "'";
                }
                else if (comboBox2.Text != "Name")
                {
                    query = "SELECT *FROM Book where Title = N'" + comboBox2.Text + "'";
                }
                else query = "SELECT *FROM Book where Category = N'" + comboBox3.Text + "'";
            }
            DataTable dt = QueryData.Queryresult(connect, query);
            dataGridView1.DataSource = dt;

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            String query = null;
            if (comboBox3.Text != "Category")
            {
                if (comboBox2.Text == "Name" && comboBox4.Text == "Author")
                {
                    query = "SELECT *FROM Book where Category = N'" + comboBox3.Text + "'";
                }
                else if (comboBox2.Text != "Name" && comboBox4.Text != "Author")
                {
                    query = "SELECT *FROM Book where Title = N'" + comboBox2.Text + "'and Author = N'" + comboBox4.Text + "'and Category = N'" + comboBox3.Text + "'";
                }
                else if (comboBox2.Text != "Name")
                {
                    query = "SELECT *FROM Book where Title = N'" + comboBox2.Text + "'and Category = N'" + comboBox3.Text + "'";
                }
                else query = "SELECT *FROM Book where Author = N'" + comboBox4.Text + "'and Category = N'" + comboBox3.Text + "'";
                
            }
            else
            {
                if (comboBox2.Text == "Name" && comboBox4.Text == "Author")
                {
                    query = "SELECT *FROM Book ";
                }
                else if (comboBox2.Text != "Name" && comboBox4.Text != "Author")
                {
                    query = "SELECT *FROM Book where Title = N'" + comboBox2.Text + "'and Author = N'" + comboBox4.Text + "'";
                }
                else if (comboBox2.Text != "Name")
                {
                    query = "SELECT *FROM Book where Title = N'" + comboBox2.Text + "'";
                }
                else query = "SELECT *FROM Book where Author = N'" + comboBox4.Text + "'";
            }
            DataTable dt = QueryData.Queryresult(connect, query);
            dataGridView1.DataSource = dt;

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1)
            {

            }else if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)  // kiem tra cell khac null
            {
                try
                {
                    dataGridView1.CurrentCell.Selected = true;  // chon hang hien tai
                    textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells["IDBook"].FormattedValue.ToString().Trim();
                    textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["Title"].FormattedValue.ToString().Trim();   // dua du lieu tuong ung vao textbox
                    textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["Author"].FormattedValue.ToString().Trim();
                    textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["Category"].FormattedValue.ToString().Trim();
                    textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells["Publisher"].FormattedValue.ToString().Trim();
                    textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["Amount"].FormattedValue.ToString().Trim();
                    //if (textBox6.Text == "1") checkBox1.Checked = true;  // danh dau sach da duoc muon
                    //else checkBox1.Checked = false;
                }
                catch(Exception)
                {
                    // do something
                }
            }
            
        }

        private void Bt_Delete_Click(object sender, EventArgs e)  // xoa du lieu row duoc chon
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure?", "Warning", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (textBox1.Text.ToString() != null)
                {
                    String query1 = "DELETE FROM Book where IDBook = '" + textBox6.Text + "'";
                    DataTable db = QueryData.Queryresult(connect, query1);   //db = null
                    View();
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
            
        }

        private void Bt_Update_Click(object sender, EventArgs e)  // update khi chinh sua database
        {
            DialogResult dialogResult = MessageBox.Show("Information can be change. Are you sure?", "Warning", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (textBox1.Text.ToString() != null)
                {
                    String query1 = "UPDATE Book set IDBook = '" + textBox6.Text + "' ,Title = N'" + textBox1.Text + "' , Author = N'" + textBox2.Text + "' , Category = N'" + textBox3.Text + "',Publisher = N'" + textBox5.Text + "',Amount = '" + textBox4.Text + "' where IDBook = '" + textBox6.Text + "'";

                    DataTable db = QueryData.Queryresult(connect, query1);   //db = null
                    View();
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
            
        }
        private void View()
        {
            String query2 = "SELECT *FROM Book";
            DataTable dt = QueryData.Queryresult(connect, query2);
            dataGridView1.DataSource = dt;
        }

        private void Bt_Orders_Click(object sender, EventArgs e)
        {
            Bookitem ord = new Bookitem();
            ord.Show();
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)  // tich se dat cuon sach duoc chon
        {

            int aid = int.Parse(textBox6.Text);
            
            Book a = new Book(aid, textBox1.Text, textBox2.Text, textBox3.Text, textBox5.Text, int.Parse(textBox4.Text));
            if (checkBox1.Checked == true )
            {
                bool kq = QueryData.procborrowed(connect, aid, 1);
                if (kq)
                {
                    Login.userlogin.borrowBook(a);
                    this.View();
                }
                checkBox1.Checked = false;
            }


        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)// even enter
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }  

        private void SearchBook_Click(object sender, EventArgs e) // search
        {
            String query = "SELECT *FROM Book where  Title like N'" + comboBox1.Text.Trim() + "%' or Author like N'" + comboBox1.Text.Trim() + "%' or Category like N'" + comboBox1.Text.Trim() + "%' or Publisher like N'" + comboBox1.Text.Trim() + "%'  ";
            DataTable dt = QueryData.Queryresult(connect, query);
            dataGridView1.DataSource = dt;
            int i = comboBox1.FindString(comboBox1.Text);  // kiem tra trung lap 
            if (comboBox1.Text != "" && i < 0)
            {
                comboBox1.Items.Add(comboBox1.Text.Trim());
            }
            else if (comboBox1.Text == "") this.View();
        }  

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(1);
        }

        private void button2_Click_1(object sender, EventArgs e)  // refesh data
        {
            this.View();
        }

        private void label6_Click(object sender, EventArgs e)  // hien thi thong tin user
        {
            DataTable dt = new DataTable(); 
            dt.Columns.AddRange(new DataColumn[4] { new DataColumn("UserName",typeof(String)), new DataColumn("Password", typeof(String)),
            new DataColumn("Email",typeof(String)),new DataColumn("Permission",typeof(String))});
            dt.Rows.Add( Login.userlogin.Usernametext, Login.userlogin.Passwordtext, Login.userlogin.Emailtext, Login.userlogin.Permissiontext);
            dataGridView1.DataSource = dt;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.View();
        }
    }
}
