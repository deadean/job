using ADGLOB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ADGLOB;

namespace SendKeysEmulator
{
    public class CSendKeysEmulator
    {
        private const int MOUSEEVENTF_LEFTDOWN = 0x2;
        private const int MOUSEEVENTF_LEFTUP = 0x4;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x8;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        static int countClick = 0;

        [DllImport("USER32.dll", CallingConvention = CallingConvention.StdCall)]
        static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        [DllImport("USER32.dll", CallingConvention = CallingConvention.StdCall)]
        static extern void SetCursorPos(int X, int Y);

        private List<CommonConstants._TPoint> PATH = new List<CommonConstants._TPoint>();

        public CSendKeysEmulator(List<CommonConstants._TPoint> path)
        {
            try
            {
                if (path == null)
                    throw new ArgumentException("path can not be null.");
                PATH = path;
            }
            catch (Exception ex)
            {
                CLog.Log(ex.Message);
            }
        }

        public void StartEmulate()
        {
            this.PATH.ForEach(x => this.SetNewPositionAndClick(x.X, x.Y,x.IsClick, x.IsTrippleClick));
        }

        private void SetNewPositionAndClick(int CursorX, int CursorY, bool isClick, bool isTrippleClick)
        {
            SetCursorPos(CursorX, CursorY);

            if (isClick)
            {
                mouse_event(MOUSEEVENTF_LEFTDOWN, CursorX, CursorY, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTUP, CursorX, CursorY, 0, 0);
            }
            if (isTrippleClick)
            {
                mouse_event(MOUSEEVENTF_LEFTDOWN, CursorX, CursorY, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTUP, CursorX, CursorY, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTDOWN, CursorX, CursorY, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTUP, CursorX, CursorY, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTDOWN, CursorX, CursorY, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTUP, CursorX, CursorY, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTDOWN, CursorX, CursorY, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTUP, CursorX, CursorY, 0, 0);
            }

            CSendKeysEmulator.countClick++;
            Thread.Sleep(2000);
        }
    }
}


/*
 * private List<CommonConstants._TPoint> GeneratePath()
        {
            List<CommonConstants._TPoint> result = new List<CommonConstants._TPoint>();

            int x = 200;
            int y = 570;

            result.Add(new CommonConstants._TPoint() { X = x, Y = y, IsClick=true });

            x = SystemInformation.PrimaryMonitorSize.Width-220;
            y = 15;

            result.Add(new CommonConstants._TPoint() { X = x, Y = y , IsClick = true});

            PerformOnePage(ref result, ref x, ref y);

            ClickScrollBar(ref result, ref x, ref y);

            PerformOnePage(ref result, ref x, ref y);

            ClickScrollBar(ref result, ref x, ref y);

            PerformOnePage(ref result, ref x, ref y);

            return result;
        }

        private void ClickScrollBar(ref List<CommonConstants._TPoint> result, ref int x, ref int y)
        {
            x = SystemInformation.PrimaryMonitorSize.Width - 10;
            y = 600;
            result.Add(new CommonConstants._TPoint() { X = x, Y = y ,IsTrippleClick=true});

        }

        private static void PerformOnePage(ref List<CommonConstants._TPoint> result, ref int x, ref int y)
        {
            x = 200;
            y = 575;

            y -= 360;
            x += 320;

            result.Add(new CommonConstants._TPoint() { X = x, Y = y });

            for (int i = 0; i < 2; i++)
            {
                x += 380;
                result.Add(new CommonConstants._TPoint() { X = x, Y = y });
            }

            y += 100;
            for (int i = 0; i < 3; i++)
            {
                result.Add(new CommonConstants._TPoint() { X = x, Y = y });
                x -= 380;
            }

            x += 380;
            y += 110;
            for (int i = 0; i < 3; i++)
            {
                result.Add(new CommonConstants._TPoint() { X = x, Y = y });
                x += 380;
            }

            x -= 380;
            y += 110;
            for (int i = 0; i < 3; i++)
            {
                result.Add(new CommonConstants._TPoint() { X = x, Y = y });
                x -= 380;
            }
        }
*/