package crc644103bb497e895a1b;


public class InputLayoutClearButtonViewRenderer_GestureListener
	extends android.view.GestureDetector.SimpleOnGestureListener
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onDown:(Landroid/view/MotionEvent;)Z:GetOnDown_Landroid_view_MotionEvent_Handler\n" +
			"n_onSingleTapUp:(Landroid/view/MotionEvent;)Z:GetOnSingleTapUp_Landroid_view_MotionEvent_Handler\n" +
			"";
		mono.android.Runtime.register ("Syncfusion.XForms.Android.TextInputLayout.InputLayoutClearButtonViewRenderer+GestureListener, Syncfusion.Core.XForms.Android", InputLayoutClearButtonViewRenderer_GestureListener.class, __md_methods);
	}


	public InputLayoutClearButtonViewRenderer_GestureListener ()
	{
		super ();
		if (getClass () == InputLayoutClearButtonViewRenderer_GestureListener.class)
			mono.android.TypeManager.Activate ("Syncfusion.XForms.Android.TextInputLayout.InputLayoutClearButtonViewRenderer+GestureListener, Syncfusion.Core.XForms.Android", "", this, new java.lang.Object[] {  });
	}

	public InputLayoutClearButtonViewRenderer_GestureListener (crc644103bb497e895a1b.InputLayoutClearButtonViewRenderer p0)
	{
		super ();
		if (getClass () == InputLayoutClearButtonViewRenderer_GestureListener.class)
			mono.android.TypeManager.Activate ("Syncfusion.XForms.Android.TextInputLayout.InputLayoutClearButtonViewRenderer+GestureListener, Syncfusion.Core.XForms.Android", "Syncfusion.XForms.Android.TextInputLayout.InputLayoutClearButtonViewRenderer, Syncfusion.Core.XForms.Android", this, new java.lang.Object[] { p0 });
	}


	public boolean onDown (android.view.MotionEvent p0)
	{
		return n_onDown (p0);
	}

	private native boolean n_onDown (android.view.MotionEvent p0);


	public boolean onSingleTapUp (android.view.MotionEvent p0)
	{
		return n_onSingleTapUp (p0);
	}

	private native boolean n_onSingleTapUp (android.view.MotionEvent p0);

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
