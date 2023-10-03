using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR 
using UnityEditor;

// GameMove_ManagerのInspectorをカスタムする
[CustomEditor(typeof(GameMove_Manager))]
public class GameMove_Editor : Editor
{
    // 配列の長さを一時的に保存するための変数
    private int arraysize = 0;

    public override void OnInspectorGUI()
    {
        // serializedObjectを最新に変更
        serializedObject.Update();

        // GameMove_Managerクラスのインスタンスを取得
        GameMove_Manager gamemove = target as GameMove_Manager;

        EditorGUI.BeginChangeCheck();

        // S_3_Selectクラスの配列 SelectDataを取得
        var moveobj = serializedObject.FindProperty("_bomMove");

        // 見出しを設定する
        EditorGUILayout.LabelField("動作を止めるオブジェクトの設定", EditorStyles.boldLabel);

        // CameraSystemのオブジェクトを取得するフィールドを表示
        gamemove._cameraMove = (GameObject)EditorGUILayout.ObjectField("CameraSystem", gamemove._cameraMove, typeof(GameObject), true);
        // Playerのオブジェクトを取得するフィールドを表示
        gamemove._playerMove = (GameObject)EditorGUILayout.ObjectField("Player", gamemove._playerMove, typeof(GameObject), true);
        // CPMのオブジェクトを取得するフィールドを表示
        gamemove._copyMove = (GameObject)EditorGUILayout.ObjectField("Playerの中のCPM", gamemove._copyMove, typeof(GameObject), true);
        // GameManagerのオブジェクトを取得するフィールドを表示
        gamemove._gamemanagerMove = (GameObject)EditorGUILayout.ObjectField("GameManager", gamemove._gamemanagerMove, typeof(GameObject), true);

        //serializedObjectへの変更を適用
        serializedObject.ApplyModifiedProperties();
        EditorUtility.SetDirty(gamemove);
    }
}
#endif

public class GameMove_Manager : MonoBehaviour
{
    // カメラの操作を止めるために「CameraSystem」を取得する
    public GameObject _cameraMove;

    // プレイヤーの動作と操作を止めるために「Player」を取得する
    public GameObject _playerMove;

    // プレイヤーのコピーペーストの操作を止めるために「Player」の「CPM」を取得する
    public GameObject _copyMove;

    // ポーズ画面の動作を止めるために「GameManager」を取得する
    public GameObject _gamemanagerMove;

    private void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // ゲームオーバーもしくはゲームクリアの判定が有効になった場合
        if (GameDirector.GameClear || GameDirector.GameOver)
        {
            // 動作を止める関数を呼び出す
            Move_Function();
        }
    }

    // 動作を止める処理の関数
    private void Move_Function()
    {
        // カメラのオブジェクトを無効にする
        _cameraMove.SetActive(false);

        // プレイヤーの移動を止めるために「PlayerController」を無効にする
        _playerMove.GetComponent<PlayerController>().enabled = false;
        // プレイヤーのアニメーションを止めるために「Animator_Controller」を無効にする
        _playerMove.GetComponent<Animator_Controller>().enabled = false;

        // プレイヤーのコピーペーストの動作を止めるために「Copyinput」を無効にする
        _copyMove.GetComponent<Copyinput>().enabled = false;

        // ポーズ画面を起動しないように「CanvasActiveScript」を無効にする
        _gamemanagerMove.GetComponent<CanvasActiveScript>().enabled = false;
    }
}