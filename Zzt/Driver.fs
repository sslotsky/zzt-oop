namespace Zzt

open SyntaxTree

type Driver(character:Character) =
    let character = character

    member private this.Exec character =
        this

    member this.Perform(commands:Command list) =
        this.ExecuteCommands(List.rev commands)

    member private this.ExecuteCommands(commands:Command list) =
        match commands with
        | [] -> this
        | h::t -> this.ExecuteCommands(t).Execute(h)

    member this.Execute(command:Command) =
        match command with
        | Move(direction) -> this.Exec (character.Move(direction))
        | Name(newName) -> this.Exec (character.Name(newName))
        | Announce(message) -> this.Exec (character.Announce(message))
        | On(eventName, commandList) -> this.Exec (character.Subscribe(eventName, commandList))
        | Shoot(direction) -> this.Exec (character.Shoot(direction))

