#include <iostream>
using namespace std;

string calculateRank (float score) {

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

int main ()
{
    float score;
    cout << "Enter student's score: ";
    cin >> score;

    string rank = calculateRank(score);
    cout << "Student's rank is: " << rank;
    return 0;
}