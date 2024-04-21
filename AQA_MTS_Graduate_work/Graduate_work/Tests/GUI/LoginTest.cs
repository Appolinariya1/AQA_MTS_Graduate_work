using Graduate_work.Helpers.Configuration;

namespace Graduate_work.Tests.GUI;

public class LoginTest : BaseGuiTest
{
    [Test]
    [Description("Тест успешного входа в систему")]
    [Category("Positive")]
    public void SuccessfulLoginTest()
    {
        Assert.That(_navigationSteps
            .SuccessfulLogin(Configurator.Users.First(x => x.Email == "polinaholod97@gmail.com"))
            .TitleLabel
            .Displayed);
    }
}