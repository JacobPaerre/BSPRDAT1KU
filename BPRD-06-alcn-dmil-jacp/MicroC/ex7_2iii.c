//Exersice 7.2iii


//main declares and allocates the array freq, parse it to histogram, and
//prints the contents of array freq after calling histogram.
void main () {
    int arr[7];
    int freq[4];
    arr[0] = 1;
    arr[1] = 2;
    arr[2] = 1;
    arr[3] = 1;
    arr[4] = 1;
    arr[5] = 2;
    arr[6] = 0;
    
    histogram(7, arr, 3, freq);
    
    int i;
    i = 0;
    while (i < 4) {
        print freq[i];
        i = i + 1;
    }
}

/*
histogram fills array freq the frequencies of the numbers in array ns. 
More precisely, when the function returns, element freq[c] must equal the number of times 
that value c appears among the first n elements of arr, for 0<=c<=max. 
Assume that all numbers in ns are between 0 and max, inclusive.

Example: if the main function creates an array arr holding the seven numbers 1 2 1 1 1 2 0 
and calls histogram(7, arr, 3, freq), then afterwards freq[0] is 1, freq[1] is 4, freq[2] is 2, and freq[3] is 0.
Of course, freq must be an array with at least four elements. What happens if it is not?

Answer: Since the max value for the numbers in the array is 3 in the example, 
the array of numbers might include some 3's and which should be registered at index 3 in freq. 
To make sure that we do not access memory outside the array, freq must have at least max-1 elements (in this case 4).
*/


void histogram(int n, int ns[], int max, int freq[]) {
    int i;
    i = 0;
    while (i <= max) {
        freq[i] = 0;
        i = i + 1;
    }
    
    i = 0;
    while (i < n) {
        freq[ns[i]] = freq[ns[i]] + 1;
        i = i + 1;
    }
}