using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
           Mailer.SendMail();
        }
    }
}
