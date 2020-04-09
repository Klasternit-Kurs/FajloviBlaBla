using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace FajloviBlaBla
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			foreach (string ld in System.Environment.GetLogicalDrives())
			{
				TreeViewItem tvI = new TreeViewItem();
				tvI.Header = ld;
				tv.Items.Add(tvI);

				DriveInfo drajv = new DriveInfo(ld);

				if (drajv.IsReady)
				{
					tvI.Tag = new DirectoryInfo(ld);
					IzlistajDirektorijum(tvI);
				}
				//DriveInfo
				//DirectoryInfo
				//FileInfo
			}
		}

		private void IzlistajDirektorijum(TreeViewItem tvI)
		{
			try
			{
				foreach (DirectoryInfo di in (tvI.Tag as DirectoryInfo).GetDirectories())
				{
					TreeViewItem tvD = new TreeViewItem();
					tvD.Header = di.Name;
					tvD.Tag = di;
					tvD.Expanded += MojaMetodaZaDogadjaj;

					tvI.Items.Add(tvD);
					try
					{
						if (di.GetDirectories().Length != 0 || di.GetFiles().Length != 0)
						{
							tvD.Items.Add("*");
						}
					}
					catch { }
				}


				foreach (FileInfo fi in (tvI.Tag as DirectoryInfo).GetFiles())
				{
					TreeViewItem tvF = new TreeViewItem();
					tvF.Header = fi.Name;
					tvF.Tag = fi;
					tvI.Items.Add(tvF);
				}
			}
			catch { }
		}

		public void MojaMetodaZaDogadjaj(object KoSalje, RoutedEventArgs a)
		{
			var tvI  = KoSalje as TreeViewItem;
			if (tvI.Items.Contains("*"))
			{
				tvI.Items.Remove("*");
				IzlistajDirektorijum(tvI);
			}
		}

		private void RadiOvo(object sender, DependencyPropertyChangedEventArgs e)
		{

		}

		private void PromenaSelekcije(object sender, RoutedPropertyChangedEventArgs<object> e)
		{
			var tv = sender as TreeView;

			if (tv.SelectedItem != null)
			{
				TreeViewItem tvI = tv.SelectedItem as TreeViewItem;

				/*if (tv.SelectedItem is FileInfo f)
				{ 
				}
				else
				{
					var d = tv.SelectedItem as DirectoryInfo;
				}*/
					
				switch(tvI.Tag)
				{
					case DirectoryInfo d:
						lblExt.Content = "--";
						lblNap.Content = d.CreationTime;
						lblPri.Content = d.LastAccessTime;
						break;
					case FileInfo f:
						lblExt.Content = f.Extension;
						lblNap.Content = f.CreationTime;
						lblPri.Content = f.LastAccessTime;
						break;
				}
			}
		}

		/*
		private void IzlistajDirektorijum(TreeViewItem tvI)
		{
			try
			{
				foreach (DirectoryInfo di in (tvI.Tag as DirectoryInfo).GetDirectories())
				{
					TreeViewItem tvD = new TreeViewItem();
					tvD.Header = di.Name;
					tvD.Tag = di;
					tvI.Items.Add(tvD);
					IzlistajDirektorijum(tvD);
				}
			

				foreach (FileInfo fi in (tvI.Tag as DirectoryInfo).GetFiles())
				{
					TreeViewItem tvF = new TreeViewItem();
					tvF.Header = fi.Name;
					tvF.Tag = tvF;
					tvI.Items.Add(tvF);
				}
			}
			catch { }
		}*/
	}
}
