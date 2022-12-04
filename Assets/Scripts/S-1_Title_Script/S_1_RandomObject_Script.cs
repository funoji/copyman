using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_1_RandomObject_Script : MonoBehaviour
{
    [Header("演出用の落下オブジェクトの処理")]
    [SerializeField] [Tooltip("生成する範囲始まり")] private Transform rangeA;
    [SerializeField] [Tooltip("生成する範囲終わり")] private Transform rangeB;
    [SerializeField] [Tooltip("生成する周期")] public float cycle;

    private float time;
    private Rigidbody rb;
    private Quaternion rotation;
    private Vector3 scale;
    private GameObject instansObj;
    private int instanNum;

    [Header("ランダム値の設定")]
    [SerializeField] [Tooltip("スケールの最小値")] private float scaleMin;
    [SerializeField] [Tooltip("スケールの最大値")] private float scaleMax;
    [SerializeField] [Tooltip("回転の最小値")] private float rotaMin;
    [SerializeField] [Tooltip("回転の最大値")] private float rotaMax;
    [SerializeField] [Tooltip("落ちるスピードの最小値")] private float dragMin;
    [SerializeField] [Tooltip("落ちるスピードの最大値")] private float dragMax;
    [SerializeField] [Tooltip("回転スピードの最小値")] private float angleMin;
    [SerializeField] [Tooltip("回転スピードの最大値")] private float angleMax;
    [SerializeField] [Tooltip("落下スピードの最小値")] private float speedMin;
    [SerializeField] [Tooltip("落下スピードの最大値")] private float speedMax;

    [Header("表示するオブジェクト")]
    [SerializeField] [Tooltip("生成するオブジェクト")] public GameObject[] creatPrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //時間を加算 : Add time
        time = time + Time.deltaTime;

        //落下オブジェクトの種類のランダム
        instanNum = Random.Range(0, creatPrefab.Length);

        //落下オブジェクトの大きさを取得
        scale = creatPrefab[instanNum].transform.localScale;

        //落下オブジェクトのribidbodyを取得 : Get "ridbody" of the falling object
        rb = creatPrefab[instanNum].GetComponent<Rigidbody>();

        //落下オブジェクトの大きさのランダム : Random size of falling objects
        float scaleRandom = Random.Range(scaleMin, scaleMax);

        //落下オブジェクトの回転角度のランダム : Random angle of rotation of falling objects
        float rotRandom = Random.Range(-rotaMin, rotaMax);
        rotation = Quaternion.Euler(rotRandom, rotRandom, rotRandom);

        //落下オブジェクトのスピードのランダム
        float speedRandom = Random.Range(speedMin, speedMax);

        //設定した秒数周期で処理 : Processed in a set number of second cycles
        if (time > cycle)
        {
            //落下オブジェクトの位置のランダム : Random position of falling objects
            float x = Random.Range(rangeA.position.x, rangeB.position.x);
            float y = Random.Range(rangeA.position.y, rangeB.position.y);
            float z = Random.Range(rangeA.position.z, rangeB.position.z);

            //落下オブジェクトを生成 : Generate falling objects
            instansObj = Instantiate(creatPrefab[instanNum], new Vector3(x, y, z), rotation);

            //落下オブジェクトの大きさを変更 : Change size of falling objects
            instansObj.transform.localScale = new Vector3(scale.x * scaleRandom, scale.y * scaleRandom, scale.z * scaleRandom);

            //落下オブジェクトの落下スピードと回転スピードを変更 : Change falling speed and rotation speed of falling objects
            rb.drag = Random.Range(-dragMin, dragMax);
            rb.AddForce(0, -speedRandom, 0);
            rb.angularDrag = Random.Range(angleMin, angleMax);

            //時間初期化 : time initialization
            time = 0f;
        }
    }
}
