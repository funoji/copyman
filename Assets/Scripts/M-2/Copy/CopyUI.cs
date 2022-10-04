using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyUI : MonoBehaviour
{
    [SerializeField] Transform ObjPos;
    GameObject Obj = default!;
    CopyColl CopyColl;
    // Update is called once per frame
    void Update()
    {
        Obj = CopyColl.Obj;
        Obj.transform.position = ObjPos.position;
        Obj.transform.Rotate(new Vector3(0, 100, 0)*Time.deltaTime);
    }
}
