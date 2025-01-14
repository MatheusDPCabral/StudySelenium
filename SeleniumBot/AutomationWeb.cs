using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumBot;


public class AutomationWeb
{
    public IWebDriver driver; // variável de instância
    WebDriverWait wait; // variavel para processo de aguardar 
    IWebElement element;  

    public AutomationWeb()
    {
        ChromeOptions options = new ChromeOptions();

        // Remover flag que indica automação
        options.AddExcludedArgument("enable-automation");
        options.AddAdditionalOption("useAutomationExtension", false);

        // Passar argumentos para parecer um navegador comum
        options.AddArgument("--disable-blink-features=AutomationControlled");

        driver = new ChromeDriver(options);
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
    }

    public string TestWeb()
    {
        driver.Navigate().GoToUrl("https://www.google.com");

        driver.FindElement(By.Name("q")).SendKeys("hello world");

        driver.FindElement(By.XPath("/html/body/div[1]/div[3]/form/div[1]/div[1]/div[3]/center/input[1]")).Click();

        var texto = driver.FindElement(By.XPath("//*[@id=\"Pu32td\"]/div/div/div[2]/div/span")).Text;

        return texto;
    }

    public void EntrandoEmSiteYouTube()
    {
        driver.Manage().Window.Maximize();

        // inicia com o navegador do google aberto
        driver.Navigate().GoToUrl("https://www.google.com");

        // procura por youtbe
        TakeElementAndPutValueAndPressEnter(By.Name("q"), "youtube");

        //procura pelo link do youtube e entra no site
        TakeAndClickElement(By.XPath("//h3[text()='YouTube']"));

        // clicia no botão de fazer login
        TakeAndClickElement(By.CssSelector("a[aria-label='Fazer login']"));

        // Verifica o campo de email e preenche
        TakeElementAndPutValueAndPressEnter(By.Name("identifier"), "matheusdelpinocabral@gmail.com");

        // Aguarda o carregamento do campo de senha e preenche
        TakeElementAndPutValueAndPressEnter(By.Name("Passwd"), "ma290404");

        //vai na barra de pesquisa e realiza pesquisa 
        TakeElementAndPutValueAndPressEnter(By.Name("search_query"), "tck10");

        //entra no canal do tck
        TakeAndClickElement(By.Id("channel-title"));

        // vai na aba de videos
        TakeAndClickElement(By.XPath("//div[contains(@class, 'yt-tab-shape-wiz__tab') and text()='Videos']"));

        //clica no video desejado
        TakeAndClickElement(By.XPath("//a[contains(@title, 'ESSES STREAMERS VIRARAM MEUS FREGUESES')]"));

        //clica em pular anuncio
        TakeAndClickElement(By.XPath("//*[@id=\"skip-button:2\"]"));
    }


    // -------------------------------------
    //               METODOS
    // -------------------------------------

    public IWebElement FindElementNotNull(By by)
    {
        wait.Until(driver =>
        {
            element = driver.FindElement(by);
            return element != null && element.Displayed && element.Enabled;
        });

        try
        {
            return element;
        }
        catch (NoSuchElementException)
        {
            return null;
        }
    }

    public void TakeAndClickElement(By by)
    {
        element = FindElementNotNull(by);
        element.Click();
    }

    public void TakeElementAndPutValueAndPressEnter(By by, string value)
    {
        element = FindElementNotNull(by);
        element.SendKeys(value + Keys.Enter);
    }
}