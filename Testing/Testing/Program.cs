// See https://aka.ms/new-console-template for more information

using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security.AccessControl;
//pointer unsafe 




//file stream read 
Assembly assem = typeof(Example).Assembly;
Assembly assem2=typeof(Program).Assembly;


Console.WriteLine("Assembly full Name");
Console.WriteLine(assem.FullName);
Console.WriteLine(assem.Location);
Console.WriteLine(assem.DefinedTypes);
Console.WriteLine(assem.EntryPoint);



public class Example
{
    private int factor;

    public Example(int f)
    {
        factor = f;
    }
}