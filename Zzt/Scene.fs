namespace Zzt

open SyntaxTree
open System
open System.Collections.Generic

type Scene() =
    let characters = new Dictionary<string, GameObject>()
    let add name gameObject =
        match gameObject with
        | Player(_) -> ignore(characters.Add(name, gameObject)); gameObject
        | _ -> None

    let rename oldName newName gameObject =
        ignore(characters.Remove(oldName))
        let gameObject = add newName gameObject
        gameObject

    let renameCharacter(newName, character:Character) =
        let oldName, player = character.Name(), Player(character)
        rename oldName newName player

    let find characterName =
        let gameObject = characters.[characterName]
        match gameObject with
        | Player(_) -> gameObject
        | _ -> None

    member this.AddCharacter() : GameObject =
        let character = new Character(this)
        let player = Player(character)
        let gameObject =
            let name = character.Name()
            add name player
        gameObject

    member this.RenameCharacter(newName, character:Character) =
        match find newName with
        | Player(_) -> NameTaken
        | _ -> renameCharacter(newName, character)


    interface IScene with
        // Stub interface members
        member this.Place(x, y) = true
        member this.Emit(eventName) = printf "%s" eventName
        member this.Notify(eventName, objectName) = printf "%s %s" eventName objectName
        member this.Seek() = North