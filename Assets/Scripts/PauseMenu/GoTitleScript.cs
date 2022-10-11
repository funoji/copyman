using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoTitleScript : MonoBehaviour
{
    public void OnClick()
    {
        StartCoroutine("Test");
    }

    private IEnumerator Test()
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("S-02_Menu_Scene");
    }
}
