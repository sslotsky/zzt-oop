module ParserTest

open NUnit.Framework
open FsUnit
open Microsoft.FSharp.Text.Lexing
open SyntaxTree

[<TestFixture>]
type ParserTest() =
    member this.parse script =
        let lexbuf = LexBuffer<char>.FromString script
        let res = Parser.start Lexer.read lexbuf
        res

    [<Test>]
    member this.MoveTest() =
        let simpleScript = "move North move South"
        let commandList = this.parse(simpleScript)
        commandList.Length |> should equal 2

    [<Test>]
    member this.NameTest() =
        let script = "myNameIs 'Johnny Rotten Fucking Tomatoes'"
        let commandList = this.parse(script)
        commandList.Length |> should equal 1

    [<Test>]
    member this.ScriptTest() =
        let script = """
            myNameIs 'Johnny'
            move North
            move South
            on 'mock' do
                announce 'I hate you'
                shoot Seek
            end
        """
        let commandList = this.parse(script)
        commandList.Length |> should equal 4