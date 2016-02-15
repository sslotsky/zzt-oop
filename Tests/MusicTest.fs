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
    let vocal phrase = Vocal phrase
    let instrumental instrument = 
        let resolve phrase =
            Instrumental (instrument, phrase)

        resolve

    let mary voiceResolver =
        let quarters = Quarter, [ E; D; C; D; E; E] |> List.map (fun noteName -> Default noteName)
        let half = Half, [ Default E ]
        let phrase = NoteGroups [ quarters; half ]
        let key = Major (NaturalKey C)
        let tempo = BeatsPerMinute 100
        let voice = voiceResolver(phrase)
        let song = Composition (tempo, key, [voice])
        song

    let instrumentalMary instrument =
        mary (instrumental instrument)

    let saxophoneMary = instrumentalMary Saxophone

    let vocalMary = mary vocal

    let reader = new ScriptReader()

    let verifyScript songScript song =
        let commandList = reader.Read songScript
        commandList |> should equal ([Play song])
                
    [<Test>]
    member this.WithDefaultTempo() =
        let songScript = """
            playMusic {
                C
                [Sax Q EDCDEE H E]
            }
        """

        verifyScript songScript saxophoneMary

    [<Test>]
    member this.WithDefaultKey() =
        let songScript = """
            playMusic {
                100
                [Sax Q EDCDEE H E]
            }
        """

        verifyScript songScript saxophoneMary

    [<Test>]
    member this.WithoutInstrument() =
        let songScript = """
            playMusic {
                [Q EDCDEE H E]
            }
        """

        verifyScript songScript vocalMary

    [<Test>]
    member this.WithoutBrackets() =
        let songScript = """
            playMusic {
                Q EDCDEE H E
            }
        """

        verifyScript songScript vocalMary

    [<Test>]
    member this.CompleteScript() =
        let songScript = """
            playMusic {
                100
                C
                [Sax Q EDCDEE H E]
            }
        """

        verifyScript songScript saxophoneMary