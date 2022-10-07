using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Megutan_CanCopy : MonoBehaviour
{
    [SerializeField] GameObject copys;
    [SerializeField] GameObject Pos;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 CopyPos = Pos.transform.position;
        if(Input.GetMouseButton(0))
        {
            GameObject instance = (GameObject)Instantiate(copys,CopyPos,Quaternion.identity);
        }
    }
}
