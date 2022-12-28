using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemShot : MonoBehaviour
{
    [SerializeField] ObjectManager copyManager;
    [SerializeField] Transform spawnPoint;
    [SerializeField] private Vector3 minPower;
    [SerializeField] private Vector3 maxPower;
    [SerializeField] private Vector3 minTorque;
    [SerializeField] private Vector3 maxTorque;
    [SerializeField] private float spawnCoolTime;
    private int itemNum;

    // Start is called before the first frame update
    void Start()
    {
        itemNum = Random.Range(0, copyManager._CanCopyObj.Length);
        StartCoroutine(SpawnItem());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnItem()
    {
        while(true)
        {
            Vector3 shotPower = (new Vector3(Random.Range(minPower.x, maxPower.x),
                                          Random.Range(minPower.y, maxPower.y),
                                          Random.Range(minPower.z, maxPower.z)));
            Vector3 torquePower = (new Vector3(Random.Range(minPower.x, maxPower.x),
                                          Random.Range(minPower.y, maxPower.y),
                                          Random.Range(minPower.z, maxPower.z)));

            GameObject item = Instantiate(copyManager._CanCopyObj[itemNum].Object);
            Rigidbody rb = item.GetComponent<Rigidbody>();

            item.transform.position = spawnPoint.position;
            item.name = copyManager._CanCopyObj[itemNum].name;
            rb.AddForce(shotPower, ForceMode.Acceleration);
            rb.AddTorque(torquePower, ForceMode.Acceleration);

            itemNum = Random.Range(0, copyManager._CanCopyObj.Length);

            yield return new WaitForSeconds(spawnCoolTime);
        }
    }

}
