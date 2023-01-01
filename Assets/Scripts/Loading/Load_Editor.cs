using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEditor;
using UnityEngine.Video;

[CustomEditor(typeof(Load_Manager))]
public class Load_Editor : Editor
{
    //private int _imagesize = 0;
    //private int _audiosize = 0; //�z��̒������ꎞ�I�ɕۑ����邽�߂̕ϐ�
    //private bool fold = false; //�܂肽���݋@�\�̂��߂̕ϐ�

    public override void OnInspectorGUI()
    {
        Load_Manager loading = target as Load_Manager;
        serializedObject.Update(); //serializedObject���ŐV�ɕύX
        var imageObj = serializedObject.FindProperty("fixationImage");
        var loadObj = serializedObject.FindProperty("audioSource");
        EditorGUI.BeginChangeCheck();

        //_imagesize = imageObj.arraySize;
        //_audiosize = loadObj.arraySize;

        //Load
        EditorGUILayout.LabelField("Load Setting", EditorStyles.boldLabel);
        loading.loadImage = (GameObject)EditorGUILayout.ObjectField("�@Load Image ", loading.loadImage, typeof(GameObject), true);
        loading.loadVideo = (VideoPlayer)EditorGUILayout.ObjectField("�@Load Video ", loading.loadVideo, typeof(VideoPlayer), true);
        loading.loadTime = EditorGUILayout.FloatField("�@Load Time ", loading.loadTime);
        EditorGUILayout.HelpBox("���[�h��ʂ̍Đ�����\n1000�c��U�b�@500�c��Q�b", MessageType.None);
        EditorGUILayout.PropertyField(imageObj);

        //_imagesize = EditorGUILayout.IntField("Fixation Image ", _imagesize); //�ꎞ�I�ɕۑ������������J�X�^���C���X�^���X�ɕ`��i���������\�j
        ////�ꎞ�I�ɕۑ������z��̒����ƁA�{���̔z��̒������������`�F�b�N����
        //if (_imagesize != imageObj.arraySize)
        //{
        //    imageObj.arraySize = _imagesize; // �����̕ύX��K�p

        //    //������serializedObject�ւ̕ύX��K�p���A�ĂэX�V����
        //    serializedObject.ApplyModifiedProperties();
        //    serializedObject.Update();
        //}
        //else
        //{
        //    //�ꎞ�I�ɕۑ������z��̒����ƁA�{���̔z��̒����������ꍇ�́@�z��̗v�f��`�悷��
        //    for (int num = 0; num < imageObj.arraySize; num++) { loading.fixationImage[num] = (Image)EditorGUILayout.ObjectField("�@ " + num, loading.fixationImage[num], typeof(Image), true); }
        //}

        EditorGUILayout.Space();

        //Fade
        EditorGUILayout.LabelField("Fade Setting", EditorStyles.boldLabel);
        loading.fadeScript = (Fade_Manager)EditorGUILayout.ObjectField("�@Fade Script ", loading.fadeScript, typeof(Fade_Manager), true);
        EditorGUILayout.Space();

        //AudioSource
        EditorGUILayout.LabelField("Audio Source", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(loadObj);

        ////��̗v�f�������тɕ\��������
        //EditorGUILayout.BeginHorizontal();
        //fold = EditorGUILayout.Foldout(fold, "�@AudioSource ");
        //_audiosize = EditorGUILayout.IntField(_audiosize, GUILayout.Width(30)); //�ꎞ�I�ɕۑ������������J�X�^���C���X�^���X�ɕ`��i���������\�j
        //EditorGUILayout.EndHorizontal();
        //if (fold)
        //{
        //    //�ꎞ�I�ɕۑ������z��̒����ƁA�{���̔z��̒������������`�F�b�N����
        //    if (_audiosize != loadObj.arraySize)
        //    {
        //        loadObj.arraySize = _audiosize; // �����̕ύX��K�p

        //        //������serializedObject�ւ̕ύX��K�p���A�ĂэX�V����
        //        serializedObject.ApplyModifiedProperties();
        //        serializedObject.Update();
        //    }
        //    else
        //    {
        //        using (new EditorGUILayout.HorizontalScope())
        //        {
        //            GUILayout.FlexibleSpace(); //�E�[�Ɋ񂹂�
        //            //�ꎞ�I�ɕۑ������z��̒����ƁA�{���̔z��̒����������ꍇ�́@�z��̗v�f��`�悷��
        //            for (int num = 0; num < loadObj.arraySize; num++) { loading.audioSource[num] = (AudioSource)EditorGUILayout.ObjectField(loading.audioSource[num], typeof(AudioSource), true, GUILayout.Width(300)); }
        //        }
        //    }
        //    EditorGUILayout.Space();
        //}

        serializedObject.ApplyModifiedProperties(); //serializedObject�ւ̕ύX��K�p
        EditorUtility.SetDirty(loading);
    }
}
