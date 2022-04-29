using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;

namespace GitDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IWebDriver Driver = new ChromeDriver();
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            Thread.Sleep(2000);
            Driver.Navigate().GoToUrl("https://www.google.co.in/");
            Thread.Sleep(2000);
            Driver.Manage().Window.Maximize();
            Thread.Sleep(2000);



            //var links = Driver.FindElements(By.XPath("//a[@href]"));
            //Console.WriteLine("Total Links  : " + links.Count);
            //foreach (var item in links)
            //{
            //    Console.WriteLine(item.GetAttribute("href"));
            //}

            //Screenshot SS = ((ITakesScreenshot)Driver).GetScreenshot();


            //SS.SaveAsFile(@"D:\Testing\ss.png", ScreenshotImageFormat.Png);

            TakeScreenShot(Driver, Driver.FindElement(By.ClassName("lnXdpd")));







        }

        public static void TakeScreenShot(IWebDriver driver,IWebElement element)
        {
            string filename = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss")+".jpg";

            Byte[] byteArray = ((ITakesScreenshot)driver).GetScreenshot().AsByteArray;

            Bitmap screenshot = new Bitmap(new System.IO.MemoryStream(byteArray));

            Rectangle croppedImage = new Rectangle(element.Location.X,element.Location.Y,element.Size.Width,element.Size.Width);

            screenshot=screenshot.Clone(croppedImage,screenshot.PixelFormat);

            screenshot.Save(String.Format(filename,ScreenshotImageFormat.Jpeg));
        }



    }
}
