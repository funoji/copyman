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

    void Start()
    {
        StageNum.text = Stage;
        MissionUI.text = MissionStr;
    }
    // Update is called once per frame
    void Update()
    {
        UIobj = CopyCollObj.GetComponent<CopyColl>().ForUIObj;
        UIobj.transform.position = ObjUiPos.position;
        UIobj.name = CopyColl.Obj.name;
        if (GameDirector.GameClear)
        {
            UIobj = defaltUi;
        }
        for (int i = 0; i < ObjectManager._CanCopyObj.Length; i++)
        {
            if (UIobj.name == ObjectManager._CanCopyObj[i].name)
            {
                UIobj.GetComponent<Transform>().localScale = ObjectManager._CanCopyObj[i].Scale;
                UIobj.transform.position = ObjUiPos.position + ObjectManager._CanCopyObj[i].Position;
                Debug.Log(UIobj.GetComponent<Transform>().localScale);
            }
            if(GameDirector.GameOver)
            {
                UIobj.SetActive(false);
            }
        }
    }
}
