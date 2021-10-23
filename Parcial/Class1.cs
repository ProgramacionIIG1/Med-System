using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial
{
    class Class1
    {
        public int genId9()
        {
            Random r = new Random();
            var Id = r.Next(10, 100000);

            return Id;
        }
}
}

