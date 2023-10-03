using UnityEngine;
#if UNITY_EDITOR 
using UnityEditor;

[CustomEditor(typeof(SelectButton_Maneger))]
public class SelectButton_Editor : Editor
{
    // 配列の長さを一時的に保存するための変数
    private int arraysize = 0;
    public override void OnInspectorGUI()
    {
        // serializedObjectを最新に変更
        serializedObject.Update();

        // S_3_Selectクラスの配列 SelectDataを取得
        var selectObj = serializedObject.FindProperty("selectData");
        var events = serializedObject.FindProperty("events");

        // S_3_Selectクラスのインスタンスを取得
        SelectButton_Maneger select = target as SelectButton_Maneger;

        EditorGUI.BeginChangeCheck();

        // 配列SelectDataの長さを一時的に変数に保存しておく
        arraysize = selectObj.arraySize;

        // 選択状態のモードの設定
        select.mode = (SelectButton_Maneger.ModeType)EditorGUILayout.EnumPopup("選択中の演出モード", select.mode);

        // 一時的に保存した長さをカスタムインスタンスに描画（書き換え可能）
        arraysize = EditorGUILayout.IntField("ボタンの個数", arraysize);

        // スペースを描画
        EditorGUILayout.Space();

        // 特定のモードの時に表示する項目
        if (select.mode == SelectButton_Maneger.ModeType.none)
        {
            // Inspectorに何も表示しない
        }
        if (select.mode == SelectButton_Maneger.ModeType.size)
        {
            // 変化する速さを設定するフィールドを表示
            select.scallSpeed = EditorGUILayout.FloatField("変化する速さ", select.scallSpeed);
            // 切り替わるまでの時間を設定するフィールドを表示
            select.maxTime = EditorGUILayout.FloatField("切り替わる時間", select.maxTime);

            // スペースを描画
            EditorGUILayout.Space();

            // 一時的に保存した配列の長さと、本来の配列の長さが同じかチェックする
            if (arraysize != selectObj.arraySize)
            {
                // 長さの変更を適用
                selectObj.arraySize = arraysize;

                //ここでserializedObjectへの変更を適用し、再び更新する
                serializedObject.ApplyModifiedProperties();
                serializedObject.Update();
            }
            else
            {
                // 一時的に保存した配列の長さと、本来の配列の長さが同じ場合は配列の要素を描画する
                for (int num = 0; num < selectObj.arraySize; num++)
                {
                    // 枠組みを作る
                    GUILayout.BeginVertical(GUI.skin.box);

                    // ボタンの見出しを表示する
                    EditorGUILayout.LabelField("Button " + (num + 1));
                    // ボタンのオブジェクトを取得するフィールドを表示
                    select.selectData[num].buttonObj = (GameObject)EditorGUILayout.ObjectField("　ボタンのオブジェクト", select.selectData[num].buttonObj, typeof(GameObject), true);
                    // ボタンのUI画像をオブジェクトとして取得するフィールドを表示
                    select.selectData[num].buttonImage = (GameObject)EditorGUILayout.ObjectField("　ボタンのUI画像", select.selectData[num].buttonImage, typeof(GameObject), true);

                    // 枠組みの最後を設定する
                    GUILayout.EndVertical();

                    //スペースを描画
                    EditorGUILayout.Space();
                }
            }

            // ボタンBのボタン選択を有効にするかのトグルを表示
            select.ExitButton = EditorGUILayout.Toggle("ボタンBを有効にするか", select.ExitButton);

            if (select.ExitButton)
            {
                // 枠組みを作る
                GUILayout.BeginVertical(GUI.skin.box);

                // ボタンのオブジェクトを取得するフィールドを表示
                select.exitData.exitButton = (GameObject)EditorGUILayout.ObjectField("　ボタンのオブジェクト", select.exitData.exitButton, typeof(GameObject), true);
                // ボタンのUI画像をオブジェクトとして取得するフィールドを表示
                select.exitData.exitImage = (GameObject)EditorGUILayout.ObjectField("　ボタンのUI画像", select.exitData.exitImage, typeof(GameObject), true);

                // スペースを描画
                EditorGUILayout.Space();

                // イベント関数の処理を表示する
                EditorGUILayout.PropertyField(events);

                // 枠組みの最後を設定する
                GUILayout.EndVertical();

            }
        }
        if (select.mode == SelectButton_Maneger.ModeType.image)
        {
            //一時的に保存した配列の長さと、本来の配列の長さが同じかチェックする
            if (arraysize != selectObj.arraySize)
            {
                // 長さの変更を適用
                selectObj.arraySize = arraysize;

                //ここでserializedObjectへの変更を適用し、再び更新する
                serializedObject.ApplyModifiedProperties();
                serializedObject.Update();
            }
            else
            {
                //一時的に保存した配列の長さと、本来の配列の長さが同じ場合は配列の要素を描画する
                for (int num = 0; num < selectObj.arraySize; num++)
                {
                    // 枠組みを作る
                    GUILayout.BeginVertical(GUI.skin.box);

                    // ボタンの見出しを表示する
                    EditorGUILayout.LabelField("Button " + (num + 1));
                    // ボタンのオブジェクトを取得するフィールドを表示
                    select.selectData[num].buttonObj = (GameObject)EditorGUILayout.ObjectField("　ボタンのオブジェクト", select.selectData[num].buttonObj, typeof(GameObject), true);
                    // ボタンのUI画像をオブジェクトとして取得するフィールドを表示
                    select.selectData[num].buttonImage = (GameObject)EditorGUILayout.ObjectField("　ボタンのUI画像", select.selectData[num].buttonImage, typeof(GameObject), true);

                    // 枠組みの最後を設定する
                    GUILayout.EndVertical();

                    //スペースを描画
                    EditorGUILayout.Space();
                }
            }

            // ボタンBのボタン選択を有効にするかのトグルを表示
            select.ExitButton = EditorGUILayout.Toggle("ボタンBを有効にするか", select.ExitButton);

            if (select.ExitButton)
            {
                // 枠組みを作る
                GUILayout.BeginVertical(GUI.skin.box);

                // ボタンのオブジェクトを取得するフィールドを表示
                select.exitData.exitButton = (GameObject)EditorGUILayout.ObjectField("　ボタンのオブジェクト", select.exitData.exitButton, typeof(GameObject), true);
                // ボタンのUI画像をオブジェクトとして取得するフィールドを表示
                select.exitData.exitImage = (GameObject)EditorGUILayout.ObjectField("　ボタンのUI画像", select.exitData.exitImage, typeof(GameObject), true);

                // スペースを描画
                EditorGUILayout.Space();

                // 変化する速さを設定するフィールドを表示
                select.scallSpeed = EditorGUILayout.FloatField("変化する速さ", select.scallSpeed);
                // 切り替わるまでの時間を設定するフィールドを表示
                select.maxTime = EditorGUILayout.FloatField("切り替わる時間", select.maxTime);

                // スペースを描画
                EditorGUILayout.Space();

                // イベント関数の処理を表示する
                EditorGUILayout.PropertyField(events);

                // 枠組みの最後を設定する
                GUILayout.EndVertical();
            }
        }
        if (select.mode == SelectButton_Maneger.ModeType.normal)
        {
            //一時的に保存した配列の長さと、本来の配列の長さが同じかチェックする
            if (arraysize != selectObj.arraySize)
            {
                // 長さの変更を適用
                selectObj.arraySize = arraysize;

                //ここでserializedObjectへの変更を適用し、再び更新する
                serializedObject.ApplyModifiedProperties();
                serializedObject.Update();
            }
            else
            {
                //一時的に保存した配列の長さと、本来の配列の長さが同じ場合は配列の要素を描画する
                for (int num = 0; num < selectObj.arraySize; num++)
                {
                    // 枠組みを作る
                    GUILayout.BeginVertical(GUI.skin.box);

                    // ボタンの見出しを表示する
                    EditorGUILayout.LabelField("Button " + (num + 1));
                    // ボタンのオブジェクトを取得するフィールドを表示
                    select.selectData[num].buttonObj = (GameObject)EditorGUILayout.ObjectField("　ボタンのオブジェクト", select.selectData[num].buttonObj, typeof(GameObject), true);

                    // 枠組みの最後を設定する
                    GUILayout.EndVertical();

                    //スペースを描画
                    EditorGUILayout.Space();
                }
            }

            // ボタンBのボタン選択を有効にするかのトグルを表示
            select.ExitButton = EditorGUILayout.Toggle("ボタンBを有効にするか", select.ExitButton);

            if (select.ExitButton)
            {
                // 枠組みを作る
                GUILayout.BeginVertical(GUI.skin.box);

                // ボタンのオブジェクトを取得するフィールドを表示
                select.exitData.exitButton = (GameObject)EditorGUILayout.ObjectField("　ボタンのオブジェクト", select.exitData.exitButton, typeof(GameObject), true);
                // ボタンのUI画像をオブジェクトとして取得するフィールドを表示
                select.exitData.exitImage = (GameObject)EditorGUILayout.ObjectField("　ボタンのUI画像", select.exitData.exitImage, typeof(GameObject), true);

                // スペースを描画
                EditorGUILayout.Space();

                // 変化する速さを設定するフィールドを表示
                select.scallSpeed = EditorGUILayout.FloatField("変化する速さ", select.scallSpeed);
                // 切り替わるまでの時間を設定するフィールドを表示
                select.maxTime = EditorGUILayout.FloatField("切り替わる時間", select.maxTime);

                // スペースを描画
                EditorGUILayout.Space();

                // イベント関数の処理を表示する
                EditorGUILayout.PropertyField(events);

                // 枠組みの最後を設定する
                GUILayout.EndVertical();
            }
        }

        //serializedObjectへの変更を適用
        serializedObject.ApplyModifiedProperties();
        EditorUtility.SetDirty(select);
    }
}
#endif