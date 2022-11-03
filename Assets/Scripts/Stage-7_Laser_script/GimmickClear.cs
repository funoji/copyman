using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickClear : MonoBehaviour
{
    //橋の変数
    [SerializeField] GameObject target;

    //オブジェクトがひも？に当たったら橋を重力で落とす。またひも？を消す。
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Trigger")
        {
            Attach_Gravity(); //重力を付与する
            Destroy(this.gameObject); //オブジェクトを消す
        }
    }

    //重力を付与する
    void Attach_Gravity()
    {
        target.GetComponent<Rigidbody>().useGravity = true;
    }
}
