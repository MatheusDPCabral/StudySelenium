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
    public IWebDriver driver; // Variável de instância

    WebDriverWait wait;


    public AutomationWeb()
    {
        ChromeOptions options = new ChromeOptions();

        // Remover flag que indica automação
        options.AddExcludedArgument("enable-automation");
        options.AddAdditionalOption("useAutomationExtension", false);

        // Passar argumentos para parecer um navegador comum
        options.AddArgument("--disable-blink-features=AutomationControlled");

        // Inicializar a variável de instância driver
        driver = new ChromeDriver(options);

        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

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
        driver.FindElement(By.Name("q")).SendKeys("youtube" + Keys.Enter);

        //procura pelo link do youtube e entra no site
        driver.FindElement(By.XPath("//*[@id=\"AkU20\"]/div/div/div/div/div/div/div[1]/div/span/a/h3")).Click();

        // clcia no botão de fazer login
        driver.FindElement(By.XPath("//*[@id=\"buttons\"]/ytd-button-renderer/yt-button-shape/a/yt-touch-feedback-shape/div/div[2]")).Click();
        Thread.Sleep(2000);

        //preenche campo de email login
        driver.FindElement(By.Name("identifier")).SendKeys("matheusdelpinocabral@gmail.com" + Keys.Enter);
        Thread.Sleep(3000);

        //preenche campo de senha login
        driver.FindElement(By.Name("Passwd")).SendKeys("ma290404" + Keys.Enter);
        Thread.Sleep(6500);

        //vai na barra de pesquisa e realiza pesquisa 
        driver.FindElement(By.Name("search_query")).SendKeys("tck10" + Keys.Enter);
        Thread.Sleep(2000);

        //entra no canal do tck
        driver.FindElement(By.XPath("/html/body/ytd-app/div[1]/ytd-page-manager/ytd-search/div[1]/ytd-two-column-search-results-renderer/div/ytd-section-list-renderer/div[2]/ytd-item-section-renderer/div[3]/ytd-channel-renderer/div")).Click();
        Thread.Sleep(1000);

        // vai na aba de videos
        driver.FindElement(By.XPath("//*[@id=\"tabsContent\"]/yt-tab-group-shape/div[1]/yt-tab-shape[2]")).Click();
        Thread.Sleep(1000);

        //clica na live ao vivo
        driver.FindElement(By.XPath("/html/body/ytd-app/div[1]/ytd-page-manager/ytd-browse[2]/ytd-two-column-browse-results-renderer/div[1]/ytd-rich-grid-renderer/div[6]/ytd-rich-item-renderer[10]/div/ytd-rich-grid-media/div[1]/div[3]/div[2]")).Click();
    }

}
