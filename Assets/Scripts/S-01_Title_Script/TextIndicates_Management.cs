using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//文字の点滅する処理
public class TextIndicates_Management : MonoBehaviour
{
    public TitleController fadebool; // TitleControllerのスクリプト参照

    private TextMeshProUGUI text;
    private float time;

    [SerializeField] float speed = 1.0f; //点滅をする周期のスピード
    [SerializeField] float Flashspeed;　 //色が変化するスピード
    [SerializeField] float Offspeed;     //消えてる間のスピード

    // Start is called before the first frame update
    void Start()
    {
        text = this.gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (fadebool.fadeout == false)
        {
            //テキストの色を代入
            text.color = Change_Color(text.color);
        }
    }

    //色を変化させる
    Color Change_Color(Color color)
    {
        time += Time.deltaTime * speed * Flashspeed;
        color.a = Mathf.Sin(time) * 5.0f + Offspeed; //Color.aは「alpha値」で透明度を表す

        return color;
    }
}
