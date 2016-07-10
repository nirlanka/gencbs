using System;
using Gtk;

public partial class MainWindow: Gtk.Window
{
	string[] _cmbOne;

	public MainWindow () : base (Gtk.WindowType.Toplevel)
	{
		Build ();

		btnTwo.Clicked += TestCallBack;

		_cmbOne = new string[]{"","one", "two", "three"};
		var __cmbOne = new ListStore (typeof(string), typeof(int));
		int i = 0;
		foreach (var item in _cmbOne) {
			__cmbOne.AppendValues (item, i++);
		}
		cmbOne.Clear ();
		Gtk.CellRendererText text = new Gtk.CellRendererText ();
		cmbOne.Model = __cmbOne;
		cmbOne.PackStart (text, false);
		cmbOne.AddAttribute (text, "text", 0);
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected void TestCallBack (object o, EventArgs e)
	{
		TreeIter iter;
		int positionMask = 0;
		if (cmbOne.GetActiveIter (out iter))
			positionMask = (int) cmbOne.Model.GetValue (iter, 1);

		MessageDialog md = new MessageDialog (
			this, 
			DialogFlags.DestroyWithParent,
			MessageType.Info, 
			ButtonsType.Ok, 
			"Selected item is " + _cmbOne[positionMask]
		);

		md.Run ();
		md.Destroy();
	}
}
