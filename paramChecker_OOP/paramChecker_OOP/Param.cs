using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paramChecker_OOP
{
    public abstract class Param
    {
        public string Name { get; set; }

        public string Value { get; set; }


        public abstract bool Validate();
    }
}
