using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEditor;
using UnityEngine.Video;

[CustomEditor(typeof(Load_Manager))]
public class Load_Editor : Editor
{
    //private int _imagesize = 0;
    //private int _audiosize = 0; //配列の長さを一時的に保存するための変数
    //private bool fold = false; //折りたたみ機能のための変数

    public override void OnInspectorGUI()
    {
        Load_Manager loading = target as Load_Manager;
        serializedObject.Update(); //serializedObjectを最新に変更
        var imageObj = serializedObject.FindProperty("fixationImage");
        var loadObj = serializedObject.FindProperty("audioSource");
        EditorGUI.BeginChangeCheck();

        //_imagesize = imageObj.arraySize;
        //_audiosize = loadObj.arraySize;

        //Load
        EditorGUILayout.LabelField("Load Setting", EditorStyles.boldLabel);
        loading.loadImage = (GameObject)EditorGUILayout.ObjectField("　Load Image ", loading.loadImage, typeof(GameObject), true);
        loading.loadVideo = (VideoPlayer)EditorGUILayout.ObjectField("　Load Video ", loading.loadVideo, typeof(VideoPlayer), true);
        loading.loadTime = EditorGUILayout.FloatField("　Load Time ", loading.loadTime);
        EditorGUILayout.HelpBox("ロード画面の再生時間\n1000…約６秒　500…約２秒", MessageType.None);
        EditorGUILayout.PropertyField(imageObj);

        //_imagesize = EditorGUILayout.IntField("Fixation Image ", _imagesize); //一時的に保存した長さをカスタムインスタンスに描画（書き換え可能）
        ////一時的に保存した配列の長さと、本来の配列の長さが同じかチェックする
        //if (_imagesize != imageObj.arraySize)
        //{
        //    imageObj.arraySize = _imagesize; // 長さの変更を適用

        //    //ここでserializedObjectへの変更を適用し、再び更新する
        //    serializedObject.ApplyModifiedProperties();
        //    serializedObject.Update();
        //}
        //else
        //{
        //    //一時的に保存した配列の長さと、本来の配列の長さが同じ場合は　配列の要素を描画する
        //    for (int num = 0; num < imageObj.arraySize; num++) { loading.fixationImage[num] = (Image)EditorGUILayout.ObjectField("　 " + num, loading.fixationImage[num], typeof(Image), true); }
        //}

        EditorGUILayout.Space();

        //Fade
        EditorGUILayout.LabelField("Fade Setting", EditorStyles.boldLabel);
        loading.fadeScript = (Fade_Manager)EditorGUILayout.ObjectField("　Fade Script ", loading.fadeScript, typeof(Fade_Manager), true);
        EditorGUILayout.Space();

        //AudioSource
        EditorGUILayout.LabelField("Audio Source", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(loadObj);

        ////二つの要素を横並びに表示させる
        //EditorGUILayout.BeginHorizontal();
        //fold = EditorGUILayout.Foldout(fold, "　AudioSource ");
        //_audiosize = EditorGUILayout.IntField(_audiosize, GUILayout.Width(30)); //一時的に保存した長さをカスタムインスタンスに描画（書き換え可能）
        //EditorGUILayout.EndHorizontal();
        //if (fold)
        //{
        //    //一時的に保存した配列の長さと、本来の配列の長さが同じかチェックする
        //    if (_audiosize != loadObj.arraySize)
        //    {
        //        loadObj.arraySize = _audiosize; // 長さの変更を適用

        //        //ここでserializedObjectへの変更を適用し、再び更新する
        //        serializedObject.ApplyModifiedProperties();
        //        serializedObject.Update();
        //    }
        //    else
        //    {
        //        using (new EditorGUILayout.HorizontalScope())
        //        {
        //            GUILayout.FlexibleSpace(); //右端に寄せる
        //            //一時的に保存した配列の長さと、本来の配列の長さが同じ場合は　配列の要素を描画する
        //            for (int num = 0; num < loadObj.arraySize; num++) { loading.audioSource[num] = (AudioSource)EditorGUILayout.ObjectField(loading.audioSource[num], typeof(AudioSource), true, GUILayout.Width(300)); }
        //        }
        //    }
        //    EditorGUILayout.Space();
        //}

        serializedObject.ApplyModifiedProperties(); //serializedObjectへの変更を適用
        EditorUtility.SetDirty(loading);
    }
}
