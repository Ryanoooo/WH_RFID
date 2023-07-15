package mono.com.unitech.lib.protocol;


public class IProtocolEventListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.unitech.lib.protocol.IProtocolEventListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onEvent:(IILjava/lang/Object;)V:GetOnEvent_IILjava_lang_Object_Handler:Com.Unitech.Lib.Protocol.IProtocolEventListenerInvoker, libunitechRFID\n" +
			"";
		mono.android.Runtime.register ("Com.Unitech.Lib.Protocol.IProtocolEventListenerImplementor, libunitechRFID", IProtocolEventListenerImplementor.class, __md_methods);
	}


	public IProtocolEventListenerImplementor ()
	{
		super ();
		if (getClass () == IProtocolEventListenerImplementor.class) {
			mono.android.TypeManager.Activate ("Com.Unitech.Lib.Protocol.IProtocolEventListenerImplementor, libunitechRFID", "", this, new java.lang.Object[] {  });
		}
	}


	public void onEvent (int p0, int p1, java.lang.Object p2)
	{
		n_onEvent (p0, p1, p2);
	}

	private native void n_onEvent (int p0, int p1, java.lang.Object p2);

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
