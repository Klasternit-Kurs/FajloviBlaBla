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
			foreach(string ld in System.Environment.GetLogicalDrives())
			{
				TreeViewItem tvI = new TreeViewItem();
				tvI.Header = ld;
				tv.Items.Add(tvI);

				DriveInfo drajv = new DriveInfo(ld);

				if (drajv.IsReady)
				{
					DirectoryInfo dir = drajv.RootDirectory;
					foreach (DirectoryInfo di in dir.GetDirectories())
					{
						TreeViewItem tvD = new TreeViewItem();
						tvD.Header = di.Name;
						tvI.Items.Add(tvD);
					}
					foreach (FileInfo fi in dir.GetFiles())
					{
						TreeViewItem tvF = new TreeViewItem();
						tvF.Header = fi.Name;
						tvI.Items.Add(tvF);
					}
				}
				//DriveInfo
				//DirectoryInfo
				//FileInfo
			}
		}
		private void IzlistajDirektorijum()
		{

		}
	}
}
