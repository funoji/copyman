using UnityEngine;
using Cinemachine;

public class ClearCameraTurn : MonoBehaviour
{
    private CinemachineBrain _cinema;

    public Transform target; //�ǐՑΏۂƂȂ�L�����N�^�[
    public float rotationSpeed = 5.0f; //�J�����̉~�^�����x
    public float finalDistance = 10.0f; //�L�����N�^�[����̍ŏI�I�ȃJ�����܂ł̋���

    private bool isRotating = false; //�J�������~�^�����邩�ǂ����̃t���O
    private float targetAngle = 0.0f; //�J�����̖ڕW�p�x
    private Vector3 initialPosition; //�~�^���J�n���̃J�����̈ʒu
    private Quaternion initialRotation; //�~�^���J�n���̃J�����̉�]

    private void Awake()
    {
        _cinema = GetComponent<CinemachineBrain>();
    }

    void Update()
    {
        if (isRotating)
        {
            _cinema.enabled = false;

            // ���̉�]�X�e�b�v���v�Z
            float step = rotationSpeed * Time.deltaTime;
            targetAngle += step;

            // �J�����̖ڕW�ʒu���v�Z
            Vector3 finalPosition = target.position - target.forward * finalDistance;
            transform.position = Vector3.Slerp(initialPosition, finalPosition, targetAngle / 180.0f);

            // �J�����̖ڕW��]���v�Z
            Quaternion finalRotation = Quaternion.LookRotation(target.position - transform.position);
            transform.rotation = Quaternion.Slerp(initialRotation, finalRotation, targetAngle / 180.0f);

            // ��]�������������ǂ������`�F�b�N
            if (targetAngle >= 180.0f)
            {
                isRotating = false;
                targetAngle = 0.0f;
                _cinema.enabled = true; //��]���I�������Cinemachine��L����
            }
        }
    }

    public void StartRotating()
    {
        // �~�^�����J�n
        isRotating = true;
        initialPosition = transform.position; // ���݂̃J�����̈ʒu��ۑ�
        initialRotation = transform.rotation; // ���݂̃J�����̉�]��ۑ�
    }
}
