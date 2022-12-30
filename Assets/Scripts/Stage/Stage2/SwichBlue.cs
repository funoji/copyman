using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwichBlue : MonoBehaviour
{
    MoveGimmick gimmick;
    Stage3_CrearFlag count;

    private bool firstPushFlag;

    private void Start()
    {
        firstPushFlag = false;
        count = GameObject.Find("Stage2Manger").GetComponent<Stage3_CrearFlag>();
        gimmick = GameObject.Find("MoveWall").GetComponent<MoveGimmick>();
        if (count == null) count = new Stage3_CrearFlag();
        if (gimmick == null) gimmick = new MoveGimmick();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Cancopy" && other.tag != "Player") return;
        AudioManager.Instance.PlaySE(SESoundData.SE.button);
        if (firstPushFlag) return;
        count.pushButtonNum += 1;
        firstPushFlag = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag != "Cancopy" && other.tag != "Player") return;
        gimmick.ActiveGimmick = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag != "Cancopy" && other.tag != "Player") return;
        gimmick.ActiveGimmick = false;
    }
}
