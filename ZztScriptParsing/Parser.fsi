// Signature file for parser generated by fsyacc
module Parser
type token = 
  | EOF
  | SHOOT
  | ANNOUNCE
  | ON
  | DO
  | END
  | NORTH
  | SOUTH
  | EAST
  | WEST
  | SEEK
  | MOVE
  | MY_NAME_IS
  | STRING of (string)
type tokenId = 
    | TOKEN_EOF
    | TOKEN_SHOOT
    | TOKEN_ANNOUNCE
    | TOKEN_ON
    | TOKEN_DO
    | TOKEN_END
    | TOKEN_NORTH
    | TOKEN_SOUTH
    | TOKEN_EAST
    | TOKEN_WEST
    | TOKEN_SEEK
    | TOKEN_MOVE
    | TOKEN_MY_NAME_IS
    | TOKEN_STRING
    | TOKEN_end_of_input
    | TOKEN_error
type nonTerminalId = 
    | NONTERM__startstart
    | NONTERM_start
    | NONTERM_script
    | NONTERM_commandList
    | NONTERM_command
    | NONTERM_move
    | NONTERM_shoot
    | NONTERM_name
    | NONTERM_announce
    | NONTERM_on
    | NONTERM_direction
/// This function maps tokens to integer indexes
val tagOfToken: token -> int

/// This function maps integer indexes to symbolic token ids
val tokenTagToTokenId: int -> tokenId

/// This function maps production indexes returned in syntax errors to strings representing the non terminal that would be produced by that production
val prodIdxToNonTerminal: int -> nonTerminalId

/// This function gets the name of a token as a string
val token_to_string: token -> string
val start : (Microsoft.FSharp.Text.Lexing.LexBuffer<'cty> -> token) -> Microsoft.FSharp.Text.Lexing.LexBuffer<'cty> -> ( SyntaxTree.Command list ) 