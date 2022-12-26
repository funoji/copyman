using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class OnEffect : MonoBehaviour
{
    private bool OnStart = false;
    [SerializeField] VisualEffect eff;

    public bool StartEff
    {
        get => OnStart;
        set => OnStart = value;
    }

    // Update is called once per frame
    void Update()
    {
        if (!OnStart) return;
        eff.SendEvent("OnPlay");
        OnStart = false;
    }
}
