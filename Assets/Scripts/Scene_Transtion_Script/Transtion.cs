using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Scene�J�ڂ̃X�N���v�g
public class Transtion : MonoBehaviour
{
    //Fade_Manager�̎Q��
    [SerializeField, Header("Fade Feature")]
    public Fade_Manager fadeFeature;

    //�V�[���J�ڂ̎���
    public float transTime;

    //�^�C�g���ֈڍs
    public void Trasn_ToTitle() 
    {
        StartCoroutine(Do_FadeOut());
        Invoke("Trans_Title", transTime);
    }
    private void Trans_Title() { SceneManager.LoadScene("S-01_Title_Scene"); }

    //�Q�[���I���ֈڍs
    public void Trans_ToGameEnd()
    {
        StartCoroutine(Do_FadeOut());
        Invoke("Trans_GameEnd", transTime);
    }
    private void Trans_GameEnd() { Application.Quit(); }

    //���j���[�ֈڍs
    public void Trans_ToMenu() 
    {
        StartCoroutine(Do_FadeOut());
        Invoke("Trans_Menu", transTime);
    }
    private void Trans_Menu() { SceneManager.LoadScene("S-02_Menu_Scene"); }

    //�I�v�V�����ֈڍs
    public void Trans_ToOption() 
    {
        StartCoroutine(Do_FadeOut());
        Invoke("Trans_Option", transTime);
    }
    private void Trans_Option() { SceneManager.LoadScene("S-03_Option_Scene"); }

    //�A�C�e���}�ӂֈڍs
    public void Trans_ToCatalog()
    {
        StartCoroutine(Do_FadeOut());
        Invoke("Trans_Catalog", transTime);
    }
    private void Trans_Catalog() { SceneManager.LoadScene("Item_Dictionary");}

    //�X�e�[�W�I���ֈڍs
    public void Trans_ToSelect()
    {
        StartCoroutine(Do_FadeOut());
        Invoke("Trans_Select", transTime);
    }
    private void Trans_Select() { SceneManager.LoadScene("S_04_Stage_Select"); }

    //�`���[�g���A���ֈڍs
    public void Trans_ToTutorial()
    {
        StartCoroutine(Do_FadeOut());
        Invoke("Trans_Tutorial", transTime);
    }
    private void Trans_Tutorial() { SceneManager.LoadScene("Tutorial"); }

    //�X�e�[�W�P�ֈڍs
    public void Trans_ToStage1()
    {
        Debug.Log("Click Trans_ToStage1()");
        StartCoroutine(Do_FadeOut());
        Invoke("Trans_Stage1", transTime);
    }
    private void Trans_Stage1() { Debug.Log("Trans_Stage1()"); SceneManager.LoadScene("Stage1"); }

    //�X�e�[�W�Q�ֈڍs
    public void Trans_ToStage2()
    {
        StartCoroutine(Do_FadeOut());
        Invoke("Trans_Stage2", transTime);
    }
    private void Trans_Stage2() { SceneManager.LoadScene("Stage2"); }

    //�X�e�[�W�R�ֈڍs
    public void Trans_ToStage3() 
    {
        StartCoroutine(Do_FadeOut());
        Invoke("Trans_Stage3", transTime);
    }
    private void Trans_Stage3() { SceneManager.LoadScene("Stage3"); }

    //�X�e�[�W�S�ֈڍs
    public void Trans_ToStage4() 
    {
        StartCoroutine(Do_FadeOut());
        Invoke("Trans_Stage4", transTime);
    }
    private void Trans_Stage4() { SceneManager.LoadScene("Stage4"); }

    //���Ȃ���
    public void Trans_ToRetry()
    {
        StartCoroutine(Do_FadeOut());
        Invoke("Trans_Retry", transTime);
    }
    private void Trans_Retry() { SceneManager.LoadScene(SceneManager.GetActiveScene().name); }

    //FadeOut�̏���
    IEnumerator Do_FadeOut()
    {
        fadeFeature.fadeSystem[0].fadeOut = true;

        //UI�֘A�̌Œ肳��Ă�����̂�\��
        if (fadeFeature.fadeSystem.Length > 1)
        {
            for (int num = 1; num < fadeFeature.fadeSystem.Length; num++) { fadeFeature.fadeSystem[num].fadeIn = true; }
        }
        if (fadeFeature._soundBool) { fadeFeature.sound_fadeOut = true; }

        //Debug.Log("Do_FadeOut()");

        yield return new WaitForSeconds(transTime);  //���Ԃ�҂�
    }
}
