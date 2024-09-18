using System;
using System.Collections.Generic;
using SmartFormat;

namespace ConsoleAppDemoSmartFormat
{
  internal class Program
  {
    static void Main()
    {
      Console.WriteLine("exemples d'utilisation de la librairie SmartFormat");
      var data = new { Library = "SmartFormat" };
      var result = Smart.Format("Composed with {Library}.", data);
      // Result: "Composed with SmartFormat."
      Console.WriteLine(result);

      var stringFormat = string.Format("{0} {0:N2} {1:yyyy-MM-dd}", 5, new DateTime(1900, 12, 31));
      var smartFormat = Smart.Format(  "{0} {0:N2} {1:yyyy-MM-dd}", 5, new DateTime(1900, 12, 31));
      // Result: (stringFormat == smartFormat) == true

      var data2 = new[] { 1, 2, 3, 4, 5 };
      _ = Smart.Format("{0:list:N2|, |, and }.", data2);
      // Result: "1.00, 2.00, 3.00, 4.00, and 5.00."

      var data3 = new[]  { new { Name = "John", Gender = 0 },
                           new { Name = "Mary", Gender = 1 } };
      var result3 = Smart.Format("{Name} commented on {Gender:choose:his|her} photo", data3[1]);
      // Result: "Mary commented on her photo"
      Console.WriteLine(result3);

      var data4 = new List<int[]> {
                                    new[] { 1, 2, 3 },
                                    new[] { 4, 5, 6 },
                                    new[] { 7, 8, 9 }
                                   };
      // "list" is the formatter name
      _ = Smart.Format("{0:list:Elements\\: {:list:{:000}|, |, }|\n|\n}", data);
      //                |                   |        | |       |      |
      //                |                   |  element format  |      |
      //                |                   |___ inner list ___|      |
      //                |_______________________ outer list __________|
      /* Result:
      Elements: 001, 002, 003
      Elements: 004, 005, 006
      Elements: 007, 008, 009
      */

      Smart.Format("{0:plural(en):zero|one|many}", 1);
      // outputs "one" for the English language option


      Console.WriteLine("Press anykey to exit:");
      Console.ReadKey();
    }
  }
}
