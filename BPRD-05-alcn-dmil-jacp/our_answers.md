### Exercise 5.1: Det er hele mappen, der er lavet af os.

### Exercise 5.7: Der er kommentarer i TypedFun, der viser, hvad vi har lavet.

### Exercise 6.1

```
let add x = let f y = x+y in f end
in add 2 5 end
```

- Resultat: 7

```
let add x = let f y = x+y in f end
in let addtwo = add 2
in addtwo 5 end
end
```

- Resultat: 7

```
let add x = let f y = x+y in f end
in let addtwo = add 2
in let x = 77 in addtwo 5 end
end
end
```

- Resultat: 7
- Dette er som forventet, da scopet er anderledes når vi kører `let x = 77`. ´x´ er 2 i `addtwo`-closuren, hvorfor 7 er et forventet resultat, og at den ikke bruger den nydefinerede variabel `x = 77`.

```
let add x = let f y = x+y in f end
in add 2 end
```

- Dette returnerer bare en funktion/closure/partially applied function. Her får vi et environment, hvor der er vores `x`-variabel, der har værdien 2, og vi får en `add`, der har en closure.

### Exercise 6.3: Ændringer i `Absyn.fs` og `HigherFun.fs` er markeret med kommentar om at det er til denne exercise.

### Exercise 6.5a:

```
> inferType (fromString "let f x = 1 in f f end");;
val it: string = "int"
```

```
> inferType (fromString "let f g = g g in f end");;
System.Exception: type error: circularity
```
Vi får en cirkularitetsfejl, fordi `g` bliver anvendt på sig selv, hvilket ikke er tilladt.

```
> inferType (fromString "let f x = let g y = y in g false end in f 42 end");;
val it: string = "bool"
```

```
> inferType (fromString "let f x = let g y = if true then y else x in g false end in f 42 end");;
System.Exception: type error: bool and int
```
Vi får en typefejl, fordi `g` bliver anvendt på både en `bool` og en `int`, hvilket ikke er tilladt.

```
> inferType (fromString "let f x = let g y = if true then y else x in g false end in f true end");;
val it: string = "bool"
```

### Exercise 6.5b:

1.

```
> inferType (fromString "let f x = if x then true else false in f end");;
val it: string = "(bool -> bool)"
```

2.

```
> inferType (fromString "let f x = x+x in f end");;
val it: string = "(int -> int)"
```

3.

```
> inferType (fromString "let f x = let g y = x + y in g end in f end");;
val it: string = "(int -> (int -> int))"
```

4.

```
> inferType (fromString "let f x = let g y = x in g end in f end");;
val it: string = "('h -> ('g -> 'h))"
```

5.

```
> inferType (fromString "let f x = let g y = y in g end in f end");;
val it: string = "('g -> ('h -> 'h))"
```

6.

```
> inferType (fromString "let f a = let g h = let i x = h (a x) in i end in g end in f end");;
val it: string = "(('l -> 'k) -> (('k -> 'm) -> ('l -> 'm)))"
```

7.

```
> inferType (fromString "let f x = f x in f end");;
val it: string = "('e -> 'f)"
```

8.

```
> inferType (fromString "let f x = f x in f f end");;
val it: string = "'f"
```
