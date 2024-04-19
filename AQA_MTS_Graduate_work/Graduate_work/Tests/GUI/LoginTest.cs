using Graduate_work.Helpers.Configuration;
using Graduate_work.Models;

namespace Graduate_work.Tests;

public class LoginTest : BaseGuiTest
{
    [Test]
    [Description("Тест успешного входа в систему")]
    public void SuccessfulLoginTest()
    {
        Assert.That(NavigationSteps
            .SuccessfulLogin(Configurator.Users.First(x => x.Email == "polinaholod97@gmail.com"))
            .TitleLabel
            .Displayed);
    }
}