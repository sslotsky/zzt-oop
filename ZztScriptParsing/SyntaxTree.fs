module SyntaxTree

type Direction = North | South | East | West | Seek

type Command =
    | Move of Direction
    | Shoot of Direction
    | Name of string
    | Announce of string
    | On of (string * Command list)


(*
    myNameIs "Johnny"
    move North
    move South
    move East
    move West

    on "mock" do
        Announce "I hate you"
        Shoot Seek
    end
*)