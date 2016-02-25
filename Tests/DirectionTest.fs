module DirectionTest

open FsUnit
open NUnit.Framework
open Moq

open SyntaxTree

[<TestFixture>]
type DirectionTest() =
    [<Test>]
    member this.LeftTest() =
        North.Left |> should equal West
        (CounterClockwise North).Left |> should equal South
        (Opposite North).Left |> should equal East

    [<Test>]
    member this.BackTest() =
        West.Back |> should equal East
        (Clockwise East).Back |> should equal North
        (Opposite South).Back |> should equal South

    [<Test>]
    member this.ResolveTest() =
        (Clockwise (Clockwise North)).Resolve |> should equal South
        (Opposite (Opposite North)).Resolve |> should equal North

    [<Test>]
    member this.RNDPTest() =
        [North; South] |> should contain East.RNDP
        [North; South] |> should contain West.RNDP
        [East; West] |> should contain North.RNDP
        [East; West] |> should contain South.RNDP