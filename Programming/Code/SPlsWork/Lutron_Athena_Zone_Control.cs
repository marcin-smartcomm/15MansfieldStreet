using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;
using Crestron;
using Crestron.Logos.SplusLibrary;
using Crestron.Logos.SplusObjects;
using Crestron.SimplSharp;
using Lutron.Leap.CommLib.ProtocolSupport;
using Lutron.Leap.CommLib.Models.Bodies.SubClasses;
using Lutron.Leap.CommLib.Event_Arguments;
using Lutron.Leap.CommLib.ComponentStates;
using Lutron.Leap.CommLib.Models;
using Lutron.Leap.CommLib.Models.Bodies;
using Lutron.Leap.CommLib.LeapSupport;
using Lutron.Leap.CommLib.Components;
using Lutron.Leap.CommLib.JsonSupport;
using Lutron.Leap.CommLib.Components.SubComponents;
using Lutron.Leap.CommLib;
using Lutron.Leap.CommLib.CCI_Support;
using CCI.SimplSharp.Library.Comm.Priority;
using CCI.SimplSharp.Library.Comm.Model;
using CCI.SimplSharp.Library.Comm.Equality;
using CCI.SimplSharp.Library.Comm.Common;
using CCI.SimplSharp.Library.Components.EventArguments;
using CCI.SimplSharp.Library.Components.States;
using CCI.SimplSharp.Library.Components.Common;
using CCI.SimplSharp.Library.Components.Registration;
using CCI.SimplSharp.Library.IO.Utilities;
using CCI.SimplSharp.Library.IO.Common;

