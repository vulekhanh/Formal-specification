using System.Drawing;
using System.Windows.Forms;

namespace FormalSpecification
{
    internal class HandleHighlight
    {
        public void ChangeTextColor(string text, Color color, RichTextBox tb)
        {
            int pos = 0;

            do
            {
                if (pos != 0 && pos + text.Length < tb.Text.Length)
                    pos += text.Length;

                pos = tb.Find(text, pos, RichTextBoxFinds.None);

                if (text == ":R" || text == ":Z" || text == ":B" || text == ":char*")
                {
                    if (pos > 0)
                    {
                        tb.Select(++pos, text.Length - 1);
                        tb.SelectionColor = color;
                    }
                }

                else
                {
                    if (pos > 0)
                    {
                        tb.Select(pos, text.Length);
                        tb.SelectionColor = color;
                    }
                }


                if (pos + text.Length > tb.Text.Length - 1)
                    break;
            }
            while (pos >= 0 && pos < tb.Text.Length);
        }

        public void Highlight(RichTextBox rich)
        {

            string[] list = { "<", "==", ">", ">=", "<=", "!=" };

            foreach(var i in list)
            {
                ChangeTextColor(i, Color.SteelBlue, rich);
            }

            string[] list2 = { "&&", "||" };

            foreach (var i in list2)
            {
                ChangeTextColor(i, Color.RosyBrown, rich);
            }

            string[] list3 = { ":R", ":Z", ":B", ":char*" };

            foreach (var i in list3)
            {
                ChangeTextColor(i, Color.DarkRed, rich);
            }

            string[] list1 = { "pre ", "post ", "if", "else" };

            foreach (var i in list1)
            {
                ChangeTextColor(i, Color.DarkViolet, rich);
            }

            string[] listGeneral = { "Program" };

            foreach (var i in listGeneral)
            {
                ChangeTextColor(i, Color.DarkRed, rich);
            }

            string[] listGeneral1 = { "namespace", "class", "public", "void", "float", "float[]", "int", "string", "string[]", "static", "ref", "return", "new" };

            foreach (var i in listGeneral1)
            {
                ChangeTextColor(i, Color.Blue, rich);
            }

            string[] listYellow = { "this", "WriteLine", "ReadLine" };

            foreach (var i in listYellow)
            {
                ChangeTextColor(i, Color.Orange, rich);
            }

            string[] listGreen = { "Console" };

            foreach (var i in listGreen)
            {
                ChangeTextColor(i, Color.Green, rich);
            }

            string[] listBlack = { "FormalSpecification" };

            foreach (var i in listBlack)
            {
                ChangeTextColor(i, Color.Black, rich);
            }
        }
    }
}
