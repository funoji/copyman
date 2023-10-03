using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// テキストを時間経過で拡大しながら表示する
public class GameOver_Manager : MonoBehaviour
{
    [Header("テキストの設定")]
    // 拡大する時間
    public float changeTime;
    // 表示するまでの待機時間
    public float waitTime;

    // Text
    [System.Serializable]
    public struct TextObj
    {
        // Text用変数
        public TextMeshProUGUI text;
        // Textの保存用変数
        [HideInInspector] public float _textSize;
        // Textの判定用変数
        [HideInInspector] public bool onFade;
    }
    [Space(5)]
    public TextObj[] textObj;

    // AudioSourceの参照
    [SerializeField]private AudioSource audioSource;

    private void Start()
    {
        if (audioSource.isPlaying)
        {
            // 音量を０に初期化
            audioSource.Stop();
        }

        for (int num = 0; num < textObj.Length; num++)
        {
            // 元のテキストサイズを保存
            textObj[num]._textSize = textObj[num].text.fontSize;
            // フォントサイズを０に初期化
            textObj[num].text.GetComponent<TextMeshProUGUI>().fontSize = 0;
        }

        // 処理を待つ
        StartCoroutine(WaitTime());
    }

    // 表示するまでの待機処理
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
        //Textを表示するか判定
        for (int num = 0; num < textObj.Length; num++)
        {
            if (textObj[num].onFade)
            {
                Change_TextSize(num);
            }
        }
    }

    // Textのサイズ変更
    void Change_TextSize(int Num)
    {
        //Textのサイズに加算
        textObj[Num].text.fontSize += Time.deltaTime * changeTime;

        if (textObj[Num]._textSize <= textObj[Num].text.fontSize)
        {
            // textが大きくなったら大きさを固定にする
            textObj[Num].text.fontSize = textObj[Num]._textSize;

            // フェードアウトの判定を無効にする
            textObj[Num].onFade = false;
        }
    }
}
