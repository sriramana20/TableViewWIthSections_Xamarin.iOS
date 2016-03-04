TableViewWIthSections_Xamarin.iOS

UITableView can have a ‘grouped’ or ‘plain’ style, and consists of the following parts:
•	Section Header
•	Cells (or rows, if you prefer)
•	Section Footer
•	Index

To add rows to a UITableView you need to implement a UITableViewSource subclass and override the methods that the table view calls to populate itself.
•	Subclassing a UITableViewSource
•	Cell Reuse
•	Adding an Index
•	Adding Headers and Footers

A UITableViewSource subclass is assigned to every UITableView. The table view queries the source class to determine how to render itself (for example, how many rows are required and the height of each row if different from the default). Most importantly, the source supplies each cell view populated with data.
There are only two mandatory methods required to make a table display data:
•	RowsInSection – return an nint count of the total number of rows of data the table should display.
GetCell – return a UITableCellView populated with data for the corresponding row index passed to the method.

In this example , I have created a table view and one can specify the number of sections they want in the table by simply mentioning the number to the property “numberOfSections”, this will creates a table with the sections specified by the user.
And  section titles can be changed by user , and also the number of rows in each section you can mention there. And various acessors also shown depending upon usage one can modify them.

Requirements 
Xamarin Studio
Xcode 7

Author
K.SriRamana
