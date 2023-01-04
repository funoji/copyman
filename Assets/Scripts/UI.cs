using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class UI : MonoBehaviour
{
    [Header("Player > CopyCollObj���A�^�b�`���� ")]
    [SerializeField] GameObject CopyCollObj;
    [SerializeField] Transform ObjUiPos;
    [SerializeField] TextMeshProUGUI MissionUI;
    [SerializeField] TextMeshProUGUI result;
    [SerializeField] TextMeshProUGUI StageNum;
    [HeaderAttribute("�X�g�����O�^�ł����݌n")]
    [SerializeField] public string MissionStr;
    [SerializeField] string Stage;
    [SerializeField] ObjectManager ObjectManager;
    GameObject  UIobj;
    

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
        //for (int i = 0; i < ObjectManager._CanCopyObj.Length; i++)
        //{
        //    if (UIobj.name == ObjectManager._CanCopyObj[i].name)
        //    {
        //        UIobj.GetComponent<Transform>().localScale = ObjectManager._CanCopyObj[i].Scale;
        //    }
        //}

        //if (GameDirector.GameClear) result.text = "StageClear";
        //if (GameDirector.GameOver) result.text = "GameOver";

        //var rectObj = new RectTransform();  // �V�[������Ƃ��Ă������̂Ƃ���
        //var rectP = rectObj.rect;
        //rectObj.rect.x--;
        //rectP.y--;
        //rectObj.rect = rectP;
    }
}
