package crc644103bb497e895a1b;


public class SfTextInputLayoutRenderer
	extends crc643f46942d9dd1fff9.ViewRenderer_2
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onAttachedToWindow:()V:GetOnAttachedToWindowHandler\n" +
			"";
		mono.android.Runtime.register ("Syncfusion.XForms.Android.TextInputLayout.SfTextInputLayoutRenderer, Syncfusion.Core.XForms.Android", SfTextInputLayoutRenderer.class, __md_methods);
	}


	public SfTextInputLayoutRenderer (android.content.Context p0)
	{
		super (p0);
		if (getClass () == SfTextInputLayoutRenderer.class)
			mono.android.TypeManager.Activate ("Syncfusion.XForms.Android.TextInputLayout.SfTextInputLayoutRenderer, Syncfusion.Core.XForms.Android", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public SfTextInputLayoutRenderer (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == SfTextInputLayoutRenderer.class)
			mono.android.TypeManager.Activate ("Syncfusion.XForms.Android.TextInputLayout.SfTextInputLayoutRenderer, Syncfusion.Core.XForms.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public SfTextInputLayoutRenderer (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == SfTextInputLayoutRenderer.class)
			mono.android.TypeManager.Activate ("Syncfusion.XForms.Android.TextInputLayout.SfTextInputLayoutRenderer, Syncfusion.Core.XForms.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public void onAttachedToWindow ()
	{
		n_onAttachedToWindow ();
	}

	private native void n_onAttachedToWindow ();

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
