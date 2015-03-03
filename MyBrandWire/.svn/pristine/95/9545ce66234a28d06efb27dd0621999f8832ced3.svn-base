using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CaptchaAnalizator
{
    public class CCaptchaWrapper
    {
        private void TakeAndSave()
        {
            Bitmap _bitmap = TakeScreenShot(Screen.PrimaryScreen);
            SaveScreenShot(_bitmap);
        }

        private Bitmap TakeScreenShot(Screen currentScreen)
        {
            Bitmap bmpScreenShot = new Bitmap(currentScreen.Bounds.Width, currentScreen.Bounds.Height, PixelFormat.Format32bppArgb);

            Graphics gScreenShot = Graphics.FromImage(bmpScreenShot);

            gScreenShot.CopyFromScreen(currentScreen.Bounds.X, currentScreen.Bounds.Y, 0, 0, currentScreen.Bounds.Size, CopyPixelOperation.SourceCopy);
            return bmpScreenShot;
        }

        private void SaveScreenShot(Bitmap _bitmap)
        {
            Directory.CreateDirectory("InputImage");
            string filename = "1" + ".jpg";
            _bitmap.Save("InputImage" + "/" + filename, ImageFormat.Jpeg);
        }

        public string TakeAndAnalizeCaptcha()
        {
            this.TakeAndSave();
            Bitmap bp = new Bitmap("InputImage/1.jpg");
            CCaptchaAnalizator captchaAnalizator = new CCaptchaAnalizator(bp);
            List<int> results = captchaAnalizator.StartAnalize();
            string resultsString = String.Empty;
            results.ForEach(x => resultsString += x.ToString());
            return resultsString;
        }
    }
}
