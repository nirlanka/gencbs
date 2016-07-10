using System;
using Gtk;

namespace UI
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Application.Init ();
			MainWindow win = new MainWindow ();
			win.Show ();
			Application.Run ();

//			Gtk.TreeIter iter;
//			combo.Model.GetIterFirst (out iter);
//			do {
//				GLib.Value thisRow = new GLib.Value ();
//				combo.Model.GetValue (iter, 0, ref thisRow);
//				if ((thisRow.Val as string).Equals("two")) {
//					combo.SetActiveIter (iter);
//					break;
//				}
//			} while (combo.Model.IterNext (ref iter));
		}
	}
}
