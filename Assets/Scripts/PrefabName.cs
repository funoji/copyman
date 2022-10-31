using UnityEngine;
using System.Collections;

public class PrefabName : MonoBehaviour
{

    public GameObject target1;

    void Start()
    {
        GameObject newTarget1 = (GameObject)Instantiate(target1);
        newTarget1.name = target1.name;
    }
}