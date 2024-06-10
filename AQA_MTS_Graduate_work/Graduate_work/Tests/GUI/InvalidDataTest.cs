using NUnit.Allure.Attributes;

namespace Graduate_work.Tests.GUI;

public class InvalidDataTest : BaseGuiTest
{
    [Test]
    [Description("Тест на использование некорректных данных")]
    [AllureFeature("Negative")]
    public void InvalidLoginTest()
    {
        Assert.That(_navigationSteps
                .IncorrectLogin("kukuha@hasgone.com", "veryVeryAffordable")
                .ErrorAlert.Text.Trim(),
            Is.EqualTo("These credentials do not match our records.")
        );
    }
}