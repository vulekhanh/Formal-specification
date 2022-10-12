#include <iostream>
using namespace std;

double max(double a, double b){

    if ( a <= 0 || b <= 0)
        return 0;
    return ( a >= b ) ? a : b;
   
} 

int main ()
{
   double num1, num2;
   cout << "Enter the first number: ";
   cin >> num1;
   cout << "Enter the second number: "; 
   cin >> num2;
   double maxNumber = max(num1, num2);
   if (maxNumber == 0){
    cout << "Invalid input, cannot calculate";
    return 0;
   }
   if (num1 == maxNumber)
     cout << num1 << " is greater than " << num2;
   else
      cout << num2 << " is greater than " << num1;
    return 0;
}