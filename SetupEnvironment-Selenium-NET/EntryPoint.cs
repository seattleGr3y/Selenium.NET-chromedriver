
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

class EntryPoint
{
    static IWebDriver driver = new ChromeDriver();
    static IWebElement dropDownMenu;
    static IWebElement dDownMenuElement;
    static string dDownSelection;

    static void Main()
    {
        string url = "http://testing.todvachev.com/special-elements/drop-down-menu-test/";
        string dDownMenuElements;

        driver.Navigate().GoToUrl(url);

        try
        {
            dropDownMenu = driver.FindElement(By.Name("DropDownTest"));
            Thread.Sleep(1000);

            for (int i = 0; i < 4; i++)
            {
                TextMessage(dropDownMenu.GetAttribute("value"));
                dDownMenuElements = "#post-6 > div > p:nth-child(6) > select > option:nth-child(" + (i + 1) + ")";
                dDownMenuElement = driver.FindElement(By.CssSelector(dDownMenuElements));
                dDownMenuElement.Click();
                TextMessage("The Selected Value is: " + dropDownMenu.GetAttribute("value"));

                if (dDownMenuElement.GetAttribute("checked") == "true")
                {
                    dDownSelection = dropDownMenu.GetAttribute("value");
                    TextMessage(dDownMenuElement.GetAttribute("value"));
                    GreenMessage("This drop down option is selected");
                }
                else
                {
                    TextMessage("This is NOT checked");
                }

                Thread.Sleep(3000);
            }
        }
        catch (NoSuchElementException)
        {
            RedMessage("I am NOT seeing drop down option " + dDownSelection + " I expect to see");
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
