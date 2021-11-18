using System;
using System.Collections.Generic;
using System.Linq;

namespace paramsChecker
{
    class Program
    {


        private static bool ValidateCount(string countStr)
        {
            var success = int.TryParse(countStr, out var countNum);
            if (!success)
                return false;

            return countNum >= 10 && countNum <= 100;
        }

        private static bool ValidateName(string nameStr)
        {
            var nameLength = nameStr.Length;
            return nameLength >= 3 && nameLength <= 10;
        }




        public static int Validate(string[] args)
        {

            // empty argument
            if (args.Length == 0) return -1;

            if (args.Length > 5) return -1;

            // help only
            if (args.Length == 1)
            {
                if (string.Equals(args[0].ToLower(), "--help"))
                    return 1;
                return -1;
            }


            var argumentDict = new Dictionary<string, string>();
            var helpExisted = false;

            var countElement = Math.Floor((float) args.Length / 2);

            if (args.Length % 2 == 0)
                countElement -= 1;

            try
            {

                // 2 - Add to Dict
                for (var i = 0; i <= countElement; i++)
                {
                    if (!string.Equals(args[2 * i].ToLower(), "--help"))
                        if(helpExisted)
                            argumentDict.Add(args[2 * i - 1].ToLower(), args[2 * i]);
                        else
                            argumentDict.Add(args[2 * i].ToLower(), args[2 * i + 1]);

                    else
                        helpExisted = true;
                }


                var validateNameResult = false;
                if (argumentDict.ContainsKey("--name"))
                    validateNameResult = ValidateName(argumentDict["--name"]);

                var validateCountResult = false;
                if (argumentDict.ContainsKey("--count"))
                    validateCountResult = ValidateCount(argumentDict["--count"]);


                // 3 - judgment
                if (helpExisted)
                {
                    if (argumentDict.Count == 0)
                        return 1;

                    if (argumentDict.Count == 1)
                    {
                        if (argumentDict.ContainsKey("--count"))
                            if (validateCountResult)
                                return 1;

                        if (argumentDict.ContainsKey("--name"))
                            if (validateNameResult)
                                return 1;
                        return -1;

                    }

                    if (validateCountResult && validateNameResult)
                        return 1;
                    return -1;



                }

                if (argumentDict.Count == 1)
                {
                    if (argumentDict.ContainsKey("--count"))
                        if (validateCountResult)
                            return 0;

                    if (argumentDict.ContainsKey("--name"))
                        if (validateNameResult)
                            return 0;
                }

                if (validateCountResult && validateNameResult)
                    return 0;
                return -1;


            }
            catch (Exception)
            {
                return -1;
            }

        }


        static void Main(string[] args)
        {

            var argSl = new string[4] { "--names","aaa" , "--count" , "10"};


            var res = Validate(argSl);
            Console.WriteLine(res);
        }
    }
}
