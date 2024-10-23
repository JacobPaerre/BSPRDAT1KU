//Exersice 7.3ii

//main allocates an array holding up to 20 integers, 
//call function squares to fill the array with n square numbers 
//(where n ≤ 20 is given as a parameter to the main function), 
//then call function arrsum from exersice 7.2i to compute the sum of the n squares, and print the sum.
void main(int n) {
    int a[20];
    int s;
    squares(n, a);
    arrsum(n, a, &s);
    print s;
}

void squares(int n, int arr[]) {
    int i;

    for (i = 0; i < n; i = i + 1) {
        arr[i] = i * i;
    }
}

void arrsum(int n, int arr[], int *sump) {
    int i;
    *sump = 0;

    for (i = 0; i < n; i = i + 1) {
        *sump = *sump + arr[i];
    }
}