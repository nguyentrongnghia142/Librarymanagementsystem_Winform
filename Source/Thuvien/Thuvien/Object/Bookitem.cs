using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Thuvien.Object
{
    class Bookitem
    {
        private int idBook;
        private int idUser;
        private String title;
        private DateTime borrowed;
        private DateTime duedate;
        private String status;
        public int IDBook
        {
            get { return idBook; }
            set { idBook = value; }
        }
        public int IDUser
        {
            get { return idUser; }
            set { idUser = value; }
        }
        public String Titletext
        {
            get { return title; }
            set { title = value; }
        }
        public DateTime Borrowtime
        {
            get { return borrowed; }
            set { borrowed = value; }
        }
        public DateTime DueTime
        {
            get { return duedate; }
            set { duedate = value; }
        }
        public String Statusbool
        {
            get { return status; }
            set { status = value; }
        }
    }
}
