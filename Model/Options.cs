public class Options
{

    public String Content { get; set; }
    public Delegate MethodCalculation { get; set; }
    public String MethodString { get; set; }
    public Options(String content, Delegate methodCalculation, String methodString)
    {
        Content = content;
        MethodCalculation = methodCalculation;
        MethodString = methodString;
    }



}