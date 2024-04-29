using Graduate_work.Helpers.Configuration;
using NUnit.Allure.Attributes;

namespace Graduate_work.Tests.GUI;

public class LoginTest : BaseGuiTest
{
    [Test]
    [Description("Тест успешного входа в систему")]
    [AllureFeature("Positive")]
    public void SuccessfulLoginTest()
    {
        Assert.That(_navigationSteps
            .SuccessfulLogin(Configurator.Users.First(x => x.Email == "polinaholod97@gmail.com"))
            .TitleLabel
            .Displayed);
    }
}