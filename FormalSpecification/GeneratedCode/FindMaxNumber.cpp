#include <iostream>;
using namespace std;

double max(double a, double b){

   return ( a >= b ) ? a : b;
   
} 

int main ()
{
   double num1, num2;
   cout << "Enter the the first number: ";
   cin >> num1;
   cout << "Enter the the second number: "; 
   cin >> num2;
   double maxNumber = max(num1, num2);
   if (num1 == maxNumber)
     cout << num1 << " is greater than " << num2;
   else
      cout << num2 << " is greater than " << num1;
    return 0;
}