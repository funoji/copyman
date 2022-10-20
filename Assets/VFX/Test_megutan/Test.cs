using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private Rigidbody rb;　　　　//Rigidbody読み込み用変数
    public float JumpPower = 200f;　　//ジャンプする力(上方向への力)
    public int JumpLimit = 1;    //ジャンプできる回数
    private int jumpCount = 0;   //内部処理用
    private bool IsGround = true;　//接地フラグ用

    void Start()
    {
        rb = GetComponent<Rigidbody>();   //Rigidbody取得  
    }

    void Update()
    {
        //着地するまでジャンプ回数は元に戻らないよーっていう処理
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        if (IsGround)
            jumpCount = 0;
    }

    public void Jump()
    {
        if (jumpCount < JumpLimit)　　//Limitの分だけジャンプできる
        {
            rb.velocity = Vector3.zero;
            rb.AddForce(new Vector3(0, JumpPower, 0)); //ジャンプの方向
            IsGround = false;　//ジャンプしたよーっていうフラグ

            jumpCount++;
        }
    }
    private void OnCollisionEnter(Collision coll)
    {
        //地面に着地しているかどうかの判定
        //ここを作るにあたってステージのタグを”StageGround”に変更しました。
        if (coll.gameObject.tag == "StageGround")
        {
            IsGround = true;
        }
    }
}