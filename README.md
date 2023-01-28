# VpnSwitch

このソフトは、Windows10でVPNをワンクリックで切り替える為のソフトです。  
VPNの接続設定は、予めWindows側で行っておく必要があります。

## 使い方

1. 起動する
	以下のコマンドを実行する(ショートカットで以下のコマンドになるようにしてもよい)  
	```
	VpnSwitch.exe [VPN名]
	```
	※VPN名は、VPNの設定名を指定します。  
		省略時のVPN名は、「VPN」です。  
1. タスクトレイに「家」又は「社」というアイコンが表示されるアイコンを左クリックするとトグル形式で接続・切断が行われる  
1. 終了時は、タスクトレイのアイコンを右クリックして終了を選ぶ  

## パスワードが煩わしい場合

以下のファイルのPreviewUserPw=0にすると、自動的に接続できるようなる  
```
%UserProfile%\AppData\Roaming\Microsoft\Network\Connections\Pbk\rasphone.pbk
```
