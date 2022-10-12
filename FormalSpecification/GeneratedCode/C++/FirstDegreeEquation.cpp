#include <iostream>
using namespace std;

float result(float a, float b){

   if( b != 0)
      return (-b)/a;
   return 0;
} 

void main ()
{
   float a, b, x;
   cout<<"Enter the values of a, b: "<<endl;
   cin>>a>>b;

   x = result(a, b);
   cout << "The value of x = " << x <<endl;
   
}