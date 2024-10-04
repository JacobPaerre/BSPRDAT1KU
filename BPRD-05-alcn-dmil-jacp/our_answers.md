### Til exercise 5.1 er det hele mappen, der er lavet af os.

### Til exercise 5.7 er der kommentarer i TypedFun, der viser, hvad vi har lavet.

# Exercise 6.1

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
