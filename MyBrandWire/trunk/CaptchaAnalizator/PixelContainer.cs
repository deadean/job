using System.Collections.Generic;
using System.Drawing;

namespace CaptchaAnalizator
{
    public class PixelContainer
    {
        public enum BrightnessRange
        {
            Ziro=0,
            First,
            Second,
            Third,
            Fourth,
            Five,
            Six,
            Seven,
            Eight,
            Nine,
            Ten
        }
        public struct Coordinates
        {
            public int I;
            public int J;
        }
        #region Fields
        /// <summary>
        /// Pixel in the image container
        /// </summary>
        private Color _pixel;
        /// <summary>
        /// Collection of the bool value of the neighboring pixel
        /// If neighboring pixels walk into the same intervals of the brightness that current pixel
        /// then value is true, in another case is false
        /// </summary>
        private List<bool> _listNearbyPixel = new List<bool>();
        private List<BrightnessRange>  _listNearbyPixelRange = new List<BrightnessRange>();
        /// <summary>
        /// Accessory current pixel to the apropriate brightness range
        /// </summary>
        private BrightnessRange _brightnessRange;

        private Coordinates _coordinates;
        #endregion

        #region Constructors
        public PixelContainer(List<bool> listNearbyPixel, Color pixel)
        {
            _listNearbyPixel = listNearbyPixel;
            _pixel = pixel;
        }
        public PixelContainer()
        {
        }

        #endregion

        #region Properties
        public Color Pixel
        {
            get { return this._pixel; }
            set { this._pixel = value; }
        }
        public List<bool> NeighboringPixels
        {
            get { return this._listNearbyPixel; }
            set { this._listNearbyPixel = value; }
        }
        public List<BrightnessRange> NeighboringPixelsRange
        {
            get { return this._listNearbyPixelRange; }
            set { this._listNearbyPixelRange = value; }
        }
        public BrightnessRange Range
        {
            get { return this._brightnessRange; }
            set { this._brightnessRange = value; }
        }
        public Coordinates Coordinate 
        {
            get { return this._coordinates; }
            set { this._coordinates = value; }
        }

        #endregion
    }
}
