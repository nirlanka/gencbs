using System;
using Gtk;
using gencbs.Resources;

public partial class MainWindow: Gtk.Window
{
	string[] _cmbResourceType1;
	string[] _cmbResourceType2;

	ToolButton btnSync, btnCopy, btnAdd, btnDelete, btnSave;

	public MainWindow () : base (Gtk.WindowType.Toplevel)
	{
		Build ();
		this.Resize (800, 600);

		// resource-type setup
		_cmbResourceType1 = new string [] { "—", "one", "two", "three" };
		SetComboBoxEntries (cmbResourceType1, _cmbResourceType1);
		_cmbResourceType2 = new string [] { "—", "one", "two", "three" };
		SetComboBoxEntries (cmbResourceType2, _cmbResourceType2);

		// toolbar setup
		btnSync = (ToolButton)toolbarMain.Children.GetValue (0);
		btnCopy = (ToolButton)toolbarMain.Children.GetValue (1);
		btnAdd = (ToolButton)toolbarMain.Children.GetValue (2);
		btnDelete = (ToolButton)toolbarMain.Children.GetValue (3);
		btnSave = (ToolButton)toolbarMain.Children.GetValue (4);
		// toolbar tooltips
		btnSync.TooltipText = "Sync changes with file system";
		btnCopy.TooltipText = "Clone current resource";
		btnAdd.TooltipText = "Add resource";
		btnDelete.TooltipText = "Delete current resource";
		btnSave.TooltipText = "Accept changes to current resource";
		// toolbar event handlers
		btnSync.Clicked += SyncCallBack;
	}



	/* callbacks */

	protected void SyncCallBack (object sender, EventArgs e)
	{
		try {
			var res = CollectInput ();
		} catch (InvalidCastException ex) {
			ShowMessageDialog (MessageType.Error, ButtonsType.Ok, "Efficiency and the costs must be integers");
		}
		// TODO: implement
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}


	/* functionality */

	// create object with input data
	protected Resource CollectInput ()
	{
		int eff=0, cost=0;
		try {
			eff = int.Parse (txtEfficiency.Text);
			cost = int.Parse (txtCostPerHour.Text);
		} catch	(Exception ex) {
			throw new InvalidCastException ();
		}

		// TODO: fix resource-type and other inputs
		var res = new Resource (txtName.Text, new ResourceType ("restype"), eff, cost);
		return res;
	}


	/* helper functions */

	protected void ShowMessageDialog (MessageType type, ButtonsType btns, string msg)
	{
		MessageDialog md = new MessageDialog (
			this, 
			DialogFlags.DestroyWithParent,
			type, 
			btns, 
			msg
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
		cmbResourceType1.Clear ();
		Gtk.CellRendererText text = new Gtk.CellRendererText ();
		cmbResourceType1.Model = __cmb;
		cmbResourceType1.PackStart (text, false);
		cmbResourceType1.AddAttribute (text, "text", 0);
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
