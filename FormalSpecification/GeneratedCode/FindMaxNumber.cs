using System;

public class MaxNumber
{
    public static double max(double a, double b){

    return ( a >= b ) ? a : b;
   
} 
    public static void Main(string[] args)
    {
        double num1, num2;
        
        Console.WriteLine ("Enter the the first number: ");
        num1 = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine ("Enter the the second number: ");
        num2 = Convert.ToDouble(Console.ReadLine());
        
        double maxNumber = max(num1, num2);
        
        if (num1 == maxNumber)
            Console.WriteLine( num1 + " is greater than " + num2);
        else
            Console.WriteLine( num2 + " is greater than " + num1);
    }
}