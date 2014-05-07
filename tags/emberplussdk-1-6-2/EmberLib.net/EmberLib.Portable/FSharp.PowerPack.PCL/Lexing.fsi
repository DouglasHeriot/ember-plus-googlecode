//==========================================================================
// LexBuffers are for use with automatically generated lexical analyzers,
// in particular those produced by 'fslex'.
//
// (c) Microsoft Corporation 2005-2008.
//===========================================================================

#if INTERNALIZED_POWER_PACK
namespace Internal.Utilities.Text.Lexing
#else
namespace Microsoft.FSharp.Text.Lexing 
#endif

open System.Collections.Generic

/// Position information stored for lexing tokens
//
// Note: this is an OCaml compat record type. 
#if INTERNALIZED_POWER_PACK
type internal Position = 
#else
type Position = 
#endif
    { /// The file name for the position
      pos_fname: string;
      /// The line number for the position
      pos_lnum: int;
#if INTERNALIZED_POWER_PACK
      /// The line number for the position in the original source file
      pos_orig_lnum : int;
#endif
      /// The absolute offset of the beginning of the line
      pos_bol: int;
      /// The absolute offset of the column for the position
      pos_cnum: int; }
     /// The file name associated with the input stream.
     member FileName : string
     /// The line number in the input stream, assuming fresh positions have been updated 
     /// using AsNewLinePos() and by modifying the EndPos property of the LexBuffer.
     member Line : int
#if INTERNALIZED_POWER_PACK
     /// The line number for the position in the input stream, assuming fresh positions have been updated 
     /// using AsNewLinePos()
     member OriginalLine : int
#endif
     [<System.ObsoleteAttribute("Use the AbsoluteOffset property instead")>]
     member Char : int
     /// The character number in the input stream
     member AbsoluteOffset : int
     /// Return absolute offset of the start of the line marked by the position
     member StartOfLineAbsoluteOffset : int
     /// Return the column number marked by the position, i.e. the difference between the AbsoluteOffset and the StartOfLineAbsoluteOffset
     member Column : int
     // Given a position just beyond the end of a line, return a position at the start of the next line
     member NextLine : Position     
     
     /// Given a position at the start of a token of length n, return a position just beyond the end of the token
     member EndOfToken: n:int -> Position
     /// Gives a position shifted by specified number of characters
     member ShiftColumnBy: by:int -> Position
     
     [<System.ObsoleteAttribute("Consider using the NextLine property instead")>]
     member AsNewLinePos : unit -> Position
     
     /// Get an arbitrary position, with the empty string as filename, and  
     static member Empty : Position

     /// Get a position corresponding to the first line (line number 1) in a given file
     static member FirstLine : filename:string -> Position
    
[<Sealed>]
#if INTERNALIZED_POWER_PACK
type internal LexBuffer<'char> =
#else
/// Input buffers consumed by lexers generated by <c>fslex.exe </c>
type LexBuffer<'char> =
#endif
    /// The start position for the lexeme
    member StartPos: Position with get,set
    /// The end position for the lexeme
    member EndPos: Position with get,set
    /// The matched string 
    member Lexeme: 'char array
    
    /// Fast helper to turn the matched characters into a string, avoiding an intermediate array
    static member LexemeString : LexBuffer<char> -> string
    
    /// The length of the matched string 
    member LexemeLength: int
    /// Fetch a particular character in the matched string 
    member LexemeChar: int -> 'char

    /// Dynamically typed, non-lexically scoped parameter table
    member BufferLocalStore : IDictionary<string,obj>
    
    /// True if the refill of the buffer ever failed , or if explicitly set to true.
    member IsPastEndOfStream: bool with get,set
    /// Remove all input, though don't discard the current lexeme 
    member DiscardInput: unit -> unit

    /// Create a lex buffer suitable for byte lexing that reads characters from the given array
    static member FromBytes: byte[] -> LexBuffer<byte>
    /// Create a lex buffer suitable for Unicode lexing that reads characters from the given array
    static member FromChars: char[] -> LexBuffer<char>
    /// Create a lex buffer suitable for Unicode lexing that reads characters from the given string
    static member FromString: string -> LexBuffer<char>
    /// Create a lex buffer that reads character or byte inputs by using the given function
    static member FromFunction: ('char[] * int * int -> int) -> LexBuffer<'char>
    /// Create a lex buffer that asynchronously reads character or byte inputs by using the given function
    static member FromAsyncFunction: ('char[] * int * int -> Async<int>) -> LexBuffer<'char>


    [<System.Obsolete("Use LexBuffer<char>.FromFunction instead")>]
    static member FromCharFunction: (char[] -> int -> int) -> LexBuffer<char>
    [<System.Obsolete("Use LexBuffer<byte>.FromFunction instead")>]
    static member FromByteFunction: (byte[] -> int -> int) -> LexBuffer<byte>

    /// Create a lex buffer suitable for use with a Unicode lexer that reads character inputs from the given text reader
    static member FromTextReader: System.IO.TextReader -> LexBuffer<char>
    /// Create a lex buffer suitable for use with ASCII byte lexing that reads byte inputs from the given binary reader
    static member FromBinaryReader: System.IO.BinaryReader -> LexBuffer<byte>


/// The type of tables for an ascii lexer generated by fslex. 
[<Sealed>]
#if INTERNALIZED_POWER_PACK
type internal AsciiTables =
#else
type AsciiTables =
#endif
    static member Create : uint16[] array * uint16[] -> AsciiTables
    /// Interpret tables for an ascii lexer generated by fslex. 
    member Interpret:  initialState:int * LexBuffer<byte>  -> int
    /// Interpret tables for an ascii lexer generated by fslex, processing input asynchronously
    member AsyncInterpret:  initialState:int * LexBuffer<byte> -> Async<int>


/// The type of tables for an unicode lexer generated by fslex. 
[<Sealed>]
#if INTERNALIZED_POWER_PACK
type internal UnicodeTables =
#else
type UnicodeTables =
#endif
    static member Create : uint16[] array * uint16[] -> UnicodeTables
    /// Interpret tables for a unicode lexer generated by fslex. 
    member Interpret:  initialState:int * LexBuffer<char> -> int

    /// Interpret tables for a unicode lexer generated by fslex, processing input asynchronously
    member AsyncInterpret:  initialState:int * LexBuffer<char> -> Async<int>

