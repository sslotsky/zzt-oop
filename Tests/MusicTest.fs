module MusicTest

open FsUnit
open NUnit.Framework
open Moq

open SyntaxTree
open MusicSyntax

open Zzt
open ZztScriptParsing

[<TestFixture>]
type MusicTests() =
    [<Test>]
    member this.TestMaryHadALittleLamb() =
        let quarters = Quarter, [ E; D; C; D; E; E] |> List.map (fun noteName -> Default noteName)
        let half = Half, [ Default E ]
        let phrase = NoteGroups [ quarters; half ]
        let key = Major (NaturalKey C)
        let tempo = BeatsPerMinute 100
        let voice = Instrumental (Saxophone, phrase)
        let song = Composition (tempo, key, [voice])

        let songScript = """
            playMusic {
                100
                C
                [Sax Q EDCDEE H E]
            }
        """

        let reader = new ScriptReader()
        let commandList = reader.Read songScript
        commandList |> should equal ([Play song])