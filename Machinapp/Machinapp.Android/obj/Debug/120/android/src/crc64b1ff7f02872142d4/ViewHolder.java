package crc64b1ff7f02872142d4;


public class ViewHolder
	extends androidx.recyclerview.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Com.Syncfusion.Carousel.ViewHolder, Syncfusion.SfCarousel.XForms.Android", ViewHolder.class, __md_methods);
	}


	public ViewHolder (android.view.View p0)
	{
		super (p0);
		if (getClass () == ViewHolder.class)
			mono.android.TypeManager.Activate ("Com.Syncfusion.Carousel.ViewHolder, Syncfusion.SfCarousel.XForms.Android", "Android.Views.View, Mono.Android", this, new java.lang.Object[] { p0 });
	}

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
