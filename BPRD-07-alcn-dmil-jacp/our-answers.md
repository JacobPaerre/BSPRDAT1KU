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

### Execute & Trace:

```bash
$ java Machine ex3.out 4
0 1 2 3
Ran 0.042 seconds
```

```zsh
$ java Machinetrace ex3.out 4
[ ]{0: LDARGS}                      # loader argumenter ind i stacken
[ 4 ]{1: CALL 1 5}                  # kalder metoden på placering 5 (main) med 1 argument (4)
[ 4 -999 4 ]{5: INCSP 1}            # øger sp med 1 for at gøre plads til i (int i)
[ 4 -999 4 0 ]{7: GETBP}            # finder base pointer (index 2)
[ 4 -999 4 0 2 ]{8: CSTI 1}         # tilføjer 1 til stacken
[ 4 -999 4 0 2 1 ]{10: ADD}         # plusser de 2 øverste elementer (2+1 = 3)
[ 4 -999 4 0 3 ]{11: CSTI 0}        # tilføjer 0 til stacken
[ 4 -999 4 0 3 0 ]{13: STI}         # store 0 på index 3 (i = 0)
[ 4 -999 4 0 0 ]{14: INCSP -1}      # skrumper stacken med 1 (fjern øverste 0)
[ 4 -999 4 0 ]{16: GOTO 43}         # gå til while-loopet
[ 4 -999 4 0 ]{43: GETBP}           # find base pointer (index 2)
[ 4 -999 4 0 2 ]{44: CSTI 1}        # tilføj 1 til stacken
[ 4 -999 4 0 2 1 ]{46: ADD}         # plus øverste elementer (for at finde ud af, hvad i's adresse er)
[ 4 -999 4 0 3 ]{47: LDI}           # load hvadend, der står på index 3 (i)
[4 -999 4 0 0 ]{48: GETBP}          # find base pointer
[ 4 -999 4 0 0 2 ]{49: CSTI 0}      # tilføj 0 til stacken
[ 4 -999 4 0 0 2 0 ]{51: ADD}       # plus 2 øverste elementer
[ 4 -999 4 0 0 2 ]{52: LDI}         # load hvadend, der står på index 2 (n)
[4 -999 4 0 0 4 ]{53: LT}           # tjek om index 3 eller mindre end index 2 (i < n)
[ 4 -999 4 0 1 ]{54: IFNZRO 18}     # hvis i ikke er mindre end n gå til 18 (i er  mindre end n her)
[ 4 -999 4 0 ]{18: GETBP}           # find base pointer
[ 4 -999 4 0 2 ]{19: CSTI 1}        # tilføj 1 til stacken
[ 4 -999 4 0 2 1 ]{21: ADD}         # plus 2 øverste elementer
[ 4 -999 4 0 3 ]{22: LDI}           # load hvadend, der står på index 3 (i)
[ 4 -999 4 0 0 ]{23: PRINTI}        # print det, der står på index 3 (i = 0)
0 [ 4 -999 4 0 0 ]{24: INCSP -1}    # skrump stack pointer med 1
[ 4 -999 4 0 ]{26: GETBP}           # find base pointer
[ 4 -999 4 0 2 ]{27: CSTI 1}        # tilføj 1 til stacken
[ 4 -999 4 0 2 1 ]{29: ADD}         # plus 2 øverste elementer
[ 4 -999 4 0 3 ]{30: GETBP}         # find base pointer
[ 4 -999 4 0 3 2 ]{31: CSTI 1}      # tilføj 1 til stacken
[ 4 -999 4 0 3 2 1 ]{33: ADD}       # plus 2 øverste elementer
[ 4 -999 4 0 3 3 ]{34: LDI}         # load index 3 (i = 0)
[ 4 -999 4 0 3 0 ]{35: CSTI 1}      # tilføj 1 til stacken
[ 4 -999 4 0 3 0 1 ]{37: ADD}       # plus 2 øverste elementer (værdi på index 3 (i = 0) + 1)
[ 4 -999 4 0 3 1 ]{38: STI}         # store det vi finder lige oppe over på index 3 (i), så vi har linje 8 (i = i + 1)
[ 4 -999 4 1 1 ]{39: INCSP -1}      # skrump stack pointer med 1 (fjern det vi lige har storet fra stacken)
[ 4 -999 4 1 ]{41: INCSP 0}
[ 4 -999 4 1 ]{43: GETBP}           # herfra gør vi det samme igen, hvor vi nu er ved starten af while-loopet og loader først i, så n og tjekker om i < n for derefter at printe i og øge i med 1 indtil at i < n :)
[ 4 -999 4 1 2 ]{44: CSTI 1}
[ 4 -999 4 1 2 1 ]{46: ADD}
[ 4 -999 4 1 3 ]{47: LDI}
[ 4 -999 4 1 1 ]{48: GETBP}
[ 4 -999 4 1 1 2 ]{49: CSTI 0}
[ 4 -999 4 1 1 2 0 ]{51: ADD}
[ 4 -999 4 1 1 2 ]{52: LDI}
[ 4 -999 4 1 1 4 ]{53: LT}
[ 4 -999 4 1 1 ]{54: IFNZRO 18}
[ 4 -999 4 1 ]{18: GETBP}
[ 4 -999 4 1 2 ]{19: CSTI 1}
[ 4 -999 4 1 2 1 ]{21: ADD}
[ 4 -999 4 1 3 ]{22: LDI}
[ 4 -999 4 1 1 ]{23: PRINTI}
1 [ 4 -999 4 1 1 ]{24: INCSP -1}
[ 4 -999 4 1 ]{26: GETBP}
[ 4 -999 4 1 2 ]{27: CSTI 1}
[ 4 -999 4 1 2 1 ]{29: ADD}
[ 4 -999 4 1 3 ]{30: GETBP}
[ 4 -999 4 1 3 2 ]{31: CSTI 1}
[ 4 -999 4 1 3 2 1 ]{33: ADD}
[ 4 -999 4 1 3 3 ]{34: LDI}
[ 4 -999 4 1 3 1 ]{35: CSTI 1}
[ 4 -999 4 1 3 1 1 ]{37: ADD}
[ 4 -999 4 1 3 2 ]{38: STI}
[ 4 -999 4 2 2 ]{39: INCSP -1}
[ 4 -999 4 2 ]{41: INCSP 0}
[ 4 -999 4 2 ]{43: GETBP}
[ 4 -999 4 2 2 ]{44: CSTI 1}
[ 4 -999 4 2 2 1 ]{46: ADD}
[ 4 -999 4 2 3 ]{47: LDI}
[ 4 -999 4 2 2 ]{48: GETBP}
[ 4 -999 4 2 2 2 ]{49: CSTI 0}
[ 4 -999 4 2 2 2 0 ]{51: ADD}
[ 4 -999 4 2 2 2 ]{52: LDI}
[ 4 -999 4 2 2 4 ]{53: LT}
[ 4 -999 4 2 1 ]{54: IFNZRO 18}
[ 4 -999 4 2 ]{18: GETBP}
[ 4 -999 4 2 2 ]{19: CSTI 1}
[ 4 -999 4 2 2 1 ]{21: ADD}
[ 4 -999 4 2 3 ]{22: LDI}
[ 4 -999 4 2 2 ]{23: PRINTI}
2 [ 4 -999 4 2 2 ]{24: INCSP -1}
[ 4 -999 4 2 ]{26: GETBP}
[ 4 -999 4 2 2 ]{27: CSTI 1}
[ 4 -999 4 2 2 1 ]{29: ADD}
[ 4 -999 4 2 3 ]{30: GETBP}
[ 4 -999 4 2 3 2 ]{31: CSTI 1}
[ 4 -999 4 2 3 2 1 ]{33: ADD}
[ 4 -999 4 2 3 3 ]{34: LDI}
[ 4 -999 4 2 3 2 ]{35: CSTI 1}
[ 4 -999 4 2 3 2 1 ]{37: ADD}
[ 4 -999 4 2 3 3 ]{38: STI}
[ 4 -999 4 3 3 ]{39: INCSP -1}
[ 4 -999 4 3 ]{41: INCSP 0}
[ 4 -999 4 3 ]{43: GETBP}
[ 4 -999 4 3 2 ]{44: CSTI 1}
[ 4 -999 4 3 2 1 ]{46: ADD}
[ 4 -999 4 3 3 ]{47: LDI}
[ 4 -999 4 3 3 ]{48: GETBP}
[ 4 -999 4 3 3 2 ]{49: CSTI 0}
[ 4 -999 4 3 3 2 0 ]{51: ADD}
[ 4 -999 4 3 3 2 ]{52: LDI}
[ 4 -999 4 3 3 4 ]{53: LT}
[ 4 -999 4 3 1 ]{54: IFNZRO 18}
[ 4 -999 4 3 ]{18: GETBP}
[ 4 -999 4 3 2 ]{19: CSTI 1}
[ 4 -999 4 3 2 1 ]{21: ADD}
[ 4 -999 4 3 3 ]{22: LDI}
[ 4 -999 4 3 3 ]{23: PRINTI}
3 [ 4 -999 4 3 3 ]{24: INCSP -1}
[ 4 -999 4 3 ]{26: GETBP}
[ 4 -999 4 3 2 ]{27: CSTI 1}
[ 4 -999 4 3 2 1 ]{29: ADD}
[ 4 -999 4 3 3 ]{30: GETBP}
[ 4 -999 4 3 3 2 ]{31: CSTI 1}
[ 4 -999 4 3 3 2 1 ]{33: ADD}
[ 4 -999 4 3 3 3 ]{34: LDI}
[ 4 -999 4 3 3 3 ]{35: CSTI 1}
[ 4 -999 4 3 3 3 1 ]{37: ADD}
[ 4 -999 4 3 3 4 ]{38: STI}
[ 4 -999 4 4 4 ]{39: INCSP -1}
[ 4 -999 4 4 ]{41: INCSP 0}
[ 4 -999 4 4 ]{43: GETBP}
[ 4 -999 4 4 2 ]{44: CSTI 1}
[ 4 -999 4 4 2 1 ]{46: ADD}
[ 4 -999 4 4 3 ]{47: LDI}
[ 4 -999 4 4 4 ]{48: GETBP}
[ 4 -999 4 4 4 2 ]{49: CSTI 0}
[ 4 -999 4 4 4 2 0 ]{51: ADD}
[ 4 -999 4 4 4 2 ]{52: LDI}
[ 4 -999 4 4 4 4 ]{53: LT}
[ 4 -999 4 4 0 ]{54: IFNZRO 18}
[ 4 -999 4 4 ]{56: INCSP -1}
[ 4 -999 4 ]{58: RET 0}
[ 4 ]{4: STOP}

Ran 0.18 seconds
```

