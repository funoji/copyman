using UnityEngine;
using Cinemachine;

public class ClearCameraTurn : MonoBehaviour
{
    private CinemachineBrain _cinema;

    public Transform target; //追跡対象となるキャラクター
    public float rotationSpeed = 5.0f; //カメラの円運動速度
    public float finalDistance = 10.0f; //キャラクターからの最終的なカメラまでの距離

    private bool isRotating = false; //カメラが円運動するかどうかのフラグ
    private float targetAngle = 0.0f; //カメラの目標角度
    private Vector3 initialPosition; //円運動開始時のカメラの位置
    private Quaternion initialRotation; //円運動開始時のカメラの回転

    private void Awake()
    {
        _cinema = GetComponent<CinemachineBrain>();
    }

    void Update()
    {
        if (isRotating)
        {
            _cinema.enabled = false;

            // 次の回転ステップを計算
            float step = rotationSpeed * Time.deltaTime;
            targetAngle += step;

            // カメラの目標位置を計算
            Vector3 finalPosition = target.position - target.forward * finalDistance;
            transform.position = Vector3.Slerp(initialPosition, finalPosition, targetAngle / 180.0f);

            // カメラの目標回転を計算
            Quaternion finalRotation = Quaternion.LookRotation(target.position - transform.position);
            transform.rotation = Quaternion.Slerp(initialRotation, finalRotation, targetAngle / 180.0f);

            // 回転が完了したかどうかをチェック
            if (targetAngle >= 180.0f)
            {
                isRotating = false;
                targetAngle = 0.0f;
                _cinema.enabled = true; //回転が終わったらCinemachineを有効化
            }
        }
    }

    public void StartRotating()
    {
        // 円運動を開始
        isRotating = true;
        initialPosition = transform.position; // 現在のカメラの位置を保存
        initialRotation = transform.rotation; // 現在のカメラの回転を保存
    }
}
