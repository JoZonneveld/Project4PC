using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using DatabaseTest.Database;

namespace Database
{
    class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }


        public Person(int id, string name, string phone, string adress)
        {
            this.Id = id;
            this.Name = name;
            this.Phone = phone;
            this.Adress = adress;
        }

        public Person()
        {
            
        }

        public override string ToString()
        {
            return Name + " - " +  Phone + " - " + Adress;
        }
    }
}