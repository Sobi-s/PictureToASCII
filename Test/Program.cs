using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;


namespace Test
{
    internal class Program

    {
        private const double HeightCoeff = 1.5;

        [STAThread]
        static void Main(string[] args)
        {
            var open = new OpenFileDialog();
            open.Filter = "Image | *.JPEG;*.bmp;*.png; *.jpg";

            var open2 = new OpenFileDialog();
            open2.Filter = "Image | *.JPEG;*.bmp;*.png; *.jpg";

            while (true)
            {


                open.ShowDialog();
                
                    var openImage1 = new Bitmap(open.FileName);
                    GetSize(openImage1, open.FileName);

                open2.ShowDialog();

                var openImage2 = new Bitmap(open2.FileName);
                    GetSize(openImage2, open2.FileName);
                openImage2 = Resize(openImage2);

                GetSize(openImage2, open2.FileName);
                Console.ReadLine();

            }
                
            
        }

        public static void GetSize(Bitmap image, string imageName)
        {
            int width = image.Width;
            int height = image.Height;
            Console.WriteLine($"Image 1 {imageName}  /n Width: {width} /n Height: {height}");

        }

        public static Bitmap Resize (Bitmap image)
        {
            int maxWidth = 350;
            int maxHeight = (int) ((float)maxWidth / image.Width * (image.Height * HeightCoeff));

            if (image.Width > maxWidth || image.Height > maxHeight) {
             image = new Bitmap(image, maxWidth, maxHeight);
            }
            return image;
        }
    }
}
