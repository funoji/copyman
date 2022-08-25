using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundAngleController: MonoBehaviour
{
    //オブジェクトのRigidbodyを取得
    [SerializeField] Rigidbody laserObject;

    //オブジェクトと鏡との入射角と反射角を同じにさせる
    private void OnCollisionEnter(Collision collision)
    {
        // 入射ベクトル（速度）
        var inDirection = laserObject.velocity;
        // 法線ベクトル
        var inNormal = transform.up;
        // 反射ベクトル（速度）
        var result = Vector3.Reflect(inDirection, inNormal);

        // バウンド後の速度をボールに反映
        laserObject.velocity = result;
    }
}
