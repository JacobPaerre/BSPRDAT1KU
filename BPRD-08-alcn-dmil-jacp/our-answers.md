# Exercises: 9.1 and 9.2 or 9.3

## Exercise 9.1

### i

See comments in the file `Selsort/Selsort.il`.

### ii

Se kommentarer i filen `Selsort/Selsort.jvmbytecode`

## Exercise 9.3

Problemet er, at i vores `get`-metode skal ændre `head` til at pege på `first.next`. Som implementeringen er nu, så vil `first.next`-referencen stadigvæk eksisterer efter at metoden er kørt færdig, hvorfor vi nu har et objekt, der refererer til noget, men som vi ikke kan tilgå. Altså har vi rykket vores `head`, men det objekt, der pegede på `head` eksisterer stadigvæk. Dette løses ved at efter vores `head` er ændret til `first.next`, skal vi sætte `first.next` til at pege på `null`, hvorefter at mr. Garbage Collection kan spise objektet og fikse vores `OutOfMemoryError` :)
