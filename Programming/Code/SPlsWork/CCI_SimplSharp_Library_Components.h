namespace CCI.SimplSharp.Library.Components.EventArguments;
        // class declarations
         class DigitalEventArgs;
         class BooleanEventArgs;
         class StringEventArgs;
         class SignedAnalogEventArgs;
         class AnalogEventArgs;
     class DigitalEventArgs 
    {
        // class delegates

        // class events

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
        INTEGER Payload;
    };

     class BooleanEventArgs 
    {
        // class delegates

        // class events

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

     class StringEventArgs 
    {
        // class delegates

        // class events

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING Payload[];
    };

     class SignedAnalogEventArgs 
    {
        // class delegates

        // class events

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
        SIGNED_INTEGER Payload;
    };

     class AnalogEventArgs 
    {
        // class delegates

        // class events

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
        INTEGER Payload;
    };

namespace CCI.SimplSharp.Library.Components.States;
        // class declarations
         class BooleanComponentState;
         class AnalogComponentState;
         class StringComponentState;
         class SignedAnalogComponentState;
     class BooleanComponentState 
    {
        // class delegates

        // class events
        EventHandler OnProcessUpdate ( BooleanComponentState sender, BooleanEventArgs args );

        // class functions
        FUNCTION UpdateState ( STRING value );
        FUNCTION Reinitialize ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

     class AnalogComponentState 
    {
        // class delegates

        // class events
        EventHandler OnProcessUpdate ( AnalogComponentState sender, AnalogEventArgs args );

        // class functions
        FUNCTION UpdateState ( STRING value );
        FUNCTION Reinitialize ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

     class StringComponentState 
    {
        // class delegates

        // class events
        EventHandler OnProcessUpdate ( StringComponentState sender, StringEventArgs args );

        // class functions
        FUNCTION UpdateState ( STRING value );
        FUNCTION Reinitialize ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING State[];
        STRING InitialState[];
    };

     class SignedAnalogComponentState 
    {
        // class delegates

        // class events
        EventHandler OnProcessUpdate ( SignedAnalogComponentState sender, SignedAnalogEventArgs args );

        // class functions
        FUNCTION UpdateState ( STRING value );
        FUNCTION Reinitialize ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

namespace CCI.SimplSharp.Library.Components.Common;
        // class declarations
         class QueuePriorities;
         class DebugTypes;
    static class QueuePriorities // enum
    {
        static SIGNED_LONG_INTEGER Cmd;
        static SIGNED_LONG_INTEGER Query;
    };

    static class DebugTypes // enum
    {
        static SIGNED_LONG_INTEGER Error;
        static SIGNED_LONG_INTEGER Info;
    };

namespace CCI.SimplSharp.Library.Components.Registration;
        // class declarations
         class Registrar;
     class Registrar 
    {
        // class delegates

        // class events

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

