using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Megitan_SoundManager : MonoBehaviour
{
    private static Megitan_SoundManager instance;
    private AudioSource Sound;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Sound = GetComponent<AudioSource>();
    }

    void Update()
    {
        SoundVolume();     
    }

    private void SoundVolume()
    {
        if ((Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.UpArrow)) || (Input.GetKeyDown(KeyCode.Joystick1Button3) && Input.GetKey(KeyCode.Joystick1Button9)))
        {
            Debug.Log("VolumeUp");
            Sound.volume += 0.05f;
        }

        if ((Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.DownArrow)) || (Input.GetKeyDown(KeyCode.Joystick1Button0) && Input.GetKey(KeyCode.Joystick1Button9)))
        {
            Debug.Log("VolumeDown");
            Sound.volume -= 0.05f;
        }
    }
}
