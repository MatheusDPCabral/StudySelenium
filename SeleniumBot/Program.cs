using SeleniumBot;

class Program
{
    static void Main(string[] args)
    {
        var web = new AutomationWeb();

        //var text = web.TestWeb();

        //Console.WriteLine(text);


        web.EntrandoEmSiteYouTube();
    }
}




/*
    // -------------------------------------
    //               METODOS
    // -------------------------------------

    public IWebElement VerificaSeElementoExistePorXPath(string elementName)
    {
        IWebElement element = null;

        wait.Until(x => driver.FindElement(By.XPath(elementName)) != null);
        
        element = driver.FindElement(By.XPath(elementName));

        return element; ;
    }

    public IWebElement VerificaSeElementoExistePorID(string elementName)
    {
        IWebElement element = null;

        wait.Until(x => driver.FindElement(By.Id(elementName)) != null);
        element = driver.FindElement(By.Id(elementName));

        return element;
    }

    public IWebElement VerificaSeElementoExistePorNometeste(string elementName)
    {
        IWebElement element = null;

        wait.Until(x => driver.FindElement(By.Name(elementName)) != null);
        element = driver.FindElement(By.Name(elementName));
        
        try
        {
            return element;
        }
        catch (NoSuchElementException)
        {
            throw new TimeoutException();
        }

    }
*/



