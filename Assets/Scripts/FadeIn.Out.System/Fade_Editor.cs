using UnityEngine;
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;

//Fade用カスタムEditor
[CustomEditor(typeof(Fade_Manager))]
public class Fade_Editor : Editor
{
    private int _fadesize = 0; //配列の長さを一時的に保存するための変数
    private bool _fadeFold = false;　//折りたたみ機能の判定

    public override void OnInspectorGUI()
    {
        Fade_Manager fade = target as Fade_Manager; //Fade_Managerクラスのインスタンスを取得

        serializedObject.Update(); //serializedObjectを最新に変更

        var fadeObj = serializedObject.FindProperty("fadeSystem");　//Fade_Managerクラスの配列 fadeSystem を取得
        var soundObj = serializedObject.FindProperty("audioSource"); //Fade_Managerクラスの配列 audioSource を取得

        EditorGUI.BeginChangeCheck();

        _fadesize = fadeObj.arraySize; //配列の長さを保存

        //Fade
        EditorGUILayout.LabelField("Fade Setting", EditorStyles.boldLabel);  //ラベルを表示
        //EditorGUILayout.PropertyField(fadeObj);

        EditorGUILayout.Space();  //スペースを確保

        EditorGUILayout.BeginHorizontal(); //横に表示する
        _fadeFold = EditorGUILayout.Foldout(_fadeFold, "　Fade Setting "); //折りたたみ機能を表示
        _fadesize = EditorGUILayout.IntField(_fadesize, GUILayout.Width(30));  //Int型のフィールドを表示
        EditorGUILayout.EndHorizontal();
        if (_fadeFold)
        {
            if (_fadesize != fadeObj.arraySize)
            {
                fadeObj.arraySize = _fadesize; //元のサイズを代入

                serializedObject.ApplyModifiedProperties(); //serializedObjectへの変更を適用
                serializedObject.Update(); //表示を更新
            }
            else
            {
                for (int num = 0; num < fadeObj.arraySize; num++)
                {
                    GUILayout.BeginVertical(GUI.skin.box); //縦に表示と囲みを表示
                    fade.fadeSystem[num]._textObj = EditorGUILayout.Toggle("Use Other Object ", fade.fadeSystem[num]._textObj); //Toggleを表示
                    if (fade.fadeSystem[num]._textObj)
                    {
                        EditorGUILayout.LabelField("Text Object " + num);  //Text用ラベル表示
                        fade.fadeSystem[num].textObj = (TextMeshProUGUI)EditorGUILayout.ObjectField("  Text Object ", fade.fadeSystem[num].textObj, typeof(TextMeshProUGUI), true);  //Object用のフィールドを表示
                        fade.fadeSystem[num].fadeTime = EditorGUILayout.FloatField("　　Fade Change Time ", fade.fadeSystem[num].fadeTime);  //Float型のフィールドを表示
                        fade.fadeSystem[num].fadeIn = EditorGUILayout.Toggle("　　Fade In  ", fade.fadeSystem[num].fadeIn);  //FadeIn用のToggleを表示
                        fade.fadeSystem[num].fadeOut = EditorGUILayout.Toggle("　　Fade Out  ", fade.fadeSystem[num].fadeOut);  //FadeOut用のToggleを表示
                    }
                    else
                    {
                        EditorGUILayout.LabelField("Image Object " + num);  //Image用ラベル表示
                        fade.fadeSystem[num].imageObj = (Image)EditorGUILayout.ObjectField("　Fade Image " + num, fade.fadeSystem[num].imageObj, typeof(Image), true);  //Object用のフィールドを表示
                        fade.fadeSystem[num].fadeTime = EditorGUILayout.FloatField("　　Fade Change Time ", fade.fadeSystem[num].fadeTime);  //Float型のフィールドを表示
                        fade.fadeSystem[num].fadeIn = EditorGUILayout.Toggle("　　Fade In  ", fade.fadeSystem[num].fadeIn);  //FadeIn用のToggleを表示
                        fade.fadeSystem[num].fadeOut = EditorGUILayout.Toggle("　　Fade Out  ", fade.fadeSystem[num].fadeOut);  //FadeOut用のToggleを表示
                    }
                    GUILayout.EndVertical();

                    EditorGUILayout.Space();
                }
            }
        }

        EditorGUILayout.Space();  //スペースを確保

        //Sound
        EditorGUILayout.LabelField("Sound Setting", EditorStyles.boldLabel);  //ラベルを表示

        GUILayout.BeginVertical(GUI.skin.box);  //縦に表示と囲みを表示
        fade._soundBool = EditorGUILayout.Toggle("Use Sound Setting ", fade._soundBool);  ////Toggleを表示
        if (fade._soundBool)
        {
            EditorGUILayout.PropertyField(soundObj);  //AudioSource用のフィールドを表示

            fade.sound_fadeIn= EditorGUILayout.Toggle("　Sound Fade In ", fade.sound_fadeIn);  //SoundのFadeIn用のToggleを表示
            fade.sound_fadeOut= EditorGUILayout.Toggle("　Sound Fade Out ", fade.sound_fadeOut);  //SoundのFadeOut用のToggleを表示

            fade.soundfadeIn_Time = EditorGUILayout.FloatField("　Sound Fade In Time ", fade.soundfadeIn_Time);  //Float型のフィールドを表示
            fade.soudfadeOut_Time = EditorGUILayout.FloatField("　Sound Fade Out Time ", fade.soudfadeOut_Time);  //Float型のフィールドを表示
            fade.soundVolume = EditorGUILayout.FloatField("　Sound Volume ", fade.soundVolume);  //Float型のフィールドを表示

            EditorGUILayout.HelpBox("ロード画面終了後のメインBGMの音量を設定してください。", MessageType.Warning, true);  //注意書きを表示
        }
        GUILayout.EndVertical();

        serializedObject.ApplyModifiedProperties(); //serializedObjectへの変更を適用
        EditorUtility.SetDirty(fade);
    }
}
#endif