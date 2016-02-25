module SyntaxTree

open MusicSyntax

type Direction = 
    | North | South | East | West
    | Seek | Flow | Idle
    | Clockwise of Direction | CounterClockwise of Direction | RandomPerpendicular of Direction | Opposite of Direction

    member this.RNDP
        with get() =
            match this.Resolve with
            | North
            | South -> [East; West].[System.Random().Next (0,1)]
            | East
            | West -> [North; South].[System.Random().Next (0,1)]
            | Idle -> Idle
            | direction -> RandomPerpendicular direction

    member this.Left
        with get() =
            match this.Resolve with
            | North -> West
            | West -> South
            | South -> East
            | East -> North
            | Idle -> Idle
            | direction -> CounterClockwise direction

    member this.Right
        with get() =
            match this.Resolve with
            | North -> East
            | East -> South
            | South -> West
            | West -> North
            | Idle -> Idle
            | direction -> Clockwise direction

    member this.Back
        with get() =
            match this.Resolve with
            | North -> South
            | South -> North
            | East -> West
            | West -> East
            | Idle -> Idle
            | direction -> Opposite direction

    member this.Resolve
        with get() =
            match this with
            | Clockwise direction -> direction.Right
            | CounterClockwise direction -> direction.Left
            | RandomPerpendicular direction -> direction.RNDP
            | Opposite direction -> direction.Back
            | _ -> this

type Identifier = FlagName of string

type Flag =
    | Aligned
    | Touching
    | Blocked of Direction
    | Energized
    | UserDefined of Identifier

type Command =
    | Move of Direction
    | Shoot of Direction
    | Go of Direction
    | Walk of Direction
    | Name of string
    | Announce of string
    | Set of Flag
    | Clear of Flag
    | If of Flag * Command list
    | IfElse of Flag * Command list * Command list
    | Unless of Flag * Command list
    | On of string * Command list
    | Play of Song


(*
    myNameIs 'Johnny'
    move North
    move South
    move East
    move West

    on 'mock' do
        Announce 'I hate you'
        Shoot Seek
    end
*)