using System;

public class FirstDegreeEquation
{
    public static double result(double a, double b){

   if( b != 0)
      return (-b)/a;
   return 0;
   
} 
    public static void Main(string[] args)
    {
        double a, b;
        
        Console.WriteLine ("Enter the values of a: ");
        a = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine ("Enter the the second number: ");
        b = Convert.ToDouble(Console.ReadLine());
        
        double x = result(a, b);
        Console.WriteLine("The value of x = " + x);
       
    }
}