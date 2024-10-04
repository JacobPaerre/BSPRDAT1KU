module Exercise6_1

open ParseAndRunHigher;;

let p1 = run (fromString @"let add x = let f y = x+y in f end
                           in add 2 5 end");;

let p2 = run (fromString @"let add x = let f y = x+y in f end
                           in let addtwo = add 2
                               in addtwo 5 end
                           end");;

let p3 = run (fromString @"let add x = let f y = x+y in f end
                           in let addtwo = add 2
                              in let x = 77 in addtwo 5 end
                              end
                           end");;

let p4 = run (fromString @"let add x = let f y = x+y in f end
                           in add 2 end");;