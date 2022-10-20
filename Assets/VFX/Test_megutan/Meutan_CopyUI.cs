using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Megutan_CopyUI : MonoBehaviour
{
    [SerializeField] Transform ObjPos;
    CopyColl CopyColl;
    GameObject Obj;
    // Update is called once per frame
    void Update()
    {
        Obj = CopyColl.Obj;
        Obj.transform.position = ObjPos.position;
        Obj.transform.Rotate(new Vector3(0, 100, 0)*Time.deltaTime);
    }
}
