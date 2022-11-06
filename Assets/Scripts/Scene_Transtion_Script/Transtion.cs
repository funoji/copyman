using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transtion : MonoBehaviour
{
    public void Trans_ToMenu() { SceneManager.LoadScene("S-02_Menu_Scene"); }

    public void Trans_ToGameEnd() { Application.Quit(); }

    public void Trans_ToOption() { SceneManager.LoadScene("S-03_Option_Scene"); }

    public void Trans_ToCatalog() { /*SceneManager.LoadScene(" ");*/ }

    public void Trasn_ToRetuenTitle() { SceneManager.LoadScene("S-01_Title_Scene"); }

    public void Trans_ToStage1() { /*SceneManager.LoadScene("Stage1");*/ }

    public void Trans_ToStage4() { SceneManager.LoadScene("Stage4"); }
    
    public void Trans_ToSelect() { /*SceneManager.LoadScene(" ");*/ }
}
