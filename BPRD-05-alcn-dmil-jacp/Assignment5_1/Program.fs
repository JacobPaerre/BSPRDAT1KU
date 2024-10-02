// For more information see https://aka.ms/fsharp-console-apps
let merge (xs: int list, ys: int list) : int list =
    let rec merge' xs ys acc =
        match xs, ys with
        // edge 1: hvis xs er tom, men ys stadigvæk har elementer
        | [], ys -> List.rev acc @ ys
        // edge 2: hvis ys er tom ...
        | xs, [] -> List.rev acc @ xs
        
        | x::xs', y::ys' ->
            if x < y then
                merge' xs' ys (x::acc)
            else
                merge' xs ys' (y::acc)
    merge' xs ys []
    
    
    
printfn $"{merge ([3; 5; 12], [2; 3; 4; 7])}"