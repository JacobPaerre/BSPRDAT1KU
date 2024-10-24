## Exercise 8.1

### i

```
> run (fromFile "ex11.c") [8];;
1 5 8 6 3 7 2 4
1 6 8 3 7 4 2 5
1 7 4 6 8 2 5 3
1 7 5 8 2 4 6 3
2 4 6 8 3 1 7 5
2 5 7 1 3 8 6 4
2 5 7 4 1 8 6 3
2 6 1 7 4 8 3 5
2 6 8 3 1 4 7 5
2 7 3 6 8 5 1 4
2 7 5 8 1 4 6 3
2 8 6 1 3 5 7 4
3 1 7 5 8 2 4 6
3 5 2 8 1 7 4 6
3 5 2 8 6 4 7 1
3 5 7 1 4 2 8 6
3 5 8 4 1 7 2 6
3 6 2 5 8 1 7 4
3 6 2 7 1 4 8 5
3 6 2 7 5 1 8 4
3 6 4 1 8 5 7 2
3 6 4 2 8 5 7 1
3 6 8 1 4 7 5 2
3 6 8 1 5 7 2 4
3 6 8 2 4 1 7 5
3 7 2 8 5 1 4 6
3 7 2 8 6 4 1 5
3 8 4 7 1 6 2 5
4 1 5 8 2 7 3 6
4 1 5 8 6 3 7 2
4 2 5 8 6 1 3 7
4 2 7 3 6 8 1 5
4 2 7 3 6 8 5 1
4 2 7 5 1 8 6 3
4 2 8 5 7 1 3 6
4 2 8 6 1 3 5 7
4 6 1 5 2 8 3 7
4 6 8 2 7 1 3 5
4 6 8 3 1 7 5 2
4 7 1 8 5 2 6 3
4 7 3 8 2 5 1 6
4 7 5 2 6 1 3 8
4 7 5 3 1 6 8 2
4 8 1 3 6 2 7 5
4 8 1 5 7 2 6 3
4 8 5 3 1 7 2 6
5 1 4 6 8 2 7 3
5 1 8 4 2 7 3 6
5 1 8 6 3 7 2 4
5 2 4 6 8 3 1 7
5 2 4 7 3 8 6 1
5 2 6 1 7 4 8 3
5 2 8 1 4 7 3 6
5 3 1 6 8 2 4 7
5 3 1 7 2 8 6 4
5 3 8 4 7 1 6 2
5 7 1 3 8 6 4 2
5 7 1 4 2 8 6 3
5 7 2 4 8 1 3 6
5 7 2 6 3 1 4 8
5 7 2 6 3 1 8 4
5 7 4 1 3 8 6 2
5 8 4 1 3 6 2 7
5 8 4 1 7 2 6 3
6 1 5 2 8 3 7 4
6 2 7 1 3 5 8 4
6 2 7 1 4 8 5 3
6 3 1 7 5 8 2 4
6 3 1 8 4 2 7 5
6 3 1 8 5 2 4 7
6 3 5 7 1 4 2 8
6 3 5 8 1 4 2 7
6 3 7 2 4 8 1 5
6 3 7 2 8 5 1 4
6 3 7 4 1 8 2 5
6 4 1 5 8 2 7 3
6 4 2 8 5 7 1 3
6 4 7 1 3 5 2 8
6 4 7 1 8 2 5 3
6 8 2 4 1 7 5 3
7 1 3 8 6 4 2 5
7 2 4 1 8 5 3 6
7 2 6 3 1 4 8 5
7 3 1 6 8 5 2 4
7 3 8 2 5 1 6 4
7 4 2 5 8 1 3 6
7 4 2 8 6 1 3 5
7 5 3 1 6 8 2 4
8 2 4 1 7 5 3 6
8 2 5 3 1 7 4 6
8 3 1 6 2 5 7 4
8 4 1 3 6 2 7 5
val it: Interp.store =
  map
    [(0, 8); (1, 0); (2, 9); (3, -999); (4, 0); (5, 0); (6, 0); (7, 0); (8, 0);
     ...]
```

### ii (example 3):

```bash
[LDARGS; CALL (1, "L1"); STOP;
Label "L1";
    INCSP 1;                Declare "i"
    GETBP; CSTI 1; ADD;     Calculate address of next element (&i+1)
    CSTI 0;                 constant 0
    STI;                    store 0 on &i+1
    INCSP -1;               De-allocate ???
    GOTO "L3";
Label "L2";
    GETBP; CSTI 1; ADD;
    LDI;
    PRINTI;
    INCSP -1;
    GETBP; CSTI 1; ADD;
    GETBP; CSTI 1; ADD;
    LDI;
    CSTI 1; ADD;
    STI;                    
    INCSP -1;
    INCSP 0;
Label "L3";
    GETBP; CSTI 1; ADD;     
    LDI;
    GETBP; CSTI 0; ADD;
    LDI;                    load 
    LT;                     i < n
    IFNZRO "L2";            if above is true, run while-loop again
    INCSP -1;
    RET 0]
```

### ii (example 5):

```bash
[LDARGS; CALL (1, "L1"); STOP;
Label "L1";                 main
    INCSP 1;                Declare "r"
    GETBP; CSTI 1; ADD;     
    GETBP; CSTI 0; ADD;     AccVar "r", &r
    LDI;                    Access, r on top of stack.
    STI;
    INCSP -1;
    INCSP 1;
    GETBP; CSTI 0; ADD;
    LDI;
    GETBP; CSTI 2; ADD;
    CALL (2, "L2");
    INCSP -1;
    GETBP; CSTI 2; ADD;
    LDI;
    PRINTI;
    INCSP -1;
    INCSP -1;
    GETBP; CSTI 1; ADD;
    LDI;
    PRINTI;
    INCSP -1;
    INCSP -1;
    RET 0;
Label "L2";                 square-function
    GETBP; CSTI 1; ADD;     find index for *rp
    LDI;                    load *rp
    GETBP; CSTI 0; ADD;     find index for i
    LDI;                    load i
    GETBP; CSTI 0; ADD;     find index for i
    LDI;                    load i
    MUL;                    multiply top 2 elements (i * i)
    STI;                    store value i*i in *rp
    INCSP -1;
    INCSP 0;
    RET 1]
```

## Exercise 8.3

## Exercise 8.4

## Exercise 8.5

## Exercise 8.6
