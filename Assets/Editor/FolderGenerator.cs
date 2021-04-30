using UnityEngine;
using UnityEditor;
using System.IO;

public class FolderGenerator : EditorWindow
{
    [MenuItem("Editor/FolderGenerator")]
    static void ShowWindow() => GetWindow<FolderGenerator>();

    // "フォルダ名", で作成するフォルダを追加
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
        EditorGUILayout.LabelField("選択した場所にフォルダを作成します", EditorStyles.boldLabel);

        GUILayout.Box(path);

        if (GUILayout.Button("フォルダを選択する"))
        {
            path = EditorUtility.OpenFolderPanel("フォルダを選択する", Application.dataPath, string.Empty);
            EditorGUILayout.LabelField(path);
            // エディターの更新
            AssetDatabase.Refresh();
        }
        EditorGUILayout.Space();

        EditorGUILayout.LabelField("作成するフォルダ", EditorStyles.boldLabel);
        EditorGUILayout.BeginScrollView(scrollBar);
        {
            foreach (string folder in folderList)
            {
                if (GUILayout.Button(folder))
                {
                    string folderPath = Path.Combine(path, folder);

                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                        Debug.Log(folderPath + "を作成しました");

                        // エディターの更新
                        AssetDatabase.Refresh();
                    }
                    else
                    {
                        Debug.Log("既にフォルダが存在します");
                    }
                }

            }

            EditorGUILayout.HelpBox("Assets/Editor/FolderGeneretor " +
                "を編集することで作成するフォルダの種類を増やせます。", MessageType.Info);
        }
        EditorGUILayout.EndScrollView();
    }
}
