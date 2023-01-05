using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombGenerator : MonoBehaviour
{
    [SerializeField] GameObject Bomb;
    [SerializeField] Transform SpawnPoint1, SpawnPoint2, SpawnPoint3, SpawnPoint4;
    Rigidbody rb;
    public float Power = 5f;
    public int Margin = 5;
    private enum spawnNo { FrontLeft,FrontRight,BackLeft,BackRight}
    private spawnNo no;
    private int count = 0;
    public GameObject[] boms;

    void Update()
    {
        if (FriendlyGoalJudge.EnemyGoalFlag)
        {
            count++;
        }
        if (count>=Margin)
        {
            GameObject obj = Instantiate(Bomb);
            rb = obj.GetComponent<Rigidbody>();
            no = (spawnNo)Random.Range(0, 4);
            switch (no)
            {
                case spawnNo.FrontLeft:
                    obj.transform.position = new Vector3(
                        SpawnPoint1.position.x,
                        SpawnPoint1.position.y,
                        SpawnPoint1.position.z);
                    rb.AddForce(transform.right * -Power, ForceMode.Impulse);
                    break;

                case spawnNo.FrontRight:
                    obj.transform.position = new Vector3(
                        SpawnPoint2.position.x,
                        SpawnPoint2.position.y,
                        SpawnPoint2.position.z);
                    rb.AddForce(transform.right * Power, ForceMode.Impulse);
                    break;

                case spawnNo.BackLeft:
                    obj.transform.position = new Vector3(
                        SpawnPoint3.position.x,
                        SpawnPoint3.position.y,
                        SpawnPoint3.position.z);
                    rb.AddForce(transform.right * -Power, ForceMode.Impulse);
                    break;

                case spawnNo.BackRight:
                    obj.transform.position = new Vector3(
                        SpawnPoint4.position.x,
                        SpawnPoint4.position.y,
                        SpawnPoint4.position.z);
                    rb.AddForce(transform.right * Power, ForceMode.Impulse);
                    break;
            }
            //rb.AddForce(transform.forward * Power, ForceMode.Impulse);
            count = 0;
        }
        if (GameDirector.GameClear)
        {
            GameObject obj = GameObject.Find("BOMB2(Clone)");
            Destroy(obj);
        }
    }
}
