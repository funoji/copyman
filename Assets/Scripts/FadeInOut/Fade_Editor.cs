using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEditor;
using TMPro;

[CustomEditor(typeof(Fade_Manager))]
public class Fade_Editor : Editor
{
    private int _fadesize = 0; //�z��̒������ꎞ�I�ɕۑ����邽�߂̕ϐ�
    private bool _fadeFold = false;

    public override void OnInspectorGUI()
    {
        Fade_Manager fade = target as Fade_Manager; //S_1_Fadeout_Script�N���X�̃C���X�^���X���擾
        serializedObject.Update(); //serializedObject���ŐV�ɕύX
        var fadeObj = serializedObject.FindProperty("fadeSystem");
        var soundObj = serializedObject.FindProperty("audioSource"); //S_1_Fadeout_Script�N���X�̔z�� audioSource ���擾
        EditorGUI.BeginChangeCheck();

        _fadesize = fadeObj.arraySize;

        //����̃��[�h�̎��ɕ\�����鍀��
        //Fade
        EditorGUILayout.LabelField("Fade Setting", EditorStyles.boldLabel);
        //EditorGUILayout.PropertyField(fadeObj);
        EditorGUILayout.Space();

        //��̗v�f�������тɕ\��������
        EditorGUILayout.BeginHorizontal();
        _fadeFold = EditorGUILayout.Foldout(_fadeFold, "�@Fade Setting ");
        _fadesize = EditorGUILayout.IntField(_fadesize, GUILayout.Width(30)); //�ꎞ�I�ɕۑ������������J�X�^���C���X�^���X�ɕ`��i���������\�j
        EditorGUILayout.EndHorizontal();
        if (_fadeFold)
        {
            //�ꎞ�I�ɕۑ������z��̒����ƁA�{���̔z��̒������������`�F�b�N����
            if (_fadesize != fadeObj.arraySize)
            {
                fadeObj.arraySize = _fadesize; // �����̕ύX��K�p

                //������serializedObject�ւ̕ύX��K�p���A�ĂэX�V����
                serializedObject.ApplyModifiedProperties();
                serializedObject.Update();
            }
            else
            {
                GUILayout.BeginVertical();
                //�ꎞ�I�ɕۑ������z��̒����ƁA�{���̔z��̒����������ꍇ�́@�z��̗v�f��`�悷��
                for (int num = 0; num < fadeObj.arraySize; num++)
                {
                    GUILayout.FlexibleSpace();
                    fade.fadeSystem[num]._textObj = EditorGUILayout.Toggle("Use Other Object ", fade.fadeSystem[num]._textObj);
                    if (fade.fadeSystem[num]._textObj)
                    {
                        fade.fadeSystem[num].textObj = (TextMeshProUGUI)EditorGUILayout.ObjectField("  Text Object ", fade.fadeSystem[num].textObj, typeof(TextMeshProUGUI), true);
                        fade.fadeSystem[num].fadeTime = EditorGUILayout.FloatField("�@�@Fade Change Time ", fade.fadeSystem[num].fadeTime);
                        fade.fadeSystem[num].fadeIn = EditorGUILayout.Toggle("�@�@Fade In  ", fade.fadeSystem[num].fadeIn);
                        fade.fadeSystem[num].fadeOut = EditorGUILayout.Toggle("�@�@Fade Out  ", fade.fadeSystem[num].fadeOut);

                    }
                    else
                    {
                        fade.fadeSystem[num].fadeImage = (Image)EditorGUILayout.ObjectField("�@Fade Image " + num, fade.fadeSystem[num].fadeImage, typeof(Image), true);
                        fade.fadeSystem[num].fadeTime = EditorGUILayout.FloatField("�@�@Fade Change Time ", fade.fadeSystem[num].fadeTime);
                        fade.fadeSystem[num].fadeIn = EditorGUILayout.Toggle("�@�@Fade In  ", fade.fadeSystem[num].fadeIn);
                        fade.fadeSystem[num].fadeOut = EditorGUILayout.Toggle("�@�@Fade Out  ", fade.fadeSystem[num].fadeOut);
                    }
                    EditorGUILayout.Space();
                }
                GUILayout.EndVertical();
            }
        }

        EditorGUILayout.Space();

        //Sound
        EditorGUILayout.LabelField("Sound Setting", EditorStyles.boldLabel);
        fade._soundBool = EditorGUILayout.Toggle("Use Sound Setting ", fade._soundBool);
        if (fade._soundBool)
        {
            EditorGUILayout.PropertyField(soundObj);
            ////��̗v�f�������тɕ\��������
            //EditorGUILayout.BeginHorizontal();
            //_soundFold = EditorGUILayout.Foldout(_soundFold, "�@AudioSource ");
            //_soundSize = EditorGUILayout.IntField(_soundSize, GUILayout.Width(30)); //�ꎞ�I�ɕۑ������������J�X�^���C���X�^���X�ɕ`��i���������\�j
            //EditorGUILayout.EndHorizontal();
            //if (_soundFold)
            //{
            //    //�ꎞ�I�ɕۑ������z��̒����ƁA�{���̔z��̒������������`�F�b�N����
            //    if (_soundSize != soundObj.arraySize)
            //    {
            //        soundObj.arraySize = _soundSize; // �����̕ύX��K�p

            //        //������serializedObject�ւ̕ύX��K�p���A�ĂэX�V����
            //        serializedObject.ApplyModifiedProperties();
            //        serializedObject.Update();
            //    }
            //    else
            //    {
            //        //�ꎞ�I�ɕۑ������z��̒����ƁA�{���̔z��̒����������ꍇ�́@�z��̗v�f��`�悷��
            //        for (int num = 0; num < soundObj.arraySize; num++) 
            //        {
            //            fade.audioSource[num] = (AudioSource)EditorGUILayout.ObjectField(fade.audioSource[num], typeof(AudioSource), true, GUILayout.Width(300)); 
            //        }
            //    }
            //    EditorGUILayout.Space();
            //}

            fade.soundfadeTime = EditorGUILayout.FloatField("�@Sound Fade Time ", fade.soundfadeTime);
            fade.soundVolume = EditorGUILayout.FloatField("�@Sound Volume ", fade.soundVolume);
            EditorGUILayout.HelpBox("���[�h��ʏI����̃��C��BGM�̉��ʂ�ݒ肵�Ă��������B", MessageType.Warning, true);
        }
        serializedObject.ApplyModifiedProperties(); //serializedObject�ւ̕ύX��K�p
        EditorUtility.SetDirty(fade);
    }
}
