using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Thuvien.Object;
using System.Windows.Forms;
using Thuvien.Server;
using System.Data.SqlClient;

namespace Thuvien.Object
{
    class User
    {
        public List<Bookitem> setBook = new List<Bookitem>();
        private int idUser;
        private String userName;
        private String passwordid;
        private String email;
        private String permission;

        public User(int id,String name,String pass,String mail,String per)
        {
            this.idUser = id;
            this.userName = name;
            this.passwordid = pass;
            this.email = mail;
            this.permission = per;
        }
        public void borrowBook(Book a)  // thoi gian muon trong 2 tuan
        {
            DateTime date = DateTime.Now;
           
            if (setBook.Count <= 2) // moi lan muon toi da 3 cuon sach
            {
                SqlConnection connect = QueryData.Connect_Server();

                String query = "INSERT INTO Bookitem (IDBook,IDUser,Title,Borrowed,Duedate,Bkstatus) VALUES('" + a.IDBook.ToString().Trim() + "','" + idUser.ToString().Trim() + "',N'" + a.Titletext.Trim() + "',CONVERT(datetime, '"+date.ToShortDateString().ToString()+ "', 103)  ,  CONVERT(datetime, '" +date.AddDays(14).ToShortDateString().ToString() + "',103),'" + "Being borrowed" + "')";
                bool kq = QueryData.ExecuteNonQueryBook(connect, query); // thuc thi luu du lieu
                if (kq)
                {
                    setBook.Add(new Bookitem { IDBook = a.IDBook, IDUser = idUser, Titletext = a.Titletext, Borrowtime = date, DueTime = date.AddDays(14), Statusbool = "Booked" });
                    MessageBox.Show("Borrowed successfully !!!!");
                }
            }
            else MessageBox.Show("Only borrow max three book");
        }
        public int ID
        {
            get { return idUser; }
            set { idUser = value; }
        }
        public String Usernametext
        {
            get { return userName; }
            set { userName = value; }
        }
        public String Passwordtext
        {
            get { return passwordid; }
            set { passwordid = value; }
        }
        public String Emailtext
        {
            get { return email; }
            set { email = value; }
        }
        public String Permissiontext
        {
            get { return permission; }
            set { permission = value; }
        }
    }
}
