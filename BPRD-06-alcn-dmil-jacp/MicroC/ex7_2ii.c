//Exersice 7.2ii

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

//Given n and an array arr of length n or more, 
//squares fills arr[i] with i*i for i = 0,..., n − 1.
void squares(int n, int arr[]) {
    int i;
    i = 0;
    while (i < n) {
        arr[i] = i * i;
        i = i + 1;
    }
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