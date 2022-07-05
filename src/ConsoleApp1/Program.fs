open System


type Instruction<'a> =
    | ReadLn of unit * (string -> Instruction<'a>)
    | WriteLn of string * (unit -> Instruction<'a>)
    | Stop of 'a

let readFromConsole =
    WriteLn ("Enter the first value", fun () ->
    ReadLn  ((), fun str1 ->
    WriteLn ("Enter the second value", fun () ->
    ReadLn ((), fun str2 ->
    Stop (str1, str2)))))

let interpretInstruction instruction =
    match instruction with
    | ReadLn -> Console.ReadLine()
    | WriteLn str -> printfn $"{str}"

