package mono.com.unitech.lib.transport.event;


public class IBufferControlEventListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.unitech.lib.transport.event.IBufferControlEventListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onOverflow:()V:GetOnOverflowHandler:Com.Unitech.Lib.Transport.Event.IBufferControlEventListenerInvoker, libunitechRFID\n" +
			"n_onUnderflow:()V:GetOnUnderflowHandler:Com.Unitech.Lib.Transport.Event.IBufferControlEventListenerInvoker, libunitechRFID\n" +
			"";
		mono.android.Runtime.register ("Com.Unitech.Lib.Transport.Event.IBufferControlEventListenerImplementor, libunitechRFID", IBufferControlEventListenerImplementor.class, __md_methods);
	}


	public IBufferControlEventListenerImplementor ()
	{
		super ();
		if (getClass () == IBufferControlEventListenerImplementor.class) {
			mono.android.TypeManager.Activate ("Com.Unitech.Lib.Transport.Event.IBufferControlEventListenerImplementor, libunitechRFID", "", this, new java.lang.Object[] {  });
		}
	}


	public void onOverflow ()
	{
		n_onOverflow ();
	}

	private native void n_onOverflow ();


	public void onUnderflow ()
	{
		n_onUnderflow ();
	}

	private native void n_onUnderflow ();

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
