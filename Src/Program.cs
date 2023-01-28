using System;
using System.Windows.Forms;

namespace VpnSwith {
	static class Program {
		/// <summary>アプリケーションのメイン エントリ ポイント</summary>
		[STAThread]
		static void Main(string[] Args) {
			// 引数があれば第一引数をVPN名として起動する
			var VpnName = Args.Length != 0 ? Args[0] : null;
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm(VpnName));
		}
	}
}
