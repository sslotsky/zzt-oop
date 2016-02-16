namespace ZztScriptParsing

open Microsoft.FSharp.Text.Lexing
open SyntaxTree

type ScriptReader() =
    member this.Read(script) =
        let lexbuf = LexBuffer<char>.FromString script
        let res =
            try
                Parser.start Lexer.read lexbuf
            with e ->
                let pos = lexbuf.EndPos
                let line = pos.Line
                let column = pos.Column
                //let message = e.Message
                let lastToken = new System.String(lexbuf.Lexeme)
                let message = 
                    sprintf "Parse failed at line %d, column %d:\n Last token: %s" line column lastToken
                failwith message
        res
