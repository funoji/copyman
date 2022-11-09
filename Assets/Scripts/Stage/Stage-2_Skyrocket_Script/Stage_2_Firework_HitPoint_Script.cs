using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_2_Firework_HitPoint_Script : MonoBehaviour
{
    //爆発についての処理
    [SerializeField] [Tooltip("当たり判定のオブジェクト")] GameObject hitPoint;
    [SerializeField] [Tooltip("当たった場合 : 消えるまでの時間")] private float deleTime;
    [SerializeField] [Tooltip("当たってない場合 : 消えるまでの時間")] private float NodeleTime;
    [SerializeField] [Tooltip("爆発範囲")] private float hitRadius = 2.0f;

    private void Start()
    {
        //爆発の当たり判定オブジェクトを取得
        hitPoint=GameObject.Find("HitPoint_Empty");

        //爆発範囲の変更処理
        hitPoint.GetComponent<SphereCollider>().radius = hitRadius;

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Target" && collision != null)
        {
            //爆発範囲をオンにする
            hitPoint.GetComponent<SphereCollider>().enabled = true;

            //時間経過で消す
            Destroy(this.gameObject, deleTime);
        }
        else
        {
            //当たらなかった場合 : 時間経過で消す
            Destroy(this.gameObject, NodeleTime);
        }
    }
}
