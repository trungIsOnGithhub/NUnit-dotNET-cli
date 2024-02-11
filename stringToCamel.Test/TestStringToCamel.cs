namespace stringToCamel.Test;

public class Tests
{
    private int numOfTest = 2;

    [SetUp]
    public void Setup()
    {
        Console.WriteLine($"Started {numOfTest} Tests!");
    }

    [Test]
    public void TestUsualCase()
    {
        var result = Program.StringToCamel("this_is_a_string");
        var matcher = "thisIsAString";

        Assert.That(result, Is.EqualTo(matcher));
    }

    [Test]
    public void TestOneElementCase()
    {
        var result = Program.StringToCamel("_string__");
        var matcher = "string";

        Assert.That(result, Is.EqualTo(matcher));
    }
}