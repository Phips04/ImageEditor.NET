using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;

namespace Image_Code
{
    public static class ImageEncoder
    {
        public static Bitmap Encode(Bitmap ImageToEncode, Bitmap Key)
        {
            if (ImageToEncode.Width != Key.Width || ImageToEncode.Height != Key.Height)
            {
                throw new InvalidOperationException("Heigth / width of affected image did not equal heigth / width of key image");
            }

            Bitmap EncodedBimap = ImageToEncode;

            for (int i = 0; i < ImageToEncode.Height; i++)
            {
                for (int j = 0; j < ImageToEncode.Width; j++)
                {
                    Color OldColor = ImageToEncode.GetPixel(j, i);
                    Color KeyColor = Key.GetPixel(j, i);

                    Color NewColor = Color.FromArgb(OldColor.R ^ KeyColor.R, OldColor.G ^ KeyColor.G,
                        OldColor.B ^ KeyColor.B);

                    EncodedBimap.SetPixel(j, i, NewColor);
                }
            }

            return EncodedBimap;
        }
    }
}
