module SyntaxTree

type Direction = 
    | North | South | East | West | Seek | Flow 
    | Clockwise of Direction | CounterClockwise of Direction | RandomPerpendicular of Direction | Opposite of Direction

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