using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClickSE : MonoBehaviour
{
    public void OnClick_B()
    {
        AudioManager.Instance.PlaySE(SESoundData.SE.Buck_ClickButton);
    }
    public void OnClick_A()
    {
        AudioManager.Instance.PlaySE(SESoundData.SE.A_ClickButton);
    }
}
