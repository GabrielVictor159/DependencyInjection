public class Options
{

    public String Content {get; set;}
	public Delegate MethodCalculation {get; set;}
	
	public Options(String content, Delegate methodCalculation)
	{
		Content = content;
		MethodCalculation = methodCalculation;
	}


  
}