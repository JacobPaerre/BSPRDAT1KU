namespace BPRD_01_alcn_dmil_jacp

module Assignment1 =
    
    type expr = 
      | CstI of int
      | Var of string
      | Prim of string * expr * expr
      // Exercise 1.1 (iv)
      | If of expr * expr * expr
      
    let emptyenv = []; (* the empty environment *)
    let boundenv = [("a", 3); ("c", 78); ("baf", 666); ("b", 111)]

    let rec lookup env x =
        match env with 
        | []        -> failwith (x + " not found")
        | (y, v)::r -> if x=y then v else lookup r x
    
    // Exercise 1.1 (i)
    let rec eval e (env : (string * int) list) : int =
        match e with
        | CstI i            -> i
        | Var x             -> lookup env x 
        | Prim("+", e1, e2) -> eval e1 env + eval e2 env
        | Prim("*", e1, e2) -> eval e1 env * eval e2 env
        | Prim("-", e1, e2) -> eval e1 env - eval e2 env
        | Prim("max", e1, e2) -> max (eval e1 env) (eval e2 env)
        | Prim("min", e1, e2) -> min (eval e1 env) (eval e2 env)
        | Prim("==", e1, e2) ->
            if (eval e1 env)=(eval e2 env) then 1 else 0
        | Prim _            -> failwith "unknown primitive"
        
    // Exercise 1.1 (ii)
    let e1 = Prim("min", CstI 5, CstI 4)
    let e2 = Prim("max", CstI 5, CstI 4)
    let e3 = Prim("==", CstI 5, CstI 5)
    let e4 = Prim("==", Prim("+", CstI 2, CstI 2), CstI 4)
    
    // Exercise 1.1 (iii)
    let rec eval3 e (env : (string * int) list) : int =
        match e with
        | CstI i            -> i
        | Var x             -> lookup env x 
        | Prim(ope, e1, e2) ->
            let i1 = eval3 e1 env
            let i2 = eval3 e2 env
            match ope with
                | "+"   -> i1 + i2
                | "*"   -> i1 * i2
                | "-"   -> i1 - i2
                | "max" -> max i1 i2
                | "min" -> min i1 i2
                | "=="  -> if i1=i2 then 1 else 0
                | _     -> failwith "unknown primitive"
    // Exercise 1.1 (v)
        | If(e1, e2, e3) ->
            if (eval3 e1 env) <> 0 then (eval3 e2 env) else (eval3 e3 env)
            
    let e5 = If(Var "a", CstI 11, CstI 22)
    