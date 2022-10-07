using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Megutan_Copyinput : MonoBehaviour
{
    public Megutan_Copy Copy;
    bool cooltime;
    float lapseTime;
    [SerializeField] float PasteCoolTime;
    // Start is called before the first frame update
    void Start()
    {
        cooltime = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Copy.Active_Area();
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            Copy.DisActive_Area();
        }
        if (Input.GetKeyDown(KeyCode.E) && cooltime)
        {
            Copy.Paseting();
            cooltime = false;
        }

        if (!cooltime)
        {
            lapseTime += Time.deltaTime;
        }

        if (lapseTime >= PasteCoolTime)
        {
            cooltime = true;
            lapseTime = 0.0f;
        }
        if (lapseTime > 0)
            Debug.Log(lapseTime);
    }
}
