using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Scene遷移のスクリプト
public class Transtion : MonoBehaviour
{
    //タイトルへ移行
    public void Trasn_ToTitle()
    {
        SceneManager.LoadScene("S-01_Title_Scene");
    }

    //ゲーム終了へ移行
    public void Trans_ToGameEnd()
    {
        Application.Quit();
    }

    //メニューへ移行
    public void Trans_ToMenu()
    {
        SceneManager.LoadScene("S-02_Menu_Scene");
    }

    //オプションへ移行
    public void Trans_ToOption()
    {
        SceneManager.LoadScene("S-03_Option_Scene");
    }

    //アイテム図鑑へ移行
    public void Trans_ToCatalog()
    {
        SceneManager.LoadScene("Item_Dictionary");
    }

    //ステージ選択へ移行
    public void Trans_ToSelect()
    {
        SceneManager.LoadScene("S_04_Stage_Select");
    }

    //チュートリアルへ移行
    public void Trans_ToTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    //ステージ１へ移行
    public void Trans_ToStage1()
    {
        SceneManager.LoadScene("Stage1");
    }

    //ステージ２へ移行
    public void Trans_ToStage2()
    {
        SceneManager.LoadScene("Stage2");
    }

    //ステージ３へ移行
    public void Trans_ToStage3()
    {
        SceneManager.LoadScene("Stage3");
    }

    //ステージ４へ移行
    public void Trans_ToStage4()
    {
        SceneManager.LoadScene("Stage4");
    }

    //やりなおし
    public void Trans_ToRetry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
