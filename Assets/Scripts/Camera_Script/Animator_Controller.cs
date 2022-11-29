using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animator_Controller : MonoBehaviour
{
    [Header("アニメーションの設定")]
    [SerializeField][Tooltip("Debug_Camera_Animatorを参照")]Animator animator;
    [SerializeField][Tooltip("PlayerControllerを参照")] PlayerController moveController;

    private void Start()
    {
        //コンポーネント関連付け
        TryGetComponent(out animator);
    }

    // Update is called once per frame
    void Update()
    {
        //移動中のモーションの処理
        if (moveController.horizontal > 0.2f || moveController.vertical > 0.2f || moveController.horizontal < -0.2f || moveController.vertical < -0.2f) animator.SetBool("isRun", true);
        else animator.SetBool("isRun", false);
    }
}
