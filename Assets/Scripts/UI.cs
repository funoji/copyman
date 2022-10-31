using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class UI : MonoBehaviour
{
    [SerializeField] GameObject CopyCollObj;
    [SerializeField] Transform ObjUiPos;
    [SerializeField] TextMeshProUGUI MissionUI;
    [SerializeField] TextMeshProUGUI result;
    [SerializeField] TextMeshProUGUI StageNum;
    [HeaderAttribute("�X�g�����O�^�ł����݌n")]
    [SerializeField] string MissionStr;
    [SerializeField] string Stage;
    GameObject  UIobj;

    private void Start()
    {
        StageNum.text = Stage;
        MissionUI.text = MissionStr;
    }
    // Update is called once per frame
    void Update()
    {
        UIobj = CopyCollObj.GetComponent<CopyColl>().ForUIObj;
        UIobj.transform.position = ObjUiPos.position;
        if (GameDirector.GameClear) result.text = "StageClear";

        //var rectObj = new RectTransform();  // �V�[������Ƃ��Ă������̂Ƃ���
        //var rectP = rectObj.rect;
        //rectObj.rect.x--;
        //rectP.y--;
        //rectObj.rect = rectP;
    }
}