﻿using OvertimeTracker.Views;

namespace OvertimeTracker
{
	public partial class AppShell : Shell
	{
		public AppShell()
		{
			InitializeComponent();
			Routing.RegisterRoute(nameof(AddPage), typeof(AddPage));
		}
	}
}
