using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Stage3_CrearFlag : MonoBehaviour
{
    private float clearNum;
    private int pushButtonNow = 0;
    public int PushButtonNum
    {
        set => pushButtonNow = value;
        get => pushButtonNow;
    }

    [SerializeField] GameObject[] targetObj;
    [SerializeField] TextMeshProUGUI buttonUI;

    private void Awake()
    {
        clearNum = ClearNum(targetObj);
    }

    void Start()
    {
        StartCoroutine("ClearButton");
        PushButtonNum = 0;
    }

    void Update()
    {
        buttonUI.text = pushButtonNow + "/" + clearNum;
        Clear();
    }

    void Clear()
    {
        if (PushButtonNum >= clearNum) GameDirector.GameClear = true;
    }

    int ClearNum(GameObject[] targets)
    {
        int num = 0;
        foreach (GameObject obj in UnityEngine.Object.FindObjectsOfType(typeof(GameObject)))
        {
            if (!obj.activeInHierarchy) return -1;
            for (int i = 0; i < targets.Length; i++)
            {
                if (obj.name == targets[i].name) num++;
            }
        }
        return num;
    }

    private IEnumerator ClearButton()
    {
        while (true)
        {
            clearNum = ClearNum(targetObj);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
