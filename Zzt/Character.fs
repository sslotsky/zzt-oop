namespace Zzt

open SyntaxTree
open System
open System.Collections.Generic

type Character(scene:IScene) =
    let scene = scene
    let x = ref 0
    let y = ref 0
    let mutable name = Guid.NewGuid().ToString()
    let events = new Dictionary<string, Command list>()

    member this.Name() = name
    member this.X() = x
    member this.Y() = y

    member this.Subscribe(name, commandList) =
        events.[name] <- commandList
        this

    member this.Name(newName:string) =
        name <- newName
        this

    member this.Shoot(direction) =
        this

    member this.Announce(message:string) =
        Console.WriteLine message
        this

    member this.Move(direction:Direction) =
        match direction with
        // TODO: This should check with the scene first
        | North -> incr y; this
        | South -> decr y; this
        | East -> incr x; this
        | West -> decr x; this
        | Seek -> this.Move(scene.Seek())
