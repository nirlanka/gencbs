using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gencbs
{
    class Program
    {
        static void Main(string[] args)
        {
            Resources.Resource machine1 = new Resources.Machine();
            Resources.Resource machine2 = new Resources.Machine();
            Console.WriteLine( machine2.id);
            Console.Read();
        }
    }
}
