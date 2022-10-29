using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public GameObject ballPrefab;
    public float minPower = 1.0f;
    public float maxPower = 10f;
    private int count;
    public float shotCoolTime;

    private void FixedUpdate()
    {
        count += 1;

        // �i�|�C���g�j
        // �U�O�t���[�����ƂɖC�e�𔭎˂���
        if (count % (60 * shotCoolTime) == 0)
        {
            Vector3 Power = (new Vector3(Random.Range(minPower, maxPower),
                                      0, -Random.Range(minPower, maxPower)));

            GameObject ball = Instantiate(ballPrefab, transform.position, Quaternion.identity);
            Rigidbody shellRb = ball.GetComponent<Rigidbody>();

            // �e���͎��R�ɐݒ�
            shellRb.AddForce(Power, ForceMode.Impulse);

        }
    }
}