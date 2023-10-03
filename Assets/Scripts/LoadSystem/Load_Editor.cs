using UnityEngine;
using UnityEngine.Video;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;

//Load�p�J�X�^��Editor
[CustomEditor(typeof(Load_Manager))]
public class Load_Editor : Editor
{
    // ���Ԃ�ݒ肷��X���C�_�[�̍ŏ��l��ۑ�����ϐ�
    private int timeMin = 0;
    // ���Ԃ�ݒ肷��X���C�_�[�̍ő�l��ݒ肷��ϐ�
    private int timeMax = 1000;

    public override void OnInspectorGUI()
    {
        // Load_Manager�N���X�̃C���X�^���X���擾
        Load_Manager loading = target as Load_Manager;

        // serializedObject���ŐV�ɕύX
        serializedObject.Update();

        EditorGUI.BeginChangeCheck();

        // Load 
        // ���o����ݒ肷��
        EditorGUILayout.LabelField("���[�h�̐ݒ�", EditorStyles.boldLabel);

        // ���[�h��ʂ�\������I�u�W�F�N�g���擾����t�B�[���h��\��
        loading.loadImage = (GameObject)EditorGUILayout.ObjectField("�@Load_Panel ", loading.loadImage, typeof(GameObject), true);
        // ���[�h��ʕ\������VideoClip���擾����t�B�[���h��\��
        loading.loadVideo = (VideoPlayer)EditorGUILayout.ObjectField("�@Loading_RawImage ", loading.loadVideo, typeof(VideoPlayer), true);
        // ���[�h��ʂ�\�����鎞�Ԃ�ݒ肷��X���C�_�[��\��
        loading.loadTime = EditorGUILayout.IntSlider("�@���[�h��ʂ�\�����鎞�� ", loading.loadTime, timeMin, timeMax);

        // ���ӏ�����\��
        EditorGUILayout.HelpBox("���[�h��ʂ̍Đ�����(�Q�l����)\n1000�c��U�b�@500�c��Q�b", MessageType.None);

        //�X�y�[�X���m��
        EditorGUILayout.Space();

        //AudioSource
        // ���o����ݒ肷��
        EditorGUILayout.LabelField("���Ɋւ���ݒ�", EditorStyles.boldLabel);

        // �����Ǘ�����AudioSource���擾����t�B�[���h��\��
        //loading.audioSource = (AudioSource)EditorGUILayout.ObjectField("�@Audio Source ", loading.audioSource, typeof(AudioSource), true);
        loading.audioSource = (GameObject)EditorGUILayout.ObjectField("�@Audio Source ", loading.audioSource, typeof(GameObject), true);

        //�X�y�[�X���m��
        EditorGUILayout.Space();

        //serializedObject�ւ̕ύX��K�p
        serializedObject.ApplyModifiedProperties();
        EditorUtility.SetDirty(loading);
    }
}
#endif