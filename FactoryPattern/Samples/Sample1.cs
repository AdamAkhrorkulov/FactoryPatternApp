namespace FactoryPattern.Samples;

public interface ISample1
{
    String CurrentDateTime { get; set; }
}

public class Sample1 : ISample1
{
    public String CurrentDateTime { get; set; } = DateTime.Now.ToString();
}