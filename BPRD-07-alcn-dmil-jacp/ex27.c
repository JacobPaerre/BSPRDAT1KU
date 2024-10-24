//Exercise 7.2 - To understand the use of pointer arithmetics

void main() {
    int *p;                               // pointer to int
    int i;                                // int
    int j;                                // int

    i = 13;
    j = 21;
    p = &i;                               // now p points to i

    print i;
    print j;
    print p;                             // prints the address that p points to (the address of i ie. &i)
    print *p;                            // prints the value of what p points to (i)

    *p = i + 2;                           // i is changed to i+2 = 15
    p = &j;                                // now p points to j
    *p = j-2;                             // j is changed to 5

    print 99;                             //print 99 to easily locate the prints after the changes
    print i;
    print j;
    print p;
    print *p;

    p = &j-1;                            // now p points to the address before the address of j (i)
    i = j-5;                            // i is changed to the value j-5

    print 98;                           //print 98 to easily locate the prints after the changes
    print i;
    print j;
    print p;
    print *p;                            
}
