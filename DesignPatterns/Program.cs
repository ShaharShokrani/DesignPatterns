using System.Diagnostics;

namespace DesignPatterns.SOLID.SRP
{
    class Program
    {
        static void Main(string[] args)
        {
            //Single Responsibility principle
            var j = new Journal();
            j.AddEntry("I cried today.");
            j.AddEntry("I ate a bug.");
            Debug.WriteLine(j);

            var p = new Persistence();
            var filename = @"c:\temp\journal.txt";
            p.SaveToFile(j, filename);
            Process.Start(filename);
        }
    }
}