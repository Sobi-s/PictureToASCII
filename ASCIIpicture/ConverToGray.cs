using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCIIpicture
{
    public static class ConverToGray
    {

        // Checking for indexed pixels

        public static Bitmap CheckIndexedAndConvertToGray (this Bitmap image) { 
            if (image.PixelFormat == PixelFormat.Indexed ||
               image.PixelFormat == PixelFormat.Format1bppIndexed ||
               image.PixelFormat == PixelFormat.Format4bppIndexed ||
               image.PixelFormat == PixelFormat.Format8bppIndexed)
            {
                ToGray(ConvertToNonIndexed (image));
            }

            else
            {
                ToGray(image);
            }
            return image;
            
            }

        public static Bitmap ConvertToNonIndexed (Bitmap image)
        {
            Bitmap nonPixeledImage = new Bitmap(image.Width, image.Height, PixelFormat.Format32bppArgb); // creating new pixel image with specific format - pixels are non indexed

            using (Graphics newImage = Graphics.FromImage(nonPixeledImage)) // Create graphics object
            {
                newImage.DrawImage(image, 0, 0); // Drawing from indexed to non indexed
            }

                return nonPixeledImage;
        }
        public static void ToGray (this Bitmap image)
        {                                
            {
                for (int x = 0; x < image.Width; x++)
                {
                    for (int y = 0; y < image.Height; y++)
                    {
                        var pixel = image.GetPixel(x, y);
                        if (pixel != null)
                        {
                            int avg = (pixel.R + pixel.G + pixel.B) / 3;
                            image.SetPixel(x, y, Color.FromArgb(avg, avg, avg));
                        }
                    }
                }
            }
        }
    }
}
