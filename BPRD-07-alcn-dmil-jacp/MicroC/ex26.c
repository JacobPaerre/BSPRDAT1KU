//Exercise 7.2 - to understand the use of arrays

int a[10];

void main(int n) { 
    int i; 
    i = 0; 
    int f;
    f = 0;
    while (i < 10) {
        a[i] = f;
        i = i + 1;
        f = f + n;
    }
    printarr(10, a);
}

void printarr(int len, int a[]) {
    int i; 
    i = 0; 
    while (i < len) { 
        print a[i]; 
        i=i+1; 
    }
}
