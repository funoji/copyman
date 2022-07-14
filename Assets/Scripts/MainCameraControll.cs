using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Cinemachine;

public class MainCameraControll : MonoBehaviour
{
    //三人称カメラ：カメラ操作入力を記憶するプロパティ
    Vector2 cameraRotationInput = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        //オブジェクトの名前で検索して取得
        //GameObject Maincamera_object = GameObject.Find("Main Camera");
        GameObject Playercamera_object = GameObject.Find("PlayerCamera");
        //Debug.Log("メインカメラの位置"+Maincamera_object.transform.position);
        Debug.Log("プレイヤーカメラの位置"+Playercamera_object.transform.position);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Look(Vector2 input)
    {
        cameraRotationInput = input;
    }

}
