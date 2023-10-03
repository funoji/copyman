using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// �e�L�X�g�����Ԍo�߂Ŋg�債�Ȃ���\������
public class GameOver_Manager : MonoBehaviour
{
    [Header("�e�L�X�g�̐ݒ�")]
    // �g�傷�鎞��
    public float changeTime;
    // �\������܂ł̑ҋ@����
    public float waitTime;

    // Text
    [System.Serializable]
    public struct TextObj
    {
        // Text�p�ϐ�
        public TextMeshProUGUI text;
        // Text�̕ۑ��p�ϐ�
        [HideInInspector] public float _textSize;
        // Text�̔���p�ϐ�
        [HideInInspector] public bool onFade;
    }
    [Space(5)]
    public TextObj[] textObj;

    // AudioSource�̎Q��
    [SerializeField]private AudioSource audioSource;

    private void Start()
    {
        if (audioSource.isPlaying)
        {
            // ���ʂ��O�ɏ�����
            audioSource.Stop();
        }

        for (int num = 0; num < textObj.Length; num++)
        {
            // ���̃e�L�X�g�T�C�Y��ۑ�
            textObj[num]._textSize = textObj[num].text.fontSize;
            // �t�H���g�T�C�Y���O�ɏ�����
            textObj[num].text.GetComponent<TextMeshProUGUI>().fontSize = 0;
        }

        // ������҂�
        StartCoroutine(WaitTime());
    }

    // �\������܂ł̑ҋ@����
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
        //Text��\�����邩����
        for (int num = 0; num < textObj.Length; num++)
        {
            if (textObj[num].onFade)
            {
                Change_TextSize(num);
            }
        }
    }

    // Text�̃T�C�Y�ύX
    void Change_TextSize(int Num)
    {
        //Text�̃T�C�Y�ɉ��Z
        textObj[Num].text.fontSize += Time.deltaTime * changeTime;

        if (textObj[Num]._textSize <= textObj[Num].text.fontSize)
        {
            // text���傫���Ȃ�����傫�����Œ�ɂ���
            textObj[Num].text.fontSize = textObj[Num]._textSize;

            // �t�F�[�h�A�E�g�̔���𖳌��ɂ���
            textObj[Num].onFade = false;
        }
    }
}
