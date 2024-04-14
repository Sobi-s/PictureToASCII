using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;


namespace ASCIIpicture
{
    internal class Program
    {
        private const double HeightConstResize = 1.5;

        [STAThread] // atribute that makes show dialog works :
                    // Если атрибут отсутствует, приложение использует многопототочную модель, которая не поддерживается Windows Forms

        static void Main(string[] args)
        {
            Console.WriteLine("Press ENTER to start.");

            var openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Image | *.JPEG;*.bmp;*.png; *.jpg";
            
            while (true) // so the program dosen't close and we can open multiple pics
                         
            {
                Console.ReadLine();

                // Call a window to open a picture
                if (openFileDialog.ShowDialog() != DialogResult.OK)
                    continue;

                Console.Clear();

                // Open the picture
                var image = new Bitmap(openFileDialog.FileName);
                image = Resize(image);

                // A set of chats to render the image
                // char[] pixeltable = { '.', ',', ':', '+', '*', '?', '%', '$', '#', '@' };

                // Converitng the image to gray scale
                image.CheckIndexedAndConvertToGray();

                // Converting to ASCII
                var converter = new ToASCIIConverter(image);
                var resultPicture = converter.ConvertToASCII();

                // Picture output
                foreach (var line in resultPicture)
                {
                    Console.WriteLine(line);
                  
                }
                Console.SetCursorPosition(0, 0);
            }
        }

        // Resize the image if the original one is bigger than the window

        private static Bitmap Resize (Bitmap image)
        {
            int maxWidth = 350;
            int maxHeight = (int)((float)maxWidth / image.Width * (image.Height * HeightConstResize));

            if (image.Width > maxWidth || image.Height > maxHeight)
            {
                image = new Bitmap (image, new Size(maxWidth,maxHeight));  
                
            }
            return image;
        }
    }
}
