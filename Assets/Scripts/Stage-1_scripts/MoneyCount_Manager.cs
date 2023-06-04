//ì¬ÒFƒ„ƒ}ƒUƒL
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyCount_Manager : MonoBehaviour
{
    public TextMeshProUGUI money;
    //public TextMeshProUGUI moneyCount;
    private int count;

    [SerializeField] Money_counter cp;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        //Debug
        if (Input.GetKey(KeyCode.Space)) { count += 1; }
        moneyCount.text = "" + count;
        money.text = "count%100 : " + (count % 100) + "–œ‰~"+"    count/100 : "+(count/100)+"–œ‰~";
        */
        count = cp.metaobject - 22;

        //9900–œ‰~ˆÈ‰º‚Ì‚Íç–œ’PˆÊ‚Å•\¦Bcount‚ª99
        //9900‰­ˆÈ‰º‚Ì‚Í‰­‚Æç–œ’PˆÊ‚Å•\¦Bcount‚ª999999
        if (count == 0) { money.text = count + "–œ‰~"; }
        else if (count > 0 && count <= 99) { money.text = count + "00–œ‰~"; }
        else if (count > 99 && count <= 999999) { money.text = (count / 100) + "‰­" + (count % 100) + "00–œ‰~"; }
    }
}
