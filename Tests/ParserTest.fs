﻿module ParserTest

open NUnit.Framework
open FsUnit
open Microsoft.FSharp.Text.Lexing
open SyntaxTree
open ZztScriptParsing

[<TestFixture>]
type ParserTest() =
    let reader = new ScriptReader()

    [<Test>]
    member this.MoveTest() =
        let simpleScript = "move North move South"
        let commandList = reader.Read(simpleScript)
        commandList.Length |> should equal 2

    [<Test>]
    member this.NameTest() =
        let script = "myNameIs 'Johnny Rotten Fucking Tomatoes'"
        let commandList = reader.Read(script)
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

            move Seek
            walk Flow
            shoot CW North
            go CCW Flow
            walk RNDP Seek
            walk OPP Flow

            set Aligned
            set ~Annoyed
            clear ~Annoyed
            if ~Annoyed then
                walk OPP Seek
            end

            if Blocked North then
                walk East
            else
                walk North
            end

            unless Blocked West do
                walk West
            end

            walk North if Blocked South

            shoot CW Seek unless Aligned
        """
        let commandList = reader.Read(script)
        commandList.Length |> should equal 18