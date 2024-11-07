# Exercises: 9.1 and 9.2 or 9.3

## Exercise 9.1

### i

See comments in the file `Selsort/Selsort.il`.

### ii

Se kommentarer i filen `Selsort/Selsort.jvmbytecode`

## Exercise 9.3

Problemet er, at i vores `get`-metode skal ændre `head` til at pege på `first.next`. Som implementeringen er nu, så vil `first.next`-referencen stadigvæk eksisterer efter at metoden er kørt færdig, hvorfor vi nu har et objekt, der refererer til noget, men som vi ikke kan tilgå. Altså har vi rykket vores `head`, men det objekt, der pegede på `head` eksisterer stadigvæk. Dette løses ved at efter vores `head` er ændret til `first.next`, skal vi sætte `first.next` til at pege på `null`, hvorefter at mr. Garbage Collection kan spise objektet og fikse vores `OutOfMemoryError` :)

### QueueWithMistake timings

```zsh
SentinelLockQueue   	   1	   4,04	199999994
SentinelLockQueue   	   2	  15,41	199999994
SentinelLockQueue   	   3	  39,28	199999994
SentinelLockQueue   	   4	  50,32	199999994
SentinelLockQueue   	   5	  64,03	199999994
SentinelLockQueue   	   6	  85,75	199999994
SentinelLockQueue   	   7	  87,16	199999994
SentinelLockQueue   	   8	 108,70	199999994
SentinelLockQueue   	   9	 111,76	199999994
SentinelLockQueue   	  10	 127,10	199999994
SentinelLockQueue   	  11	 153,54	199999994
SentinelLockQueue   	  12	 150,04	199999994
SentinelLockQueue   	  13	 167,72	199999994
SentinelLockQueue   	  14	 183,44	199999994
SentinelLockQueue   	  15	 186,45	199999994
SentinelLockQueue   	  16	 209,59	199999994
SentinelLockQueue   	  17	 219,53	199999994
SentinelLockQueue   	  18	 232,77	199999994
SentinelLockQueue   	  19	 271,96	199999994
```
