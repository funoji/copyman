//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class CopyUI : MonoBehaviour
//{
//    [SerializeField] Transform ObjPos;
//    [SerializeField] GameObject CopyCallObj;
//    GameObject UIObj;
//    [SerializeField] GameObject DEMI;

//    void Start()
//    {
        
//    }
//    // Update is called once per frame
//    void Update()
//    {
//        UIObj = CopyCallObj.GetComponent<CopyColl>().ForUIObj;
//        if (!UIObj)
//        {
//            UIObj = DEMI;
//        }
//        UIObj.transform.position = ObjPos.position;
//        UIObj.transform.Rotate(new Vector3(0, 100, 0)*Time.deltaTime);
//    }
//}
    