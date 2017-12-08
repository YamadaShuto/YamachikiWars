using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlayerPrefsEditor : EditorWindow
{
    private string key;
    private string value;

    private TYPE type;
    enum TYPE
    {
        INT,
        FLOAT,
        STRING
    }
    
    [MenuItem("Tools/PlayerPrefs/OpenEditor")]
    static void OpenEditor()
    {
        EditorWindow.GetWindow<PlayerPrefsEditor>("PlayerPrefsEditor");
    }

    void OnGUI()
    {
        //castをしないといけない
        type = (TYPE)EditorGUILayout.EnumPopup("Type", type);
        GUILayout.BeginHorizontal();
        GUILayout.Label("Key");
        key = GUILayout.TextField(key);
        GUILayout.Label("value");
        value = GUILayout.TextField(value);
        GUILayout.EndHorizontal();
        
        if (PlayerPrefs.HasKey(key))
        {
            var date = PlayerPrefs.GetString(key);
            GUILayout.Label("Save Value : " + date);
        }
        if (GUILayout.Button("Save"))
        {
            PlayerPrefs.SetString(key, value);
            // Saving data
            PlayerPrefs.Save();
        }
        if (GUILayout.Button("Delete"))
        {
            PlayerPrefs.DeleteKey(key);
            PlayerPrefs.Save();
        }
        if (GUILayout.Button("DeleteAll"))
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
        }
    } 
}
