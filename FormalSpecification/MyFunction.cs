using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormalSpecification
{
    internal class MyFunction
    {
        public string Name { get; set; }

        public MyParams[] Parameters { get; set; }

        public string ReturnType { get; set; }

        public string ReturnParam { get; set; }

        public string Content { get; set; }

        public string Pre { get; set; } 

        public string Post { get; set; }

        public string GenerateConstructorFunc()
        {
            string hihi = "";
            List<string> result = new List<string>();

            string temp = "";

            for (int i = 0; i < Parameters.Count(); i++)
            {
                temp += Parameters[i].Type + " " + Parameters[i].Name;

                if(i < Parameters.Count() - 1)
                {
                    temp += ", ";
                }
            }

            result.Add(String.Format("\t\tpublic {0}({1}) {{",Name, temp));
            for (int i = 0; i < Parameters.Count(); i++)
                result.Add(String.Format("\t\t\tthis.{0} = {0};", Parameters[i].Name));
            result.Add("\t\t}");

            for (int i = 0; i < result.Count(); i++)
            {
                hihi += result[i].ToString();
                hihi += "\n";
            }

            return hihi; 
        }

        public string GenerateInputFunc()
        {
            string hihi = "";
            List<string> result = new List<string>();

            string temp = "";

            for (int i = 0; i < Parameters.Count(); i++)
            {
                if (Parameters[i].Type != "float[]") {
                    temp += "ref ";
                }
                temp += Parameters[i].Type + " " + Parameters[i].Name;

                if (i < Parameters.Count() - 1)
                {
                    temp += ", ";
                }
            }

            result.Add(String.Format("\t\tpublic {0} {1}({2}) {{", ReturnType, Name, temp));

            bool isLoop = false;

            for (int i = 0; i < Parameters.Count(); i++)
            {
                // Check if a Loop func
                if (i == 0 && Parameters[i].Type == "float[]")
                {
                    isLoop = true;
                }

                if (Parameters[i].Type != "float[]")
                {
                    result.Add(String.Format("\t\t\tConsole.WriteLine(\"Nhap {0}: \");", Parameters[i].Name));
                    result.Add(String.Format("\t\t\t{0} = {1}.Parse(Console.ReadLine());", Parameters[i].Name, Parameters[i].Type));
                }
            }

            // Handle Loop Func
            if(isLoop)
            {
                result.Add(String.Format("\t\t\tthis.{0} = new {1};", Parameters[0].Name, Parameters[0].Type));
                result.Add(this.Content);
                //result.Add(String.Format("for ( int {0}=0; {0}<n; {0}++) {{", "hihi"));
            }

            result.Add("\t\t}");

            for (int i = 0; i < result.Count(); i++)
            {
                hihi += result[i].ToString();
                hihi += "\n";
            }

            return hihi;
        }

        public string GenerateOutputFunc()
        {
            string hihi = "";
            List<string> result = new List<string>();
            string temp = "";

            
            temp = Parameters[0].Type + " " + Parameters[0].Name;


            result.Add(String.Format("\t\tpublic {0} {1}({2}) {{", ReturnType, Name, temp));
            result.Add(String.Format("\t\t\tConsole.WriteLine(\"Ket qua la : {{0}}\", {0});", Parameters[0].Name));
            result.Add("\t\t}");

            for (int i = 0; i < result.Count(); i++)
            {
                hihi += result[i].ToString();
                hihi += "\n";
            }

            return hihi;
        }

        public string GenerateFunc()
        {
            string hihi = "";
            List<string> result = new List<string>();
            string temp = "";

            if (Parameters != null && Parameters.Length > 0)
            {
                for (int i = 0; i < Parameters.Count(); i++)
                {
                    temp += Parameters[i].Type + " " + Parameters[i].Name;

                    if(i < Parameters.Count() - 1)
                    {
                        temp += ", ";
                    }
                }
            }

            result.Add(String.Format("\t\tpublic {0} {1}({2}) {{", ReturnType, Name, temp));
            result.Add((String.IsNullOrEmpty(Content) == false) ? Content : "");
            result.Add("\t\t}");

            for (int i = 0; i < result.Count(); i++)
            {
                hihi += result[i].ToString();
                hihi += "\n";
            }

            return hihi;
        }
    }

    public class LoopFunc{

        public string Param { get; set; }

        public string startValue { get; set; }

        public string finishValue { get; set; }
    }
}
