using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormalSpecification
{
    internal class HandleGenerate
    {
        public static string _result { get; private set; }
        public static string[] _inputLines { get; private set; }
        public string[] _inputLine1 { get; private set; }
        public string[] _inputLine2 { get; private set; }
        public string[] _inputLine3 { get; private set; }
        public static string _input { get; private set; }
        private static MyFunction _function { get; set; }
        private static MyProgram _program { get; set; }

        public HandleGenerate()
        {
            
        }

        public HandleGenerate(string input)
        {
            _input = input;
        }

        public void SetInput(string input)
        {
            _input = input;
        }

        public string Generate()
        {
            // Split into 3 lines
            SplitInput(_input);

            // Check if input valid
            bool isValid = IsValid();

            if (isValid)
            {
                _result = GenerateCode();
            }
            else
            {
                // Show noti that input is not valid
            }

            return _result;
        }

        private bool IsValid()
        {
            if (_inputLine1.Count() > 1 && _inputLine3.Count() > 0)
            {
                return true;
            }

            return false;
        }

        private void SplitInput(string input)
        {
            _inputLines = _input.Split(new[] { "\n" }, StringSplitOptions.None);

            _inputLine1 = _inputLines[0].Split(new[] { "(" , ")" }, StringSplitOptions.None); // bat loi
            _inputLine2 = _inputLines[1].Split(new[] { "pre" }, StringSplitOptions.RemoveEmptyEntries);
            _inputLine3 = _inputLines[2].Split(new[] { "post" }, StringSplitOptions.RemoveEmptyEntries);

            return;
        }

        private string GenerateCode()
        {
            // Create new Function with name, params, return type
            _function = new MyFunction()
            {
                Name = _inputLine1[0],
                ReturnType = GetTypeString(_inputLine1[2].Split(new[] { ":" }, StringSplitOptions.RemoveEmptyEntries)[1]),
                ReturnParam = _inputLine1[2].Split(new[] { ":" }, StringSplitOptions.RemoveEmptyEntries)[0],
            };

            // Generate params + Handle line 1
            var pars = _inputLine1[1].Split(new[] { "," }, StringSplitOptions.None);

            _function.Parameters = new MyParams[pars.Count()];

            for (int i = 0; i < pars.Count(); i++)
            {
                _function.Parameters[i] = new MyParams()
                {
                    Name = pars[i].Split(new[] { ":" }, StringSplitOptions.None)[0],
                    Type = GetTypeString((pars[i].Split(new[] { ":" }, StringSplitOptions.None)[1])),
                };
            }

            // Handle line 2
            if (_inputLine2[0].Length > 0 && _inputLine2[0].ElementAt(0) == '(' && _inputLine2[0].ElementAt(_inputLine2[0].Length - 1) == ')')
            {
                _inputLine2[0] = _inputLine2[0].Remove(0, 1);
                _inputLine2[0] = _inputLine2[0].Remove(_inputLine2[0].Length - 1, 1);
            }

            GenerateProgram();

            return _result;
        }

        private void GenerateProgram()
        {
            _program = new MyProgram()
            {
                Library = "System",
                NameSpace = "FormalSpecification",
                ClassName = "Program",
                MyParams = _function.Parameters,
            };

            _program.Constructor = new MyFunction()
            {
                Name = _program.ClassName,
                ReturnType = "void",
            };

            _program.InputFunc = new MyFunction()
            {
                Name = "Input",
                ReturnType = "void",
            };

            _program.OutputFunc = new MyFunction()
            {
                Name = "Output",
                ReturnType = "void",

            };

            _program.MainFunc = new MyFunction()
            {
                Name = "Main",
                ReturnType = "void",
            };

            _program.PreFunc = new MyFunction()
            {
                Name = "CheckPreCondition",
                ReturnType = "int",
                Pre = _inputLine2[0],
            };

            _program.PostFunc = new MyFunction()
            {
                Name = "Handle" + _function.Name,
                ReturnType = _function.ReturnType,
                ReturnParam = _function.ReturnParam,
                Post = _inputLine3[0],
            };

            _result = _program.Generate();
        }

        public string GetTypeString(string a)
        {
            string result = "";

            switch (a)
            {
                case "R":
                    result = "float";
                    break;
                case "Z":
                    result = "int";
                    break;
                case "char*":
                    result = "string";
                    break;
                case "B":
                    result = "bool";
                    break;
                default:
                    result = "string";
                    break;
            }

            return result;
        }
    }
}