```zsh
$ java Machine ex5.out 4
16 4
Ran 0.019 seconds
```

```zsh
$ java Machinetrace ex5.out 4
[ ]{0: LDARGS}                          # load cli argumenter
[ 4 ]{1: CALL 1 5}                      # kald 5 (main) med 1 argument
[ 4 -999 4 ]{5: INCSP 1}                # øg sp med 1: gør plads til r
[ 4 -999 4 0 ]{7: GETBP}                # find base pointer
[ 4 -999 4 0 2 ]{8: CSTI 1}             # tilføj 1 til stacken
[ 4 -999 4 0 2 1 ]{10: ADD}             # plus 2 øverste elementer: find index-placering for r
[ 4 -999 4 0 3 ]{11: GETBP}             # find base pointer
[ 4 -999 4 0 3 2 ]{12: CSTI 0}          # tilføj 0 til stacken
[ 4 -999 4 0 3 2 0 ]{14: ADD}           # plus 2 øverste elementer: find index-placering for n
[ 4 -999 4 0 3 2 ]{15: LDI}             # load n's værdi
[ 4 -999 4 0 3 4 ]{16: STI}             # store den loadede værdi på index-placeringen for r
[ 4 -999 4 4 4 ]{17: INCSP -1}          # skrump sp med 1 (fjern værdien 4 (den værdi vi lige har storet))
[ 4 -999 4 4 ]{19: INCSP 1}             # øg sp med 1: gør plads til int r inde i blocken
[ 4 -999 4 4 4 ]{21: GETBP}             # find base pointer
[ 4 -999 4 4 4 2 ]{22: CSTI 0}          # tilføj 0 til stacken
[ 4 -999 4 4 4 2 0 ]{24: ADD}           # plus 2 øverste elementer: find index-placering for n
[ 4 -999 4 4 4 2 ]{25: LDI}             # load værdi for n
[ 4 -999 4 4 4 4 ]{26: GETBP}           # find base pointer
[ 4 -999 4 4 4 4 2 ]{27: CSTI 2}        # tilføj 2 til stacken
[ 4 -999 4 4 4 4 2 2 ]{29: ADD}         # plus 2 øverste elementer: find index-placering for r inde i vores block
[ 4 -999 4 4 4 4 4 ]{30: CALL 2 57}     # kald 57 (square) med 2 argumenter (n og placering for r)
[ 4 -999 4 4 4 33 2 4 4 ]{57: GETBP}    # find base pointer
[ 4 -999 4 4 4 33 2 4 4 7 ]{58: CSTI 1} # tilføj 1 til stacken
[ 4 -999 4 4 4 33 2 4 4 7 1 ]{60: ADD}  # plus 2 øverste elementer: find index-placering for *rp
[ 4 -999 4 4 4 33 2 4 4 8 ]{61: LDI}    # load værdi for rp
[ 4 -999 4 4 4 33 2 4 4 4 ]{62: GETBP}  # find base pointer
[ 4 -999 4 4 4 33 2 4 4 4 7 ]{63: CSTI 0}   # tilføj 0 til stacken
[ 4 -999 4 4 4 33 2 4 4 4 7 0 ]{65: ADD}    # plus 2 øverste elementer: find index-placering for i
[ 4 -999 4 4 4 33 2 4 4 4 7 ]{66: LDI}  # load værdi for i
[ 4 -999 4 4 4 33 2 4 4 4 4 ]{67: GETBP}    # find base pointer
[ 4 -999 4 4 4 33 2 4 4 4 4 7 ]{68: CSTI 0} # tilføj 0 til stacken
[ 4 -999 4 4 4 33 2 4 4 4 4 7 0 ]{70: ADD}  # plus 2 øverste elementer: find index-placering for i
[ 4 -999 4 4 4 33 2 4 4 4 4 7 ]{71: LDI}    # load i
[ 4 -999 4 4 4 33 2 4 4 4 4 4 ]{72: MUL}    # gang de øverste elementer: i * i
[ 4 -999 4 4 4 33 2 4 4 4 16 ]{73: STI} # store den værdi vi lige har fundet ovenfor i værdien for *rp.
[ 4 -999 4 4 16 33 2 4 4 16 ]{74: INCSP -1} # skrump sp med 1: fjern den værdi vi har storet fra stacken
[ 4 -999 4 4 16 33 2 4 4 ]{76: INCSP 0}
[ 4 -999 4 4 16 33 2 4 4 ]{78: RET 1}   # return adressen til r
[ 4 -999 4 4 16 4 ]{33: INCSP -1}       # skrump sp med 1: fjern adressen for r
[ 4 -999 4 4 16 ]{35: GETBP}            # find base pointer
[ 4 -999 4 4 16 2 ]{36: CSTI 2}         # tilføj 2 til stacken
[ 4 -999 4 4 16 2 2 ]{38: ADD}          # plus 2 øverste elementer: find index-placering for r inde i vores block
[ 4 -999 4 4 16 4 ]{39: LDI}            # load værdien for r i vores block
[ 4 -999 4 4 16 16 ]{40: PRINTI}        # print værdien for r
16 [ 4 -999 4 4 16 16 ]{41: INCSP -1}   # skrump stacken med 1: fjern værdien for r
[ 4 -999 4 4 16 ]{43: INCSP -1}         # skrump stacken med 1: fjern værdien for r (igen)
[ 4 -999 4 4 ]{45: GETBP}               # find base pointer
[ 4 -999 4 4 2 ]{46: CSTI 1}            # tilføj 1 til stacken
[ 4 -999 4 4 2 1 ]{48: ADD}             # plus 2 øverste elementer: find adressen for r i vores main-metode - ikke i block længere,
[ 4 -999 4 4 3 ]{49: LDI}               # load værdi for r
[ 4 -999 4 4 4 ]{50: PRINTI}            # print værdi for r
4 [ 4 -999 4 4 4 ]{51: INCSP -1}        # skrump stack med 1: fjern værdi for r fra stacken
[ 4 -999 4 4 ]{53: INCSP -1}            # skrump stacken med 1: fjern int r
[ 4 -999 4 ]{55: RET 0}                 # main returnerer 0 (default), og metoden er kørt færdig.
[ 4 ]{4: STOP}                          # program død.

Ran 0.14 seconds
```

