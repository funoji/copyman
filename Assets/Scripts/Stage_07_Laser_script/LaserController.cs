using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    [SerializeField] [Tooltip("発射場所")] GameObject firingLocatioin;
    [SerializeField] [Tooltip("レーザーの元となるオブジェクト")] GameObject laserObj;
    [SerializeField] [Tooltip("オブジェクトの速さ")]float laserSpeed = 50f;

    private float time;         //　秒数管理
    private bool isOn = false;   //　３秒間隔でonとoffの切り替えの判定
    private bool shotOn = true; //　１回のみオブジェクトを生成させるための判定

    [SerializeField] bool gameOver;
    [SerializeField] bool gameClear;
    LaserGameOver laserGameOverScript;
    GoarManeger goarScript;

    private void Start()
    {
        //gameOver = GameObject.FindWithTag("Trigger");
        //gameOver = laserGameOverScript.GetComponent<LaserGameOver>().gameoverFlag;
        //gameClear = GameObject.FindWithTag("Goar_Judg");
        //gameClear = goarScript.GetComponent<GoarManeger>().gameclearFlag;
    }

    private void Update()
    {
        //時間を生成
        time += Time.deltaTime;
        //Debug.Log(time);

        //３秒間隔
        if (time <= 3.0f)
        {
            //３秒間隔でレーザーを発射させる（当たり判定のオブジェクトは一回のみ生成）
            if (isOn && shotOn)
            {
                ShotMove(); //オブジェクトの発射
                shotOn = false;
            }
        }
        if (time > 3.0f)
        {
            if (isOn) isOn = false;
            else if (!isOn) isOn = true; shotOn = true;
            time = 0; //時間の初期化
        }

        ////GameOverになったら処理を停止する。又はGameClearになったら処理を停止する
        //if (gameOver == false || gameClear == false) 
        //{
        //    //時間を生成
        //    time += Time.deltaTime;
        //    //Debug.Log(time);

        //    //３秒間隔
        //    if (time <= 3.0f)
        //    {
        //        //３秒間隔でレーザーを発射させる（当たり判定のオブジェクトは一回のみ生成）
        //        if (isOn && shotOn)
        //        {
        //            ShotMove(); //オブジェクトの発射
        //            shotOn = false;
        //        }
        //    }
        //    if (time > 3.0f)
        //    {
        //        if (isOn) isOn = false;
        //        else if (!isOn) isOn = true; shotOn = true;
        //        time = 0; //時間の初期化
        //    }
        //}
    }

    //オブジェクトの発射
    void ShotMove()
    {
        //オブジェクトを発射させる場所を取得
        Vector3 laserobjPosition = firingLocatioin.transform.position;
        //取得した場所にオブジェクトを出現させる
        GameObject newLaser = Instantiate(laserObj, laserobjPosition, transform.rotation);
        //出現させたオブジェクトのfoward(z軸方向）
        Vector3 direction = newLaser.transform.right;
        //オブジェクトの発射方向にZ方向を入れ、オブジェクトのrigibodyに力を加える
        newLaser.GetComponent<Rigidbody>().AddForce(direction * laserSpeed, ForceMode.Impulse);
    }
}
