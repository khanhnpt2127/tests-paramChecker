using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paramChecker_OOP
{
    public class CountParam : Param
    {
        public override bool Validate()
        {
            var success = int.TryParse(Value, out var countNum);
            if (!success)
                return false;

            return countNum >= 10 && countNum <= 100;
        }
    }
}
