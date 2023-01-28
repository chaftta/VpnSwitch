using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VpnSwith {
	public partial class MainForm : Form {
		/// <summary>VPNの名前</summary>
		private string VpnName;
		/// <summary>通知領域に表示するアイコンの一覧</summary>
		private Icon[] StateIcons = new [] { Properties.Resources.Off, Properties.Resources.On, };
		/// <summary>通知領域のアイコン</summary>
		NotifyIcon notifyIcon;
		public MainForm(string VpnName) {
			InitializeComponent();
			this.VpnName = VpnName ?? "VPN";
			// windowを表示しない
			ShowInTaskbar = false;
			WindowState = FormWindowState.Minimized;

			// タスクトレイのアイコン
			notifyIcon = new NotifyIcon();
			notifyIcon.Visible = true;
			notifyIcon.Text = "VPN接続";
			notifyIcon.MouseClick += (S, E) => {
				switch(E.Button) {
					case MouseButtons.Left:
						SwitchState();
						return;
					case MouseButtons.Right:
						//Application.Exit();
						return;
				}
			};

			// コンテキストメニュー
			var notifyMenu = new ContextMenuStrip();
			var menuItem = new ToolStripMenuItem();
			menuItem.Text = "終了";
			menuItem.Click += (Sender, Event) => { Application.Exit(); };
			notifyMenu.Items.Add(menuItem);
			notifyIcon.ContextMenuStrip = notifyMenu;

			NetworkChange.NetworkAddressChanged += (s, e) => { UpdateState(); };
			// アイコンの初期化
			UpdateState();
		}
		/// <summary>ステータス状態を更新する</summary>
		void UpdateState() {
			var IsUp = GetState();
			notifyIcon.Icon = new Icon(StateIcons[IsUp ? 1 : 0], new Size(48, 48));
		}
		/// <summary>ステータスをスイッチする</summary>
		void SwitchState() {
			var IsUp = GetState();
			var info = new ProcessStartInfo("rasphone");
			info.CreateNoWindow = true;
			info.WindowStyle = ProcessWindowStyle.Hidden;
			info.Arguments = (IsUp ? " -h ": " -d ") + VpnName;
			
			var hProcess = Process.Start(info);
			hProcess.WaitForExit();
			hProcess.Close();
			hProcess.Dispose();
		}
		/// <summary>VPNが起動しているか取得する</summary>
		/// <returns>true:起動中 false:停止中</returns>
		private bool GetState() {
			bool Up = false;
			try { 
				Up = NetworkInterface.GetAllNetworkInterfaces().Any(N => N.NetworkInterfaceType == NetworkInterfaceType.Ppp && N.Name == VpnName);
			} catch {}
			return Up;
		}
	}
}
