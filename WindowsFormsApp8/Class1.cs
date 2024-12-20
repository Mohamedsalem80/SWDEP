using System;
using System.Drawing;


namespace WindowsFormsApp8
{
    internal class Class1
    {
        public static int GetTextHeight(System.Windows.Forms.Label lbl)
        {
            using (Graphics g = lbl.CreateGraphics())
            {
                SizeF size = g.MeasureString(lbl.Text, lbl.Font, lbl.Width);
                return (int)Math.Ceiling(size.Height*1.1);
            }
        }
    }
}
