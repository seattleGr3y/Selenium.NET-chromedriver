
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

class EntryPoint
{
    static IWebDriver driver = new ChromeDriver();
    static IWebElement dropDownMenu;
    static IWebElement dDownMenuElement;

    static void Main()
    {
        string url = "http://testing.todvachev.com/special-elements/drop-down-menu-test/";
        string[] options = { "1", "2", "3", "4" };
        string dDownMenuElements;

        driver.Navigate().GoToUrl(url);

        dropDownMenu = driver.FindElement(By.Name("DropDownTest"));
        TextMessage(dropDownMenu.GetAttribute("value"));
        Thread.Sleep(1000);
        
        foreach (string dDownChoice in options)
        {
            TextMessage(dDownChoice);
            try
            {
                dDownMenuElements = "#post-6 > div > p:nth-child(6) > select > option:nth-child(" + dDownChoice + ")";
                dDownMenuElement = driver.FindElement(By.CssSelector(dDownMenuElements));
                dDownMenuElement.Click();
                TextMessage("The Selected Value is: " + dropDownMenu.GetAttribute("value"));

                if (dDownMenuElement.GetAttribute("checked") == "true")
                {
                    TextMessage(dDownMenuElement.GetAttribute("value"));
                    GreenMessage("This radio button is checked");
                }
                else
                {
                    TextMessage("This is NOT checked");
                }
            }
            catch (NoSuchElementException)
            {
                RedMessage("I am NOT seeing radio button I expect to see");
            }

            Thread.Sleep(3000);
        }

        Thread.Sleep(4000);
        driver.Quit();
    }

    private static void RedMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ForegroundColor = ConsoleColor.Gray;
    }

    private static void GreenMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(message);
        Console.ForegroundColor = ConsoleColor.Gray;
    }

    private static void TextMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(message);
        Console.ForegroundColor = ConsoleColor.Gray;
    }
}

