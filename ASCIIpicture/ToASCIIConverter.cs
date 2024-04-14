using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCIIpicture
{
    internal class ToASCIIConverter
    {
        private readonly Bitmap _image;
        char[] _pixeltable = { '.', ',', ':', '+', '*', '?', '%', '$', '#', '@' };
        public ToASCIIConverter(Bitmap image) 
        { 
            _image = image;
        }

        // Converting
        public char[][] ConvertToASCII () 
        {
            var result = new char[_image.Height][];

            for (int y=0; y < _image.Height; y++) // iterating by height = row by row 
            {
                result[y] = new char[_image.Width]; // nested array: isolating each row into a nested array, length = width, represents a row of chars

                for (int x =0; x < _image.Width; x++) // iterating by each pixel
                {
                    int mapPixel = (int) Map(_image.GetPixel(x, y).R, 0, 255, 0, _pixeltable.Length-1); // index calculation
                    result[y][x] = _pixeltable[mapPixel]; // assign char of the index to the pixel
                }

            }

            return result;
        }

        
        // Pixl mapping: pixel = ASCII
        public static float Map (float PixelValue, float RgbStart, float RgbStop, float CharArrStart, float ChatArrStop)
        {
            return ((PixelValue - RgbStart) / (RgbStop - RgbStart)) * (ChatArrStop - CharArrStart) + CharArrStart;
        }
    }
}
