//Exersice 7.3i


//main creates an array holding the four numbers 7, 13, 9, 8, 
//call function arrsum on that array, 
//and print the result.
void main() {
    int a[4];
    int s;
    a[0] = 7;
    a[1] = 13;
    a[2] = 9;
    a[3] = 8;
    arrsum(4, a, &s);

    print s;
}


/* Exercise 7.3 */

void arrsum(int n, int arr[], int *sump) {
    int i;
    *sump = 0;

    for (i = 0; i < n; i = i + 1) {
        *sump = *sump + arr[i];
    }
}