using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Megutan_Gameover : MonoBehaviour
{
    [SerializeField] [Tooltip("ƒ{ƒ^ƒ“‚Ì•\Ž¦")] GameObject gameover;
    private bool retryFlag;
    // Start is called before the first frame update
    public void Awake()
    {
        retryFlag = false;
        gameover.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (GameDirector.GameOver == true)
        {
            gameover.SetActive(true);
            retryFlag = true;
        }
        if(retryFlag)
        {
            if(Input.GetKey(KeyCode.Joystick1Button0))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

    }
}
