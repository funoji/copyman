using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animator_Controller : MonoBehaviour
{
    [Header("�A�j���[�V�����̐ݒ�")]
    [SerializeField][Tooltip("Debug_Camera_Animator���Q��")]Animator animator;
    [SerializeField][Tooltip("PlayerController���Q��")] PlayerController moveController;

    private void Start()
    {
        //�R���|�[�l���g�֘A�t��
        TryGetComponent(out animator);
    }

    // Update is called once per frame
    void Update()
    {
        //�ړ����̃��[�V�����̏���
        if (moveController.horizontal > 0.2f || moveController.vertical > 0.2f || moveController.horizontal < -0.2f || moveController.vertical < -0.2f) animator.SetBool("isRun", true);
        else animator.SetBool("isRun", false);
    }
}
