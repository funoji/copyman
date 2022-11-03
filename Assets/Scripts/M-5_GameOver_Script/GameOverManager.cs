using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverManager : MonoBehaviour
{
	//[SerializeField] GameObject panel;
	float fadeSpeed = 0.005f;        //透明度が変わるスピードを管理
	float red, green, blue, alfa;   //パネルの色、不透明度を管理

	public bool isFadeOut = false;  //フェードアウト処理の開始、完了を管理するフラグ

	Image fadeImage;                //透明度を変更するパネルのイメージ

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
		fadeImage.enabled = true;  // a)パネルの表示をオンにする
		alfa += fadeSpeed;         // b)不透明度を徐々にあげる
		SetAlpha();               // c)変更した透明度をパネルに反映する
		if (alfa >= 1)
		{             // d)完全に不透明になったら処理を抜ける
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
				causeText.text = "ケース１";
				break;
			case Cause.cause2:
				causeText.text = "ケース２";
				break;
			default:
				causeText.text = "原因をココに表示";
				break;
		}
    }
}
