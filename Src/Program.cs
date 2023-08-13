using System;
using System.Windows.Forms;

namespace VpnSwith {
	static class Program {
		private static MainForm Form;
		/// <summary>アプリケーションのメイン エントリ ポイント</summary>
		[STAThread]
		static void Main(string[] Args) {
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			// 引数があれば第一引数をVPN名として起動する
			var VpnName = Args.Length != 0 ? Args[0] : null;
			Form = new MainForm(VpnName);
			Application.Run();
		}
	}
}
