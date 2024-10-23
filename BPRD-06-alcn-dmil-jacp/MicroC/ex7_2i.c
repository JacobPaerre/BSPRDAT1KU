//Exercise 7.2i


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


//arrsum computes and returns the sum of the first n elements of the given array arr.
//The result is returned through the sump pointer. 
void arrsum(int n, int arr[], int *sump) {
    int i;
    *sump = 0;
    i = 0;
    while (i < n) {
        *sump = *sump + arr[i];
        i = i + 1;
    }
}