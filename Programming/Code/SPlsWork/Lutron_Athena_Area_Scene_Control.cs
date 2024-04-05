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

namespace UserModule_LUTRON_ATHENA_AREA_SCENE_CONTROL
{
    public class UserModuleClass_LUTRON_ATHENA_AREA_SCENE_CONTROL : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> RECALL_SCENE;
        Crestron.Logos.SplusObjects.DigitalOutput IS_INITIALIZED;
        Crestron.Logos.SplusObjects.DigitalOutput ROOM_IS_OCCUPIED;
        Crestron.Logos.SplusObjects.DigitalOutput ROOM_IS_VACANT;
        UShortParameter COMMAND_PROCESSOR_ID;
        UIntParameter AREA_HREF_ID;
        InOutArray<UIntParameter> PRESET_HREF_ID;
        Lutron.Leap.CommLib.Components.AreaComponent COMPONENT;
        public void ONINITIALIZATIONCHANGE ( object __sender__ /*Lutron.Leap.CommLib.Components.AreaComponent SENDER */, Lutron.Leap.CommLib.Event_Arguments.InitializationEventArgs ARGS ) 
            { 
            AreaComponent  SENDER  = (AreaComponent )__sender__;
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 100;
                IS_INITIALIZED  .Value = (ushort) ( ARGS.Payload ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        public void ONOCCUPANCYCHANGE ( object __sender__ /*Lutron.Leap.CommLib.Components.AreaComponent SENDER */, Lutron.Leap.CommLib.Event_Arguments.OccupiedEventArgs ARGS ) 
            { 
            AreaComponent  SENDER  = (AreaComponent )__sender__;
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 106;
                ROOM_IS_OCCUPIED  .Value = (ushort) ( Functions.BoolToInt (ARGS.Payload == OccupiedStateTypes.Occupied) ) ; 
                __context__.SourceCodeLine = 107;
                ROOM_IS_VACANT  .Value = (ushort) ( Functions.BoolToInt (ARGS.Payload == OccupiedStateTypes.Unoccupied) ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        object RECALL_SCENE_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                ushort PRESET = 0;
                
                
                __context__.SourceCodeLine = 118;
                PRESET = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
                __context__.SourceCodeLine = 120;
                COMPONENT . RecallPreset ( (ushort)( PRESET )) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    public override object FunctionMain (  object __obj__ ) 
        { 
        ushort PRESET = 0;
        
        try
        {
            SplusExecutionContext __context__ = SplusFunctionMainStartCode();
            
            __context__.SourceCodeLine = 133;
            WaitForInitializationComplete ( ) ; 
            __context__.SourceCodeLine = 135;
            // RegisterEvent( COMPONENT , ONINITIALIZATIONCHANGE , ONINITIALIZATIONCHANGE ) 
            try { g_criticalSection.Enter(); COMPONENT .OnInitializationChange  += ONINITIALIZATIONCHANGE; } finally { g_criticalSection.Leave(); }
            ; 
            __context__.SourceCodeLine = 136;
            // RegisterEvent( COMPONENT , ONOCCUPANCYCHANGE , ONOCCUPANCYCHANGE ) 
            try { g_criticalSection.Enter(); COMPONENT .OnOccupancyChange  += ONOCCUPANCYCHANGE; } finally { g_criticalSection.Leave(); }
            ; 
            __context__.SourceCodeLine = 138;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)17; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( PRESET  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (PRESET  >= __FN_FORSTART_VAL__1) && (PRESET  <= __FN_FOREND_VAL__1) ) : ( (PRESET  <= __FN_FORSTART_VAL__1) && (PRESET  >= __FN_FOREND_VAL__1) ) ; PRESET  += (ushort)__FN_FORSTEP_VAL__1) 
                {
                __context__.SourceCodeLine = 139;
                COMPONENT . AddPreset ( (ushort)( PRESET ), (uint)( PRESET_HREF_ID[ PRESET ] .Value )) ; 
                __context__.SourceCodeLine = 138;
                }
            
            __context__.SourceCodeLine = 141;
            COMPONENT . Configure ( (ushort)( COMMAND_PROCESSOR_ID  .Value ), (uint)( AREA_HREF_ID  .Value )) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler(); }
        return __obj__;
        }
        
    
    public override void LogosSplusInitialize()
    {
        _SplusNVRAM = new SplusNVRAM( this );
        
        RECALL_SCENE = new InOutArray<DigitalInput>( 17, this );
        for( uint i = 0; i < 17; i++ )
        {
            RECALL_SCENE[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( RECALL_SCENE__DigitalInput__ + i, RECALL_SCENE__DigitalInput__, this );
            m_DigitalInputList.Add( RECALL_SCENE__DigitalInput__ + i, RECALL_SCENE[i+1] );
        }
        
        IS_INITIALIZED = new Crestron.Logos.SplusObjects.DigitalOutput( IS_INITIALIZED__DigitalOutput__, this );
        m_DigitalOutputList.Add( IS_INITIALIZED__DigitalOutput__, IS_INITIALIZED );
        
        ROOM_IS_OCCUPIED = new Crestron.Logos.SplusObjects.DigitalOutput( ROOM_IS_OCCUPIED__DigitalOutput__, this );
        m_DigitalOutputList.Add( ROOM_IS_OCCUPIED__DigitalOutput__, ROOM_IS_OCCUPIED );
        
        ROOM_IS_VACANT = new Crestron.Logos.SplusObjects.DigitalOutput( ROOM_IS_VACANT__DigitalOutput__, this );
        m_DigitalOutputList.Add( ROOM_IS_VACANT__DigitalOutput__, ROOM_IS_VACANT );
        
        COMMAND_PROCESSOR_ID = new UShortParameter( COMMAND_PROCESSOR_ID__Parameter__, this );
        m_ParameterList.Add( COMMAND_PROCESSOR_ID__Parameter__, COMMAND_PROCESSOR_ID );
        
        AREA_HREF_ID = new UIntParameter( AREA_HREF_ID__Parameter__, this );
        m_ParameterList.Add( AREA_HREF_ID__Parameter__, AREA_HREF_ID );
        
        PRESET_HREF_ID = new InOutArray<UIntParameter>( 17, this );
        for( uint i = 0; i < 17; i++ )
        {
            PRESET_HREF_ID[i+1] = new UIntParameter( PRESET_HREF_ID__Parameter__ + i, PRESET_HREF_ID__Parameter__, this );
            m_ParameterList.Add( PRESET_HREF_ID__Parameter__ + i, PRESET_HREF_ID[i+1] );
        }
        
        
        for( uint i = 0; i < 17; i++ )
            RECALL_SCENE[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( RECALL_SCENE_OnPush_0, false ) );
            
        
        _SplusNVRAM.PopulateCustomAttributeList( true );
        
        NVRAM = _SplusNVRAM;
        
    }
    
    public override void LogosSimplSharpInitialize()
    {
        COMPONENT  = new Lutron.Leap.CommLib.Components.AreaComponent();
        
        
    }
    
    public UserModuleClass_LUTRON_ATHENA_AREA_SCENE_CONTROL ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}
    
    
    
    
    const uint RECALL_SCENE__DigitalInput__ = 0;
    const uint IS_INITIALIZED__DigitalOutput__ = 0;
    const uint ROOM_IS_OCCUPIED__DigitalOutput__ = 1;
    const uint ROOM_IS_VACANT__DigitalOutput__ = 2;
    const uint COMMAND_PROCESSOR_ID__Parameter__ = 10;
    const uint AREA_HREF_ID__Parameter__ = 11;
    const uint PRESET_HREF_ID__Parameter__ = 12;
    
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
