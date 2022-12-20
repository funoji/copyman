using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowMissionScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Mission;
    UI ui;

    void Start()
    {
        ui = GameObject.Find("UI").GetComponent<UI>();
        Mission.text = ui.MissionStr;
    }
}
