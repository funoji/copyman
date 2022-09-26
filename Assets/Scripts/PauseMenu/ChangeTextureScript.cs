using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTextureScript : MonoBehaviour
{
    [SerializeField] Sprite DefaultTexture;
    [SerializeField] Sprite ChangeTexture;
    void Start()
    {
        //this.gameObject.GetComponent<Image>().sprite=DefaultTexture;
    }

    private void OnMouseOver()
    {
        this.gameObject.GetComponent<Image>().sprite=ChangeTexture;
    }

    private void OnMouseExit()
    {
        this.gameObject.GetComponent<Image>().sprite=DefaultTexture;
    }
}
