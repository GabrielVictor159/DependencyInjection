using DependencyInjection.Model;
using System.Reflection;
public interface IMenu

{
    Dictionary<string, IList<Options>> optionsByCategory { get; }
}