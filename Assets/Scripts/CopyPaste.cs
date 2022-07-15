using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyPaste : MonoBehaviour
{
    [SerializeField] Collider AreaCollider;
    [SerializeField] GameObject Area;
    [SerializeField] GameObject Point;
    [SerializeField] int PasteCoolTime;
    GameObject PasteObj;
    GameObject Obj;
    bool cooltime;
    float lapseTime;
    string Name;

    // Start is called before the first frame update
    void Start()
    {
        cooltime = true;
        AreaCollider.enabled = false;
        Area.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            AreaCollider.enabled = true;
            Area.SetActive(true);
        }
        if(Input.GetKeyUp(KeyCode.Q))
        {
            AreaCollider.enabled = false;
            Area.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.E) && cooltime) 
        {
            PasteObj = Instantiate(Obj, Point.transform.position, Quaternion.identity);
            cooltime = false;
        }

        if (!cooltime)
        {
            lapseTime += Time.deltaTime;
        }

        if(lapseTime >= PasteCoolTime)
        {
            cooltime = true;
            lapseTime = 0.0f;
        }

        Debug.Log(lapseTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cancopy"))
        {
            Debug.Log("“–‚½‚Á‚½");
            Name = other.gameObject.name;
            Debug.Log(Name);

            Obj =GameObject.Find(Name);
        }
    }
}
