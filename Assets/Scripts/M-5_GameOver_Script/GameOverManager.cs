using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    [Header("Size Change Setting")]
    public float changeTime;
    public float waitTime;

    [System.Serializable]
    public struct TextObj
    {
        public TextMeshProUGUI text;
        [HideInInspector]
        public float _textSize;
        [HideInInspector]
        public bool onFade;
    }
    [Space(5)]
    public TextObj[] textObj;

    private void Start()
    {
        for (int num = 0; num < textObj.Length; num++)
        {
            textObj[num]._textSize = textObj[num].text.fontSize;
            Debug.Log("_textSize[" + num + "] : " + textObj[num]._textSize);
            textObj[num].text.GetComponent<TextMeshProUGUI>().fontSize = 0;
            Debug.Log("textObj[" + num + "] : " + textObj[num].text.fontSize);
        }
        StartCoroutine(WaitTime());
    }

    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(waitTime);

        for (int num = 0; num < textObj.Length; num++)
        {
            textObj[num].onFade = true;
        }
    }

    private void Update()
    {
        for (int num = 0; num < textObj.Length; num++)
        {
            if (textObj[num].onFade)
            {
                Debug.Log(textObj[num].onFade);
                Change_TextSize(num); 
            }

        }
    }

    void Change_TextSize(int Num)
    {
        textObj[Num].text.fontSize += Time.deltaTime * changeTime;
        Debug.Log("textObj[" + Num + "] : " + textObj[Num].text.fontSize);
        if (textObj[Num]._textSize <= textObj[Num].text.fontSize)
        {
            textObj[Num].text.fontSize = textObj[Num]._textSize;
            textObj[Num].onFade = false;
        }
    }
}
