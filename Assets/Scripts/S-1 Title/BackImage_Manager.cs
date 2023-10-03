using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackImage_Manager : MonoBehaviour
{
    // 背景画像を表示するためにオブジェクトととして取得
    [SerializeField] private GameObject[] _image = new GameObject[5];

    // 画像が切り替わる時間を保存する変数
    [SerializeField, Range(0, 10)] private int _imageTime = 0;

    // コルーチンを複数呼び出さないための変数
    private bool _isCortine;

    // Start is called before the first frame update
    void Start()
    {
        // 初期化
        for (int i = 0; i < _image.Length; i++)
        {
            _image[i].SetActive(false);
        }

        _isCortine = false;
    }

    // Update is called once per frame
    void Update()
    {
        // コルーチンを呼び出すための処理
        if (!_isCortine)
        {
            _isCortine = true;
            StartCoroutine("Display_Image");
        }
    }

    // 背景画像の演出のコルーチン
    IEnumerator Display_Image()
    {
        for (int i = 0; i < _image.Length; i++)
        {
            // 画像を表示
            _image[i].SetActive(true);

            // 処理を待つ
            yield return new WaitForSeconds(_imageTime);

            // 画像を非表示にする
            _image[i].SetActive(false);
        }

        // 判定を無効にする
        _isCortine = false;
    }
}
