using System;
using System.Reflection.Metadata.Ecma335;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumBot.AutomationWeb.Tests;

public class Tests
{
    IWebElement element;
    public IWebDriver? driver;
    public WebDriverWait wait;

         // METODO DE APOIO
    public IWebElement FindElementNotNull(By by)
    {
        IWebElement element = null;

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
    //---------------------------------------

        //  TESTES
    [SetUp]
    public void Setup()
    {
        ChromeOptions options = new ChromeOptions();
        options.AddExcludedArgument("enable-automation");
        options.AddAdditionalOption("useAutomationExtension", false);
        options.AddArgument("--disable-blink-features=AutomationControlled");

        // Defina o caminho do ChromeDriver explicitamente
        string chromeDriverPath = AppContext.BaseDirectory;
        
        driver = new ChromeDriver(chromeDriverPath, options);
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    [TearDown]
    public void TearDown()
    {
        driver?.Quit();  // Garante que o navegador será fechado 
        driver?.Dispose();
    }

    [Test]
    public void SearchBarNotNullTest()
    {
        // arrange
        driver.Navigate().GoToUrl("https://www.google.com");

        // act
        var barraDePesquisa = wait.Until(driver =>  
        {
            var element = driver.FindElement(By.Name("q"));
            return element != null && element.Displayed && element.Enabled;
        });

        // assert
        Assert.IsNotNull(barraDePesquisa);
    }

    [Test]
    public void TestParaVerificarSeElementoDoLinkParaYoutubeEstaDisponivel()
    {
        // arrange
        driver.Navigate().GoToUrl("https://www.google.com");
        element = FindElementNotNull(By.Name("q"));
        element.SendKeys("youtube" + Keys.Enter);

        // act
        var linkParaSiteDoYoutube = FindElementNotNull(By.XPath("//h3[text()='YouTube']"));

        // assert
        Assert.IsNotNull(linkParaSiteDoYoutube, "Link para o YouTube não foi encontrado.");
    }

    [Test]
    public void TestParaVerificarSeBotaoDeLoginEstaDisponivel()
    {
        // arrange
        driver.Navigate().GoToUrl("https://www.google.com");
        element = FindElementNotNull(By.Name("q"));
        element.SendKeys("youtube" + Keys.Enter);
        element = FindElementNotNull(By.XPath("//h3[text()='YouTube']"));
        element.Click();

        // act
        var botaoDeFazerLogin = FindElementNotNull(By.CssSelector("a[aria-label='Fazer login']"));

        //assert
        Assert.IsNotNull(botaoDeFazerLogin, "Botão não foi encontrado.");

    }

    [Test]
    public void VerificacaoCampoDeEmailESenhaEstaDisponivel()
    {
        // arrange
        driver.Navigate().GoToUrl("https://www.google.com");
        element = FindElementNotNull(By.Name("q"));
        element.SendKeys("youtube" + Keys.Enter);
        element = FindElementNotNull(By.XPath("//h3[text()='YouTube']"));
        element.Click();
        element = FindElementNotNull(By.CssSelector("a[aria-label='Fazer login']"));
        element.Click();

        // act
        var campoDeEmail = FindElementNotNull(By.Name("identifier"));
        campoDeEmail.SendKeys("matheusdelpinocabral@gmail.com" + Keys.Enter);
        var campoDeSenha = FindElementNotNull(By.Name("Passwd"));
        campoDeSenha.SendKeys("ma290404" + Keys.Enter);

        // asserts
        Assert.IsTrue(campoDeEmail.Enabled);
        Assert.IsTrue(campoDeSenha.Enabled);
    }

    [Test]
    public void TesteParaVerificarSeCanalEstaDisponivel()
    {
        // arrange
        driver.Navigate().GoToUrl("https://www.google.com");
        element = FindElementNotNull(By.Name("q"));
        element.SendKeys("youtube" + Keys.Enter);
        element = FindElementNotNull(By.XPath("//h3[text()='YouTube']"));
        element.Click();
        element = FindElementNotNull(By.CssSelector("a[aria-label='Fazer login']"));
        element.Click();
        element = FindElementNotNull(By.Name("identifier"));
        element.SendKeys("matheusdelpinocabral@gmail.com" + Keys.Enter);
        element = FindElementNotNull(By.Name("Passwd"));
        element.SendKeys("ma290404" + Keys.Enter);
        element = FindElementNotNull(By.Name("search_query"));
        element.SendKeys("tck10" + Keys.Enter);

        // act
        var CanalDoTCK10 = FindElementNotNull(By.Id("channel-title"));

        // asserts
        Assert.IsTrue(CanalDoTCK10.Displayed);
    }


    [Test]
    public void VerificarSeVideoEstaDisponivel()
    {
        // arrange
        driver.Navigate().GoToUrl("https://www.google.com");
        element = FindElementNotNull(By.Name("q"));
        element.SendKeys("youtube" + Keys.Enter);
        element = FindElementNotNull(By.XPath("//h3[text()='YouTube']"));
        element.Click();
        element = FindElementNotNull(By.CssSelector("a[aria-label='Fazer login']"));
        element.Click();
        element = FindElementNotNull(By.Name("identifier"));
        element.SendKeys("matheusdelpinocabral@gmail.com" + Keys.Enter);
        element = FindElementNotNull(By.Name("Passwd"));
        element.SendKeys("ma290404" + Keys.Enter);
        element = FindElementNotNull(By.Name("search_query"));
        element.SendKeys("tck10" + Keys.Enter);
        element = FindElementNotNull(By.Id("channel-title"));
        element.Click();
        element = FindElementNotNull(By.XPath("//div[contains(@class, 'yt-tab-shape-wiz__tab') and text()='Videos']"));
        element.Click();

        // act
        var videoDesejado = FindElementNotNull(By.XPath("//a[contains(@title, 'ESSES STREAMERS VIRARAM MEUS FREGUESES')]"));

        // assert
        Assert.IsTrue(videoDesejado.Displayed);
    }

}
