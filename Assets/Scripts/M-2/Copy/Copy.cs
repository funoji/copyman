using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Copy : MonoBehaviour
{
    [SerializeField] Collider AreaCollider;
    [SerializeField] GameObject Area;
    [SerializeField] GameObject Point;
    [SerializeField] GameObject muzzele;
    [SerializeField] float Y, Z;
    [SerializeField] float rot;
    [SerializeField] float speed;
    [SerializeField] GameObject moneycount;
    [SerializeField] GameObject countObject;
    GameObject PasteObj;

    [SerializeField] CopyColl CopyColl;
    Vector3 rotvec;
    public GameObject preLineRenderer;

    [SerializeField] AudioSource ObjectSEAudioSorce;  //‰½‚©‚ ‚ê‚Î•Ûˆä‚Ü‚Å

    private void Start()
    {
        AreaCollider.enabled = false;
        Area.SetActive(false);
        rotvec = new Vector3 ( 0f, Mathf.Cos(rot * Mathf.Deg2Rad), Mathf.Sin(rot * Mathf.Deg2Rad));
       // TryGetComponent(out animator);
        //objLineRenderer = Instantiate(preLineRenderer, gameObject.transform);
        //objLineRenderer.transform.localPosition = Vector3.zero;
        //lineRenderer = objLineRenderer.GetComponent<LineRenderer>();


    }
    public void Active_Area()
    {
        AreaCollider.enabled = true;
        Area.SetActive(true);
    }

    public void DisActive_Area()
    {
        AreaCollider.enabled = false;
        Area.SetActive(false);
    }

    public void Paseting()
    {
        PasteObj = Instantiate(CopyColl.Obj, Point.transform.position, transform.rotation);
        PasteObj.name = CopyColl.Obj.name;
        // animator.SetBool("isPaste", true);  
        if (CopyColl.Obj.name == countObject.name)
        {
            moneycount.GetComponent<Money_counter>().metaobject++;
            Debug.Log(moneycount.GetComponent<Money_counter>().metaobject);
        }
        ObjectSEAudioSorce.PlayOneShot(CopyColl.audio);
    }

    public void Shot()
    { 
        PasteObj = Instantiate(CopyColl.Obj, muzzele.transform.position,transform.rotation);
        PasteObj.name = CopyColl.Obj.name;
        Rigidbody m_rigidbody = PasteObj.GetComponent<Rigidbody>();
        Vector3 v = muzzele.transform.TransformDirection(new Vector3(0, Y, Z));
        m_rigidbody.AddForce(rotvec + v * speed, ForceMode.Impulse);
        if (CopyColl.Obj.name == countObject.name)
        {
            moneycount.GetComponent<Money_counter>().metaobject++;
            Debug.Log(moneycount.GetComponent<Money_counter>().metaobject);
        }
        ObjectSEAudioSorce.PlayOneShot(CopyColl.audio);
    }
}
