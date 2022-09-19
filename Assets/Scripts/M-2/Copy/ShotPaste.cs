using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ShotPaste : MonoBehaviour
{
    [SerializeField] GameObject Muzzle;
    [SerializeField] private AnimationCurve _animationCurve;
    [SerializeField] private Material _LineMaterial;
    [SerializeField] int Point_of;
    [SerializeField] int Ranges;
    [SerializeField] int height;
    // LineRendererコンポーネントをゲームオブジェクトにアタッチする
    LineRenderer lineRenderer;
    Vector3[] Line_positions;
    private int Range_Count;
    private int Height_Count;
    private int Top;
    public void Start()
    {
        lineRenderer = Muzzle.AddComponent<LineRenderer>();

        Line_positions = new Vector3[]
        {
         Muzzle.transform.position,           // 開始点
        };

        Array.Resize(ref Line_positions, Line_positions.Length + Point_of);

        // 点の数を指定する
        lineRenderer.positionCount = Line_positions.Length;

        //インスペクター上で線を管理
        lineRenderer.widthCurve = _animationCurve;

        lineRenderer.material = _LineMaterial;

        Range_Count =  Ranges / Point_of;
        Height_Count = height / Point_of;
    }

    public void Update()
    {
        Vector3 muzllePos = Muzzle.transform.position;

        Line_positions[0] = muzllePos;
        for (int i = 1; i < Line_positions.Length; i++)
        {
            if (i < Point_of / 2) 
            {
                muzllePos.y  += Height_Count;
                muzllePos.z += Range_Count;
                Top += Height_Count;
            }
            else
            {
                muzllePos.y -= Height_Count;
                muzllePos.z += Range_Count;
            }
            Line_positions[i] = muzllePos;

        }

        // 線を引く場所を指定する
        lineRenderer.SetPositions(Line_positions);

        Debug.Log(muzllePos);

    }
}