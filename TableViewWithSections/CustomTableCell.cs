
using System;

using Foundation;
using UIKit;

namespace TableViewWithSections
{
	public partial class CustomTableCell : UITableViewCell
	{
		public static readonly UINib Nib = UINib.FromName ("CustomTableCell", NSBundle.MainBundle);
		public static readonly NSString Key = new NSString ("CustomTableCell");

		public CustomTableCell (IntPtr handle) : base (handle)
		{
		}

		public static CustomTableCell Create ()
		{
			return (CustomTableCell)Nib.Instantiate (null, null) [0];
		}
	}
}

