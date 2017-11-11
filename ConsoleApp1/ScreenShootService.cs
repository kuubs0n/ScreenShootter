using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Mail;
using System.Windows.Forms;

namespace ConsoleApp1
{
    public static class ScreenShootService
    {
        public static Attachment GetScreenShotAttachment()
        {
            //Create a new bitmap.
            Bitmap bmpScreenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
                Screen.PrimaryScreen.Bounds.Height,
                PixelFormat.Format32bppArgb);

            // Create a graphics object from the bitmap.
            Graphics gfxScreenshot = Graphics.FromImage(bmpScreenshot);

            // Take the screenshot from the upper left corner to the right bottom corner.
            gfxScreenshot.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
                Screen.PrimaryScreen.Bounds.Y,
                0,
                0,
                Screen.PrimaryScreen.Bounds.Size,
                CopyPixelOperation.SourceCopy);

            // Save the screenshot to the specified path that the user has chosen.
            //bmpScreenshot.Save("Screenshot.jpeg", ImageFormat.Jpeg);

            Stream stream = new MemoryStream();
            bmpScreenshot.Save(stream, ImageFormat.Jpeg);
            stream.Position = 0;

            return new Attachment(stream, "MyImage.jpg");
        }
    }
}
