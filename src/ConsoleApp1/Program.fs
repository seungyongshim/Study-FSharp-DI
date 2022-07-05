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

let rec interpret instruction =
    match instruction with
    | ReadLn (_, next) ->
        let str = Console.ReadLine()
        let nextInstruction = next str
        interpret nextInstruction
    | WriteLn (str, next) ->
        printfn $"{str}"
        let nextInstruction  =  next ()
        interpret nextInstruction
    | Stop value ->
        value

let _ = interpret readFromConsole
