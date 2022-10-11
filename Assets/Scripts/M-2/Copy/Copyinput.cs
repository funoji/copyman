using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Copyinput : MonoBehaviour
{
    public Copy Copy;
    bool cooltime;
    float lapseTime;
    [SerializeField] float PasteCoolTime;
    int count;
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
            CopyColl.count = 0;
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            Copy.DisActive_Area();
        }
        if (Input.GetKeyUp(KeyCode.E) && cooltime)
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
        //if (lapseTime > 0)
            //Debug.Log(lapseTime);

        if (Input.GetKeyDown(KeyCode.R))
        {
            count++;
            Copy.ShotArkDrow(count);
        }

        if(Input.GetKeyUp(KeyCode.R))
        {
            Copy.Shot();
        }
    }
}
