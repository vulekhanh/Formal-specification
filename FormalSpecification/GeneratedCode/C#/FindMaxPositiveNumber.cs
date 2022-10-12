using System;

public class MaxNumber
{
    public static double max(double a, double b){

    if ( a <= 0 || b <= 0)
        return 0;
    return ( a >= b ) ? a : b;
   
} 
    public static void Main(string[] args)
    {
        double num1, num2;
        
        Console.WriteLine ("Enter the first number: ");
        num1 = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine ("Enter the second number: ");
        num2 = Convert.ToDouble(Console.ReadLine());
        
        double maxNumber = max(num1, num2);
        
        if (maxNumber == 0){
            Console.WriteLine ("Invalid input, cannot calculate");
            return;
        }
        
        if (num1 == maxNumber)
            Console.WriteLine( num1 + " is greater than " + num2);
        else
            Console.WriteLine( num2 + " is greater than " + num1);
    }
}