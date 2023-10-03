using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR 
using UnityEditor;

// GameMove_Manager��Inspector���J�X�^������
[CustomEditor(typeof(GameMove_Manager))]
public class GameMove_Editor : Editor
{
    // �z��̒������ꎞ�I�ɕۑ����邽�߂̕ϐ�
    private int arraysize = 0;

    public override void OnInspectorGUI()
    {
        // serializedObject���ŐV�ɕύX
        serializedObject.Update();

        // GameMove_Manager�N���X�̃C���X�^���X���擾
        GameMove_Manager gamemove = target as GameMove_Manager;

        EditorGUI.BeginChangeCheck();

        // S_3_Select�N���X�̔z�� SelectData���擾
        var moveobj = serializedObject.FindProperty("_bomMove");

        // ���o����ݒ肷��
        EditorGUILayout.LabelField("������~�߂�I�u�W�F�N�g�̐ݒ�", EditorStyles.boldLabel);

        // CameraSystem�̃I�u�W�F�N�g���擾����t�B�[���h��\��
        gamemove._cameraMove = (GameObject)EditorGUILayout.ObjectField("CameraSystem", gamemove._cameraMove, typeof(GameObject), true);
        // Player�̃I�u�W�F�N�g���擾����t�B�[���h��\��
        gamemove._playerMove = (GameObject)EditorGUILayout.ObjectField("Player", gamemove._playerMove, typeof(GameObject), true);
        // CPM�̃I�u�W�F�N�g���擾����t�B�[���h��\��
        gamemove._copyMove = (GameObject)EditorGUILayout.ObjectField("Player�̒���CPM", gamemove._copyMove, typeof(GameObject), true);
        // GameManager�̃I�u�W�F�N�g���擾����t�B�[���h��\��
        gamemove._gamemanagerMove = (GameObject)EditorGUILayout.ObjectField("GameManager", gamemove._gamemanagerMove, typeof(GameObject), true);

        //serializedObject�ւ̕ύX��K�p
        serializedObject.ApplyModifiedProperties();
        EditorUtility.SetDirty(gamemove);
    }
}
#endif

public class GameMove_Manager : MonoBehaviour
{
    // �J�����̑�����~�߂邽�߂ɁuCameraSystem�v���擾����
    public GameObject _cameraMove;

    // �v���C���[�̓���Ƒ�����~�߂邽�߂ɁuPlayer�v���擾����
    public GameObject _playerMove;

    // �v���C���[�̃R�s�[�y�[�X�g�̑�����~�߂邽�߂ɁuPlayer�v�́uCPM�v���擾����
    public GameObject _copyMove;

    // �|�[�Y��ʂ̓�����~�߂邽�߂ɁuGameManager�v���擾����
    public GameObject _gamemanagerMove;

    private void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // �Q�[���I�[�o�[�������̓Q�[���N���A�̔��肪�L���ɂȂ����ꍇ
        if (GameDirector.GameClear || GameDirector.GameOver)
        {
            // ������~�߂�֐����Ăяo��
            Move_Function();
        }
    }

    // ������~�߂鏈���̊֐�
    private void Move_Function()
    {
        // �J�����̃I�u�W�F�N�g�𖳌��ɂ���
        _cameraMove.SetActive(false);

        // �v���C���[�̈ړ����~�߂邽�߂ɁuPlayerController�v�𖳌��ɂ���
        _playerMove.GetComponent<PlayerController>().enabled = false;
        // �v���C���[�̃A�j���[�V�������~�߂邽�߂ɁuAnimator_Controller�v�𖳌��ɂ���
        _playerMove.GetComponent<Animator_Controller>().enabled = false;

        // �v���C���[�̃R�s�[�y�[�X�g�̓�����~�߂邽�߂ɁuCopyinput�v�𖳌��ɂ���
        _copyMove.GetComponent<Copyinput>().enabled = false;

        // �|�[�Y��ʂ��N�����Ȃ��悤�ɁuCanvasActiveScript�v�𖳌��ɂ���
        _gamemanagerMove.GetComponent<CanvasActiveScript>().enabled = false;
    }
}