using System;
using System.Drawing;
using System.IO;

namespace ImageEditor.NET
{
    class ImageEditor
    {
        public ImageEditor()
        {

        }

        private static Bitmap CreateImageInternal(int heigth, int width)
        {
            Bitmap OutputImage = new Bitmap(heigth, width);

            for (int i = 0; i < OutputImage.Height; i++)
            {
                for (int j = 0; j < OutputImage.Width; j++)
                {
                    //Edit pixels -> e.g. set them to Blue (= #0000FF)
                    OutputImage.SetPixel(j, i, Color.FromArgb(0, 255, 0)); 
                }
            }

            return OutputImage;
        }

        public static void CreateImage(int heigth, int width, string outputPath)
        {
            CreateImageInternal(heigth, width).Save(outputPath);
        }

        public static Bitmap CreateImage(int heigth, int width)
        {
            return CreateImageInternal(heigth, width);
        }

        private static Bitmap EditImageInternal(Bitmap inputImage)
        {
            Bitmap outputImage = new Bitmap(inputImage.Height, inputImage.Width);

            for (int i = 0; i < outputImage.Height; i++)
            {
                for (int j = 0; j < outputImage.Width; j++)
                {
                    //Edit pixels -> e.g. copy each pixel
                    outputImage.SetPixel(j, i, inputImage.GetPixel(j, i));
                }
            }

            return outputImage;
        }

        public static void EditImage(string inputPath, string outputPath)
        {
            if (!System.IO.File.Exists(inputPath))
            {
                throw new ArgumentException("URL to source image is invalid");
            }

            FileStream inputStream = File.OpenRead(inputPath);
            Bitmap inoutImage = new Bitmap(inputStream);
            EditImageInternal(new Bitmap(inputStream)).Save(outputPath);
        }

        public static Bitmap EditImage(Bitmap inputImage)
        {
            return EditImageInternal(inputImage);
        }
    }
}