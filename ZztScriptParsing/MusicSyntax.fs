module MusicSyntax

type NoteName = A | B | C | D | E | F | G

type MusicNote =
    | Default of NoteName // defers to the key signature
    | RaiseOctave of MusicNote
    | LowerOctave of MusicNote
    | Sharp of NoteName
    | Flat of NoteName
    | Natural of NoteName
    | Rest

type Duration = Whole | Half | Quarter | Eighth | Sixteenth | ThirtySecond | TimeAndAHalf of Duration | OneThird of Duration

type KeyName = 
    | NaturalKey of NoteName 
    | SharpKey of NoteName 
    | FlatKey of NoteName 

type Key =
    | Major of KeyName
    | HarmonicMinor of KeyName
    | MelodicMinorAscending of KeyName
    | MelodicMinorDescending of KeyName

type Tempo =
    | BeatsPerMinute of int

type Phrase =
    | NoteGroups of (Duration * MusicNote list) list
    | Repeat of int * Phrase

type Instrument = Guitar | Piano | Saxophone

type Voice = Instrumental of Instrument * Phrase | Vocal of Phrase

type Song =
    | Composition of Tempo * Key * Voice list

(*
    # Arpeggiate a CM7#11 in triplets.

    playMusic { Q3 C G E B D F# }

    # Play the CM7#11 chord

    playMusic { 
        [W C] [W E] [W G] [W B] [W D] [W F#]
    }

    # CM7#11 chord using key signature and tempo, switching voices

    playMusic {
        120 C 
        [Sax W CEGBDF#] 
        [Keys W EGBDF#C] 
        [Guitar W GBDF#CE]
    }
*)