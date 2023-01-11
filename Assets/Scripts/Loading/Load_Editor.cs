using UnityEngine;
using UnityEngine.Video;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;

//Load用カスタムEditor
[CustomEditor(typeof(Load_Manager))]
public class Load_Editor : Editor
{
    public override void OnInspectorGUI()
    {
        Load_Manager loading = target as Load_Manager;  //Load_Managerクラスのインスタンスを取得

        serializedObject.Update(); //serializedObjectを最新に変更

        var imageObj = serializedObject.FindProperty("fixationImage");  //Load_Managerクラスの配列 fixationImage を取得
        var loadObj = serializedObject.FindProperty("audioSource");  //Load_Managerクラスの配列 audioSource を取得

        EditorGUI.BeginChangeCheck();

        //Load 
        EditorGUILayout.LabelField("Load Setting", EditorStyles.boldLabel);  //ラベルを表示

        loading.loadImage = (GameObject)EditorGUILayout.ObjectField("　Load Image ", loading.loadImage, typeof(GameObject), true);  //Object用のフィールドを表示
        loading.loadVideo = (VideoPlayer)EditorGUILayout.ObjectField("　Load Video ", loading.loadVideo, typeof(VideoPlayer), true);  //Object用のフィールドを表示
        loading.loadTime = EditorGUILayout.FloatField("　Load Time ", loading.loadTime);  //Float型のフィールドを表示

        EditorGUILayout.HelpBox("ロード画面の再生時間\n1000…約６秒　500…約２秒", MessageType.None);  //注意書きを表示

        EditorGUILayout.PropertyField(imageObj);  //fixationImage用のフィールドを表示

        loading._textObj = EditorGUILayout.Toggle("Use Text Object ", loading._textObj);  //Toggleを表示
        if (loading._textObj) { loading.fixationText = (TextMeshProUGUI)EditorGUILayout.ObjectField("  Text Object ", loading.fixationText, typeof(TextMeshProUGUI), true); }  //Object用のフィールドを表示

        EditorGUILayout.Space();  //スペースを確保

        //Fade
        EditorGUILayout.LabelField("Fade Setting", EditorStyles.boldLabel);  //ラベルを表示

        loading.fadeScript = (Fade_Manager)EditorGUILayout.ObjectField("　Fade Script ", loading.fadeScript, typeof(Fade_Manager), true);  //Object用のフィールドを表示

        EditorGUILayout.Space();  //スペースを確保

        //AudioSource
        EditorGUILayout.LabelField("Audio Source", EditorStyles.boldLabel);  //ラベルを表示

        EditorGUILayout.PropertyField(loadObj);  //AudioSource用のフィールドを表示

        serializedObject.ApplyModifiedProperties(); //serializedObjectへの変更を適用
        EditorUtility.SetDirty(loading);
    }
}
#endif