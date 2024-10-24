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
    INCSP 1;                Declare "i" (allocate space for i)
    GETBP; CSTI 1; ADD;     and calculate address of i (&i)
    CSTI 0;                 put 0 on the stack
    STI;                    i = 0 (store 0 at &i)
    INCSP -1;               remove leftover 0 from stack
    GOTO "L3";
Label "L2";
    GETBP; CSTI 1; ADD;     &i
    LDI;                    load i on top of stack
    PRINTI;                 print i
    INCSP -1;               remove i from stack
    GETBP; CSTI 1; ADD;     &i
    GETBP; CSTI 1; ADD;     &i
    LDI;                    load i on top of stack
    CSTI 1; ADD;            i + 1
    STI;                    store i + 1 in i
    INCSP -1;               remove i + 1 from stack (leftover from store)
    INCSP 0;                dead code
Label "L3";
    GETBP; CSTI 1; ADD;     &i
    LDI;                    load i on top of stack
    GETBP; CSTI 0; ADD;     &n
    LDI;                    load n on top of stack
    LT;                     i < n
    IFNZRO "L2";            if above is true, run while-loop again
    INCSP -1;               if above is false, remove the 0 from stack
    RET 0]                  program termination
```

### ii (example 5):

```bash
[LDARGS; CALL (1, "L1"); STOP;
Label "L1";                 main
    INCSP 1;                Declare "r" (allocate space for r)
    GETBP; CSTI 1; ADD;     and calculate address of r (&r)
    GETBP; CSTI 0; ADD;     calculate address of n (&n)
    LDI;                    load n on top of stack
    STI;                    store n at &r (r = n)
    INCSP -1;               remove n from stack (leftover from store)
    INCSP 1;                Declare new "r" (allocate space for new r)
    GETBP; CSTI 0; ADD;     calculate address of n (&n)
    LDI;                    load n on top of stack
    GETBP; CSTI 2; ADD;     calculate address of the new r (&r)
    CALL (2, "L2");         call square-function with n and &r as arguments
    INCSP -1;               remove pointer to new r from stack (leftover from call)
    GETBP; CSTI 2; ADD;     calculate address of the new r (&r)
    LDI;                    load new r on top of stack
    PRINTI;                 print new r
    INCSP -1;               remove new r from stack (leftover from load after print)
    INCSP -1;               remove original new r from stack (we are done with it)
    GETBP; CSTI 1; ADD;     calculate address of r (&r)
    LDI;                    load r on top of stack
    PRINTI;                 print r
    INCSP -1;               remove r from stack (leftover from load after print)
    INCSP -1;               remove original r from stack (we are done with it)
    RET 0;                  program termination
Label "L2";                 square-function
    GETBP; CSTI 1; ADD;     find address of rp (pointer to new r in block in main)
    LDI;                    load *rp on top of stack
    GETBP; CSTI 0; ADD;     find index for i (n in block in main)
    LDI;                    load i
    GETBP; CSTI 0; ADD;     find index for i
    LDI;                    load i
    MUL;                    multiply top 2 elements (i * i)
    STI;                    store value i*i in *rp (*rp = i*i)
    INCSP -1;               remove i*i from stack (leftover from store)
    INCSP 0;                dead code
    RET 1]                  return to main with 1 value (*rp)
```

"Note that ex5.c has a nested scope (a block ... inside a function body); how is that visible in the generated code?"

It is not really visible in the generated code. The reason for this is, that the code doesn't really care about the name of the variables, but only about their addresses. The addresses are calculated based on the current base pointer and just continue on top of the current stack. The allocated space in the block is "deleted" afterwards by adjusting the stack pointer.

## Exercise 8.3

## Exercise 8.4

## Exercise 8.5

## Exercise 8.6
