#include <iostream>
using namespace std;

bool isLeapYear (int year) {

   if ( year <= 0)
    return false;
   return ((year % 4 == 0 && year % 100 != 0) || (year % 400 == 0));
   
} 

int main ()
{
    int year;
    cout << "Enter the year: ";
    cin >> year;

    bool result = isLeapYear(year);
    if (result)
        cout << year << " is a leap year." << endl;
    else
        cout << year << " is not a leap year." << endl;
    return 0;
}