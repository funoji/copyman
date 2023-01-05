using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   static bool Gameclear = false;
    [SerializeField] GameObject bom;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Gameclear)
        {
            bom.SetActive(false);
        }
    }
}
