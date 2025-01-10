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
        // inicia com o navegador do google aberto
        driver.Navigate().GoToUrl("https://www.google.com");

        // procura por youtbe
        element = VerificaSeElementoExistePorNome("q");
        element.SendKeys("youtube" + Keys.Enter);

        //procura pelo link do youtube e entra no site
        try
        {
            element = VerificaSeElementoExistePorXPath("//*[@id=\"AkU20\"]/div/div/div/div/div/div/div[1]/div/span/a/h3");
            element.Click();
        }
        catch (NoSuchElementException)
        {
            Console.WriteLine("Site Web não encontrado.");
        }

        // clcia no botão de fazer login
        driver.FindElement(By.XPath("//*[@id=\"buttons\"]/ytd-button-renderer/yt-button-shape/a/yt-touch-feedback-shape/div/div[2]")).Click();

        //verifica se campo de email do logins existe e preenche 
        element = VerificaSeElementoExistePorNome("identifier");
        element.SendKeys("matheusdelpinocabral@gmail.com" + Keys.Enter);

        //preenche campo de senha login
        element = VerificaSeElementoExistePorNome("Passwd");
        element.SendKeys("ma290404" + Keys.Enter);

        //vai na barra de pesquisa e realiza pesquisa 
        element = VerificaSeElementoExistePorNome("search_query");
        element.SendKeys("tck10" + Keys.Enter);

        //entra no canal do tck
        element = VerificaSeElementoExistePorID("channel-title");
        element.Click();

        // vai na aba de videos
        element = VerificaSeElementoExistePorXPath("//*[@id=\"tabsContent\"]/yt-tab-group-shape/div[1]/yt-tab-shape[2]");
        element.Click();


        //clica na live ao vivo
        element = VerificaSeElementoExistePorXPath("/html/body/ytd-app/div[1]/ytd-page-manager/ytd-browse[2]/ytd-two-column-browse-results-renderer/div[1]/ytd-rich-grid-renderer/div[6]/ytd-rich-item-renderer[10]/div/ytd-rich-grid-media/div[1]/div[3]/div[2]");
        element.Click();

        //clica em pular anuncio
        try
        {
            element = VerificaSeElementoExistePorXPath("//*[@id=\"skip-button:2\"]");
            element.Click();
        }
        catch (NoSuchElementException)
        {
            Console.WriteLine("Nenhum anúncio para pular.");
        }
    }

    public IWebElement VerificaSeElementoExistePorXPath(string elementName)
    {
        int timeoutInSeconds = 10;
        IWebElement element = null;
        var endTime = DateTime.Now.AddSeconds(timeoutInSeconds);

        while (DateTime.Now < endTime)
        {
            try
            {
                element = driver.FindElement(By.XPath(elementName));
                if (element.Displayed && element.Enabled)
                    return element;
            }
            catch (NoSuchElementException)
            {
                Thread.Sleep(500); // Aguarda um pouco antes de tentar novamente
            }
        }
        throw new TimeoutException($"Elemento com o nome '{elementName}' não foi encontrado em {timeoutInSeconds} segundos.");
    }

    public IWebElement VerificaSeElementoExistePorID(string elementName)
    {
        int timeoutInSeconds = 10;
        IWebElement element = null;
        var endTime = DateTime.Now.AddSeconds(timeoutInSeconds);

        while (DateTime.Now < endTime)
        {
            try
            {
                element = driver.FindElement(By.Id(elementName));
                if (element.Displayed && element.Enabled)
                    return element;
            }
            catch (NoSuchElementException)
            {
                Thread.Sleep(500); // Aguarda um pouco antes de tentar novamente
            }
        }
        throw new TimeoutException($"Elemento com o nome '{elementName}' não foi encontrado em {timeoutInSeconds} segundos.");
    }

    public IWebElement VerificaSeElementoExistePorNome(string elementName)
    {
        int timeoutInSeconds = 10;
        IWebElement element = null;
        var endTime = DateTime.Now.AddSeconds(timeoutInSeconds);

        while (DateTime.Now < endTime)
        {
            try
            {
                element = driver.FindElement(By.Name(elementName));
                if (element.Displayed && element.Enabled)
                    return element;
            }
            catch (NoSuchElementException)
            {
                Thread.Sleep(500); // Aguarda um pouco antes de tentar novamente
            }
        }
        throw new TimeoutException($"Elemento com o nome '{elementName}' não foi encontrado em {timeoutInSeconds} segundos.");
    }
}