using UnityEngine;
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;

// Fade用カスタムEditor
[CustomEditor(typeof(Fade_Manager))]
public class Fade_Editor : Editor
{
    // 配列の長さを一時的に保存するための変数
    private int _fadesize = 0;
    // 折りたたみ機能の判定
    private bool _fadeFold = false;

    public override void OnInspectorGUI()
    {
        // Fade_Managerクラスのインスタンスを取得
        Fade_Manager fade = target as Fade_Manager;

        // serializedObjectを最新に変更
        serializedObject.Update();

        // Fade_Managerクラスの配列 fadeSystem を取得
        var fadeObj = serializedObject.FindProperty("fadeSystem");
        //Fade_Managerクラスの配列 audioSource を取得
        var soundObj = serializedObject.FindProperty("audioSource");

        EditorGUI.BeginChangeCheck();

        // 配列の長さを保存
        _fadesize = fadeObj.arraySize;

        // Fade
        // ラベルを表示
        EditorGUILayout.LabelField("Fadeの設定", EditorStyles.boldLabel);
        //EditorGUILayout.PropertyField(fadeObj);

        // スペースを確保
        EditorGUILayout.Space();

        // 横に表示する
        EditorGUILayout.BeginHorizontal();
        // 折りたたみ機能を表示
        _fadeFold = EditorGUILayout.Foldout(_fadeFold, "　Fade設定項目 ");
        // Int型のフィールドを表示
        _fadesize = EditorGUILayout.IntField(_fadesize, GUILayout.Width(30));
        // 横に表示する物を設定
        EditorGUILayout.EndHorizontal();

        if (_fadeFold)
        {
            if (_fadesize != fadeObj.arraySize)
            {
                // 元のサイズを代入
                fadeObj.arraySize = _fadesize;

                // serializedObjectへの変更を適用
                serializedObject.ApplyModifiedProperties();
                // 表示を更新
                serializedObject.Update();
            }
            else
            {
                for (int num = 0; num < fadeObj.arraySize; num++)
                {
                    // 縦に表示と囲みを表示
                    GUILayout.BeginVertical(GUI.skin.box);

                    // Toggleを表示
                    fade.fadeSystem[num]._textObj = EditorGUILayout.Toggle("Textオブジェクト", fade.fadeSystem[num]._textObj);

                    if (fade.fadeSystem[num]._textObj)
                    {
                        // Text用ラベル表示
                        EditorGUILayout.LabelField("Text Object " + num);

                        // Object用のフィールドを表示
                        fade.fadeSystem[num].textObj = (TextMeshProUGUI)EditorGUILayout.ObjectField("  Text Object ", fade.fadeSystem[num].textObj, typeof(TextMeshProUGUI), true);
                        // Float型のフィールドを表示
                        fade.fadeSystem[num].fadeTime = EditorGUILayout.FloatField("　　Fade Change Time ", fade.fadeSystem[num].fadeTime);
                        // FadeIn用のToggleを表示
                        fade.fadeSystem[num].fadeIn = EditorGUILayout.Toggle("　　Fade In  ", fade.fadeSystem[num].fadeIn);
                        // FadeOut用のToggleを表示
                        fade.fadeSystem[num].fadeOut = EditorGUILayout.Toggle("　　Fade Out  ", fade.fadeSystem[num].fadeOut);
                    }
                    else
                    {
                        // Image用ラベル表示
                        EditorGUILayout.LabelField("Image Object " + num);

                        // Object用のフィールドを表示
                        fade.fadeSystem[num].imageObj = (Image)EditorGUILayout.ObjectField("　Fade Image " + num, fade.fadeSystem[num].imageObj, typeof(Image), true);
                        // Float型のフィールドを表示
                        fade.fadeSystem[num].fadeTime = EditorGUILayout.FloatField("　　Fade Change Time ", fade.fadeSystem[num].fadeTime);
                        // FadeIn用のToggleを表示
                        fade.fadeSystem[num].fadeIn = EditorGUILayout.Toggle("　　Fade In  ", fade.fadeSystem[num].fadeIn);
                        // FadeOut用のToggleを表示
                        fade.fadeSystem[num].fadeOut = EditorGUILayout.Toggle("　　Fade Out  ", fade.fadeSystem[num].fadeOut);
                    }
                    GUILayout.EndVertical();

                    // スペースを確保
                    EditorGUILayout.Space();
                }
            }
        }

        // スペースを確保
        EditorGUILayout.Space();

        // Sound
        // ラベルを表示
        EditorGUILayout.LabelField("Sound Setting", EditorStyles.boldLabel);

        // 縦に表示と囲みを表示
        GUILayout.BeginVertical(GUI.skin.box);

        // Toggleを表示
        fade._soundBool = EditorGUILayout.Toggle("Use Sound Setting ", fade._soundBool);

        if (fade._soundBool)
        {
            // AudioSource用のフィールドを表示
            EditorGUILayout.PropertyField(soundObj);

            // SoundのFadeIn用のToggleを表示
            fade.sound_fadeIn = EditorGUILayout.Toggle("　Sound Fade In ", fade.sound_fadeIn);
            // SoundのFadeOut用のToggleを表示
            fade.sound_fadeOut = EditorGUILayout.Toggle("　Sound Fade Out ", fade.sound_fadeOut);

            // Float型のフィールドを表示
            fade.soundfadeIn_Time = EditorGUILayout.FloatField("　Sound Fade In Time ", fade.soundfadeIn_Time);
            // Float型のフィールドを表示
            fade.soudfadeOut_Time = EditorGUILayout.FloatField("　Sound Fade Out Time ", fade.soudfadeOut_Time);
            // Float型のフィールドを表示
            fade.soundVolume = EditorGUILayout.FloatField("　Sound Volume ", fade.soundVolume);

            // 注意書きを表示
            EditorGUILayout.HelpBox("ロード画面終了後のメインBGMの音量を設定してください。", MessageType.Warning, true);
        }
        GUILayout.EndVertical();

        // serializedObjectへの変更を適用
        serializedObject.ApplyModifiedProperties();
        EditorUtility.SetDirty(fade);
    }
}
#endif