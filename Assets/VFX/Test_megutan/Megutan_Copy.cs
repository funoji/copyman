using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Megutan_Copy : MonoBehaviour
{
    [SerializeField] Collider AreaCollider;
    [SerializeField] GameObject Area;
    [SerializeField] GameObject Point;
    GameObject PasteObj;
    Megutan_CopyColl CopyColl;
    private void Start()
    {
        AreaCollider.enabled = false;
        Area.SetActive(false);
    }
    public void Active_Area()
    {
        AreaCollider.enabled = true;
        Area.SetActive(true);
    }

    public void DisActive_Area()
    {
        AreaCollider.enabled = false;
        Area.SetActive(false);
    }

    public void Paseting()
    {
        PasteObj = Instantiate(Megutan_CopyColl.Obj, Point.transform.position, Quaternion.identity);
    }
}
