using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartToGimmick : MonoBehaviour
{
    private bool firstflag = true;
    // Start is called before the first frame update
    [SerializeField] OpenGimmick gimmick;
    private void OnTriggerEnter(Collider other)
    {
        if (!firstflag) return;
        if (other.gameObject.CompareTag("Cancopy") || other.gameObject.name == "CPM")
        {
            AudioManager.Instance.PlaySE(SESoundData.SE.button);
            gimmick.ActiveGimmick = true;
            gimmick.ActiveSeflag = true;
            firstflag = false;
        }
    }

}
