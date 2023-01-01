using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEditor;
using TMPro;

[CustomEditor(typeof(Fade_Manager))]
public class Fade_Editor : Editor
{
    private int _fadesize = 0; //配列の長さを一時的に保存するための変数
    private bool _fadeFold = false;

    public override void OnInspectorGUI()
    {
        Fade_Manager fade = target as Fade_Manager; //S_1_Fadeout_Scriptクラスのインスタンスを取得
        serializedObject.Update(); //serializedObjectを最新に変更
        var fadeObj = serializedObject.FindProperty("fadeSystem");
        var soundObj = serializedObject.FindProperty("audioSource"); //S_1_Fadeout_Scriptクラスの配列 audioSource を取得
        EditorGUI.BeginChangeCheck();

        _fadesize = fadeObj.arraySize;

        //特定のモードの時に表示する項目
        //Fade
        EditorGUILayout.LabelField("Fade Setting", EditorStyles.boldLabel);
        //EditorGUILayout.PropertyField(fadeObj);
        EditorGUILayout.Space();

        //二つの要素を横並びに表示させる
        EditorGUILayout.BeginHorizontal();
        _fadeFold = EditorGUILayout.Foldout(_fadeFold, "　Fade Setting ");
        _fadesize = EditorGUILayout.IntField(_fadesize, GUILayout.Width(30)); //一時的に保存した長さをカスタムインスタンスに描画（書き換え可能）
        EditorGUILayout.EndHorizontal();
        if (_fadeFold)
        {
            //一時的に保存した配列の長さと、本来の配列の長さが同じかチェックする
            if (_fadesize != fadeObj.arraySize)
            {
                fadeObj.arraySize = _fadesize; // 長さの変更を適用

                //ここでserializedObjectへの変更を適用し、再び更新する
                serializedObject.ApplyModifiedProperties();
                serializedObject.Update();
            }
            else
            {
                GUILayout.BeginVertical();
                //一時的に保存した配列の長さと、本来の配列の長さが同じ場合は　配列の要素を描画する
                for (int num = 0; num < fadeObj.arraySize; num++)
                {
                    GUILayout.FlexibleSpace();
                    fade.fadeSystem[num]._textObj = EditorGUILayout.Toggle("Use Other Object ", fade.fadeSystem[num]._textObj);
                    if (fade.fadeSystem[num]._textObj)
                    {
                        fade.fadeSystem[num].textObj = (TextMeshProUGUI)EditorGUILayout.ObjectField("  Text Object ", fade.fadeSystem[num].textObj, typeof(TextMeshProUGUI), true);
                        fade.fadeSystem[num].fadeTime = EditorGUILayout.FloatField("　　Fade Change Time ", fade.fadeSystem[num].fadeTime);
                        fade.fadeSystem[num].fadeIn = EditorGUILayout.Toggle("　　Fade In  ", fade.fadeSystem[num].fadeIn);
                        fade.fadeSystem[num].fadeOut = EditorGUILayout.Toggle("　　Fade Out  ", fade.fadeSystem[num].fadeOut);

                    }
                    else
                    {
                        fade.fadeSystem[num].fadeImage = (Image)EditorGUILayout.ObjectField("　Fade Image " + num, fade.fadeSystem[num].fadeImage, typeof(Image), true);
                        fade.fadeSystem[num].fadeTime = EditorGUILayout.FloatField("　　Fade Change Time ", fade.fadeSystem[num].fadeTime);
                        fade.fadeSystem[num].fadeIn = EditorGUILayout.Toggle("　　Fade In  ", fade.fadeSystem[num].fadeIn);
                        fade.fadeSystem[num].fadeOut = EditorGUILayout.Toggle("　　Fade Out  ", fade.fadeSystem[num].fadeOut);
                    }
                    EditorGUILayout.Space();
                }
                GUILayout.EndVertical();
            }
        }

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
