using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paramChecker_OOP
{
    public class NameParam : Param
    {
        public override bool Validate()
        {
            var nameLength = Value.Length;
            return nameLength >= 3 && nameLength <= 10;
        }
    }
}
