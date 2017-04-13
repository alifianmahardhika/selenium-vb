using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace seleniumvbhref
{
    class Program
    {
        public static void Main(string[] args)
        {
            var driver = new FirefoxDriver();
            int i = 0;
            string myurl = "http://www.ncjpn.com/";
            string filelocation = "E:/Link.txt";
            driver.Navigate().GoToUrl(myurl);
            Console.WriteLine("Links found: ");
            foreach (var item in driver.FindElements(By.TagName("a")))
            {
                Console.WriteLine(item.GetAttribute("href"));
                i++;
            }
            string[] lines = new string[i];
            int j = 0;
            foreach (var item in driver.FindElements(By.TagName("a")))
            {
                lines[j] = item.GetAttribute("href");
                j++;
            }
            File.WriteAllLines(@filelocation, lines);
            Console.WriteLine("<href> value written on {0}", filelocation);
            Console.WriteLine("Total Links Found on {0}",myurl, "=");
            Console.WriteLine("{0}", i, "links");
            Console.WriteLine("Done");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}