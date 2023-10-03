using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceDropObject_Manager : MonoBehaviour
{
    [Header("演出用の落下オブジェクトの処理")]
    [SerializeField, Tooltip("生成する範囲始まり")] private Transform rangeA;
    [SerializeField, Tooltip("生成する範囲終わり")] private Transform rangeB;
    [SerializeField, Range(0, 10), Tooltip("生成する周期")] private float cycle;

    // 計測する時間を保存する変数
    private float time;
    // Rigidbodyを保存する変数
    private Rigidbody rb;
    // Quaternionを保存する変数
    private Quaternion rotation;
    // オブジェクトの大きさを保存する変数
    private Vector3 scale;
    // 生成したオブジェクト用の変数
    private GameObject instansObj;
    // Randomの数値を保存する変数
    private int instanNum;

    [Header("ランダム値の設定")]
    [SerializeField, Range(0, 100), Tooltip("スケールの最小値")] private float scaleMin;
    [SerializeField, Range(0, 100), Tooltip("スケールの最大値")] private float scaleMax;
    [SerializeField, Range(-360, 360), Tooltip("回転の最小値")] private float rotaMin;
    [SerializeField, Range(-360, 360), Tooltip("回転の最大値")] private float rotaMax;
    [SerializeField, Range(0, 10), Tooltip("落ちるスピードの最小値")] private float dragMin;
    [SerializeField, Range(0, 10), Tooltip("落ちるスピードの最大値")] private float dragMax;
    [SerializeField, Range(0, 10), Tooltip("回転スピードの最小値")] private float angleDragMin;
    [SerializeField, Range(0, 10), Tooltip("回転スピードの最大値")] private float angleDragMax;
    [SerializeField, Range(0, 1000), Tooltip("落下スピードの最小値")] private float speedMin;
    [SerializeField, Range(0, 1000), Tooltip("落下スピードの最大値")] private float speedMax;

    [Header("表示するオブジェクト")]
    [Tooltip("生成するオブジェクト")] public GameObject[] creatPrefab;

    // Update is called once per frame
    void Update()
    {
        // 時間を加算
        time = time + Time.deltaTime;

        // 落下オブジェクトの種類のランダム
        instanNum = Random.Range(0, creatPrefab.Length);

        // 落下オブジェクトの大きさを取得
        scale = creatPrefab[instanNum].transform.localScale;

        // 落下オブジェクトのribidbodyを取得
        rb = creatPrefab[instanNum].GetComponent<Rigidbody>();

        // Constansの初期化
        rb.constraints = RigidbodyConstraints.None;

        // 落下オブジェクトの大きさのランダム
        float scaleRandom = Random.Range(scaleMin, scaleMax);

        // 落下オブジェクトの回転角度のランダム
        float rotRandom = Random.Range(-rotaMin, rotaMax);
        rotation = Quaternion.Euler(rotRandom, rotRandom, rotRandom);

        // 落下オブジェクトのスピードのランダム
        float speedRandom = Random.Range(speedMin, speedMax);

        // 設定した秒数周期で処理
        if (time > cycle)
        {
            // 落下オブジェクトの位置のランダム
            float x = Random.Range(rangeA.position.x, rangeB.position.x);
            float y = Random.Range(rangeA.position.y, rangeB.position.y);
            float z = Random.Range(rangeA.position.z, rangeB.position.z);

            // 落下オブジェクトを生成
            instansObj = Instantiate(creatPrefab[instanNum], new Vector3(x, y, z), rotation);

            // 落下オブジェクトの大きさを変更
            instansObj.transform.localScale = new Vector3(scale.x * scaleRandom, scale.y * scaleRandom, scale.z * scaleRandom);

            // 落下オブジェクトの落下スピードと回転スピードを変更
            rb.drag = Random.Range(-dragMin, dragMax);
            rb.AddForce(0, -speedRandom, 0);
            //rb.angularDrag = Random.Range(angleDragMin, angleDragMax);

            // 時間を初期化
            time = 0f;
        }
    }
}
