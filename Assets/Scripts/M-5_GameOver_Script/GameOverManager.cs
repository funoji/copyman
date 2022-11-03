using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverManager : MonoBehaviour
{
	//[SerializeField] GameObject panel;
	float fadeSpeed = 0.005f;        //�����x���ς��X�s�[�h���Ǘ�
	float red, green, blue, alfa;   //�p�l���̐F�A�s�����x���Ǘ�

	public bool isFadeOut = false;  //�t�F�[�h�A�E�g�����̊J�n�A�������Ǘ�����t���O

	Image fadeImage;                //�����x��ύX����p�l���̃C���[�W

	private Cause causeFlag;

	[SerializeField] GameObject continueButton;
	[SerializeField] GameObject endButton;
	[SerializeField] TextMeshProUGUI gameoverText;
	[SerializeField] private TextMeshProUGUI causeText;
	[SerializeField] GameObject Icon;

	public enum Cause
    {
		none,
		cause1,
		cause2,
    }

    void Start()
	{
		fadeImage = GetComponent<Image>();
		red = fadeImage.color.r;
		green = fadeImage.color.g;
		blue = fadeImage.color.b;
		alfa = fadeImage.color.a;
		causeFlag = Cause.none;

		continueButton.SetActive(false);
		endButton.SetActive(false);
		gameoverText.enabled = false;
		causeText.enabled = false;
		Icon.SetActive(false);
	}

	void Update()
	{
		if (isFadeOut)
		{
			StartFadeOut();
		}
		SetCauseText();
	}

	void StartFadeOut()
	{
		fadeImage.enabled = true;  // a)�p�l���̕\�����I���ɂ���
		alfa += fadeSpeed;         // b)�s�����x�����X�ɂ�����
		SetAlpha();               // c)�ύX���������x���p�l���ɔ��f����
		if (alfa >= 1)
		{             // d)���S�ɕs�����ɂȂ����珈���𔲂���
			continueButton.SetActive(true);
			endButton.SetActive(true);
			gameoverText.enabled = true;
			causeText.enabled = true;
			Icon.SetActive(true);


			isFadeOut = false;
		}
	}

	void SetAlpha()
	{
		fadeImage.color = new Color(red, green, blue, alfa);
	}

	void SetCauseText()
    {
        switch (causeFlag)
        {
			case Cause.cause1:
				causeText.text = "�P�[�X�P";
				break;
			case Cause.cause2:
				causeText.text = "�P�[�X�Q";
				break;
			default:
				causeText.text = "�������R�R�ɕ\��";
				break;
		}
    }
}
