using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Try_Some
{
    public class help_png
    {
        private static void blendpics1(Bitmap bg,Bitmap front,int deltx,int delty)
        {
            for (int y=0;y < front.Height ; y++)
            {
                for (int x=0;x < front.Width ; x++)
                {
                    if (front.GetPixel(x,y).A < 255)
                    {
                        Color newColor = bg.GetPixel(x + deltx,y + delty);
                        front.SetPixel(x,y,newColor);
                    }
                }
            }
        }
        public static void blendpics(PictureBox back,PictureBox front1)
        {
            int leftdeff = Math.Abs(back.Left - front1.Left);
            int toptdeff = Math.Abs(back.Top - front1.Top);
            blendpics1((Bitmap)back.Image, (Bitmap)front1.Image, leftdeff, toptdeff);
        }
    }
}
