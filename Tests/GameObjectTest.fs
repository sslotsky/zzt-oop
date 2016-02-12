module GameObjectTest

open NUnit.Framework
open FsUnit
open SyntaxTree
open Zzt

[<TestFixture>]
type GameObjectTest() =
    [<Test>]
    member this.MoveTest() =
        let command = Move(North)
        let npc = new GameObject()
        ignore(npc.Execute(command))
        npc.Y().Value |> should equal 1

    [<Test>]
    member this.NameTest() =
        let name = "Johnny"
        let command = Name(name)
        let npc = new GameObject()
        ignore(npc.Execute(command))
        npc.Name() |> should equal name
        
