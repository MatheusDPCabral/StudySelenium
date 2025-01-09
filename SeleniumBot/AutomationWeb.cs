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
        driver.Navigate().GoToUrl("https://www.google.com");

        driver.FindElement(By.Name("q")).SendKeys("youtube" + Keys.Enter);

        driver.FindElement(By.XPath("//*[@id=\"AkU20\"]/div/div/div/div/div/div/div[1]/div/span/a/h3")).Click();

        driver.FindElement(By.XPath("//*[@id=\"buttons\"]/ytd-button-renderer/yt-button-shape/a/yt-touch-feedback-shape/div/div[2]")).Click();

        Thread.Sleep(2000);

        driver.FindElement(By.Name("identifier")).SendKeys("matheusdelpinocabral@gmail.com" + Keys.Enter);

        Thread.Sleep(3000);

        driver.FindElement(By.Name("Passwd")).SendKeys("ma290404" + Keys.Enter);
        Thread.Sleep(6500);

        driver.FindElement(By.Name("search_query")).SendKeys("tck10" + Keys.Enter);
        Thread.Sleep(2000);

        driver.FindElement(By.XPath("//*[@id=\"text\"]")).Click();
        Thread.Sleep(1000);

        driver.FindElement(By.XPath("//*[@id=\"tabsContent\"]/yt-tab-group-shape/div[1]/yt-tab-shape[4]/div[1]")).Click();
        Thread.Sleep(1000);

        driver.FindElement(By.XPath("//*[@id=\"contents\"]/ytd-rich-item-renderer[1]")).Click();
    }

}
