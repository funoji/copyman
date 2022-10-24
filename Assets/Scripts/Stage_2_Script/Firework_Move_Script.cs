using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firework_Move_Script : MonoBehaviour
{
    //Debug : objectからオブジェクトを生成する
    [SerializeField] [Tooltip("弾の発射場所")] GameObject fireworkPoint;
    [SerializeField] [Tooltip("弾")] GameObject firework;
    [SerializeField] [Tooltip("弾のスピード")] float fireworkSpeed = 20f;

    //ゲームクリア条件処理
    [SerializeField] [Tooltip("ターゲットの個数")] public GameObject[] Count;

    private void Update()
    {
        //ターゲットを見つけて個数を見つける（Count.Length：ターゲットの個数）
        Count = GameObject.FindGameObjectsWithTag("Target");
        Debug.Log("残りのターゲット数：" + Count.Length);
        //個数が０になった時の処理
        if (Count.Length == 0)
        {
            Debug.Log("ゲームクリア");
        }

        //Debug : スペースキーを押したときの処理
        if (Input.GetKeyDown(KeyCode.Space)) shot();
    }

    //Debug : オブジェクトからSpeherを生成
    void shot()
    {
        Vector3 Point = this.transform.position;
        GameObject newFirework = Instantiate(firework, Point, transform.rotation);
        Vector3 direction = newFirework.transform.forward;
        newFirework.GetComponent<Rigidbody>().AddForce(direction * fireworkSpeed, ForceMode.Impulse); ;
    }
}
