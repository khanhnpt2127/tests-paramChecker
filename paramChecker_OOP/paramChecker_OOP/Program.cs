using System;
using System.Collections.Generic;
using System.Linq;

namespace paramChecker_OOP
{
    class Program
    {

        private static int FirstChecker(string[] args)
        {
            if (args.Length == 0) return -1;

            if (args.Length > 5) return -1;

            // help only
            if (args.Length == 1)
            {
                if (string.Equals(args[0].ToLower(), "--help"))
                    return 1;
                return -1;
            }

            return 0;
        }

        private static int Validate(string[] args)
        {
            // 1- first check
            var firstCheckResult = FirstChecker(args);

            if (firstCheckResult == -1) return -1;

            // 2- add args to List<param>
            var paramList = new List<Param>();

            for (var i = 0; i < args.Length; i+=2)
            {
                if (string.Equals(args[i].ToLower(), "--name"))
                    paramList.Add(new NameParam() {Name = args[i], Value = args[i + 1]});
                else if (string.Equals(args[i].ToLower(), "--count"))
                    paramList.Add(new CountParam() {Name = args[i], Value = args[i + 1]});
                else if (string.Equals(args[i].ToLower(), "--help"))
                {
                    paramList.Add(new HelpParam() {Name = args[i]});
                    i--;
                }
                else
                    return -1;

            }

            // 3 - validate
            var result = true;
            foreach (var param in paramList) 
                result = result && param.Validate();

            if (result)
            {
                if (paramList.Any(x => string.Equals(x.Name, "--help")))
                    return 1;
                return 0;
            }

            return -1;
        }


        static void Main(string[] args)
        {
            var argSl = new string[3] { "--help", "--count", "10"};


            var res = Validate(argSl);
            Console.WriteLine(res);
        }
    }
}
