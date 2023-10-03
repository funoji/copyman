using UnityEngine;
using UnityEngine.Video;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;

//Load用カスタムEditor
[CustomEditor(typeof(Load_Manager))]
public class Load_Editor : Editor
{
    // 時間を設定するスライダーの最小値を保存する変数
    private int timeMin = 0;
    // 時間を設定するスライダーの最大値を設定する変数
    private int timeMax = 1000;

    public override void OnInspectorGUI()
    {
        // Load_Managerクラスのインスタンスを取得
        Load_Manager loading = target as Load_Manager;

        // serializedObjectを最新に変更
        serializedObject.Update();

        EditorGUI.BeginChangeCheck();

        // Load 
        // 見出しを設定する
        EditorGUILayout.LabelField("ロードの設定", EditorStyles.boldLabel);

        // ロード画面を表示するオブジェクトを取得するフィールドを表示
        loading.loadImage = (GameObject)EditorGUILayout.ObjectField("　Load_Panel ", loading.loadImage, typeof(GameObject), true);
        // ロード画面表示するVideoClipを取得するフィールドを表示
        loading.loadVideo = (VideoPlayer)EditorGUILayout.ObjectField("　Loading_RawImage ", loading.loadVideo, typeof(VideoPlayer), true);
        // ロード画面を表示する時間を設定するスライダーを表示
        loading.loadTime = EditorGUILayout.IntSlider("　ロード画面を表示する時間 ", loading.loadTime, timeMin, timeMax);

        // 注意書きを表示
        EditorGUILayout.HelpBox("ロード画面の再生時間(参考時間)\n1000…約６秒　500…約２秒", MessageType.None);

        //スペースを確保
        EditorGUILayout.Space();

        //AudioSource
        // 見出しを設定する
        EditorGUILayout.LabelField("音に関する設定", EditorStyles.boldLabel);

        // 音を管理するAudioSourceを取得するフィールドを表示
        //loading.audioSource = (AudioSource)EditorGUILayout.ObjectField("　Audio Source ", loading.audioSource, typeof(AudioSource), true);
        loading.audioSource = (GameObject)EditorGUILayout.ObjectField("　Audio Source ", loading.audioSource, typeof(GameObject), true);

        //スペースを確保
        EditorGUILayout.Space();

        //serializedObjectへの変更を適用
        serializedObject.ApplyModifiedProperties();
        EditorUtility.SetDirty(loading);
    }
}
#endif