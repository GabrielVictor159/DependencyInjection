public class Options
{

    public String Content { get; set; }
    public Delegate MethodCalculation { get; set; }
    public Boolean? Persist { get; set; }

    public Options(String content, Delegate methodCalculation, Boolean? persit = true)
    {
        Content = content;
        MethodCalculation = methodCalculation;
        Persist = persit;
    }



}