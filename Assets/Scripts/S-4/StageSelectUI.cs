using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectUI : MonoBehaviour
{
    [SerializeField] GameObject UIWindow;
    [SerializeField] float GameWindou;

    RectTransform rect;
    // Start is called before the first frame update
    void Start()
    {
        rect = UIWindow.GetComponent<RectTransform>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            rect.localPosition += new Vector3(GameWindou, 0, 0);
        }
    }
}
