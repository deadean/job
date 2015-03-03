using System;
using System.Collections.Generic;
using System.Drawing;
using tesе.Model;

namespace testModel
{
    class ImageBitMapContainerImpl : IContainer
    {
        #region Fields
        private readonly string _filePathInputContainer;
        #endregion

        #region Constructors
        public ImageBitMapContainerImpl(string filePathInputContainer)
        {
            _filePathInputContainer = filePathInputContainer;
        }
        #endregion
        #region Public Services
        public List<PixelContainer> ReadData()
        {
            var listPixels = new List<PixelContainer>();
            var container = new Bitmap(this._filePathInputContainer);
            for (int i = 1; i < container.Height-1; i++)
            {
                for (int j = 1; j < container.Width-1; j++)
                {
                    PixelContainer item = new PixelContainer();
                    Color pixel = container.GetPixel(j, i);
                    item.Pixel = pixel;
                    item.Coordinate = new PixelContainer.Coordinates() {I = i,J=j};
                    item.Range = this.GetBrightnessRange(pixel.GetBrightness());
                    item.NeighboringPixels.Add(this.GetBrightnessRange(container.GetPixel(j - 1, i).GetBrightness()) == item.Range);
                    item.NeighboringPixels.Add(this.GetBrightnessRange(container.GetPixel(j - 1, i-1).GetBrightness()) == item.Range);
                    item.NeighboringPixels.Add(this.GetBrightnessRange(container.GetPixel(j, i-1).GetBrightness()) == item.Range);
                    item.NeighboringPixels.Add(this.GetBrightnessRange(container.GetPixel(j + 1, i-1).GetBrightness()) == item.Range);
                    item.NeighboringPixels.Add(this.GetBrightnessRange(container.GetPixel(j + 1, i).GetBrightness()) == item.Range);
                    item.NeighboringPixels.Add(this.GetBrightnessRange(container.GetPixel(j + 1, i+1).GetBrightness()) == item.Range);
                    item.NeighboringPixels.Add(this.GetBrightnessRange(container.GetPixel(j , i+1).GetBrightness()) == item.Range);
                    item.NeighboringPixels.Add(this.GetBrightnessRange(container.GetPixel(j - 1, i+1).GetBrightness()) == item.Range);

                    item.NeighboringPixelsRange.Add(this.GetBrightnessRange(container.GetPixel(j - 1, i).GetBrightness()));
                    item.NeighboringPixelsRange.Add(this.GetBrightnessRange(container.GetPixel(j - 1, i-1).GetBrightness()));
                    item.NeighboringPixelsRange.Add(this.GetBrightnessRange(container.GetPixel(j, i-1).GetBrightness()));
                    item.NeighboringPixelsRange.Add(this.GetBrightnessRange(container.GetPixel(j + 1, i-1).GetBrightness()));
                    item.NeighboringPixelsRange.Add(this.GetBrightnessRange(container.GetPixel(j + 1, i).GetBrightness()));
                    item.NeighboringPixelsRange.Add(this.GetBrightnessRange(container.GetPixel(j + 1, i+1).GetBrightness()));
                    item.NeighboringPixelsRange.Add(this.GetBrightnessRange(container.GetPixel(j, i+1).GetBrightness()));
                    item.NeighboringPixelsRange.Add(this.GetBrightnessRange(container.GetPixel(j - 1, i+1).GetBrightness()));
                    listPixels.Add(item);
                }
            }
            return listPixels;
        }
        public void WriteData(List<byte> data)
        {
            try
            {
                var container = new Bitmap(this._filePathInputContainer);

                int d = 0;
                for (int i = 0; i < container.Height; i++)
                {
                    for (int j = 0; j < container.Width; j++)
                    {
                        byte r = data[d]; d++;
                        byte g = data[d]; d++;
                        byte b = data[d]; d++;
                        container.SetPixel(j, i, Color.FromArgb(r, g, b));
                    }
                }
                container.Save(this._filePathInputContainer.Substring(0, this._filePathInputContainer.Length - 4) +
                    " Time % " +
                    DateTime.Now.Hour.ToString() + "h " +
                    DateTime.Now.Minute.ToString() + "min " +
                    DateTime.Now.Second.ToString() + "sec.bmp"
                    );
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException("Файл контейнера задан не верно");
            }
        }
        #endregion

        #region Private Services
        private PixelContainer.BrightnessRange GetBrightnessRange(double brightness)
        {
            int diff = 10;
            if (brightness > (double)PixelContainer.BrightnessRange.Ziro/diff && brightness < (double)PixelContainer.BrightnessRange.First/diff)
                return PixelContainer.BrightnessRange.Ziro;
            if (brightness > (double)PixelContainer.BrightnessRange.First / diff && brightness < (double)PixelContainer.BrightnessRange.Second / diff)
                return PixelContainer.BrightnessRange.First;
            if (brightness > (double)PixelContainer.BrightnessRange.Second / diff && brightness < (double)PixelContainer.BrightnessRange.Third / diff)
                return PixelContainer.BrightnessRange.Second;
            if (brightness > (double)PixelContainer.BrightnessRange.Third / diff && brightness < (double)PixelContainer.BrightnessRange.Fourth / diff)
                return PixelContainer.BrightnessRange.Third;
            if (brightness > (double)PixelContainer.BrightnessRange.Fourth / diff && brightness < (double)PixelContainer.BrightnessRange.Five / diff)
                return PixelContainer.BrightnessRange.Fourth;
            if (brightness > (double)PixelContainer.BrightnessRange.Five / diff && brightness < (double)PixelContainer.BrightnessRange.Six / diff)
                return PixelContainer.BrightnessRange.Five;
            if (brightness > (double)PixelContainer.BrightnessRange.Six / diff && brightness < (double)PixelContainer.BrightnessRange.Seven / diff)
                return PixelContainer.BrightnessRange.Six;
            if (brightness > (double)PixelContainer.BrightnessRange.Seven / diff && brightness < (double)PixelContainer.BrightnessRange.Eight / diff)
                return PixelContainer.BrightnessRange.Seven;
            if (brightness > (double)PixelContainer.BrightnessRange.Eight / diff && brightness < (double)PixelContainer.BrightnessRange.Nine / diff)
                return PixelContainer.BrightnessRange.Eight;
            if (brightness > (double)PixelContainer.BrightnessRange.Nine / diff && brightness <= (double)PixelContainer.BrightnessRange.Ten / diff)
                return PixelContainer.BrightnessRange.Nine;
            return PixelContainer.BrightnessRange.Ziro;
        }
        #endregion
    }
}
