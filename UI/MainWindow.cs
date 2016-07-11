using System;
using Gtk;

public partial class MainWindow: Gtk.Window
{
	string[] _cmbOne;

	ToolButton btnSync, btnCopy, btnAdd, btnDelete, btnSave;

	public MainWindow () : base (Gtk.WindowType.Toplevel)
	{
		Build ();

//		btnTwo.Clicked += TestCallBack;

		_cmbOne = new string [] { "—", "one", "two", "three" };
		SetComboBoxEntries (cmbOne, _cmbOne);

		btnSync = (ToolButton)toolbarMain.Children.GetValue (0);
		btnCopy = (ToolButton)toolbarMain.Children.GetValue (1);
		btnAdd = (ToolButton)toolbarMain.Children.GetValue (2);
		btnDelete = (ToolButton)toolbarMain.Children.GetValue (3);
		btnSave = (ToolButton)toolbarMain.Children.GetValue (4);

		btnSync.TooltipText = "Sync changes with file system";
		btnCopy.TooltipText = "Clone current resource";
		btnAdd.TooltipText = "Add resource";
		btnDelete.TooltipText = "Delete current resource";
		btnSave.TooltipText = "Accept changes to current resource";

	}


	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected void TestCallBack (object o, EventArgs e)
	{
		int positionMask = GetComboBoxSelection (cmbOne);

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


	protected void SetComboBoxEntries (ComboBox cmb, string[] list)
	{
		var __cmb = new ListStore (typeof(string), typeof(int));
		int i = 0;
		foreach (var item in list) {
			__cmb.AppendValues (item, i++);
		}
		cmbOne.Clear ();
		Gtk.CellRendererText text = new Gtk.CellRendererText ();
		cmbOne.Model = __cmb;
		cmbOne.PackStart (text, false);
		cmbOne.AddAttribute (text, "text", 0);
	}

	protected int GetComboBoxSelection (ComboBox cmb)
	{
		TreeIter iter;
		int positionMask = 0;
		if (cmb.GetActiveIter (out iter))
			positionMask = (int) cmb.Model.GetValue (iter, 1);

		return positionMask;
	}

}
