using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(S_3_Select))]
public class SetMonsterStatusEditor : Editor
{
    private int arraysize = 0; //配列の長さを一時的に保存するための変数
    public override void OnInspectorGUI()
    {
        serializedObject.Update(); //serializedObjectを最新に変更
        var selectObj = serializedObject.FindProperty("selectData"); //S_3_Selectクラスの配列 SelectDataを取得
        S_3_Select select = target as S_3_Select; //S_3_Selectクラスのインスタンスを取得

        arraysize = selectObj.arraySize; //配列SelectDataの長さを一時的に変数に保存しておく

        //注意書き
        EditorGUILayout.HelpBox("説明\n「button name」\n　どのボタンを設定しているかわかりやすいようにするための名前\n　※記入してもしなくても大丈夫\n「button obj」\n　Buttonオブジェクトを入れてください。\n「button image」\nMode:Size Buttonに使用しているすべての画像をまとめたオブジェクトを入れてください。\nMode:Image 選択状態の画像を入れてください。\n", MessageType.None, true);
        EditorGUILayout.HelpBox("最初に選択状態にしたボタンは１番目、戻るボタンは２番目の欄に入れてください。", MessageType.Info, true);

        //選択状態のモードの設定
        select.mode = (S_3_Select.ModeType)EditorGUILayout.EnumPopup("選択状態のモード", select.mode);

        //特定のモードの時に表示する項目
        if (select.mode == S_3_Select.ModeType.size)
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
                    select.selectData[num].buttonName = EditorGUILayout.TextField("button name:", select.selectData[num].buttonName);
                    select.selectData[num].buttonObj = (GameObject)EditorGUILayout.ObjectField("button obj:", select.selectData[num].buttonObj, typeof(GameObject), true);
                    select.selectData[num].buttonImage = (GameObject)EditorGUILayout.ObjectField("button image:", select.selectData[num].buttonImage, typeof(GameObject), true);

                    EditorGUILayout.Space(); //スペースを描画
                }
            }

            select.scallSpeed=EditorGUILayout.FloatField("変化する速さ", select.scallSpeed);
            select.maxTime= EditorGUILayout.FloatField("切り替わる時間", select.maxTime);
        }
        if (select.mode == S_3_Select.ModeType.image)
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
                    select.selectData[num].buttonName = EditorGUILayout.TextField("button name:", select.selectData[num].buttonName);
                    select.selectData[num].buttonObj = (GameObject)EditorGUILayout.ObjectField("button obj:", select.selectData[num].buttonObj, typeof(GameObject), true);
                    select.selectData[num].buttonImage = (GameObject)EditorGUILayout.ObjectField("button image:", select.selectData[num].buttonImage, typeof(GameObject), true);

                    EditorGUILayout.Space(); //スペースを描画
                }
            }
        }
        if (select.mode == S_3_Select.ModeType.normal)
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
                    select.selectData[num].buttonName = EditorGUILayout.TextField("button name:", select.selectData[num].buttonName);
                    select.selectData[num].buttonObj = (GameObject)EditorGUILayout.ObjectField("button obj:", select.selectData[num].buttonObj, typeof(GameObject), true);
                    select.selectData[num].buttonImage = (GameObject)EditorGUILayout.ObjectField("button image:", select.selectData[num].buttonImage, typeof(GameObject), true);

                    EditorGUILayout.Space(); //スペースを描画
                }
            }
        }

        serializedObject.ApplyModifiedProperties(); //serializedObjectへの変更を適用
        EditorUtility.SetDirty(target);
    }
}