## Exercise 8.3
Code changes in `Comp.fs` marked with "Exercise 8.3"

Examples functions can be found in `ex8_3i.c` and `ex8_3ii.c`.
```bash
> compileToFile (fromFile "ex8_3i.c") "ex8_3i.out";;
val it: Machine.instr list =
  [LDARGS; CALL (0, "L1"); STOP; Label "L1"; INCSP 1; GETBP; CSTI 0; ADD;
   CSTI 0; STI; INCSP -1; INCSP 1; GETBP; CSTI 1; ADD; GETBP; CSTI 0; ADD; DUP;
   LDI; CSTI 1; ADD; STI; STI; INCSP -1; GETBP; CSTI 0; ADD; LDI; PRINTI;
   INCSP -1; GETBP; CSTI 1; ADD; LDI; PRINTI; INCSP -1; INCSP -2; RET -1]
```
```bash
$ java Machine ex8_3i.out
1 1
```

```bash
> compileToFile (fromFile "ex8_3ii.c") "ex8_3ii.out";;
val it: Machine.instr list =
  [LDARGS; CALL (0, "L1"); STOP; Label "L1"; INCSP 3; GETSP; CSTI 2; SUB;
   GETBP; CSTI 3; ADD; LDI; CSTI 0; ADD; CSTI 2; STI; INCSP -1; GETBP; CSTI 3;
   ADD; LDI; CSTI 1; ADD; CSTI 4; STI; INCSP -1; GETBP; CSTI 3; ADD; LDI;
   CSTI 2; ADD; CSTI 6; STI; INCSP -1; INCSP 1; GETBP; CSTI 4; ADD; CSTI 0;
   STI; INCSP -1; INCSP 1; GETBP; CSTI 5; ADD; GETBP; CSTI 3; ADD; LDI; GETBP;
   CSTI 4; ADD; DUP; LDI; CSTI 1; ADD; STI; ADD; DUP; LDI; CSTI 1; ADD; STI;
   STI; INCSP -1; GETBP; CSTI 5; ADD; LDI; PRINTI; INCSP -1; INCSP -6; RET -1]
```

