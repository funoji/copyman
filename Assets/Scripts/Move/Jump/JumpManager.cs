using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpManager : MonoBehaviour
{
    [SerializeField] Transform playerPosition;

    public float x = -3;
    public float y = -3;
    public float z = -3;

    private Rigidbody rb;　　　　//Rigidbody読み込み用変数
    public float JumpPower = 200f;　　//ジャンプする力(上方向への力)
    public int JumpLimit = 1;    //ジャンプできる回数
    //private int jumpCount = 0;   //内部処理用
    private bool IsGround = true;　//接地フラグ用
    private float distance = 1.0f;
    Vector3 rayPosition;

    void Start()
    {
        rb= GetComponent<Rigidbody>();   //Rigidbody取得 
    }

    void Update()
    {
        rayPosition=/*transform.position+*/new Vector3(
            playerPosition.position.x-x, playerPosition.position.y-y, playerPosition.position.z-z);
        Ray ray = new Ray(rayPosition, Vector3.down);
        IsGround = Physics.Raycast(ray, distance);
        Debug.DrawRay(rayPosition, Vector3.down*distance, Color.red);

        Debug.Log(IsGround);
    }
    public void Jump()
    {
        if (IsGround) //Rayでジャンプを管理するVer
        {
            rb.velocity = Vector3.zero;
            rb.AddForce(new Vector3(0, JumpPower, 0)); //ジャンプの方向
        }
    }

    //public void Jump()
    //{
    //    if (jumpCount<JumpLimit)　　//Limitの分だけジャンプできる
    //    {
    //        rb.velocity = Vector3.zero;
    //        rb.AddForce(new Vector3(0, JumpPower, 0)); //ジャンプの方向
    //        IsGround=false;　//ジャンプしたよーっていうフラグ

    //        jumpCount++;
    //    }
    //}
    //void OnCollisionEnter(Collision coll)
    //{
    //    //地面に着地しているかどうかの判定
    //    //ここを作るにあたってステージのタグを”StageGround”に変更しました。
    //    if (coll.gameObject.tag=="StageGround")
    //    {
    //        IsGround=true;
    //    }
    //}
}
