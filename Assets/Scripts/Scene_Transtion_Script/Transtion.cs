using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transtion : MonoBehaviour
{
    public void Trasn_ToTitle() { SceneManager.LoadScene("S-01_Title_Scene"); }

    public void Trans_ToGameEnd() { Application.Quit(); }

    public void Trans_ToMenu() { SceneManager.LoadScene("S-02_Menu_Scene"); }

    public void Trans_ToOption() { SceneManager.LoadScene("S-03_Option_Scene"); }

    public void Trans_ToCatalog() { /*SceneManager.LoadScene("");*/ }

    public void Trans_ToSelect() { SceneManager.LoadScene("S_04_Stage_Select"); }

    public void Trans_ToTutorial() { SceneManager.LoadScene("Tutorial"); }

    public void Trans_ToStage1() { SceneManager.LoadScene("Stage1"); }

    public void Trans_ToStage2() { SceneManager.LoadScene("Stage2"); }

    public void Trans_ToStage3() { SceneManager.LoadScene("Stage3"); }

    public void Trans_ToStage4() { SceneManager.LoadScene("Stage4"); }

    public void Trans_ToStage5() { SceneManager.LoadScene("Stage5"); }

    public void Trans_ToStage6() { /*SceneManager.LoadScene("Stage6");*/ }

    public void Trans_ToStage7() { /*SceneManager.LoadScene("Stage7");*/ }

    public void Trans_ToStage8() { /*SceneManager.LoadScene("Stage8");*/ }

    public void Trans_ToStage9() { /*SceneManager.LoadScene("Stage9");*/ }

    public void Trans_ToStage10() { SceneManager.LoadScene("Stage10"); }
}
