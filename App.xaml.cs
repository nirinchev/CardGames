﻿using System.Windows;

namespace CardGames
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		private void Application_Startup(object sender, StartupEventArgs e)
		{
			// Create the startup window
			MainWindow wnd = new MainWindow();
			// Do stuff here, e.g. to the window
			wnd.Title = "Something else";
			// Show the window
			wnd.Show();
		}
	}
}
