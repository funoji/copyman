using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvertManagerScript : MonoBehaviour
{
    public static bool HoriInvert = false;
    public static bool VertInvert = false;

    public void HoriInvertIsCheck()
    {
        HoriInvert = !HoriInvert;
    }
    public void VertInvertIsCheck()
    {
        VertInvert = !VertInvert;
    }
}
