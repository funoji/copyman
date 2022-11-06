using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public class S_1_FadeSelect_Script : MonoBehaviour
{
    //[SerializeField] public GameObject fade;
    public GameObject fadeCanvas;

    // Start is called before the first frame update
    void Start()
    {
        if (!S_1_Fadeout_Script.fadeInstance)
        {
            Instantiate(fadeCanvas);
        }
        Invoke("Find_FadeObj", 0.02f);
    }

    void Find_FadeObj()
    {
        fadeCanvas = GameObject.FindGameObjectWithTag("Fade");
        fadeCanvas.GetComponent<S_1_Fadeout_Script>().FadeIn();
    }

    public async void Change_Scene(string sceneName)
    {
        fadeCanvas.GetComponent<S_1_Fadeout_Script>().FadeOut();
        await Task.Delay(200);
        SceneManager.LoadScene("S-02_Menu_Scene");
    }
}
