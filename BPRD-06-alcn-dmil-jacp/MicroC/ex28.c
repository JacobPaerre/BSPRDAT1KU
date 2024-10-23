//Exercise 7.2 - To understand the use of parameter passing

void main(int n) {
    int r;
    
    if (n < 5 || n > 20) 
        play (n, &r);
    else {
         while (n > 5) {
             play (n, &r);
             n = n-1;
         }
    }
}

void play(int i, int *p) {
    *p = i * 2;
    print *p - 1;
}