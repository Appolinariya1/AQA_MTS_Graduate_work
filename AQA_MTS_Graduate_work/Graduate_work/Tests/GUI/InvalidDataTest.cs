namespace Graduate_work.Tests.GUI;

public class InvalidDataTest : BaseGuiTest
{
    [Test]
    [Description("Тест на использование некорректных данных")]
    public void InvalidLoginTest()
    {
        Assert.That(NavigationSteps
                .IncorrectLogin("kukuha@hasgone.com", "veryVeryAffordable")
                .ErrorAlert.Text.Trim(),
            Is.EqualTo("These credentials do not match our records.")
        );
    }
}