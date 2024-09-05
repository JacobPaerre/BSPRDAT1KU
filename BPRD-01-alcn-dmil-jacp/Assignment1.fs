namespace BPRD_01_alcn_dmil_jacp

module Assignment1_exercise1 =
    
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
    
    // Exercise 1.2 (i)
    type aexpr = 
      | CstI of int
      | Var of string
      | Add of aexpr * aexpr
      | Mul of aexpr * aexpr
      | Sub of aexpr * aexpr
      
    // Exercise 1.2 (ii)
    let aexpr1 = Sub(Var "v", Add(Var "w", Var "z"))
    let aexpr2 = Mul(CstI 2, Sub(Var "v", Add(Var "w", Var "z")))
    let aexpr3 = Add(Var "x", Add(Var "y", Add(Var "z", Var "v")))
    
    // Exercise 1.2 (iii)
    let rec fmt e : string =
        match e with
        | CstI x -> string x
        | Var x -> x
        | Add (e1, e2) -> "(" + (fmt e1) + " + " + (fmt e2) + ")"
        | Mul (e1, e2) -> "(" + (fmt e1) + " * " + (fmt e2) + ")"
        | Sub (e1, e2) -> "(" + (fmt e1) + " - " + (fmt e2) + ")"
        
    // Exercise 1.2 (iv)
    let rec simplify e : aexpr =
        match e with
        | CstI x -> CstI x
        | Var x -> Var x
        | Add(CstI 0, x) -> simplify x
        | Add(x, CstI 0) -> simplify x
        | Sub(x, CstI 0) -> simplify x
        | Mul(CstI 1, x) -> simplify x
        | Mul(x, CstI 1) -> simplify x
        | Mul(CstI 0, _) -> CstI 0
        | Mul(_, CstI 0) -> CstI 0
        | Sub(e1, e2) when e1=e2 -> CstI 0
        | Add(e1, e2) -> simplify (Add(simplify e1, simplify e2))
        | Mul(e1, e2) -> simplify (Mul(simplify e1, simplify e2))
        | Sub(e1, e2) -> simplify (Sub(simplify e1, simplify e2))
        
    let aexpr4 = Mul(Add(CstI 1, CstI 0), Add(Var "x", CstI 0))
    
    // Exercise 1.2 (v)
    let rec diff e v : aexpr =
        match e with
        | CstI _ -> CstI 0
        | Var x when v = x -> CstI 1
        | Var _ -> CstI 0
        | Add(e1, e2) -> Add((diff e1 v), (diff e2 v))
        | Sub(e1, e2) -> Sub((diff e1 v), (diff e2 v))
        | Mul(e1, e2) -> Add(Mul((diff e1 v), e2), Mul(e1, (diff e2 v)))

module Assignment1_exercise2 =        
    // Exercise 2.1 (i)
    type expr = 
      | CstI of int
      | Var of string
      | Let of (string * expr) list * expr // changed
      | Prim of string * expr * expr
      
    let rec lookup env x =
        match env with 
        | []        -> failwith (x + " not found")
        | (y, v)::r -> if x=y then v else lookup r x

    let rec eval e (env : (string * int) list) : int =
        match e with
        | CstI i            -> i
        | Var x             -> lookup env x 
        | Let(list, ebody) ->
            let env1 =
                List.fold(fun acc (x, y) ->
                    let xval = eval y acc
                    (x, xval) :: acc 
                ) env list
            eval ebody env1
        | Prim("+", e1, e2) -> eval e1 env + eval e2 env
        | Prim("*", e1, e2) -> eval e1 env * eval e2 env
        | Prim("-", e1, e2) -> eval e1 env - eval e2 env
        | Prim _            -> failwith "unknown primitive"

    let test = Let ([("x1", Prim("+", CstI 5, CstI 7)); ("x2", Prim("*", Var "x1", CstI 2))], Prim("+", Var "x1", Var "x2"))
    let test2 = Let ([("x1", Prim("+", CstI 5, CstI 7)); ("x2", Prim("*", CstI 12, CstI 2))], Prim("+", Var "x1", Var "x2"))
    
    // Exercise 2.2 (i)
    
    let rec mem x vs = 
        match vs with
        | []      -> false
        | v :: vr -> x=v || mem x vr
        
    let rec union (xs, ys) = 
        match xs with 
        | []    -> ys
        | x::xr -> if mem x ys then union(xr, ys)
                   else x :: union(xr, ys)
                   
    let rec minus (xs, ys) = 
        match xs with 
        | []    -> []
        | x::xr -> if mem x ys then minus(xr, ys)
                   else x :: minus (xr, ys)
                   
    let rec freevars e : string list =
        match e with
        | CstI i -> []
        | Var x  -> [x]
        (*
        | Let(x, erhs, ebody) -> 
              union (freevars erhs, minus (freevars ebody, [x]))
        *)
        | Let(list, ebody) ->
            List.fold (fun acc (x, erhs) -> union ((union (freevars erhs, minus (freevars ebody, [x]))), acc)) [] list
        | Prim(ope, e1, e2) -> union (freevars e1, freevars e2)
        
    let test3 = Let([("x1", Prim("+", Var "x1", CstI 7))], Prim("+", Var "x1", CstI 8))
    
    // Exercise 2.3 (i)
    type texpr =                            (* target expressions *)
      | TCstI of int
      | TVar of int                         (* index into runtime environment *)
      | TLet of texpr * texpr               (* erhs and ebody                 *)
      | TPrim of string * texpr * texpr
      
    let rec getindex vs x = 
        match vs with 
        | []    -> failwith "Variable not found"
        | y::yr -> if x=y then 0 else 1 + getindex yr x
        
    let rec tcomp (e : expr) (cenv : string list) : texpr =
        match e with
        | CstI i -> TCstI i
        | Var x  -> TVar (getindex cenv x)
        (*
        | Let(x, erhs, ebody) -> 
          let cenv1 = x :: cenv 
          TLet(tcomp erhs cenv, tcomp ebody cenv1)
        *)
        | Let(list, ebody) ->
            let cenv1 = List.fold(fun acc (x, _) -> x :: acc) cenv list
            let erhs = snd list.Head
            TLet(tcomp erhs cenv, tcomp ebody cenv1)
        | Prim(ope, e1, e2) -> TPrim(ope, tcomp e1 cenv, tcomp e2 cenv)