# Unity-FolderGenerator
Unityでよく使うフォルダを任意の場所に簡単に作成するエディタ拡張です。

# Download
[FolderGenerator.unitypackage](https://github.com/c-nao27/Unity-FolderGenerator/raw/master/ExportPackages/FolderGenerator.unitypackage)  
ダウンロード後、適用したいUnityプロジェクトにインポートしてください。

# How to Use
1. メニューやプロジェクトウィンドウから  
    Assets -> Create -> Folder Generator
2. [フォルダを選択]を押してフォルダを作成する場所を設定します。
3. ボタンを押してフォルダを作成します。

### Custom
フォルダをさらに追加したい場合、
[Assets/Editor/FolderGenerator.cs](https://github.com/c-nao27/Unity-FolderGenerator/blob/master/Assets/Editor/FolderGenerator.cs)の  
[フォルダリスト](https://github.com/c-nao27/Unity-FolderGenerator/blob/8b0b4f9bcf34193fae7a912f1d77d1c402cf9adb/Assets/Editor/FolderGenerator.cs#L11-L29)
にフォルダ名を追加してください。
