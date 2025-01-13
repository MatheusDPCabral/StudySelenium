using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumBot.AutomationWeb.Tests;

public class Tests
{
    public IWebDriver? driver;
    public WebDriverWait wait;

    [SetUp]
    public void Setup()
    {
        ChromeOptions options = new ChromeOptions();
        options.AddExcludedArgument("enable-automation");
        options.AddAdditionalOption("useAutomationExtension", false);
        options.AddArgument("--disable-blink-features=AutomationControlled");

        // Defina o caminho do ChromeDriver explicitamente
        string chromeDriverPath = @"C:\Users\DEV\source\repos\StudySelenium\SeleniumBot.AutomationWeb.Tests\bin\Debug\net8.0"; // Substitua pelo caminho do seu ChromeDriver
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
    public void TestParaVerificarSeElementoDoLinkParaYoutubeEstaDisponivel()
    {
        // arrange
        driver.Navigate().GoToUrl("https://www.google.com");

        // act
        driver.FindElement(By.Name("q")).SendKeys("youtube" + Keys.Enter);

        // Espera até que o elemento esteja visível
        var linkParaSiteDoYoutube = wait.Until(driver =>
        {
            try
            {
                var element = driver.FindElement(By.XPath("//h3[text()='YouTube']"));
                return element.Displayed ? element : null;
            }
            catch (NoSuchElementException)
            {
                return null; // caso o elemento não seja encontrado
            }
        });

        // assert
        Assert.IsNotNull(linkParaSiteDoYoutube, "O link para o YouTube não foi encontrado ou não está visível.");
    }

}
