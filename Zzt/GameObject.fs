namespace Zzt

open SyntaxTree
open System
open System.Collections.Generic

type GameObject() = 
    let x = ref 0
    let y = ref 0
    let mutable name = ""
    let events = new Dictionary<string, Command list>()

    member this.Name() = name
    member this.X() = x
    member this.Y() = y

    member this.Perform(commands:Command list) =
        this.ExecuteCommands(List.rev commands)

    member private this.ExecuteCommands(commands:Command list) =
        match commands with
        | [] -> this
        | h::t -> this.ExecuteCommands(t).Execute(h)

    member this.Execute(command:Command) =
        match command with
            | Move(direction) -> this.Move(direction)
            | Name(newName) -> this.Name(newName)
            | Announce(message) -> this.Announce(message)
            | On(eventName, commandList) -> this.Subscribe(eventName, commandList)
            | Shoot(direction) -> this.Shoot(direction)

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
        | North -> incr y; this
        | South -> decr y; this
        | East -> incr x; this
        | West -> decr x; this
        | Seek -> this.Move(this.Seek())

    member this.Seek() =
        North // stub until we can ask the game which way the player goes