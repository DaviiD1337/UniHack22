<<<<<<<< HEAD:CityInMotionSend/CityInMotionSend.Android/obj/Debug/120/android/src/crc647769522fa831a56f/MainActivity.java
package crc647769522fa831a56f;
========
package crc647bc47abe512c4ddf;
>>>>>>>> a32d994572509f769abf1abe44e7e99c67476347:CityInMotionApp/CityInMotionApp/CityInMotionApp.Android/obj/Debug/130/android/src/crc647bc47abe512c4ddf/MainActivity.java


public class MainActivity
	extends crc643f46942d9dd1fff9.FormsAppCompatActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"n_onRequestPermissionsResult:(I[Ljava/lang/String;[I)V:GetOnRequestPermissionsResult_IarrayLjava_lang_String_arrayIHandler\n" +
			"";
<<<<<<<< HEAD:CityInMotionSend/CityInMotionSend.Android/obj/Debug/120/android/src/crc647769522fa831a56f/MainActivity.java
		mono.android.Runtime.register ("CityInMotionSend.Droid.MainActivity, CityInMotionSend.Android", MainActivity.class, __md_methods);
========
		mono.android.Runtime.register ("CityInMotionApp.Droid.MainActivity, CityInMotionApp.Android", MainActivity.class, __md_methods);
>>>>>>>> a32d994572509f769abf1abe44e7e99c67476347:CityInMotionApp/CityInMotionApp/CityInMotionApp.Android/obj/Debug/130/android/src/crc647bc47abe512c4ddf/MainActivity.java
	}


	public MainActivity ()
	{
		super ();
		if (getClass () == MainActivity.class) {
<<<<<<<< HEAD:CityInMotionSend/CityInMotionSend.Android/obj/Debug/120/android/src/crc647769522fa831a56f/MainActivity.java
			mono.android.TypeManager.Activate ("CityInMotionSend.Droid.MainActivity, CityInMotionSend.Android", "", this, new java.lang.Object[] {  });
========
			mono.android.TypeManager.Activate ("CityInMotionApp.Droid.MainActivity, CityInMotionApp.Android", "", this, new java.lang.Object[] {  });
>>>>>>>> a32d994572509f769abf1abe44e7e99c67476347:CityInMotionApp/CityInMotionApp/CityInMotionApp.Android/obj/Debug/130/android/src/crc647bc47abe512c4ddf/MainActivity.java
		}
	}


	public MainActivity (int p0)
	{
		super (p0);
		if (getClass () == MainActivity.class) {
<<<<<<<< HEAD:CityInMotionSend/CityInMotionSend.Android/obj/Debug/120/android/src/crc647769522fa831a56f/MainActivity.java
			mono.android.TypeManager.Activate ("CityInMotionSend.Droid.MainActivity, CityInMotionSend.Android", "System.Int32, mscorlib", this, new java.lang.Object[] { p0 });
========
			mono.android.TypeManager.Activate ("CityInMotionApp.Droid.MainActivity, CityInMotionApp.Android", "System.Int32, mscorlib", this, new java.lang.Object[] { p0 });
>>>>>>>> a32d994572509f769abf1abe44e7e99c67476347:CityInMotionApp/CityInMotionApp/CityInMotionApp.Android/obj/Debug/130/android/src/crc647bc47abe512c4ddf/MainActivity.java
		}
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);


	public void onRequestPermissionsResult (int p0, java.lang.String[] p1, int[] p2)
	{
		n_onRequestPermissionsResult (p0, p1, p2);
	}

	private native void n_onRequestPermissionsResult (int p0, java.lang.String[] p1, int[] p2);

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
