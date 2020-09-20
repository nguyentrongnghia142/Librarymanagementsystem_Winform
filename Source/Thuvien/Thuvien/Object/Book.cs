using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Thuvien.Object
{
    class Book
    {
        private String title;
        private int idBook;
        private String category;
        private String author;
        private String publisher;
        private int amount;
        public Book(int id,String t,String c,String au,String p,int a)
        {
            idBook = id;
            title = t;
            category = c;
            author = au;
            publisher = p;
            amount = a;

        }
        public String Titletext
        {
            get { return title; }
            set { title = value; }
        }
        public int IDBook
        {
            get { return idBook; }
            set { idBook = value; }
        }
        public String Categorytext
        {
            get { return category; }
            set { category = value; }
        }
        public String Authortext
        {
            get { return author; }
            set { author = value; }
        }
        public int Amounttext
        {
            get { return amount; }
            set { amount = value; }
        }
        public String Publishertext
        {
            get { return publisher; }
            set { publisher = value; }
        }
    }
}
