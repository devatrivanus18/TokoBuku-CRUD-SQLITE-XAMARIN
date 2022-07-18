using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TokoBuku.Model
{
    public class Buku
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public double Price { get; set; } 
        public string Publisher { get; set; }
        public double ISBN { get; set; }
        public DateTimeOffset Date { get; set; } = DateTimeOffset.Now;

    }
}
