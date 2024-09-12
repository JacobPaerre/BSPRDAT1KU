# Exercise 3.3: Write the rightmost derivation of the string

| **Rule** | **Derived expression**                                                    |
| -------- | ------------------------------------------------------------------------- |
| A        | Expr EOF                                                                  |
| F        | **LET NAME EQ Expr IN Expr END** EOF                                      |
| G        | LET NAME EQ Expr IN **Expr TIMES Expr** END EOF                           |
| C        | LET NAME EQ Expr In EXPR TIMES **CSTINT** END EOF                         |
| H        | LET NAME EQ Expr IN **Expr PLUS Expr** TIMES CSTINT END EOF               |
| C        | LET NAME EQ Expr IN Expr PLUS **CSTINT** TIMES CSTINT END EOF             |
| B        | LET NAME EQ Expr IN **NAME** PLUS CSTINT TIMES CSTINT END EOF             |
| E        | LET NAME EQ **LPAR Expr RPAR** IN NAME PLUS CSTINT TIMES CSTINT END EOF   |
| C        | LET NAME EQ LPAR **CSTINT** RPAR IN NAME PLUS CSTINT TIMES CSTINT END EOF |
|          | LET NAME EQ LPAR CSTINT RPAR IN NAME PLUS CSTINT TIMES CSTINT END EOF     |

## With conversions:

| **Rule** | **Derived expression**                       |
| -------- | -------------------------------------------- |
| A        | Expr EOF                                     |
| F        | **LET z = Expr IN Expr END** EOF             |
| G        | LET z = Expr IN **Expr \* Expr** END EOF     |
| C        | LET z = Expr In EXPR \* **3** END EOF        |
| H        | LET z = Expr IN **Expr + Expr** \* 3 END EOF |
| C        | LET z = Expr IN Expr + **2** \* 3 END EOF    |
| B        | LET z = Expr IN **z** + 2 \* 3 END EOF       |
| E        | LET z = **( Expr )** IN z + 3 \* 3 END EOF   |
| C        | LET z = ( **17** ) IN z + 2 \* 3 END EOF     |
|          | LET z = ( 17 ) IN z + 2 \* 3 END EOF         |

# Exercise 3.4: Draw the Tree
