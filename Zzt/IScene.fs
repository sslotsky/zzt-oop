namespace Zzt

open SyntaxTree

type IScene =
    abstract member Place : int * int -> bool
    abstract member Emit : string -> unit
    abstract member Notify : string * string -> unit
    abstract member Seek : unit -> Direction
