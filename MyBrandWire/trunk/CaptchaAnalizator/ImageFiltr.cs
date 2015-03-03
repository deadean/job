using System;
using System.Collections.Generic;
using System.Drawing;


namespace CaptchaAnalizator
{
    class ImageFiltr
    {
        public ImageFiltr(){}

        public void ApplyFiltr( ref List<List<byte>> data)
        {
            for (int i = 0; i < data.Count; i++)
            {
                for (int j = 0; j < data[i].Count; j++)
                {
                    data[i][j] = (byte)(data[i][j]*(-1) + 90);
                }
            }
        }
        
    }
}
