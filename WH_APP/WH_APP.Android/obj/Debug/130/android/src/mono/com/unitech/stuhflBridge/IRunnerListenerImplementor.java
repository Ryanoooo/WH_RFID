package mono.com.unitech.stuhflBridge;


public class IRunnerListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.unitech.stuhflBridge.IRunnerListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_Cycle:(Lcom/unitech/stuhflBridge/IRunnerListener$STUHFL_T_InventoryStatistics;Ljava/util/List;)Z:GetCycle_Lcom_unitech_stuhflBridge_IRunnerListener_STUHFL_T_InventoryStatistics_Ljava_util_List_Handler:Com.Unitech.StuhflBridge.IRunnerListenerInvoker, libunitechRFID\n" +
			"n_Finished:(Lcom/unitech/stuhflBridge/IRunnerListener$STUHFL_T_InventoryStatistics;Ljava/util/List;)V:GetFinished_Lcom_unitech_stuhflBridge_IRunnerListener_STUHFL_T_InventoryStatistics_Ljava_util_List_Handler:Com.Unitech.StuhflBridge.IRunnerListenerInvoker, libunitechRFID\n" +
			"";
		mono.android.Runtime.register ("Com.Unitech.StuhflBridge.IRunnerListenerImplementor, libunitechRFID", IRunnerListenerImplementor.class, __md_methods);
	}


	public IRunnerListenerImplementor ()
	{
		super ();
		if (getClass () == IRunnerListenerImplementor.class) {
			mono.android.TypeManager.Activate ("Com.Unitech.StuhflBridge.IRunnerListenerImplementor, libunitechRFID", "", this, new java.lang.Object[] {  });
		}
	}


	public boolean Cycle (com.unitech.stuhflBridge.IRunnerListener.STUHFL_T_InventoryStatistics p0, java.util.List p1)
	{
		return n_Cycle (p0, p1);
	}

	private native boolean n_Cycle (com.unitech.stuhflBridge.IRunnerListener.STUHFL_T_InventoryStatistics p0, java.util.List p1);


	public void Finished (com.unitech.stuhflBridge.IRunnerListener.STUHFL_T_InventoryStatistics p0, java.util.List p1)
	{
		n_Finished (p0, p1);
	}

	private native void n_Finished (com.unitech.stuhflBridge.IRunnerListener.STUHFL_T_InventoryStatistics p0, java.util.List p1);

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
