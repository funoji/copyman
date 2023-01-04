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

        EditorGUILayout.BeginHorizontal();
        _fadeFold = EditorGUILayout.Foldout(_fadeFold, "　Fade Setting ");
        _fadesize = EditorGUILayout.IntField(_fadesize, GUILayout.Width(30)); 
        EditorGUILayout.EndHorizontal();
        if (_fadeFold)
        {
            if (_fadesize != fadeObj.arraySize)
            {
                fadeObj.arraySize = _fadesize; 

                serializedObject.ApplyModifiedProperties();
                serializedObject.Update();
            }
            else
            {
                for (int num = 0; num < fadeObj.arraySize; num++)
                {
                    GUILayout.BeginVertical(GUI.skin.box);
                    fade.fadeSystem[num]._textObj = EditorGUILayout.Toggle("Use Other Object ", fade.fadeSystem[num]._textObj);
                    if (fade.fadeSystem[num]._textObj)
                    {
                        EditorGUILayout.LabelField("Text Object " + num);
                        fade.fadeSystem[num].textObj = (TextMeshProUGUI)EditorGUILayout.ObjectField("  Text Object ", fade.fadeSystem[num].textObj, typeof(TextMeshProUGUI), true);
                        fade.fadeSystem[num].fadeTime = EditorGUILayout.FloatField("　　Fade Change Time ", fade.fadeSystem[num].fadeTime);
                        fade.fadeSystem[num].fadeIn = EditorGUILayout.Toggle("　　Fade In  ", fade.fadeSystem[num].fadeIn);
                        fade.fadeSystem[num].fadeOut = EditorGUILayout.Toggle("　　Fade Out  ", fade.fadeSystem[num].fadeOut);
                    }
                    else
                    {
                        EditorGUILayout.LabelField("Image Object " + num);
                        fade.fadeSystem[num].imageObj = (Image)EditorGUILayout.ObjectField("　Fade Image " + num, fade.fadeSystem[num].imageObj, typeof(Image), true);
                        fade.fadeSystem[num].fadeTime = EditorGUILayout.FloatField("　　Fade Change Time ", fade.fadeSystem[num].fadeTime);
                        fade.fadeSystem[num].fadeIn = EditorGUILayout.Toggle("　　Fade In  ", fade.fadeSystem[num].fadeIn);
                        fade.fadeSystem[num].fadeOut = EditorGUILayout.Toggle("　　Fade Out  ", fade.fadeSystem[num].fadeOut);
                    }
                    GUILayout.EndVertical();
                    EditorGUILayout.Space();
                }
            }
        }

        EditorGUILayout.Space();

        //Sound
        EditorGUILayout.LabelField("Sound Setting", EditorStyles.boldLabel);
        GUILayout.BeginVertical(GUI.skin.box);
        fade._soundBool = EditorGUILayout.Toggle("Use Sound Setting ", fade._soundBool);
        if (fade._soundBool)
        {
            EditorGUILayout.PropertyField(soundObj);

            fade.sound_fadeIn= EditorGUILayout.Toggle("　Sound Fade In ", fade.sound_fadeIn);
            fade.sound_fadeOut= EditorGUILayout.Toggle("　Sound Fade Out ", fade.sound_fadeOut);

            fade.soundfadeIn_Time = EditorGUILayout.FloatField("　Sound Fade In Time ", fade.soundfadeIn_Time);
            fade.soudfadeOut_Time = EditorGUILayout.FloatField("　Sound Fade Out Time ", fade.soudfadeOut_Time);
            fade.soundVolume = EditorGUILayout.FloatField("　Sound Volume ", fade.soundVolume);
            EditorGUILayout.HelpBox("ロード画面終了後のメインBGMの音量を設定してください。", MessageType.Warning, true);
        }
        GUILayout.EndVertical();
        serializedObject.ApplyModifiedProperties(); //serializedObjectへの変更を適用
        EditorUtility.SetDirty(fade);
    }
}