```bash
$ java Machine ex8_3ii.out
5
```

## Exercise 8.4
```bash
> compileToFile (fromFile "ex8.c") "ex8.out";;
val it: Machine.instr list =
[LDARGS; CALL (0, "L1"); STOP; 
Label "L1"; 
    INCSP 1; 
    GETBP; CSTI 0; ADD;
    CSTI 20000000; 
    STI; 
    INCSP -1; 
    GOTO "L3"; 
Label "L2"; 
    GETBP; CSTI 0; ADD;
    GETBP; CSTI 0; ADD; 
    LDI; 
    CSTI 1; 
    SUB; 
    STI; 
    INCSP -1; 
    INCSP 0; 
Label "L3";
    GETBP; CSTI 0; ADD; 
    LDI; 
    IFNZRO "L2"; 
    INCSP -1; 
    RET -1
]
```

`prog1` contains `0 20000000 16 7 0 1 2 9 18 4 25` which translates to the symbolic bytecode:

```bash
CSTI 20000000
GOTO 7
CSTI 1         # 4
SUB
DUP            # 7
IFNZRO 4
STOP
```

`prog1` is much much faster because it does both the conditional and subtraction directly on the stack without storing and loading the value multiples times of i for every iteration.

```bash 
> compileToFile (fromFile "ex13.c") "ex13.out";;
val it: Machine.instr list =
[LDARGS; CALL (1, "L1"); STOP; 
    Label "L1"; 
    INCSP 1; 
    GETBP; CSTI 1; ADD;
    CSTI 1889; 
    STI; 
    INCSP -1; 
    GOTO "L3"; 
Label "L2"; 
    GETBP; CSTI 1; ADD; 
    GETBP; CSTI 1; ADD; 
    LDI; 
    CSTI 1; 
    ADD; 
    STI; 
    INCSP -1; 
    GETBP; CSTI 1; ADD; 
    LDI;
    CSTI 4; 
    MOD; 
    CSTI 0; 
    EQ; 
    IFZERO "L7"; 
    GETBP; CSTI 1; ADD; 
    LDI; 
    CSTI 100;
    MOD; 
    CSTI 0; 
    EQ; 
    NOT; 
    IFNZRO "L9"; 
    GETBP; CSTI 1; ADD; 
    LDI; 
    CSTI 400; 
    MOD;
    CSTI 0; 
    EQ; 
    GOTO "L8"; 
Label "L9"; 
    CSTI 1; 
Label "L8"; 
    GOTO "L6";
Label "L7"; 
    CSTI 0; 
Label "L6"; 
    IFZERO "L4"; 
    GETBP; CSTI 1; ADD; 
    LDI;
    PRINTI; 
    INCSP -1; 
    GOTO "L5"; 
Label "L4"; 
    INCSP 0; 
Label "L5";
    INCSP 0;
Label "L3"; 
    GETBP; CSTI 1; ADD; 
    LDI; 
    GETBP; CSTI 0; ADD; 
    LDI; 
    LT;
    IFNZRO "L2"; 
    INCSP -1; 
    RET 0
]
```

The combination of the loop and the conditionals result in a very complicated compilation with a bunch of labels.\
`L3` represents the conditional of the while-loop.\
`L6` represents the body of the if-statement which the code is directed to with a different value 1 or 0 on top of the stack depending on the result of the preceding conditional.\
Labels are created for every branch of the combined conditional in the if-statement despite the different cases resulting in the same destination in the code.


## Exercise 8.5

Code changes in `CLex.fsl`, `CPar.fsy`, `Absyn.fs` and `Comp.fs` marked with "Exercise 8.5".\
Example MicroC functions can be found in `ex8_5i.c` and `ex8_5ii.c`

## Exercise 8.6

Code changes in `CLex.fsl`, `CPar.fsy`, `Absyn.fs` and `Comp.fs` marked with "Exercise 8.6".\
Example MicroC functions can be found in `ex8_6.c`.