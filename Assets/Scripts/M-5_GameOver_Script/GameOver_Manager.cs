using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//�e�L�X�g�����Ԍo�߂Ŋg�債�Ȃ���\������
public class GameOver_Manager : MonoBehaviour
{
    [Header("Size Change Setting")]
    public float changeTime;  //�g�傷�鎞��
    public float waitTime;  //�\������܂ł̑ҋ@����

    //Text
    [System.Serializable]
    public struct TextObj
    {
        public TextMeshProUGUI text;  //Text�p�ϐ�
        [HideInInspector]
        public float _textSize;  //Text�̕ۑ��p�ϐ�
        [HideInInspector]
        public bool onFade;  //Text�̔���p�ϐ�
    }
    [Space(5)]
    public TextObj[] textObj;

    //AudioSource�̎Q��
    public AudioSource audioSource;

    private void Start()
    {
        //���ʂ��O�ɏ�����
        audioSource.volume = 0;

        for (int num = 0; num < textObj.Length; num++)
        {
            textObj[num]._textSize = textObj[num].text.fontSize;  //���̃e�L�X�g�T�C�Y��ۑ�
            textObj[num].text.GetComponent<TextMeshProUGUI>().fontSize = 0;  //�t�H���g�T�C�Y���O�ɏ�����
        }

        //������҂�
        StartCoroutine(WaitTime());
    }

    //�\������܂ł̑ҋ@����
    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(waitTime);

        for (int num = 0; num < textObj.Length; num++) { textObj[num].onFade = true; }
    }

    private void Update()
    {
        //Text��\�����邩����
        for (int num = 0; num < textObj.Length; num++)
        {
            if (textObj[num].onFade) { Change_TextSize(num); }
        }
    }

    //Text�̃T�C�Y�ύX
    void Change_TextSize(int Num)
    {
        //Text�̃T�C�Y�ɉ��Z
        textObj[Num].text.fontSize += Time.deltaTime * changeTime;
        if (textObj[Num]._textSize <= textObj[Num].text.fontSize)
        {
            textObj[Num].text.fontSize = textObj[Num]._textSize;
            textObj[Num].onFade = false;
        }
    }
}
