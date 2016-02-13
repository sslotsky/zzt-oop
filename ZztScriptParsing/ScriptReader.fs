namespace ZztScriptParsing

open Microsoft.FSharp.Text.Lexing
open SyntaxTree

type ScriptReader() =
    member this.Read(script) =
        let lexbuf = LexBuffer<char>.FromString script
        let res = Parser.start Lexer.read lexbuf
        res
