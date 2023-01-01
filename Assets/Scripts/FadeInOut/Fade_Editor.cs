using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(Fade_Manager))]
public class Fade_Editor : Editor
{
    //private int _fadeSize = 0; //配列の長さを一時的に保存するための変数
    //private int _soundSize = 0;
    //private bool _fadeFold = false;
    //private bool _soundFold = false; //折りたたみ機能のための変数

    public override void OnInspectorGUI()
    {
        Fade_Manager fade = target as Fade_Manager; //S_1_Fadeout_Scriptクラスのインスタンスを取得
        serializedObject.Update(); //serializedObjectを最新に変更
        var fadeObj = serializedObject.FindProperty("fadeSystem");
        var soundObj = serializedObject.FindProperty("audioSource"); //S_1_Fadeout_Scriptクラスの配列 audioSource を取得
        EditorGUI.BeginChangeCheck();

        //_fadeSize = fadeObj.arraySize;
        //_soundSize = soundObj.arraySize;

        //特定のモードの時に表示する項目
        //Fade
        EditorGUILayout.LabelField("Fade Setting", EditorStyles.boldLabel);
        //fade.fadeImage = (Image)EditorGUILayout.ObjectField(" Fade Image " , fade.fadeImage, typeof(Image), true);
        //fade.fadeTime = EditorGUILayout.FloatField("　Fade Change Time ", fade.fadeTime);
        //fade.fadeIn = EditorGUILayout.Toggle("　Fade In  ", fade.fadeIn);
        //fade.fadeOut = EditorGUILayout.Toggle("　Fade Out  ", fade.fadeOut);
        EditorGUILayout.PropertyField(fadeObj);
        EditorGUILayout.Space();

        //二つの要素を横並びに表示させる
        //EditorGUILayout.BeginHorizontal();
        //_fadeFold = EditorGUILayout.Foldout(_fadeFold, "　Fade Setting ");
        //_fadeSize = EditorGUILayout.IntField(_fadeSize, GUILayout.Width(30)); //一時的に保存した長さをカスタムインスタンスに描画（書き換え可能）
        //EditorGUILayout.EndHorizontal();
        //if (_fadeFold)
        //{
        //    //一時的に保存した配列の長さと、本来の配列の長さが同じかチェックする
        //    if (_fadeSize != fadeObj.arraySize)
        //    {
        //        fadeObj.arraySize = _fadeSize; // 長さの変更を適用

        //        //ここでserializedObjectへの変更を適用し、再び更新する
        //        serializedObject.ApplyModifiedProperties();
        //        serializedObject.Update();
        //    }
        //    else
        //    {
        //        GUILayout.BeginVertical();
        //        //一時的に保存した配列の長さと、本来の配列の長さが同じ場合は　配列の要素を描画する
        //        for (int num = 0; num < fadeObj.arraySize; num++)
        //        {
        //            GUILayout.FlexibleSpace();

        //            fade.fadeSystem[num].fadeImage = (Image)EditorGUILayout.ObjectField("　Image " + num, fade.fadeSystem[num].fadeImage, typeof(Image), true);
        //            fade.fadeSystem[num].fadeTime = EditorGUILayout.FloatField("　　Fade Change Time ", fade.fadeSystem[num].fadeTime);
        //            fade.fadeSystem[num].fadeIn = EditorGUILayout.Toggle("　　Fade In  ", fade.fadeSystem[num].fadeIn);
        //            fade.fadeSystem[num].fadeOut = EditorGUILayout.Toggle("　　Fade Out  ", fade.fadeSystem[num].fadeOut);
        //            EditorGUILayout.Space();
        //        }
        //        GUILayout.EndVertical();
        //    }
        //}


        EditorGUILayout.Space();

        //Sound
        EditorGUILayout.LabelField("Sound Setting", EditorStyles.boldLabel);
        fade._soundBool = EditorGUILayout.Toggle("Use Sound Setting ", fade._soundBool);
        if (fade._soundBool)
        {
            EditorGUILayout.PropertyField(soundObj);
            ////二つの要素を横並びに表示させる
            //EditorGUILayout.BeginHorizontal();
            //_soundFold = EditorGUILayout.Foldout(_soundFold, "　AudioSource ");
            //_soundSize = EditorGUILayout.IntField(_soundSize, GUILayout.Width(30)); //一時的に保存した長さをカスタムインスタンスに描画（書き換え可能）
            //EditorGUILayout.EndHorizontal();
            //if (_soundFold)
            //{
            //    //一時的に保存した配列の長さと、本来の配列の長さが同じかチェックする
            //    if (_soundSize != soundObj.arraySize)
            //    {
            //        soundObj.arraySize = _soundSize; // 長さの変更を適用

            //        //ここでserializedObjectへの変更を適用し、再び更新する
            //        serializedObject.ApplyModifiedProperties();
            //        serializedObject.Update();
            //    }
            //    else
            //    {
            //        //一時的に保存した配列の長さと、本来の配列の長さが同じ場合は　配列の要素を描画する
            //        for (int num = 0; num < soundObj.arraySize; num++) 
            //        {
            //            fade.audioSource[num] = (AudioSource)EditorGUILayout.ObjectField(fade.audioSource[num], typeof(AudioSource), true, GUILayout.Width(300)); 
            //        }
            //    }
            //    EditorGUILayout.Space();
            //}

            fade.soundfadeTime = EditorGUILayout.FloatField("　Sound Fade Time ", fade.soundfadeTime);
            fade.soundVolume = EditorGUILayout.FloatField("　Sound Volume ", fade.soundVolume);
            EditorGUILayout.HelpBox("ロード画面終了後のメインBGMの音量を設定してください。", MessageType.Warning, true);
        }
        serializedObject.ApplyModifiedProperties(); //serializedObjectへの変更を適用
        EditorUtility.SetDirty(fade);
    }
}
