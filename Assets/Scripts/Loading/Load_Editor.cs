using UnityEngine;
using UnityEngine.Video;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;

//Load�p�J�X�^��Editor
[CustomEditor(typeof(Load_Manager))]
public class Load_Editor : Editor
{
    public override void OnInspectorGUI()
    {
        Load_Manager loading = target as Load_Manager;  //Load_Manager�N���X�̃C���X�^���X���擾

        serializedObject.Update(); //serializedObject���ŐV�ɕύX

        var imageObj = serializedObject.FindProperty("fixationImage");  //Load_Manager�N���X�̔z�� fixationImage ���擾
        var loadObj = serializedObject.FindProperty("audioSource");  //Load_Manager�N���X�̔z�� audioSource ���擾

        EditorGUI.BeginChangeCheck();

        //Load 
        EditorGUILayout.LabelField("Load Setting", EditorStyles.boldLabel);  //���x����\��

        loading.loadImage = (GameObject)EditorGUILayout.ObjectField("�@Load Image ", loading.loadImage, typeof(GameObject), true);  //Object�p�̃t�B�[���h��\��
        loading.loadVideo = (VideoPlayer)EditorGUILayout.ObjectField("�@Load Video ", loading.loadVideo, typeof(VideoPlayer), true);  //Object�p�̃t�B�[���h��\��
        loading.loadTime = EditorGUILayout.FloatField("�@Load Time ", loading.loadTime);  //Float�^�̃t�B�[���h��\��

        EditorGUILayout.HelpBox("���[�h��ʂ̍Đ�����\n1000�c��U�b�@500�c��Q�b", MessageType.None);  //���ӏ�����\��

        EditorGUILayout.PropertyField(imageObj);  //fixationImage�p�̃t�B�[���h��\��

        loading._textObj = EditorGUILayout.Toggle("Use Text Object ", loading._textObj);  //Toggle��\��
        if (loading._textObj) { loading.fixationText = (TextMeshProUGUI)EditorGUILayout.ObjectField("  Text Object ", loading.fixationText, typeof(TextMeshProUGUI), true); }  //Object�p�̃t�B�[���h��\��

        EditorGUILayout.Space();  //�X�y�[�X���m��

        //Fade
        EditorGUILayout.LabelField("Fade Setting", EditorStyles.boldLabel);  //���x����\��

        loading.fadeScript = (Fade_Manager)EditorGUILayout.ObjectField("�@Fade Script ", loading.fadeScript, typeof(Fade_Manager), true);  //Object�p�̃t�B�[���h��\��

        EditorGUILayout.Space();  //�X�y�[�X���m��

        //AudioSource
        EditorGUILayout.LabelField("Audio Source", EditorStyles.boldLabel);  //���x����\��

        EditorGUILayout.PropertyField(loadObj);  //AudioSource�p�̃t�B�[���h��\��

        serializedObject.ApplyModifiedProperties(); //serializedObject�ւ̕ύX��K�p
        EditorUtility.SetDirty(loading);
    }
}
#endif