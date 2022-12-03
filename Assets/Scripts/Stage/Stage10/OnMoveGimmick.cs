using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMoveGimmick : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] MoveGimmick gimmick;

    private void OnTriggerEnter(Collider other)
    {
        gimmick.ActiveGimmick = true;
    }
}
