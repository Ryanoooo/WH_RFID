package mono.com.unitech.lib.uhf.event;


public class IModuleRfidUhfEventListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.unitech.lib.uhf.event.IModuleRfidUhfEventListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onAccessResult:(Lcom/unitech/lib/types/ResultCode;Lcom/unitech/lib/types/ActionType;Ljava/lang/String;Ljava/lang/String;Ljava/lang/Object;)V:GetOnAccessResult_Lcom_unitech_lib_types_ResultCode_Lcom_unitech_lib_types_ActionType_Ljava_lang_String_Ljava_lang_String_Ljava_lang_Object_Handler:Com.Unitech.Lib.Uhf.Event.IModuleRfidUhfEventListenerInvoker, libunitechRFID\n" +
			"n_onReadTag:(Ljava/lang/String;Ljava/lang/Object;)V:GetOnReadTag_Ljava_lang_String_Ljava_lang_Object_Handler:Com.Unitech.Lib.Uhf.Event.IModuleRfidUhfEventListenerInvoker, libunitechRFID\n" +
			"";
		mono.android.Runtime.register ("Com.Unitech.Lib.Uhf.Event.IModuleRfidUhfEventListenerImplementor, libunitechRFID", IModuleRfidUhfEventListenerImplementor.class, __md_methods);
	}


	public IModuleRfidUhfEventListenerImplementor ()
	{
		super ();
		if (getClass () == IModuleRfidUhfEventListenerImplementor.class) {
			mono.android.TypeManager.Activate ("Com.Unitech.Lib.Uhf.Event.IModuleRfidUhfEventListenerImplementor, libunitechRFID", "", this, new java.lang.Object[] {  });
		}
	}


	public void onAccessResult (com.unitech.lib.types.ResultCode p0, com.unitech.lib.types.ActionType p1, java.lang.String p2, java.lang.String p3, java.lang.Object p4)
	{
		n_onAccessResult (p0, p1, p2, p3, p4);
	}

	private native void n_onAccessResult (com.unitech.lib.types.ResultCode p0, com.unitech.lib.types.ActionType p1, java.lang.String p2, java.lang.String p3, java.lang.Object p4);


	public void onReadTag (java.lang.String p0, java.lang.Object p1)
	{
		n_onReadTag (p0, p1);
	}

	private native void n_onReadTag (java.lang.String p0, java.lang.Object p1);

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
