package mono.com.unitech.lib.transport.event;


public class IConnectStateEventListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.unitech.lib.transport.event.IConnectStateEventListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onStateChanged:(Lcom/unitech/lib/transport/types/ConnectState;Ljava/lang/Object;)V:GetOnStateChanged_Lcom_unitech_lib_transport_types_ConnectState_Ljava_lang_Object_Handler:Com.Unitech.Lib.Transport.Event.IConnectStateEventListenerInvoker, libunitechRFID\n" +
			"";
		mono.android.Runtime.register ("Com.Unitech.Lib.Transport.Event.IConnectStateEventListenerImplementor, libunitechRFID", IConnectStateEventListenerImplementor.class, __md_methods);
	}


	public IConnectStateEventListenerImplementor ()
	{
		super ();
		if (getClass () == IConnectStateEventListenerImplementor.class) {
			mono.android.TypeManager.Activate ("Com.Unitech.Lib.Transport.Event.IConnectStateEventListenerImplementor, libunitechRFID", "", this, new java.lang.Object[] {  });
		}
	}


	public void onStateChanged (com.unitech.lib.transport.types.ConnectState p0, java.lang.Object p1)
	{
		n_onStateChanged (p0, p1);
	}

	private native void n_onStateChanged (com.unitech.lib.transport.types.ConnectState p0, java.lang.Object p1);

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
