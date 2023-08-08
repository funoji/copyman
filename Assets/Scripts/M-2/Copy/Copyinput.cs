using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Copyinput : MonoBehaviour
{
    public Copy Copy;
    bool cooltime;[SerializeField] 
    bool isActive = true;
    public bool IsActive
    {
        get => isActive;
        set => isActive = value;
    }

    float lapseTime;
    [SerializeField] float PasteCoolTime;
    [SerializeField] Playeranimationcontroller PlayerAnim;
    [SerializeField] [Tooltip("Debug_Camera_Animator Reference")] Animator animator;
    int count;
    // Start is called before the first frame update
    void Start()
    {
        cooltime = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isActive) return;
        
        if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.Joystick1Button2))
        {
            AudioManager.Instance.PlaySE(SESoundData.SE.copy);
            Copy.Active_Area();
            animator.SetBool("isCopy", true);
            CopyColl.count = 0;
        }else animator.SetBool("isCopy", false);
        if (Input.GetKeyUp(KeyCode.Q) || Input.GetKeyUp(KeyCode.Joystick1Button2))
        {
            Copy.DisActive_Area();
        }
        if (Input.GetKeyUp(KeyCode.E) || Input.GetKeyUp(KeyCode.Joystick1Button1) && cooltime)
        {
            //AudioManager.Instance.PlaySE(SESoundData.SE.paste);
            Copy.Paseting();
            PlayerAnim.PlessedPasteButton();
            animator.Play("Paste", 0, 0);
            cooltime = false;
        }

        if (!cooltime)
        {
            lapseTime += Time.deltaTime;
        }

        if (lapseTime >= PasteCoolTime)
        {
            cooltime = true;
            lapseTime = 0.0f;
        }
        //if (lapseTime > 0)
            //Debug.Log(lapseTime);

        if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Joystick1Button3))
        {
            count++;
            //Copy.ShotArkDrow(count);
        }

        if(Input.GetKeyUp(KeyCode.R) || Input.GetKeyUp(KeyCode.Joystick1Button3))
        {
            //AudioManager.Instance.PlaySE(SESoundData.SE.shotpaste);
            Copy.Shot();
            animator.Play("ShotPaste", 0, 0);
        }
    }
}
