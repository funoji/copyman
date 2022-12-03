using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageBGMManager : MonoBehaviour
{
    [SerializeField] enum StageNo { ONE,TWO,THREE,FOUR }
    [SerializeField] StageNo stageNo = 0;
    // Start is called before the first frame update
    void Start()
    {
        switch (stageNo)
        {
            case StageNo.ONE:
                AudioManager.Instance.PlayBGM(BGMSoundData.BGM.Stage1);
                break;
            case StageNo.TWO:
                AudioManager.Instance.PlayBGM(BGMSoundData.BGM.Stage2);
                break;
            case StageNo.THREE:
                AudioManager.Instance.PlayBGM(BGMSoundData.BGM.Stage3);
                break;
            case StageNo.FOUR:
                AudioManager.Instance.PlayBGM(BGMSoundData.BGM.Stage4);
                break;
        }
    }
}
