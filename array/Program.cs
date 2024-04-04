// See https://aka.ms/new-console-template for more informati
String[] a1 =  new String[4];
a1[0] = "my";
a1[1] = "name";
a1[2] = "is";
a1[3] = "Rasaq";
Console.WriteLine(a1);
for (int i = 0; i < a1.Length; i++)
{
    Console.WriteLine(a1[i]);
    if (a1[i] == "Rasaq")
    {
        Console.WriteLine("It's a match");
       
    }
    
      
  
   
}