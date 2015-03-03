using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using ADGLOB;
using System.IO;

namespace CaptchaAnalizator
{
    public class CCaptchaAnalizator
    {
        #region Fields
        private Bitmap _bitMap = null;

        private const int HeightCaptcha = 15;
        private const int WidthCaptcha = 45;

        private const int HeightNumber = 15;
        private const int WidthNumber = 9;

        private const int countNumbers = 5;
        private const string ResultsParsingDirectory = "ResultsParsing";

        #endregion

        #region Ctor

        public CCaptchaAnalizator(Bitmap bitMap)
        {
            try
            {
                if (bitMap == null)
                    throw new NullReferenceException("bitMap must be not null");
                this._bitMap = bitMap;
                //Directory.CreateDirectory(ResultsParsingDirectory);
            }
            catch (Exception ex)
            {
                CLog.Log(ex.Message);
            }
        }

        #endregion

        #region Public Services

        public List<int> StartAnalize()
        {
            try
            {
                Bitmap bmp = CutCaptcha();
                if (bmp == null)
                    throw new NullReferenceException("Can not cut captcha");

                List<Bitmap> numbersImageForParsing = ShareCaptchaOnNumbersImage(bmp);
                return this.AnalizeBitmapNumbers(numbersImageForParsing);

            }
            catch (Exception ex)
            {
                CLog.Log(ex.Message);
            }
            return new List<int>();
        }

        #endregion

        #region Private Services

        private Bitmap CutCaptcha()
        {
            try
            {
                Bitmap newBmp = new Bitmap(WidthCaptcha, HeightCaptcha);

                const int startX = 530;
                const int startY = 449;

                for (int i = startX, ic = 0; i < startX+WidthCaptcha; i++,ic++)
                {
                    for (int j = startY,jc=0; j < startY+HeightCaptcha; j++,jc++)
                    {
                        newBmp.SetPixel(ic, jc, this._bitMap.GetPixel(i, j));
                    }
                }
                newBmp.Save("test.bmp");
                return newBmp;
            }
            catch (Exception ex)
            {
                CLog.Log(ex.Message);
            }
            return null;
        }
        private List<Bitmap> ShareCaptchaOnNumbersImage(Bitmap captcha)
        {
            List<Bitmap> result = new List<Bitmap>();
            try
            {
                for (int i = 0; i < WidthCaptcha; i += WidthNumber)
                {
                   result.Add(GetSubImage(i, i + WidthNumber,captcha));    
                }
                
            }
            catch (Exception ex)
            {
                CLog.Log(ex.Message);
            }
            return result;
        }

        private Bitmap GetSubImage(int istart, int iend,Bitmap captcha)
        {
            Bitmap newBmp = new Bitmap(WidthNumber, HeightNumber);

            for (int i = istart, ic = 0; i < iend; i++, ic++)
            {
                for (int j = 0, jc = 0; j < captcha.Height; j++, jc++)
                {
                    newBmp.SetPixel(ic, jc, captcha.GetPixel(i, j));
                }
            }
            //newBmp.Save(ResultsParsingDirectory + CommonConstants.IDENTIFIER_BACK_SLASH + "result" + istart.ToString() + ".bmp");
            return newBmp;
        }

        private List<int> AnalizeBitmapNumbers(List<Bitmap> bitMapNumbers)
        {
            List<int> results = new List<int>();
            ImageTranslator translator = new ImageTranslator();
            for (int i = 0; i <= 9; i++)
            {
                string d = ResultsParsingDirectory + CommonConstants.IDENTIFIER_BACK_SLASH + i.ToString() + ".bmp";
                translator.TemplateImages.Add(new TemplateImage() { TemplateImages = new ImageBitMapContainerImpl(d).ReadData(), Number = i });
                CLog.Log(d);
            }
            bitMapNumbers.ForEach(x=>translator.SampleImages.Add(new ImageBitMapContainerImpl() { Container = x}.ReadData()));

            for (int i = 0; i < translator.SampleImages.Count; i++)
            {
                double result = 1000000000000;
                int foundTemplate = 0;
                for (int j = 0; j < translator.TemplateImages.Count; j++)
                {
                    double res = translator.AnalizeSample(translator.SampleImages[i], translator.TemplateImages[j].TemplateImages);
                    if (res < result)
                    {
                        result = res;
                        foundTemplate = j;
                    }
                    
                    Console.WriteLine("Compare {0} with {1} template : {2}" ,(i + 1).ToString(), (j + 1).ToString(),res);
                    CLog.Log(String.Format("Compare {0} with {1} template : {2}", (i + 1).ToString(), (j + 1).ToString(), res));
                }
                results.Add(translator.TemplateImages[foundTemplate].Number);
                CLog.Log(String.Format("Results is {0}", translator.TemplateImages[foundTemplate].Number));
                Console.WriteLine("Results is {0}",translator.TemplateImages[foundTemplate].Number);
            }
            return results;
        }

        #endregion
    }
}
