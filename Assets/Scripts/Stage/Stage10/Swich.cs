using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swich : MonoBehaviour
{
    [SerializeField]MoveGimmick gimmick;
    [SerializeField] AudioClip se;

    Stage3_CrearFlag count;

    private bool firstPushFlag;

    private void Start()
    {
        firstPushFlag = false;
        count = GameObject.Find("Stage3Manger").GetComponent<Stage3_CrearFlag>();
        if (count == null) count = new Stage3_CrearFlag();
        if (gimmick == null) gimmick = new MoveGimmick();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Cancopy" && other.tag !="Player") return;
        AudioSource.PlayClipAtPoint(se, transform.position);
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
