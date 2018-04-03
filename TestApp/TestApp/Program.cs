using System;
using System.Collections.Generic;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Label> Labels = new List<Label>();

            Labels.Add(new Label("Maandag", 1, 2));
            Labels.Add(new Label("Di", 1, 2));
            Labels.Add(new Label("Woe", 1, 2));

            foreach (var Label in Labels)
            {
                Console.WriteLine(Label.Dag);
            }

        }
    }
}
