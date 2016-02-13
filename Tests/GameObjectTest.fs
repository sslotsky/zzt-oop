module GameObjectTest

open FsUnit
open NUnit.Framework
open Moq

open SyntaxTree
open Zzt

[<TestFixture>]
type CharacterTest() =
    let scene = new Mock<IScene>()

    [<Test>]
    member this.MoveTest() =
        let command = Move(North)
        let npc = new Character(scene.Object)
        ignore(npc.Execute(command))
        npc.Y().Value |> should equal 1

    [<Test>]
    member this.NameTest() =
        let name = "Johnny"
        let command = Name(name)
        let npc = new Character(scene.Object)
        ignore(npc.Execute(command))
        npc.Name() |> should equal name
        
