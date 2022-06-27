using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraControll : MonoBehaviour
{
    GameObject mainCamera; //カメラ
    GameObject fieldObject; //中心としたいオブジェクト
    public float rotateSpeed = 1.0f; //回転スピード
    private Vector3 lastMousePosition; //直前の回転を保持しておくための変数
    private Vector3 newAngle = new Vector3(0, 0, 0); // Vector3(0,0,0)のインスタンス
    
    void Start()
    {
        this.mainCamera = Camera.main.gameObject; //カメラのオブジェクトを取得
        this.fieldObject = GameObject.Find("LookPos"); //中心としたいオブジェクトを取得
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //入力されてから一回だけ実行する
        {
            newAngle = mainCamera.transform.localEulerAngles; //newAngle変数に相対的な回転地を代入
            lastMousePosition = Input.mousePosition;  //クリックされた際のマウス位置を代入
        }
        else if (Input.GetMouseButton(0))
        {
            rotateCamera();
        }

        Find_Angle(this.mainCamera, this.fieldObject);
        //Debug.Log("２点間の距離："+Find_Distance(this.mainCamera, this.fieldObject));
    }

    private void rotateCamera()
    {
        Vector3 angle = new Vector3(Input.GetAxis("Mouse X") * this.rotateSpeed, Input.GetAxis("Mouse Y") * this.rotateSpeed, 0); 
        this.mainCamera.transform.RotateAround(this.fieldObject.transform.position, Vector3.up, angle.x); //X軸の回転
        this.mainCamera.transform.RotateAround(this.fieldObject.transform.position, transform.right, angle.y); //ｙ軸の回転
    }

    public float Find_Distance(GameObject camera, GameObject player)
    {
        //カメラープレイヤーの距離
        float dist_x = camera.transform.position.x - player.transform.position.x;
        float dist_z = camera.transform.position.y - player.transform.position.y;
        //距離を求める
        return Mathf.Sqrt((dist_x * dist_x) + (dist_z * dist_z));
    }
    void Find_Angle(GameObject camera,GameObject player)
    {
        //角度を求める
        Quaternion.LookRotation(camera.transform.position, player.transform.position);
        Debug.Log("カメラの位置："+camera.transform.position);
        Debug.Log("プレイヤーの位置：" + player.transform.position);
        Debug.Log("２点間の角度："+Quaternion.LookRotation(camera.transform.position, player.transform.position));
    }
}