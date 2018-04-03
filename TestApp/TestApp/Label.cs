using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    class Label
    {
        public string Dag; // enum
        public int Begintijd;
        public int Eindtijd;

        public Label(string dag, int begintijd, int eindtijd)
        {
            this.Dag = dag;
            this.Begintijd = begintijd;
            this.Eindtijd = eindtijd;
        }

    }
}
