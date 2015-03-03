using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using testModel;

namespace tesе.Model
{
    class ImageTranslator
    {
        #region Fields
        private List<List<PixelContainer>> _templateImages = new List<List<PixelContainer>>();
        private List<List<PixelContainer>> _sampleImages = new List<List<PixelContainer>>();
        #endregion
        #region Constructors
        public ImageTranslator()
        {
        }
        #endregion
        #region Properties
        public List<List<PixelContainer>>  TemplateImages
        {
            get { return this._templateImages; }
            set { this._templateImages = value;}
        }
        public List<List<PixelContainer>> SampleImages
        {
            get { return this._sampleImages; }
            set { this._sampleImages = value; }
        }
        #endregion
        #region Public Services
        public double AnalizeSample(List<PixelContainer> sample, List<PixelContainer> template )
        {
            double diff = 11.1;
            double diffPercent = 1.11;
            double finalPercent = 0.0;
            for (int i = 0; i < sample.Count; i++)
            {
                //find distance of the current pixel in sample image to apropriate pixel in the template image
                double percent = 0.0;
                PixelContainer currentPixelSample = sample[i];
                PixelContainer currentPixelTemplate = template[i];
                if (currentPixelSample.Range == currentPixelTemplate.Range)
                {
                    percent += diff;
                }
                else
                {
                    percent += diff-Math.Abs(currentPixelSample.Range - currentPixelTemplate.Range)*diffPercent;
                }
                for (int j = 0; j < currentPixelSample.NeighboringPixels.Count; j++)
                {
                    if (currentPixelSample.NeighboringPixels[j] == currentPixelTemplate.NeighboringPixels[j])
                    {
                        percent += diff;
                    }
                    else
                    {
                        percent += diff-Math.Abs(currentPixelSample.NeighboringPixelsRange[j] - currentPixelTemplate.NeighboringPixelsRange[j]) * diffPercent;
                    }
                }
                finalPercent += percent;
            }
            return 100.0 - (finalPercent / sample.Count);
        }
        #endregion
    }
}
