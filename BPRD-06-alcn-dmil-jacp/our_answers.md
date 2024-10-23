## Exercise 7.1

```
> fromFile "ex1.c";;
val it: Absyn.program =
  Prog
    [Fundec
       (None, "main", [(TypI, "n")],
        Block
          [Stmt
             (While
                (Prim2 (">", Access (AccVar "n"), CstI 0),
                 Block
                   [Stmt (Expr (Prim1 ("printi", Access (AccVar "n"))));
                    Stmt
                      (Expr
                         (Assign
                            (AccVar "n",
                             Prim2 ("-", Access (AccVar "n"), CstI 1))))]));
           Stmt (Expr (Prim1 ("printc", CstI 10)))])]
```

Declarations:

- Fundec (Function declaration)

Statements:

- While ... (While loop)
- Expr ... (Expression statement)
- Block ... (grouping and scope)

Types:

- TypI n (n has type int)

Expressions:

- Prim2 (">", Access (AccVar "n"), CstI 0) (Binary primitive operator ie. n>0)
- Access (AccVar "n") (Variable access of n)
- CstI 0 (Constant 0)
- Prim1 ("printi", Access (AccVar "n")) (Unary primitive operator ie. print n)
- Assign (AccVar "n", Prim2 ("-", Access (AccVar "n"), CstI 1)) (Assign variable n = n-1)
- Prim2 ("-", Access (AccVar "n"), CstI 1) (Binary primitive operator ie. n-1)
- CstI 1 (Constant 1)
- Prim1 ("printc", CstI 10) (Unary primitive operator ie. println)
- CstI 10 (Constant 10)

```
> run (fromFile "ex1.c") [17];;
17 16 15 14 13 12 11 10 9 8 7 6 5 4 3 2 1
val it: Interp.store = map [(0, 0)]
```

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

## Exercise 7.2

### i: Se ex7_2i.c

```
> run (fromFile "ex7_2i.c") [];;
37 val it: Interp.store =
  map
    [(0, 7); (1, 13); (2, 9); (3, 8); (4, 0); (5, 37); (6, 4); (7, 0); (8, 5);
     ...]

```

### ii: Se ex7_2ii

```
> run (fromFile "ex7_2ii.c") [10];;
285 val it: Interp.store =
  map
    [(0, 10); (1, 0); (2, 1); (3, 4); (4, 9); (5, 16); (6, 25); (7, 36);
     (8, 49); ...]
```

### iii: Se ex7_2iii

```
> run (fromFile "ex7_2iii.c") [];;
1 4 2 0 val it: Interp.store =
  map
    [(0, 1); (1, 2); (2, 1); (3, 1); (4, 1); (5, 2); (6, 0); (7, 0); (8, 1);
     ...]
```

### Exercise 7.3

Vi har også rettet i `CLex.fsl` og `CPar.fsy`. Der er en kommentar, der markerer, hvor det er.

### i: Se ex7_3i.c

```
> run (fromFile "ex7_3i.c") [];;
37 val it: Interp.store =
  map

    [(0, 7); (1, 13); (2, 9); (3, 8); (4, 0); (5, 37); (6, 4); (7, 0); (8, 5);
     ...]
```

### ii: Se ex7_3ii.c

```
> run (fromFile "ex7_3ii.c") [10];;
285 val it: Interp.store =
  map

    [(0, 10); (1, 0); (2, 1); (3, 4); (4, 9); (5, 16); (6, 25); (7, 36);
     (8, 49); ...]
```

### iii: Se ex7_3iii.c:

```
> run (fromFile "ex7_3iii.c") [];;
1 4 2 0 val it: Interp.store =
  map
    [(0, 1); (1, 2); (2, 1); (3, 1); (4, 1); (5, 2); (6, 0); (7, 0); (8, 1);
     ...]
```

### Exercise 7.4

Changes findes in `Absyn.fs` og `Interp.fs`

### Exercise 7.5

Ændringer can be found i `CLex.fsl` and `CPar.fsy`

Der er også lavet en testcase i `ex7_5.c` :)
