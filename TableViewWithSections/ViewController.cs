using System;
using CoreGraphics;
using UIKit;
using Foundation;
using System.IO;
using System.Collections.Generic;

namespace TableViewWithSections
{
	public partial class ViewController : UIViewController
	{
		public ViewController (IntPtr handle) : base (handle)
		{
		}
		public UITableView customTableView;
		static NSString cellIdentifier = new NSString ("tableCell");
		public List<string> tableViewItems = new List<string>();
		public int numberOfSections;

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.
			this.createTableView();
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}

		public void createTableView()
		{
			customTableView = new UITableView (View.Bounds);
			this.View.Add (customTableView);
			tableViewItems.Add ("Row1");
			tableViewItems.Add ("Row2");
			tableViewItems.Add ("Row3");
			tableViewItems.Add ("Row4");
			tableViewItems.Add ("Row5");

			numberOfSections = 3;

			customTableView.Source = new TableSource (this,tableViewItems);
			customTableView.TableFooterView = new UIView(new CGRect(0,0,0,0));
		}
		public class TableSource : UITableViewSource 
		{
			ViewController viewcontroller;
			List<string> tableViewItems;

			public TableSource (ViewController viewcontroller,List<string> TableItems)
			{
				this.viewcontroller = viewcontroller;
				this.tableViewItems = TableItems;
			}

			public override nint NumberOfSections (UITableView tableView)
			{
				return this.viewcontroller.numberOfSections;
			}

			public override nint RowsInSection (UITableView tableview, nint section)
			{
				return this.tableViewItems.Count;

				//differentiate the number of rows that yuo wanted ineach section here
//				 if(section == 0)
//					{
//					 return list1.count;
//					}
//				else if(section == 1)
//				{
//					return list2.count;
//				}
//				else
//				{
//					return list3.count;
//				}

			}

			public override nfloat GetHeightForHeader (UITableView tableView, nint section)
			{
				return 30.0f;
			}
			public override UIView GetViewForHeader (UITableView tableView, nint section)
			{
				UILabel headerLabel = new UILabel ();
				for (int i = 0; i < this.viewcontroller.numberOfSections; i++) {
					if (i == section) {
						headerLabel.Frame = tableView.Frame; 
						headerLabel.TextColor = UIColor.FromRGB (0, 171, 200);
						headerLabel.BackgroundColor = UIColor.FromRGB (0, 113, 243);
						headerLabel.Text = section.ToString ();
						headerLabel.TextAlignment = UITextAlignment.Center;
						return headerLabel;
					} 
				}
				return headerLabel;
			}

			public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
			{  
				UITableViewCell cell = new UITableViewCell (UITableViewCellStyle.Subtitle, cellIdentifier);
				cell.TextLabel.Text = "section  "+this.tableViewItems [indexPath.Row];
				cell.TextLabel.Font = UIFont.FromName ("Helvetica Neue", 14);
				cell.BackgroundColor = UIColor.LightGray;
				cell.SelectionStyle = UITableViewCellSelectionStyle.None;
					
				cell.Accessory = UITableViewCellAccessory.Checkmark;
				//cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
				//cell.Accessory = UITableViewCellAccessory.DetailDisclosureButton; // implement AccessoryButtonTapped
				//cell.Accessory = UITableViewCellAccessory.None; // to clear the accessory

				return cell;
			}
			public override void RowSelected (UITableView tableView,Foundation.NSIndexPath indexPath)
			{
				int row = indexPath.Row+1;
				this.InvokeOnMainThread (delegate {
					new UIAlertView ("Alert!", "you selected section"+indexPath.Section + " and row "+row, null, "OK", null).Show();
					return;
				}   );
			}
		}
	}
}

