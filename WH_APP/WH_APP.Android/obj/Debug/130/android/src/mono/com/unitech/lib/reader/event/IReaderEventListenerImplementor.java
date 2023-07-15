package mono.com.unitech.lib.reader.event;


public class IReaderEventListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.unitech.lib.reader.event.IReaderEventListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onNotificationState:(Lcom/unitech/lib/reader/types/NotificationState;Ljava/lang/Object;)V:GetOnNotificationState_Lcom_unitech_lib_reader_types_NotificationState_Ljava_lang_Object_Handler:Com.Unitech.Lib.Reader.Event.IReaderEventListenerInvoker, libunitechRFID\n" +
			"n_onReaderActionChanged:(Lcom/unitech/lib/reader/BaseReader;Lcom/unitech/lib/types/ResultCode;Lcom/unitech/lib/types/ActionState;Ljava/lang/Object;)V:GetOnReaderActionChanged_Lcom_unitech_lib_reader_BaseReader_Lcom_unitech_lib_types_ResultCode_Lcom_unitech_lib_types_ActionState_Ljava_lang_Object_Handler:Com.Unitech.Lib.Reader.Event.IReaderEventListenerInvoker, libunitechRFID\n" +
			"n_onReaderBatteryState:(Lcom/unitech/lib/reader/BaseReader;ILjava/lang/Object;)V:GetOnReaderBatteryState_Lcom_unitech_lib_reader_BaseReader_ILjava_lang_Object_Handler:Com.Unitech.Lib.Reader.Event.IReaderEventListenerInvoker, libunitechRFID\n" +
			"n_onReaderKeyChanged:(Lcom/unitech/lib/reader/BaseReader;Lcom/unitech/lib/reader/types/KeyType;Lcom/unitech/lib/reader/types/KeyState;Ljava/lang/Object;)V:GetOnReaderKeyChanged_Lcom_unitech_lib_reader_BaseReader_Lcom_unitech_lib_reader_types_KeyType_Lcom_unitech_lib_reader_types_KeyState_Ljava_lang_Object_Handler:Com.Unitech.Lib.Reader.Event.IReaderEventListenerInvoker, libunitechRFID\n" +
			"n_onReaderStateChanged:(Lcom/unitech/lib/reader/BaseReader;Lcom/unitech/lib/transport/types/ConnectState;Ljava/lang/Object;)V:GetOnReaderStateChanged_Lcom_unitech_lib_reader_BaseReader_Lcom_unitech_lib_transport_types_ConnectState_Ljava_lang_Object_Handler:Com.Unitech.Lib.Reader.Event.IReaderEventListenerInvoker, libunitechRFID\n" +
			"n_onReaderTemperatureState:(Lcom/unitech/lib/reader/BaseReader;DLjava/lang/Object;)V:GetOnReaderTemperatureState_Lcom_unitech_lib_reader_BaseReader_DLjava_lang_Object_Handler:Com.Unitech.Lib.Reader.Event.IReaderEventListenerInvoker, libunitechRFID\n" +
			"";
		mono.android.Runtime.register ("Com.Unitech.Lib.Reader.Event.IReaderEventListenerImplementor, libunitechRFID", IReaderEventListenerImplementor.class, __md_methods);
	}


	public IReaderEventListenerImplementor ()
	{
		super ();
		if (getClass () == IReaderEventListenerImplementor.class) {
			mono.android.TypeManager.Activate ("Com.Unitech.Lib.Reader.Event.IReaderEventListenerImplementor, libunitechRFID", "", this, new java.lang.Object[] {  });
		}
	}


	public void onNotificationState (com.unitech.lib.reader.types.NotificationState p0, java.lang.Object p1)
	{
		n_onNotificationState (p0, p1);
	}

	private native void n_onNotificationState (com.unitech.lib.reader.types.NotificationState p0, java.lang.Object p1);


	public void onReaderActionChanged (com.unitech.lib.reader.BaseReader p0, com.unitech.lib.types.ResultCode p1, com.unitech.lib.types.ActionState p2, java.lang.Object p3)
	{
		n_onReaderActionChanged (p0, p1, p2, p3);
	}

	private native void n_onReaderActionChanged (com.unitech.lib.reader.BaseReader p0, com.unitech.lib.types.ResultCode p1, com.unitech.lib.types.ActionState p2, java.lang.Object p3);


	public void onReaderBatteryState (com.unitech.lib.reader.BaseReader p0, int p1, java.lang.Object p2)
	{
		n_onReaderBatteryState (p0, p1, p2);
	}

	private native void n_onReaderBatteryState (com.unitech.lib.reader.BaseReader p0, int p1, java.lang.Object p2);


	public void onReaderKeyChanged (com.unitech.lib.reader.BaseReader p0, com.unitech.lib.reader.types.KeyType p1, com.unitech.lib.reader.types.KeyState p2, java.lang.Object p3)
	{
		n_onReaderKeyChanged (p0, p1, p2, p3);
	}

	private native void n_onReaderKeyChanged (com.unitech.lib.reader.BaseReader p0, com.unitech.lib.reader.types.KeyType p1, com.unitech.lib.reader.types.KeyState p2, java.lang.Object p3);


	public void onReaderStateChanged (com.unitech.lib.reader.BaseReader p0, com.unitech.lib.transport.types.ConnectState p1, java.lang.Object p2)
	{
		n_onReaderStateChanged (p0, p1, p2);
	}

	private native void n_onReaderStateChanged (com.unitech.lib.reader.BaseReader p0, com.unitech.lib.transport.types.ConnectState p1, java.lang.Object p2);


	public void onReaderTemperatureState (com.unitech.lib.reader.BaseReader p0, double p1, java.lang.Object p2)
	{
		n_onReaderTemperatureState (p0, p1, p2);
	}

	private native void n_onReaderTemperatureState (com.unitech.lib.reader.BaseReader p0, double p1, java.lang.Object p2);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