namespace UserModule_LUTRON_ATHENA_ZONE_CONTROL
{
    public class UserModuleClass_LUTRON_ATHENA_ZONE_CONTROL : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput DIMLEVEL_RAISE;
        Crestron.Logos.SplusObjects.DigitalInput DIMLEVEL_LOWER;
        Crestron.Logos.SplusObjects.DigitalInput SWITCH_ON;
        Crestron.Logos.SplusObjects.DigitalInput SWITCH_OFF;
        Crestron.Logos.SplusObjects.DigitalInput SET_DIMLEVEL;
        Crestron.Logos.SplusObjects.DigitalInput CCOLEVEL_OPEN;
        Crestron.Logos.SplusObjects.DigitalInput CCOLEVEL_CLOSE;
        Crestron.Logos.SplusObjects.AnalogInput DIMLEVEL;
        Crestron.Logos.SplusObjects.AnalogInput FADETIME;
        Crestron.Logos.SplusObjects.DigitalOutput IS_INITIALIZED;
        Crestron.Logos.SplusObjects.DigitalOutput SWITCH_ON_FB;
        Crestron.Logos.SplusObjects.DigitalOutput SWITCH_OFF_FB;
        Crestron.Logos.SplusObjects.DigitalOutput CCOLEVEL_IS_OPEN;
        Crestron.Logos.SplusObjects.DigitalOutput CCOLEVEL_IS_CLOSED;
        Crestron.Logos.SplusObjects.AnalogOutput DIMLEVEL_FB;
        Crestron.Logos.SplusObjects.AnalogOutput FADETIME_FB;
        UShortParameter COMMAND_PROCESSOR_ID;
        UShortParameter ZONE_MODE;
        ShortParameter FADE_TIME;
        UIntParameter ZONE_HREF_ID;
        Lutron.Leap.CommLib.Components.ZoneComponent COMPONENT;
        public void ONINITIALIZATIONCHANGE ( object __sender__ /*Lutron.Leap.CommLib.Components.ZoneComponent SENDER */, Lutron.Leap.CommLib.Event_Arguments.InitializationEventArgs ARGS ) 
            { 
            ZoneComponent  SENDER  = (ZoneComponent )__sender__;
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 112;
                IS_INITIALIZED  .Value = (ushort) ( ARGS.Payload ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        public void ONSWITCHEDLEVELCHANGE ( object __sender__ /*Lutron.Leap.CommLib.Components.ZoneComponent SENDER */, Lutron.Leap.CommLib.Event_Arguments.SwitchedLevelEventArgs ARGS ) 
            { 
            ZoneComponent  SENDER  = (ZoneComponent )__sender__;
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 117;
                SWITCH_ON_FB  .Value = (ushort) ( Functions.BoolToInt (ARGS.Payload == SwitchedLevel.On) ) ; 
                __context__.SourceCodeLine = 118;
                SWITCH_OFF_FB  .Value = (ushort) ( Functions.BoolToInt (ARGS.Payload == SwitchedLevel.Off) ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        public void ONDIMLEVELCHANGE ( object __sender__ /*Lutron.Leap.CommLib.Components.ZoneComponent SENDER */, Lutron.Leap.CommLib.Event_Arguments.DimLevelEventArgs ARGS ) 
            { 
            ZoneComponent  SENDER  = (ZoneComponent )__sender__;
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 123;
                DIMLEVEL_FB  .Value = (ushort) ( ARGS.Payload ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        public void ONCCOLEVELCHANGE ( object __sender__ /*Lutron.Leap.CommLib.Components.ZoneComponent SENDER */, Lutron.Leap.CommLib.Event_Arguments.CCOLevelEventArgs ARGS ) 
            { 
            ZoneComponent  SENDER  = (ZoneComponent )__sender__;
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 128;
                CCOLEVEL_IS_OPEN  .Value = (ushort) ( Functions.BoolToInt (ARGS.Payload == CCOLevel.Open) ) ; 
                __context__.SourceCodeLine = 129;
                CCOLEVEL_IS_CLOSED  .Value = (ushort) ( Functions.BoolToInt (ARGS.Payload == CCOLevel.Closed) ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        object DIMLEVEL_RAISE_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 138;
                COMPONENT . Raise ( ) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object DIMLEVEL_LOWER_OnPush_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 142;
            COMPONENT . Lower ( ) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object DIMLEVEL_RAISE_OnRelease_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 147;
        COMPONENT . Stop ( ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SWITCH_ON_OnPush_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 153;
        COMPONENT . SwitchOn ( ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SWITCH_OFF_OnPush_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 159;
        COMPONENT . SwitchOff ( ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CCOLEVEL_OPEN_OnPush_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 164;
        COMPONENT . CCOLevelOpen ( ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CCOLEVEL_CLOSE_OnPush_6 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 169;
        COMPONENT . CCOLevelClose ( ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SET_DIMLEVEL_OnRelease_7 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 174;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (DIMLEVEL  .UshortValue != DIMLEVEL_FB  .Value))  ) ) 
            { 
            __context__.SourceCodeLine = 176;
            COMPONENT . SetDimLevel ( (ushort)( DIMLEVEL  .UshortValue )) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DIMLEVEL_OnChange_8 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 182;
        if ( Functions.TestForTrue  ( ( SET_DIMLEVEL  .Value)  ) ) 
            { 
            __context__.SourceCodeLine = 184;
            COMPONENT . SetDimLevel ( (ushort)( DIMLEVEL  .UshortValue )) ; 
            __context__.SourceCodeLine = 185;
            Functions.Delay (  (int) ( 10 ) ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object FADETIME_OnChange_9 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 192;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( FADETIME  .UshortValue >= 0 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( FADETIME  .UshortValue <= 14400 ) )) ))  ) ) 
            { 
            __context__.SourceCodeLine = 194;
            COMPONENT . FadeTime = (short) ( FADETIME  .ShortValue ) ; 
            __context__.SourceCodeLine = 196;
            FADETIME_FB  .Value = (ushort) ( COMPONENT.FadeTime ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

public override object FunctionMain (  object __obj__ ) 
    { 
    try
    {
        SplusExecutionContext __context__ = SplusFunctionMainStartCode();
        
        __context__.SourceCodeLine = 208;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 211;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( COMPONENT.FadeTime < 0 ))  ) ) 
            {
            __context__.SourceCodeLine = 212;
            COMPONENT . FadeTime = (short) ( FADE_TIME  .Value ) ; 
            }
        
        __context__.SourceCodeLine = 214;
        FADETIME_FB  .Value = (ushort) ( COMPONENT.FadeTime ) ; 
        __context__.SourceCodeLine = 216;
        // RegisterEvent( COMPONENT , ONINITIALIZATIONCHANGE , ONINITIALIZATIONCHANGE ) 
        try { g_criticalSection.Enter(); COMPONENT .OnInitializationChange  += ONINITIALIZATIONCHANGE; } finally { g_criticalSection.Leave(); }
        ; 
        __context__.SourceCodeLine = 217;
        // RegisterEvent( COMPONENT , ONSWITCHEDLEVELCHANGE , ONSWITCHEDLEVELCHANGE ) 
        try { g_criticalSection.Enter(); COMPONENT .OnSwitchedLevelChange  += ONSWITCHEDLEVELCHANGE; } finally { g_criticalSection.Leave(); }
        ; 
        __context__.SourceCodeLine = 218;
        // RegisterEvent( COMPONENT , ONDIMLEVELCHANGE , ONDIMLEVELCHANGE ) 
        try { g_criticalSection.Enter(); COMPONENT .OnDimLevelChange  += ONDIMLEVELCHANGE; } finally { g_criticalSection.Leave(); }
        ; 
        __context__.SourceCodeLine = 219;
        // RegisterEvent( COMPONENT , ONCCOLEVELCHANGE , ONCCOLEVELCHANGE ) 
        try { g_criticalSection.Enter(); COMPONENT .OnCCOLevelChange  += ONCCOLEVELCHANGE; } finally { g_criticalSection.Leave(); }
        ; 
        __context__.SourceCodeLine = 221;
        COMPONENT . Configure ( (ushort)( COMMAND_PROCESSOR_ID  .Value ), (ushort)( ZONE_MODE  .Value ), (uint)( ZONE_HREF_ID  .Value )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    
    DIMLEVEL_RAISE = new Crestron.Logos.SplusObjects.DigitalInput( DIMLEVEL_RAISE__DigitalInput__, this );
    m_DigitalInputList.Add( DIMLEVEL_RAISE__DigitalInput__, DIMLEVEL_RAISE );
    
    DIMLEVEL_LOWER = new Crestron.Logos.SplusObjects.DigitalInput( DIMLEVEL_LOWER__DigitalInput__, this );
    m_DigitalInputList.Add( DIMLEVEL_LOWER__DigitalInput__, DIMLEVEL_LOWER );
    
    SWITCH_ON = new Crestron.Logos.SplusObjects.DigitalInput( SWITCH_ON__DigitalInput__, this );
    m_DigitalInputList.Add( SWITCH_ON__DigitalInput__, SWITCH_ON );
    
    SWITCH_OFF = new Crestron.Logos.SplusObjects.DigitalInput( SWITCH_OFF__DigitalInput__, this );
    m_DigitalInputList.Add( SWITCH_OFF__DigitalInput__, SWITCH_OFF );
    
    SET_DIMLEVEL = new Crestron.Logos.SplusObjects.DigitalInput( SET_DIMLEVEL__DigitalInput__, this );
    m_DigitalInputList.Add( SET_DIMLEVEL__DigitalInput__, SET_DIMLEVEL );
    
    CCOLEVEL_OPEN = new Crestron.Logos.SplusObjects.DigitalInput( CCOLEVEL_OPEN__DigitalInput__, this );
    m_DigitalInputList.Add( CCOLEVEL_OPEN__DigitalInput__, CCOLEVEL_OPEN );
    
    CCOLEVEL_CLOSE = new Crestron.Logos.SplusObjects.DigitalInput( CCOLEVEL_CLOSE__DigitalInput__, this );
    m_DigitalInputList.Add( CCOLEVEL_CLOSE__DigitalInput__, CCOLEVEL_CLOSE );
    
    IS_INITIALIZED = new Crestron.Logos.SplusObjects.DigitalOutput( IS_INITIALIZED__DigitalOutput__, this );
    m_DigitalOutputList.Add( IS_INITIALIZED__DigitalOutput__, IS_INITIALIZED );
    
    SWITCH_ON_FB = new Crestron.Logos.SplusObjects.DigitalOutput( SWITCH_ON_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( SWITCH_ON_FB__DigitalOutput__, SWITCH_ON_FB );
    
    SWITCH_OFF_FB = new Crestron.Logos.SplusObjects.DigitalOutput( SWITCH_OFF_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( SWITCH_OFF_FB__DigitalOutput__, SWITCH_OFF_FB );
    
    CCOLEVEL_IS_OPEN = new Crestron.Logos.SplusObjects.DigitalOutput( CCOLEVEL_IS_OPEN__DigitalOutput__, this );
    m_DigitalOutputList.Add( CCOLEVEL_IS_OPEN__DigitalOutput__, CCOLEVEL_IS_OPEN );
    
    CCOLEVEL_IS_CLOSED = new Crestron.Logos.SplusObjects.DigitalOutput( CCOLEVEL_IS_CLOSED__DigitalOutput__, this );
    m_DigitalOutputList.Add( CCOLEVEL_IS_CLOSED__DigitalOutput__, CCOLEVEL_IS_CLOSED );
    
    DIMLEVEL = new Crestron.Logos.SplusObjects.AnalogInput( DIMLEVEL__AnalogSerialInput__, this );
    m_AnalogInputList.Add( DIMLEVEL__AnalogSerialInput__, DIMLEVEL );
    
    FADETIME = new Crestron.Logos.SplusObjects.AnalogInput( FADETIME__AnalogSerialInput__, this );
    m_AnalogInputList.Add( FADETIME__AnalogSerialInput__, FADETIME );
    
    DIMLEVEL_FB = new Crestron.Logos.SplusObjects.AnalogOutput( DIMLEVEL_FB__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( DIMLEVEL_FB__AnalogSerialOutput__, DIMLEVEL_FB );
    
    FADETIME_FB = new Crestron.Logos.SplusObjects.AnalogOutput( FADETIME_FB__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( FADETIME_FB__AnalogSerialOutput__, FADETIME_FB );
    
    COMMAND_PROCESSOR_ID = new UShortParameter( COMMAND_PROCESSOR_ID__Parameter__, this );
    m_ParameterList.Add( COMMAND_PROCESSOR_ID__Parameter__, COMMAND_PROCESSOR_ID );
    
    ZONE_MODE = new UShortParameter( ZONE_MODE__Parameter__, this );
    m_ParameterList.Add( ZONE_MODE__Parameter__, ZONE_MODE );
    
    FADE_TIME = new ShortParameter( FADE_TIME__Parameter__, this );
    m_ParameterList.Add( FADE_TIME__Parameter__, FADE_TIME );
    
    ZONE_HREF_ID = new UIntParameter( ZONE_HREF_ID__Parameter__, this );
    m_ParameterList.Add( ZONE_HREF_ID__Parameter__, ZONE_HREF_ID );
    
    
    DIMLEVEL_RAISE.OnDigitalPush.Add( new InputChangeHandlerWrapper( DIMLEVEL_RAISE_OnPush_0, false ) );
    DIMLEVEL_LOWER.OnDigitalPush.Add( new InputChangeHandlerWrapper( DIMLEVEL_LOWER_OnPush_1, false ) );
    DIMLEVEL_RAISE.OnDigitalRelease.Add( new InputChangeHandlerWrapper( DIMLEVEL_RAISE_OnRelease_2, false ) );
    DIMLEVEL_LOWER.OnDigitalRelease.Add( new InputChangeHandlerWrapper( DIMLEVEL_RAISE_OnRelease_2, false ) );
    SWITCH_ON.OnDigitalPush.Add( new InputChangeHandlerWrapper( SWITCH_ON_OnPush_3, false ) );
    SWITCH_OFF.OnDigitalPush.Add( new InputChangeHandlerWrapper( SWITCH_OFF_OnPush_4, false ) );
    CCOLEVEL_OPEN.OnDigitalPush.Add( new InputChangeHandlerWrapper( CCOLEVEL_OPEN_OnPush_5, false ) );
    CCOLEVEL_CLOSE.OnDigitalPush.Add( new InputChangeHandlerWrapper( CCOLEVEL_CLOSE_OnPush_6, false ) );
    SET_DIMLEVEL.OnDigitalRelease.Add( new InputChangeHandlerWrapper( SET_DIMLEVEL_OnRelease_7, false ) );
    DIMLEVEL.OnAnalogChange.Add( new InputChangeHandlerWrapper( DIMLEVEL_OnChange_8, true ) );
    FADETIME.OnAnalogChange.Add( new InputChangeHandlerWrapper( FADETIME_OnChange_9, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    COMPONENT  = new Lutron.Leap.CommLib.Components.ZoneComponent();
    
    
}

public UserModuleClass_LUTRON_ATHENA_ZONE_CONTROL ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint DIMLEVEL_RAISE__DigitalInput__ = 0;
const uint DIMLEVEL_LOWER__DigitalInput__ = 1;
const uint SWITCH_ON__DigitalInput__ = 2;
const uint SWITCH_OFF__DigitalInput__ = 3;
const uint SET_DIMLEVEL__DigitalInput__ = 4;
const uint CCOLEVEL_OPEN__DigitalInput__ = 5;
const uint CCOLEVEL_CLOSE__DigitalInput__ = 6;
const uint DIMLEVEL__AnalogSerialInput__ = 0;
const uint FADETIME__AnalogSerialInput__ = 1;
const uint IS_INITIALIZED__DigitalOutput__ = 0;
const uint SWITCH_ON_FB__DigitalOutput__ = 1;
const uint SWITCH_OFF_FB__DigitalOutput__ = 2;
const uint CCOLEVEL_IS_OPEN__DigitalOutput__ = 3;
const uint CCOLEVEL_IS_CLOSED__DigitalOutput__ = 4;
const uint DIMLEVEL_FB__AnalogSerialOutput__ = 0;
const uint FADETIME_FB__AnalogSerialOutput__ = 1;
const uint COMMAND_PROCESSOR_ID__Parameter__ = 10;
const uint ZONE_MODE__Parameter__ = 11;
const uint FADE_TIME__Parameter__ = 12;
const uint ZONE_HREF_ID__Parameter__ = 13;

[SplusStructAttribute(-1, true, false)]
public class SplusNVRAM : SplusStructureBase
{

    public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
    
    
}

SplusNVRAM _SplusNVRAM = null;

public class __CEvent__ : CEvent
{
    public __CEvent__() {}
    public void Close() { base.Close(); }
    public int Reset() { return base.Reset() ? 1 : 0; }
    public int Set() { return base.Set() ? 1 : 0; }
    public int Wait( int timeOutInMs ) { return base.Wait( timeOutInMs ) ? 1 : 0; }
}
public class __CMutex__ : CMutex
{
    public __CMutex__() {}
    public void Close() { base.Close(); }
    public void ReleaseMutex() { base.ReleaseMutex(); }
    public int WaitForMutex() { return base.WaitForMutex() ? 1 : 0; }
}
 public int IsNull( object obj ){ return (obj == null) ? 1 : 0; }
}


}
