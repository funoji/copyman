using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Transtion : MonoBehaviour
{
    [SerializeField, Header("Fade Feature")]
    public Fade_Manager fadeFeature;

    public float fadetime;
    public float transTime;

    public void Trasn_ToTitle() 
    {
        StartCoroutine(Do_FadeOut());
        Invoke("Trans_Title", transTime);
    }

    private void Trans_Title() { SceneManager.LoadScene("S-01_Title_Scene"); }

    public void Trans_ToGameEnd()
    {
        StartCoroutine(Do_FadeOut());
        Invoke("Trans_GameEnd", transTime);
    }
    private void Trans_GameEnd() { Application.Quit(); }

    public void Trans_ToMenu() 
    {
        StartCoroutine(Do_FadeOut());
        Invoke("Trans_Menu", transTime);
    }
    private void Trans_Menu() { SceneManager.LoadScene("S-02_Menu_Scene"); }

    public void Trans_ToOption() 
    {
        StartCoroutine(Do_FadeOut());
        Invoke("Trans_Option", transTime);
    }
    private void Trans_Option() { SceneManager.LoadScene("S-03_Option_Scene"); }

    public void Trans_ToCatalog()
    {
        StartCoroutine(Do_FadeOut());
        Invoke("Trans_Catalog", transTime);
    }
    private void Trans_Catalog() { SceneManager.LoadScene("Item_Dictionary");}

    public void Trans_ToSelect()
    {
        StartCoroutine(Do_FadeOut());
        Invoke("Trans_Select", transTime);
    }
    private void Trans_Select() { SceneManager.LoadScene("S_04_Stage_Select"); }

    public void Trans_ToTutorial()
    {
        StartCoroutine(Do_FadeOut());
        Invoke("Trans_Tutorial", transTime);
    }
    private void Trans_Tutorial() { SceneManager.LoadScene("Tutorial"); }

    public void Trans_ToStage1()
    {
        Debug.Log("Click Trans_ToStage1()");
        StartCoroutine(Do_FadeOut());
        Invoke("Trans_Stage1", transTime);
    }
    private void Trans_Stage1() { Debug.Log("Trans_Stage1()"); SceneManager.LoadScene("Stage1"); }

    public void Trans_ToStage2()
    {
        StartCoroutine(Do_FadeOut());
        Invoke("Trans_Stage2", transTime);
    }
    private void Trans_Stage2() { SceneManager.LoadScene("Stage2"); }

    public void Trans_ToStage3() 
    {
        StartCoroutine(Do_FadeOut());
        Invoke("Trans_Stage3", transTime);
    }
    private void Trans_Stage3() { SceneManager.LoadScene("Stage3"); }

    public void Trans_ToStage4() 
    {
        StartCoroutine(Do_FadeOut());
        Invoke("Trans_Stage4", transTime);
    }
    private void Trans_Stage4() { SceneManager.LoadScene("Stage4"); }

    //public void Trans_ToStage5()
    //{
    //    StartCoroutine(Do_FadeOut());
    //    Invoke("Trans_Stage5", transTime);
    //}
    //private void Trans_Stage5() { SceneManager.LoadScene("Stage5"); }

    //public void Trans_ToStage6() { /*SceneManager.LoadScene("Stage6");*/ }

    //public void Trans_ToStage7() { /*SceneManager.LoadScene("Stage7");*/ }

    //public void Trans_ToStage8() { /*SceneManager.LoadScene("Stage8");*/ }

    //public void Trans_ToStage9() { /*SceneManager.LoadScene("Stage9");*/ }

    //public void Trans_ToStage10() 
    //{
    //    StartCoroutine(Do_FadeOut());
    //    Invoke("Trans_Stage10", transTime);
    //}
    //private void Trans_Stage10() { SceneManager.LoadScene("Stage10"); }

    public void Trans_ToRetry()
    {
        StartCoroutine(Do_FadeOut());
        Invoke("Trans_Retry", transTime);
    }
    private void Trans_Retry() { SceneManager.LoadScene(SceneManager.GetActiveScene().name); }

    IEnumerator Do_FadeOut()
    {
        fadeFeature.fadeSystem[0].fadeOut = true;
        //UIŠÖ˜A‚ÌŒÅ’è‚³‚ê‚Ä‚¢‚é‚à‚Ì‚ğ•\¦
        if (fadeFeature.fadeSystem.Length > 1)
        {
            for (int num = 1; num < fadeFeature.fadeSystem.Length; num++) { fadeFeature.fadeSystem[num].fadeIn = true; }
        }
        if (fadeFeature._soundBool) { fadeFeature.sound_fadeOut = true; }

        Debug.Log("Do_FadeOut()");

        yield return new WaitForSeconds(transTime);
    }
}
