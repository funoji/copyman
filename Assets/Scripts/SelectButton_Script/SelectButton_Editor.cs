using UnityEngine;
using System.Collections;
using UnityEngine.Events;
#if UNITY_EDITOR 
using UnityEditor;

[CustomEditor(typeof(SelectButton_Maneger))]
public class SelectButton_Editor : Editor
{
    private int arraysize = 0; //配列の長さを一時的に保存するための変数
    public override void OnInspectorGUI()
    {
        serializedObject.Update(); //serializedObjectを最新に変更
        var selectObj = serializedObject.FindProperty("selectData"); //S_3_Selectクラスの配列 SelectDataを取得
        var events = serializedObject.FindProperty("events");
        SelectButton_Maneger select = target as SelectButton_Maneger; //S_3_Selectクラスのインスタンスを取得

        EditorGUI.BeginChangeCheck();

        arraysize = selectObj.arraySize; //配列SelectDataの長さを一時的に変数に保存しておく

        //注意書き
        EditorGUILayout.HelpBox("説明\n【 button obj 】\n　Buttonオブジェクトを入れてください。\n【 button image 】\nMode:Size Buttonに使用しているすべての画像をまとめたオブジェクトを入れてください。\nMode:Image 選択状態の画像を入れてください。", MessageType.None, true);

        //選択状態のモードの設定
        select.mode = (SelectButton_Maneger.ModeType)EditorGUILayout.EnumPopup("選択状態のモード", select.mode);

        //特定のモードの時に表示する項目
        if(select.mode == SelectButton_Maneger.ModeType.none) { }
        if (select.mode == SelectButton_Maneger.ModeType.size)
        {
            select.scallSpeed = EditorGUILayout.FloatField("変化する速さ", select.scallSpeed);
            select.maxTime = EditorGUILayout.FloatField("切り替わる時間", select.maxTime);

            EditorGUILayout.Space(); //スペースを描画

            arraysize = EditorGUILayout.IntField("Number of buttons", arraysize); //一時的に保存した長さをカスタムインスタンスに描画（書き換え可能）

            EditorGUILayout.Space();

            select._pushBool = EditorGUILayout.Toggle("Push Other No Stop", select._pushBool);

            EditorGUILayout.Space();

            //一時的に保存した配列の長さと、本来の配列の長さが同じかチェックする
            if (arraysize != selectObj.arraySize)
            {
                selectObj.arraySize = arraysize; // 長さの変更を適用

                //ここでserializedObjectへの変更を適用し、再び更新する
                serializedObject.ApplyModifiedProperties();
                serializedObject.Update();
            }
            else 
            {
                //一時的に保存した配列の長さと、本来の配列の長さが同じ場合は　配列の要素を描画する
                for (int num = 0; num < selectObj.arraySize; num++)
                {
                    GUILayout.BeginVertical(GUI.skin.box);
                    EditorGUILayout.LabelField("Button " + (num + 1));
                    select.selectData[num].buttonObj = (GameObject)EditorGUILayout.ObjectField("button obj:", select.selectData[num].buttonObj, typeof(GameObject), true);
                    select.selectData[num].buttonImage = (GameObject)EditorGUILayout.ObjectField("button image:", select.selectData[num].buttonImage, typeof(GameObject), true);
                    GUILayout.EndVertical();

                    EditorGUILayout.Space(); //スペースを描画
                }
            }
            GUILayout.BeginVertical(GUI.skin.box);
            select.ExitButton = EditorGUILayout.Toggle("Use Exit Button ", select.ExitButton);
            if (select.ExitButton)
            {
                select.exitData.exitButton = (GameObject)EditorGUILayout.ObjectField("Exit button:", select.exitData.exitButton, typeof(GameObject), true);
                select.exitData.exitImage = (GameObject)EditorGUILayout.ObjectField("Exit button image:", select.exitData.exitImage, typeof(GameObject), true);

                EditorGUILayout.Space();
            }
            EditorGUILayout.PropertyField(events);
            GUILayout.EndVertical();
            EditorGUILayout.Space(); //スペースを描画
        }
        if (select.mode == SelectButton_Maneger.ModeType.image)
        {
            arraysize = EditorGUILayout.IntField("Number of buttons", arraysize); //一時的に保存した長さをカスタムインスタンスに描画（書き換え可能）

            EditorGUILayout.Space(); //スペースを描画

            select._pushBool = EditorGUILayout.Toggle("Push Other No Stop", select._pushBool);

            EditorGUILayout.Space();

            //一時的に保存した配列の長さと、本来の配列の長さが同じかチェックする
            if (arraysize != selectObj.arraySize)
            {
                selectObj.arraySize = arraysize; // 長さの変更を適用

                //ここでserializedObjectへの変更を適用し、再び更新する
                serializedObject.ApplyModifiedProperties();
                serializedObject.Update();
            }
            else
            {
                //一時的に保存した配列の長さと、本来の配列の長さが同じ場合は　配列の要素を描画する
                for (int num = 0; num < selectObj.arraySize; num++)
                {
                    GUILayout.BeginVertical(GUI.skin.box);
                    EditorGUILayout.LabelField("Button "+(num+1));
                    select.selectData[num].buttonObj = (GameObject)EditorGUILayout.ObjectField("button obj:", select.selectData[num].buttonObj, typeof(GameObject), true);
                    select.selectData[num].buttonImage = (GameObject)EditorGUILayout.ObjectField("button image:", select.selectData[num].buttonImage, typeof(GameObject), true);
                    GUILayout.EndVertical();

                    EditorGUILayout.Space(); //スペースを描画
                }
            }
            GUILayout.BeginVertical(GUI.skin.box);
            select.ExitButton = EditorGUILayout.Toggle("Use Exit Button ", select.ExitButton);
            if (select.ExitButton)
            {
                select.exitData.exitButton = (GameObject)EditorGUILayout.ObjectField("Exit button:", select.exitData.exitButton, typeof(GameObject), true);
                select.exitData.exitImage = (GameObject)EditorGUILayout.ObjectField("Exit button image:", select.exitData.exitImage, typeof(GameObject), true);
                EditorGUILayout.Space(); //スペースを描画

                select.scallSpeed = EditorGUILayout.FloatField("変化する速さ", select.scallSpeed);
                select.maxTime = EditorGUILayout.FloatField("切り替わる時間", select.maxTime);

                EditorGUILayout.Space();
            }
            EditorGUILayout.PropertyField(events);
            GUILayout.EndVertical();
        }
        if (select.mode == SelectButton_Maneger.ModeType.normal)
        {
            arraysize = EditorGUILayout.IntField("Number of buttons", arraysize); //一時的に保存した長さをカスタムインスタンスに描画（書き換え可能）

            EditorGUILayout.Space(); //スペースを描画

            //一時的に保存した配列の長さと、本来の配列の長さが同じかチェックする
            if (arraysize != selectObj.arraySize)
            {
                selectObj.arraySize = arraysize; // 長さの変更を適用

                //ここでserializedObjectへの変更を適用し、再び更新する
                serializedObject.ApplyModifiedProperties();
                serializedObject.Update();
            }
            else
            {
                //一時的に保存した配列の長さと、本来の配列の長さが同じ場合は　配列の要素を描画する
                for (int num = 0; num < selectObj.arraySize; num++)
                {
                    GUILayout.BeginVertical(GUI.skin.box);
                    EditorGUILayout.LabelField("Button " + (num + 1));
                    select.selectData[num].buttonObj = (GameObject)EditorGUILayout.ObjectField("button obj:", select.selectData[num].buttonObj, typeof(GameObject), true);
                    GUILayout.EndVertical();
                    EditorGUILayout.Space(); //スペースを描画
                }
            }
            GUILayout.BeginVertical(GUI.skin.box);
            select.ExitButton = EditorGUILayout.Toggle("Use Exit Button ", select.ExitButton);
            if (select.ExitButton)
            {
                EditorGUILayout.LabelField("Exit Button");
                select.exitData.exitButton = (GameObject)EditorGUILayout.ObjectField("Exit button:", select.exitData.exitButton, typeof(GameObject), true);
                select.exitData.exitImage = (GameObject)EditorGUILayout.ObjectField("Exit button image:", select.exitData.exitImage, typeof(GameObject), true);
                EditorGUILayout.Space(); //スペースを描画

                select.scallSpeed = EditorGUILayout.FloatField("変化する速さ", select.scallSpeed);
                select.maxTime = EditorGUILayout.FloatField("切り替わる時間", select.maxTime);

                EditorGUILayout.Space();
            }
            EditorGUILayout.PropertyField(events);
            GUILayout.EndVertical();
        }
        serializedObject.ApplyModifiedProperties(); //serializedObjectへの変更を適用
        EditorUtility.SetDirty(select);
    }
}
#endif