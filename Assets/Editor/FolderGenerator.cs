using UnityEngine;
using UnityEditor;
using System.IO;

public class FolderGenerator : EditorWindow
{
    [MenuItem("Editor/FolderGenerator")]
    static void ShowWindow() => GetWindow<FolderGenerator>();

    // 作成するフォルダのリスト
    private static readonly string[] folderList = new string[]
    {
        "Scenes",
        "Scripts",
        "Prefabs",
        "Textures",
        "Shaders",
        "Materials",
        "Physics Materials",
        "Animations",
        "Animator Controllers",
        "Audio",
        "Resources",
        "Fonts",
        "Plugins",
        "Editor",
        // "Editor DefaultResources",
        // "Gizmos",
    };

    private string path = "Assets";
    private Vector2 scrollBar = Vector2.zero;

    private void OnGUI()
    {
        EditorGUILayout.LabelField("選択したフォルダの下にフォルダを作成します", EditorStyles.boldLabel);

        GUILayout.Box(path);

        if (GUILayout.Button("フォルダを選択"))
        {
            path = EditorUtility.OpenFolderPanel("作成するフォルダ", Application.dataPath, string.Empty);
            EditorGUILayout.LabelField(path);
        }
        EditorGUILayout.Space();

        EditorGUILayout.LabelField("フォルダを作成", EditorStyles.boldLabel);
        EditorGUILayout.BeginScrollView(scrollBar);
        {
            // フォルダの数だけボタンを作成
            foreach (string folder in folderList)
            {
                if (GUILayout.Button(folder))
                {
                    string folderPath = Path.Combine(path, folder);

                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                        Debug.Log(folderPath + "を作成しました");

                        // 更新
                        AssetDatabase.Refresh();
                    }
                    else
                    {
                        Debug.Log(folderPath + "は既に存在します");
                    }
                }

            }

            EditorGUILayout.HelpBox("Assets/Editor/FolderGeneretor.cs"
                + "\nを編集して作成するフォルダを追加できます", MessageType.Info);
        }
        EditorGUILayout.EndScrollView();
    }
}
