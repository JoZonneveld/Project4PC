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


        public Person(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public Person()
        {
            
        }

        
    }
}