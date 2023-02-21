using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Itemdictionary : MonoBehaviour
{
    [SerializeField] GameObject CopyM;
     GameObject[] items;
    [SerializeField] GameObject[] Images;
    [SerializeField] int page;
    int WhereIN = 0;
    // Start is called before the first frame update
    void Start()
    {
        WhereIN = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button4) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
           // AudioManager.Instance.PlaySE(SESoundData.Object.A_ClickButton);

            if (WhereIN > 0)WhereIN--;
        }

        if (Input.GetKeyDown(KeyCode.Joystick1Button5) || Input.GetKeyDown(KeyCode.RightArrow))
        {
           // AudioManager.Instance.PlaySE(SESoundData.Object.A_ClickButton);

            if (WhereIN < page)WhereIN++;
        }

        if (WhereIN == 0) Images[0].SetActive(true); else Images[0].SetActive(false);
        if (WhereIN == 1) Images[1].SetActive(true); else Images[1].SetActive(false);
        if (WhereIN == 2) Images[2].SetActive(true); else Images[2].SetActive(false);
        if (WhereIN == 3) Images[3].SetActive(true); else Images[3].SetActive(false);

        if (Input.GetKeyDown(KeyCode.Joystick1Button1) || Input.GetKeyDown(KeyCode.Escape))
        {
            //AudioManager.Instance.PlaySE(SESoundData.Object.A_ClickButton);

            SceneManager.LoadScene("S-02_Menu_Scene");
        }
    }
}
