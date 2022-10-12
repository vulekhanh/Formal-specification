using System;

public class FirstDegreeEquation
{
    public static bool isLeapYear (int year) {

        if ( year <= 0)
            return false;
        return ((year % 4 == 0 && year % 100 != 0) || (year % 400 == 0));
   
    } 

    public static void Main(string[] args)
    {
        int year;
        
        Console.WriteLine ("Enter the year: ");
        year = Convert.ToInt32(Console.ReadLine());

        
        bool result = isLeapYear(year);
        if (result)
            Console.WriteLine(year + " is a leap year.");
        else
            Console.WriteLine(year + " is not a leap year.");
    }
}