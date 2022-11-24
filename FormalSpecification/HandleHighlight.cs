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

                if (text == ":R")
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
            string[] list = { "<", "=", ">", "!" };

            foreach(var i in list)
            {
                ChangeTextColor(i, Color.SteelBlue, rich);
            }

            string[] list2 = { "&&", "||" };

            foreach (var i in list2)
            {
                ChangeTextColor(i, Color.RosyBrown, rich);
            }

            string[] list3 = { ":R" };

            foreach (var i in list3)
            {
                ChangeTextColor(i, Color.DarkRed, rich);
            }

            string[] list1 = { "pre", "post" };

            foreach (var i in list1)
            {
                ChangeTextColor(i, Color.DarkViolet, rich);
            }
        }
    }
}
