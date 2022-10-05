using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shot : MonoBehaviour
{
    //bulletプレハブ
    public GameObject bullet;
    //弾が生成されるポジションを保有するゲームオブジェクト
    public GameObject bulletPos;
    //弾のスピード
    public float speed = 1500f;

    // Update is called once per frame
    void Update()
    {
        //スペースが押されたとき
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //ballをインスタンス化して発射
            GameObject createdBullet = Instantiate(bullet) as GameObject;
            createdBullet.transform.position = bulletPos.transform.position;

            //発射ベクトル
            Vector3 force;
            //発射の向きと速度を決定
            force = bulletPos.transform.forward * speed;
            // Rigidbodyに力を加えて発射
            createdBullet.GetComponent<Rigidbody>().AddForce(force);
        }
    }
}
