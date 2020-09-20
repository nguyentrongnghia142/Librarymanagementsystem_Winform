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
    public partial class Bookitem : Form
    {
        public Bookitem()
        {
            InitializeComponent();
        }
        private String iddelU;
        private String iddelB;
        SqlConnection connect = QueryData.Connect_Server();
        private void Bookitem_Load(object sender, EventArgs e)
        {
            QueryData.procDuedate(connect); 
            if (Login.userlogin.Permissiontext == "User")
            {
                this.Viewuser();
            }
            else this.View();
        }

        private void Return_Click(object sender, EventArgs e)
        {
            
            String query1 = "DELETE FROM Bookitem where IDBook = '" + iddelB + "' and IDUser = '" + iddelU + "'";
            DataTable db = QueryData.Queryresult(connect, query1);   //db = null
            if(iddelB != null) QueryData.procborrowed(connect, int.Parse(iddelB), -1);
            if (Login.userlogin.Permissiontext == "User")
            {
                this.Viewuser();
            }
            else this.View();
       
        }

        public void View()  // hien thi all
        {
            String query2 = "SELECT *FROM Bookitem";
            DataTable dt = QueryData.Queryresult(connect, query2);
            dataGridView1.DataSource = dt;
        }
        public void Viewuser()  // sach muon cuatung user
        {
            String query2 = "SELECT *FROM Bookitem where IDUser = '"+Login.userlogin.ID+"'";
            DataTable dt = QueryData.Queryresult(connect, query2);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1)
            {

            }else if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)   // kiem tra cell khac null
            {
                try
                {
                    dataGridView1.CurrentCell.Selected = true;  // chon hang hien tai
                    iddelB = dataGridView1.Rows[e.RowIndex].Cells["IDBook"].FormattedValue.ToString().Trim();
                    iddelU = dataGridView1.Rows[e.RowIndex].Cells["IDUser"].FormattedValue.ToString().Trim();
                }
                catch (Exception)
                {
                    // do something
                }
            }
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Login.userlogin.Permissiontext == "admin")
            {
               String query2 = "SELECT IDBook ,Title, Count(IDBook) as Amount FROM Bookitem Group by IDBook , Title";
                DataTable dt = QueryData.Queryresult(connect, query2);
                dataGridView1.DataSource = dt;
            }
            
        }
    }
}
