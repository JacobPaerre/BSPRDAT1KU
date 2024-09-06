# Questions

## Question 1: What are the regular expressions involved, and which semantic values are they associated with?

2 regular expressions:

- match any single digit character from 0 to 9
- match anything and fail with illegal symbol

## Question 2: How many states are there by the automaton of the lexer?

For `hello.fsl` there are 3 states generated.

## Question 6: Consider the 3 examples of input provided at the prompt and the result. Explain why the results are expected behavior from the lexer.

The first input `34` is matched by the regular expression defined in the lexer, which is why the lexer recognizes this. It matches any digit one or more times.

The second input `34.24` is also matched properly by the regex in the lexer. The regex has a `.` that can be used to make the integer a float. It matches zero or more digits before a `.` and one or more digit after.

The last input `34,34` is recognized as `34` due to the regex not matching the `,`-symbol. When it meets this symbol the lexer then stops matching.
