using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
ArrayList a =new ArrayList();
a.Add("my");
a.Add("name");
a.Add("is");
a.Add("tomi");
Console.WriteLine(a[1]);
foreach(String item  in a)
{
    Console.WriteLine(item);
}
Console.WriteLine(a.Contains("tomi"));
Console.WriteLine("after sorting");
a.Sort();
foreach (String item in a)
{
    Console.WriteLine(item);
}
