using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swich : MonoBehaviour
{
    [SerializeField]MoveGimmick gimmick;

    private void OnTriggerStay()
    {
        gimmick.ActiveGimmick = true;
    }

    private void OnTriggerExit()
    {
        gimmick.ActiveGimmick = false;
    }
}
