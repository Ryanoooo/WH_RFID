package mono.com.unitech.lib.uhf.event;


public class IRfidUhfEventListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.unitech.lib.uhf.event.IRfidUhfEventListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onRfidUhfAccessResult:(Lcom/unitech/lib/uhf/BaseUHF;Lcom/unitech/lib/types/ResultCode;Lcom/unitech/lib/types/ActionState;Ljava/lang/String;Ljava/lang/String;Ljava/lang/Object;)V:GetOnRfidUhfAccessResult_Lcom_unitech_lib_uhf_BaseUHF_Lcom_unitech_lib_types_ResultCode_Lcom_unitech_lib_types_ActionState_Ljava_lang_String_Ljava_lang_String_Ljava_lang_Object_Handler:Com.Unitech.Lib.Uhf.Event.IRfidUhfEventListenerInvoker, libunitechRFID\n" +
			"n_onRfidUhfReadTag:(Lcom/unitech/lib/uhf/BaseUHF;Ljava/lang/String;Ljava/lang/Object;)V:GetOnRfidUhfReadTag_Lcom_unitech_lib_uhf_BaseUHF_Ljava_lang_String_Ljava_lang_Object_Handler:Com.Unitech.Lib.Uhf.Event.IRfidUhfEventListenerInvoker, libunitechRFID\n" +
			"";
		mono.android.Runtime.register ("Com.Unitech.Lib.Uhf.Event.IRfidUhfEventListenerImplementor, libunitechRFID", IRfidUhfEventListenerImplementor.class, __md_methods);
	}


	public IRfidUhfEventListenerImplementor ()
	{
		super ();
		if (getClass () == IRfidUhfEventListenerImplementor.class) {
			mono.android.TypeManager.Activate ("Com.Unitech.Lib.Uhf.Event.IRfidUhfEventListenerImplementor, libunitechRFID", "", this, new java.lang.Object[] {  });
		}
	}


	public void onRfidUhfAccessResult (com.unitech.lib.uhf.BaseUHF p0, com.unitech.lib.types.ResultCode p1, com.unitech.lib.types.ActionState p2, java.lang.String p3, java.lang.String p4, java.lang.Object p5)
	{
		n_onRfidUhfAccessResult (p0, p1, p2, p3, p4, p5);
	}

	private native void n_onRfidUhfAccessResult (com.unitech.lib.uhf.BaseUHF p0, com.unitech.lib.types.ResultCode p1, com.unitech.lib.types.ActionState p2, java.lang.String p3, java.lang.String p4, java.lang.Object p5);


	public void onRfidUhfReadTag (com.unitech.lib.uhf.BaseUHF p0, java.lang.String p1, java.lang.Object p2)
	{
		n_onRfidUhfReadTag (p0, p1, p2);
	}

	private native void n_onRfidUhfReadTag (com.unitech.lib.uhf.BaseUHF p0, java.lang.String p1, java.lang.Object p2);

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
