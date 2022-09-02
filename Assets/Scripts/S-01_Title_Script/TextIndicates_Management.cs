using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//�����̓_�ł��鏈��
public class TextIndicates_Management : MonoBehaviour
{
    public TitleController fadebool; // TitleController�̃X�N���v�g�Q��

    private TextMeshProUGUI text;
    private float time;

    [SerializeField] float speed = 1.0f; //�_�ł���������̃X�s�[�h
    [SerializeField] float Flashspeed;�@ //�F���ω�����X�s�[�h
    [SerializeField] float Offspeed;     //�����Ă�Ԃ̃X�s�[�h

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
            //�e�L�X�g�̐F����
            text.color = Change_Color(text.color);
        }
    }

    //�F��ω�������
    Color Change_Color(Color color)
    {
        time += Time.deltaTime * speed * Flashspeed;
        color.a = Mathf.Sin(time) * 5.0f + Offspeed; //Color.a�́ualpha�l�v�œ����x��\��

        return color;
    }
}
