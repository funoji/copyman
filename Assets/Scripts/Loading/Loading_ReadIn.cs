using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Loading_ReadIn : MonoBehaviour
{
    [SerializeField] S_1_Fadeout_Script fadeScript;
    [SerializeField] S_1_SoundPlayer soundScript;
    //　シーンロード中に表示するUI画面
    [SerializeField] private GameObject loadImage;
    [SerializeField] VideoPlayer loadVideo;
    private float loadTime;
    public bool loading ;

    private void Start()
    {
        loading = false;
        loadVideo = GetComponent<VideoPlayer>();
        loadImage.SetActive(true);
        loadVideo.Play();
    }

    private void Update()
    {
        Video_Player();
    }

    public bool Video_Player()
    {
        loadTime += Time.deltaTime;
        //Debug.Log(loadTime);
        if (loadTime > 10f)
        {
            loadVideo.Stop();
            loadImage.SetActive(false);
            return true;
        }
        return false;
    }
}
