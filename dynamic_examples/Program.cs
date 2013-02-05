using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dynamic_examples {
    
    class Program {
        static void Main(string[] args)
        {
            dynamic x = 10;
            x = x + 9.5;
            //19.520
            x += "20";

            x = Double.Parse(x) + 9;
            Console.WriteLine(x);
            Console.WriteLine(x.GetType());
        }
        
    }
}
