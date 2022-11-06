using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Initia_SetActiv : MonoBehaviour
{
    public void Awake()
    {
        GameDirector.GameClear = false;
        GameDirector.GameOver = false;
    }
}
