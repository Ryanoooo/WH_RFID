package mono.com.unitech.lib.device;


public class IDeviceEventListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.unitech.lib.device.IDeviceEventListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onActionChanged:(Lcom/unitech/lib/types/ResultCode;Lcom/unitech/lib/types/ActionType;Ljava/lang/Object;)V:GetOnActionChanged_Lcom_unitech_lib_types_ResultCode_Lcom_unitech_lib_types_ActionType_Ljava_lang_Object_Handler:Com.Unitech.Lib.Device.IDeviceEventListenerInvoker, libunitechRFID\n" +
			"n_onBatteryState:(ILjava/lang/Object;)V:GetOnBatteryState_ILjava_lang_Object_Handler:Com.Unitech.Lib.Device.IDeviceEventListenerInvoker, libunitechRFID\n" +
			"n_onEvent:(ILjava/lang/Object;)V:GetOnEvent_ILjava_lang_Object_Handler:Com.Unitech.Lib.Device.IDeviceEventListenerInvoker, libunitechRFID\n" +
			"n_onKeyEvent:(Lcom/unitech/lib/reader/types/KeyType;Lcom/unitech/lib/reader/types/KeyState;Ljava/lang/Object;)V:GetOnKeyEvent_Lcom_unitech_lib_reader_types_KeyType_Lcom_unitech_lib_reader_types_KeyState_Ljava_lang_Object_Handler:Com.Unitech.Lib.Device.IDeviceEventListenerInvoker, libunitechRFID\n" +
			"n_onNotificationState:(Lcom/unitech/lib/reader/types/NotificationState;Ljava/lang/Object;)V:GetOnNotificationState_Lcom_unitech_lib_reader_types_NotificationState_Ljava_lang_Object_Handler:Com.Unitech.Lib.Device.IDeviceEventListenerInvoker, libunitechRFID\n" +
			"n_onStateChanged:(Lcom/unitech/lib/transport/types/ConnectState;Ljava/lang/Object;)V:GetOnStateChanged_Lcom_unitech_lib_transport_types_ConnectState_Ljava_lang_Object_Handler:Com.Unitech.Lib.Device.IDeviceEventListenerInvoker, libunitechRFID\n" +
			"n_onTemperatureState:(DLjava/lang/Object;)V:GetOnTemperatureState_DLjava_lang_Object_Handler:Com.Unitech.Lib.Device.IDeviceEventListenerInvoker, libunitechRFID\n" +
			"";
		mono.android.Runtime.register ("Com.Unitech.Lib.Device.IDeviceEventListenerImplementor, libunitechRFID", IDeviceEventListenerImplementor.class, __md_methods);
	}


	public IDeviceEventListenerImplementor ()
	{
		super ();
		if (getClass () == IDeviceEventListenerImplementor.class) {
			mono.android.TypeManager.Activate ("Com.Unitech.Lib.Device.IDeviceEventListenerImplementor, libunitechRFID", "", this, new java.lang.Object[] {  });
		}
	}


	public void onActionChanged (com.unitech.lib.types.ResultCode p0, com.unitech.lib.types.ActionType p1, java.lang.Object p2)
	{
		n_onActionChanged (p0, p1, p2);
	}

	private native void n_onActionChanged (com.unitech.lib.types.ResultCode p0, com.unitech.lib.types.ActionType p1, java.lang.Object p2);


	public void onBatteryState (int p0, java.lang.Object p1)
	{
		n_onBatteryState (p0, p1);
	}

	private native void n_onBatteryState (int p0, java.lang.Object p1);


	public void onEvent (int p0, java.lang.Object p1)
	{
		n_onEvent (p0, p1);
	}

	private native void n_onEvent (int p0, java.lang.Object p1);


	public void onKeyEvent (com.unitech.lib.reader.types.KeyType p0, com.unitech.lib.reader.types.KeyState p1, java.lang.Object p2)
	{
		n_onKeyEvent (p0, p1, p2);
	}

	private native void n_onKeyEvent (com.unitech.lib.reader.types.KeyType p0, com.unitech.lib.reader.types.KeyState p1, java.lang.Object p2);


	public void onNotificationState (com.unitech.lib.reader.types.NotificationState p0, java.lang.Object p1)
	{
		n_onNotificationState (p0, p1);
	}

	private native void n_onNotificationState (com.unitech.lib.reader.types.NotificationState p0, java.lang.Object p1);


	public void onStateChanged (com.unitech.lib.transport.types.ConnectState p0, java.lang.Object p1)
	{
		n_onStateChanged (p0, p1);
	}

	private native void n_onStateChanged (com.unitech.lib.transport.types.ConnectState p0, java.lang.Object p1);


	public void onTemperatureState (double p0, java.lang.Object p1)
	{
		n_onTemperatureState (p0, p1);
	}

	private native void n_onTemperatureState (double p0, java.lang.Object p1);

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
