using System;

public class FirstDegreeEquation
{
    public static string calculateRank (double score) {

        if (score < 0 || score > 10)
            return "Invalid";
        if (score < 3.5)
            return "Kem";
        if (score < 5)
            return "Yeu";
        if (score < 6.5)
            return "Trung binh";
        if (score < 8)
            return "Kha";
        if (score < 9)
            return "Gioi";
        return "Xuat sac";
    } 

    public static void Main(string[] args)
    {
        double  score;
        
        Console.WriteLine ("Enter student's score: ");
        score = Convert.ToDouble(Console.ReadLine());

        string rank = calculateRank(score);
        Console.WriteLine("Student's rank is: " + rank);
        
    }
}