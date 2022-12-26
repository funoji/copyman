using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class OnEffect : MonoBehaviour
{
    private bool OnStart = false;
    [SerializeField] VisualEffect eff;
    [SerializeField] AudioClip se;
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
        AudioSource.PlayClipAtPoint(se, transform.position);
        OnStart = false;
    }
}
