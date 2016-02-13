namespace Zzt

open SyntaxTree
open ZztScriptParsing

type Driver(character:Character) =
    let character = character

    let updateCharacter(command:Command) =
        match command with
        | Move(direction) ->  character.Move(direction)
        | Name(newName) ->  character.Name(newName)
        | Announce(message) ->  character.Announce(message)
        | On(eventName, commandList) ->  character.Subscribe(eventName, commandList)
        | Shoot(direction) ->  character.Shoot(direction)

    member private this.Exec character command =
        ignore(updateCharacter(command))
        this

    member this.PerformScript(script) =
        let reader = new ScriptReader()
        this.Perform(reader.Read(script))

    member this.Perform(commands:Command list) =
        this.ExecuteCommands(List.rev commands)

    member private this.ExecuteCommands(commands:Command list) =
        match commands with
        | [] -> this
        | h::t -> this.ExecuteCommands(t).Execute(h)

    member this.Execute(command:Command) =
        this.Exec character command

