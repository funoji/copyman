using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class UI : MonoBehaviour
{
    [Header("Player > CopyCollObjをアタッチする ")]
    [SerializeField] GameObject CopyCollObj;
    [SerializeField] Transform ObjUiPos;
    [SerializeField] TextMeshProUGUI MissionUI;
    [SerializeField] TextMeshProUGUI result;
    [SerializeField] TextMeshProUGUI StageNum;
    [HeaderAttribute("ストリング型打ち込み系")]
    [SerializeField] public string MissionStr;
    [SerializeField] string Stage;
    [SerializeField] ObjectManager ObjectManager;
    GameObject  UIobj;
    [SerializeField] GameObject defaltUi;
    [SerializeField] CopyColl CopyColl;

    private GameObject preUiObj;
    void Start()
    {
        StageNum.text = Stage;
        MissionUI.text = MissionStr;
    }
    // Update is called once per frame
    void Update()
    {
        preUiObj = UIobj;
        UIobj = CopyCollObj.GetComponent<CopyColl>().ForUIObj;
        UIobj.transform.position = ObjUiPos.position;
        UIobj.name = CopyColl.Obj.name; 
        if (preUiObj != UIobj)
        {
            //UIobj.GetComponent<Rigidbody>().isKinematic = true;
            Destroy(preUiObj);
        }

        for (int i = 0; i < ObjectManager._CanCopyObj.Length; i++)
        {
            if (UIobj.name == ObjectManager._CanCopyObj[i].name)
            {
                UIobj.GetComponent<Transform>().localScale = ObjectManager._CanCopyObj[i].Scale;
                UIobj.transform.position = ObjUiPos.position + ObjectManager._CanCopyObj[i].Position;
                UIobj.transform.rotation = ObjectManager._CanCopyObj[i].Rotate;

             
            }
            if(GameDirector.GameOver || GameDirector.GameClear)
            {
                UIobj.SetActive(false);
            }
        }
    }
}
