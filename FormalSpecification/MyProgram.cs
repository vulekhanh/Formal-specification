using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormalSpecification
{
    internal class MyProgram
    {
        public string Library { get; set; }

        public string NameSpace { get; set; }

        public string ClassName { get; set; }

        public MyParams[] MyParams { get; set; }

        public MyFunction Constructor { get; set; }

        public MyFunction InputFunc { get; set; }

        public MyFunction OutputFunc { get; set; }

        public MyFunction MainFunc { get; set; }

        public MyFunction PreFunc { get; set; }

        public MyFunction PostFunc { get; set; }

        public LoopFunc LoopFunc { get; set; }

        public string Generate()
        {
            string hihi = "";

            List<string> result = new List<string>();

            // Generate generally code
            result.Add("using " + Library + ";");
            result.Add("namespace " + NameSpace);
            result.Add("{");
            result.Add(string.Format("\tpublic class {0}", ClassName));
            result.Add("\t{");

            // Generate params
            result.Add(String.Format("\t\t//property"));
            for (int i = 0; i < MyParams.Count(); i++)
            {
                result.Add(String.Format("\t\tpublic {0} {1};", MyParams[i].Type, MyParams[i].Name));
            }
            result.Add("\n");

            result.Add(String.Format("\t\t//method"));
            // Generate basic function: input, ouput, constructor
            result.Add(String.Format("\t\tpublic {0}() {{", Constructor.Name));
            result.Add("\t\t}\n");

            string temp = "";

            for (int i = 0; i < MyParams.Count(); i++)
            {
                temp += MyParams[i].Type + " " + MyParams[i].Name;
                temp += ", ";
            }

            // Constructor
            Constructor.Parameters = MyParams;
            result.Add(Constructor.GenerateConstructorFunc());

            // Input Func
            InputFunc.Parameters = MyParams;
            var item = InputFunc.Parameters.Where(o => o.Type == "float[]");
            if (item != null)
            {
                InputFunc.Content = GenerateInputLoopFunc();
            }
            result.Add(InputFunc.GenerateInputFunc());

            // Output Func
            OutputFunc.Parameters = new MyParams[1];
            OutputFunc.Parameters[0] = new MyParams() { Name = PostFunc.ReturnParam, Type = PostFunc.ReturnType };
            result.Add(OutputFunc.GenerateOutputFunc());

            // Generate pre function
            PreFunc.Content = GeneratePreFunc();
            result.Add(PreFunc.GenerateFunc());

            // Generate post function
            PostFunc.Content = GeneratePostFunc();
            result.Add(PostFunc.GenerateFunc());

            // Generate main function
            MainFunc.Parameters = new MyParams[1];
            MainFunc.ReturnType = "static void";
            MainFunc.Parameters[0] = new MyParams()
            {
                Name = "args",
                Type = "string[]",
            };
            MainFunc.Content = GenerateMainFunc();
            result.Add(MainFunc.GenerateFunc());

            result.Add("\t}");
            result.Add("}");

            for (int i = 0; i < result.Count(); i++)
            {
                hihi += result[i].ToString();
                hihi += "\n";
            }

            return hihi;
        }

        private string GenerateInputLoopFunc()
        {
            string hihi = "";

            string post = PostFunc.Post.Trim();

            List<string> result = new List<string>();

            // Split line 3 into param and bieuthuc
            string[] temp = post.Split(new[] { "=" }, 2, StringSplitOptions.RemoveEmptyEntries);

            // Remove brackets
            if (temp[1].Length > 0 && temp[1].ElementAt(0) == '(' && temp[1].ElementAt(temp[1].Length - 1) == ')')
            {
                temp[1] = temp[1].Remove(0, 1);
                temp[1] = temp[1].Remove(temp[1].Length - 1, 1);
            }

            // Split bieuthuc into first loop line and content of it
            //string[] LoopLines = temp[1].Split(new[] { "...", "." }, StringSplitOptions.RemoveEmptyEntries);

            int indexLastDot = temp[1].LastIndexOf('.');

            string firstLoopLine = temp[1].Substring(0, indexLastDot).Trim();
            string contentLoop = temp[1].Substring(indexLastDot+1, temp[1].Length - firstLoopLine.Length -1).Trim();

            // Split fist loop line
            string[] fistLoopCompos = firstLoopLine.Split(new[] { "TH" }, StringSplitOptions.RemoveEmptyEntries);

            string conditionParam = fistLoopCompos[0].Substring(0, 2);
            string loopParam = fistLoopCompos[0].Substring(2, fistLoopCompos[0].Length - 2);

            // get start and finish val
            string[] startEnds = fistLoopCompos[1].Split(new[] { "..", "{", "}" }, StringSplitOptions.RemoveEmptyEntries);
             
            LoopFunc = new LoopFunc()
            {
                Param = loopParam,
                startValue = startEnds[0],
                finishValue = startEnds[1],
            };

            result.Add(String.Format("\t\t\tfor ( int {0}=0; {0}<n; {0}++)", LoopFunc.Param));
            result.Add("\t\t\t{");
            result.Add(String.Format("\t\t\t\tConsole.WriteLine(\"Nhap phan tu thu \" + {0} + \": \");", LoopFunc.Param));
            result.Add(String.Format("\t\t\t\tthis.{0}[{2}] = {1}.Parse(Console.ReadLine());", MyParams[0].Name, MyParams[0].Type.Substring(0, MyParams[0].Type.Length - 2), LoopFunc.Param));
            result.Add("\t\t\t}");

            for (int i = 0; i < result.Count(); i++)
            {
                hihi += result[i].ToString();
                hihi += "\n";
            }

            return hihi;
        }

        private string GenerateMainFunc()
        {
            string hihi = "";

            List<string> result = new List<string>();

            string temp = "";

            for (int i = 0; i < MyParams.Count(); i++)
            {
                temp += "ref mp." + MyParams[i].Name;

                if (i < MyParams.Count() - 1)
                {
                    temp += ", ";
                }
            }

            result.Add(String.Format("\t\t\t{0} mp = new {0}();", ClassName));
            result.Add(String.Format("\t\t\tmp.{0}({1});", InputFunc.Name, temp));
            result.Add(String.Format("\t\t\tif( mp.{0}() == 1 ) {{", PreFunc.Name));
            result.Add(String.Format("\t\t\t\t{0} {1} = {2};", PostFunc.ReturnType, PostFunc.ReturnParam, GetDefaultValueString(PostFunc.ReturnType)));
            result.Add(String.Format("\t\t\t\t{0} = mp.{1}();", PostFunc.ReturnParam, PostFunc.Name));
            result.Add(String.Format("\t\t\t\tmp.{0}({1});", OutputFunc.Name, PostFunc.ReturnParam));
            result.Add("\t\t\t}");
            result.Add(String.Format("\t\t\telse {{"));
            result.Add(String.Format("\t\t\t\tConsole.WriteLine(\"Ban da nhap thong tin khong hop le, vui long nhap lai!\");"));
            result.Add("\t\t\t}");
            result.Add("\t\t\tConsole.ReadLine();");

            for (int i = 0; i < result.Count(); i++)
            {
                hihi += result[i].ToString();
                hihi += "\n";
            }

            return hihi;
        }

        private string GeneratePreFunc()
        {
            string hihi = "";

            List<string> result = new List<string>();

            if (!String.IsNullOrWhiteSpace(PreFunc.Pre) && !String.IsNullOrEmpty(PreFunc.Pre))
            {
                result.Add(String.Format("\t\t\tif( {0} ) {{", PreFunc.Pre));
                result.Add("\t\t\t\treturn 1;");
                result.Add("\t\t\t}");
                result.Add("\t\t\telse{");
                result.Add("\t\t\t\treturn 0;");
                result.Add("\t\t\t}");
            }
            else
            {
                result.Add("\t\t\treturn 1;");
            }

            for (int i = 0; i < result.Count(); i++)
            {
                hihi += result[i].ToString();
                hihi += "\n";
            }

            return hihi;
        }

        private string GeneratePostFunc()
        {
            string hihi = "";
            string post = PostFunc.Post.Trim().ToLower();

            string[] temp = post.Split(new[] { "||" }, StringSplitOptions.RemoveEmptyEntries);
            MyIf[] myIfs = new MyIf[temp.Length];

            if (temp.Length > 1)
            {
                for (int i = 0; i < temp.Length; i++)
                {
                    if (temp[i].Length > 0 && temp[i].ElementAt(0) == '(' && temp[i].ElementAt(temp[i].Length - 1) == ')')
                    {
                        temp[i] = temp[i].Remove(0, 1);
                        temp[i] = temp[i].Remove(temp[i].Length - 1, 1);
                    }

                    string[] ifs = temp[i].Split(new[] { "&&", "(", ")" }, StringSplitOptions.RemoveEmptyEntries);

                    string tempIfs = "";

                    // Change "=" into "=="
                    for(int j = 1; j < ifs.Count(); j++)
                    {
                        int index = ifs[j].IndexOf("=");

                        if (index != -1)
                        {
                            if (ifs[j].IndexOf(">=") != -1 || ifs[j].IndexOf("<=") != -1 || ifs[j].IndexOf("==") != -1 || ifs[j].IndexOf("!=") != -1)
                            {

                            }
                            else
                                ifs[j] = ifs[j].Insert(index, "=");
                        }

                        tempIfs += ifs[j];

                        if (j < ifs.Count() - 1)
                        {
                            tempIfs += "&&";
                        }
                    }

                    myIfs[i] = new MyIf()
                    {
                        Condition = tempIfs,
                        Result = ifs[0]
                    };
                }
            }

            else
            {
                if (temp[0].Length > 0 && temp[0].ElementAt(0) == '(' && temp[0].ElementAt(temp[0].Length - 1) == ')')
                {
                    temp[0] = temp[0].Remove(0, 1);
                    temp[0] = temp[0].Remove(temp[0].Length - 1, 1);
                }
            }

            List<string> result = new List<string>();

            if (!String.IsNullOrEmpty(PostFunc.Post))
            {
                result.Add(String.Format("\t\t\t{0} {2} = {1};", PostFunc.ReturnType, GetDefaultValueString(PostFunc.ReturnType), PostFunc.ReturnParam));

                if (myIfs[0] != null)
                {
                    for (int i = 0; i < myIfs.Length; i++)
                    {
                        result.Add(String.Format("\t\t\tif( {0} ) {{", myIfs[i].Condition));
                        result.Add(String.Format("\t\t\t\t{0};", myIfs[i].Result));
                        result.Add("\t\t\t}");

                        if (i < myIfs.Length - 1)
                        {
                            result.Add("\t\t\telse");
                        }
                    }
                }

                if (temp.Length == 1)
                {
                    result.Add("\t\t\t" + temp[0] + ";");
                }

                result.Add("\t\t\treturn " + PostFunc.ReturnParam + ";");
            }
            else
            {

            }

            for (int i = 0; i < result.Count(); i++)
            {
                hihi += result[i].ToString();
                hihi += "\n";
            }

            return hihi;
        }

        public string GetDefaultValueString(string a)
        {
            string result = "";

            switch (a)
            {
                case "float":
                    result = "0";
                    break;
                case "int":
                    result = "0";
                    break;
                case "string":
                    result = "\"\"";
                    break;
                case "bool":
                    result = "false";
                    break;
                default:
                    result = "";
                    break;
            }

            return result;
        }
    }

    internal class MyIf
    {
        public string Condition { get; set; }

        public string Result { get; set; }
    }
}
