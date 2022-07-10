using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//　重力操作用のスクリプト。Rigidbody持ってるオブジェクトにアタッチすると
//そのオブジェクトのみにかかる重力を調整できる。


[RequireComponent(typeof(Rigidbody))]
public class GravityController : MonoBehaviour
{
    public float ExtraGravity = 1f;　//Rigidbodyに加える重力の倍率
    private Rigidbody rb;　　//Rigidbody取得用の変数

    private void Start()
    {
        rb= GetComponent<Rigidbody>(); //Rigidbody取得
    }

    private void FixedUpdate()
    {
        rb.AddForce((ExtraGravity-1f)*Physics.gravity, ForceMode.Acceleration);　//本処理
    }
}
