using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClear : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "CPM")
        {
            GameDirector.GameClear = true;
        }
    }
}
