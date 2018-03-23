using System;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {

            using (DB db = new DB())
            {
                db.get();
            }

            Console.ReadKey();
        }
    }
}
