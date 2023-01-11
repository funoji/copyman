using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Scene遷移のスクリプト
public class Transtion : MonoBehaviour
{
    //Fade_Managerの参照
    [SerializeField, Header("Fade Feature")]
    public Fade_Manager fadeFeature;

    //シーン遷移の時間
    public float transTime;

    //タイトルへ移行
    public void Trasn_ToTitle() 
    {
        StartCoroutine(Do_FadeOut());
        Invoke("Trans_Title", transTime);
    }
    private void Trans_Title() { SceneManager.LoadScene("S-01_Title_Scene"); }

    //ゲーム終了へ移行
    public void Trans_ToGameEnd()
    {
        StartCoroutine(Do_FadeOut());
        Invoke("Trans_GameEnd", transTime);
    }
    private void Trans_GameEnd() { Application.Quit(); }

    //メニューへ移行
    public void Trans_ToMenu() 
    {
        StartCoroutine(Do_FadeOut());
        Invoke("Trans_Menu", transTime);
    }
    private void Trans_Menu() { SceneManager.LoadScene("S-02_Menu_Scene"); }

    //オプションへ移行
    public void Trans_ToOption() 
    {
        StartCoroutine(Do_FadeOut());
        Invoke("Trans_Option", transTime);
    }
    private void Trans_Option() { SceneManager.LoadScene("S-03_Option_Scene"); }

    //アイテム図鑑へ移行
    public void Trans_ToCatalog()
    {
        StartCoroutine(Do_FadeOut());
        Invoke("Trans_Catalog", transTime);
    }
    private void Trans_Catalog() { SceneManager.LoadScene("Item_Dictionary");}

    //ステージ選択へ移行
    public void Trans_ToSelect()
    {
        StartCoroutine(Do_FadeOut());
        Invoke("Trans_Select", transTime);
    }
    private void Trans_Select() { SceneManager.LoadScene("S_04_Stage_Select"); }

    //チュートリアルへ移行
    public void Trans_ToTutorial()
    {
        StartCoroutine(Do_FadeOut());
        Invoke("Trans_Tutorial", transTime);
    }
    private void Trans_Tutorial() { SceneManager.LoadScene("Tutorial"); }

    //ステージ１へ移行
    public void Trans_ToStage1()
    {
        Debug.Log("Click Trans_ToStage1()");
        StartCoroutine(Do_FadeOut());
        Invoke("Trans_Stage1", transTime);
    }
    private void Trans_Stage1() { Debug.Log("Trans_Stage1()"); SceneManager.LoadScene("Stage1"); }

    //ステージ２へ移行
    public void Trans_ToStage2()
    {
        StartCoroutine(Do_FadeOut());
        Invoke("Trans_Stage2", transTime);
    }
    private void Trans_Stage2() { SceneManager.LoadScene("Stage2"); }

    //ステージ３へ移行
    public void Trans_ToStage3() 
    {
        StartCoroutine(Do_FadeOut());
        Invoke("Trans_Stage3", transTime);
    }
    private void Trans_Stage3() { SceneManager.LoadScene("Stage3"); }

    //ステージ４へ移行
    public void Trans_ToStage4() 
    {
        StartCoroutine(Do_FadeOut());
        Invoke("Trans_Stage4", transTime);
    }
    private void Trans_Stage4() { SceneManager.LoadScene("Stage4"); }

    //やりなおし
    public void Trans_ToRetry()
    {
        StartCoroutine(Do_FadeOut());
        Invoke("Trans_Retry", transTime);
    }
    private void Trans_Retry() { SceneManager.LoadScene(SceneManager.GetActiveScene().name); }

    //FadeOutの処理
    IEnumerator Do_FadeOut()
    {
        fadeFeature.fadeSystem[0].fadeOut = true;

        //UI関連の固定されているものを表示
        if (fadeFeature.fadeSystem.Length > 1)
        {
            for (int num = 1; num < fadeFeature.fadeSystem.Length; num++) { fadeFeature.fadeSystem[num].fadeIn = true; }
        }
        if (fadeFeature._soundBool) { fadeFeature.sound_fadeOut = true; }

        //Debug.Log("Do_FadeOut()");

        yield return new WaitForSeconds(transTime);  //時間を待つ
    }
}
