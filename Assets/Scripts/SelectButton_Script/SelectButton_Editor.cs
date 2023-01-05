using UnityEngine;
using System.Collections;
using UnityEngine.Events;
#if UNITY_EDITOR 
using UnityEditor;

[CustomEditor(typeof(SelectButton_Maneger))]
public class SelectButton_Editor : Editor
{
    private int arraysize = 0; //�z��̒������ꎞ�I�ɕۑ����邽�߂̕ϐ�
    public override void OnInspectorGUI()
    {
        serializedObject.Update(); //serializedObject���ŐV�ɕύX
        var selectObj = serializedObject.FindProperty("selectData"); //S_3_Select�N���X�̔z�� SelectData���擾
        var events = serializedObject.FindProperty("events");
        SelectButton_Maneger select = target as SelectButton_Maneger; //S_3_Select�N���X�̃C���X�^���X���擾

        EditorGUI.BeginChangeCheck();

        arraysize = selectObj.arraySize; //�z��SelectData�̒������ꎞ�I�ɕϐ��ɕۑ����Ă���

        //���ӏ���
        EditorGUILayout.HelpBox("����\n�y button obj �z\n�@Button�I�u�W�F�N�g�����Ă��������B\n�y button image �z\nMode:Size Button�Ɏg�p���Ă��邷�ׂẲ摜���܂Ƃ߂��I�u�W�F�N�g�����Ă��������B\nMode:Image �I����Ԃ̉摜�����Ă��������B", MessageType.None, true);

        //�I����Ԃ̃��[�h�̐ݒ�
        select.mode = (SelectButton_Maneger.ModeType)EditorGUILayout.EnumPopup("�I����Ԃ̃��[�h", select.mode);

        //����̃��[�h�̎��ɕ\�����鍀��
        if(select.mode == SelectButton_Maneger.ModeType.none) { }
        if (select.mode == SelectButton_Maneger.ModeType.size)
        {
            select.scallSpeed = EditorGUILayout.FloatField("�ω����鑬��", select.scallSpeed);
            select.maxTime = EditorGUILayout.FloatField("�؂�ւ�鎞��", select.maxTime);

            EditorGUILayout.Space(); //�X�y�[�X��`��

            arraysize = EditorGUILayout.IntField("Number of buttons", arraysize); //�ꎞ�I�ɕۑ������������J�X�^���C���X�^���X�ɕ`��i���������\�j

            EditorGUILayout.Space();

            select._pushBool = EditorGUILayout.Toggle("Push Other No Stop", select._pushBool);

            EditorGUILayout.Space();

            //�ꎞ�I�ɕۑ������z��̒����ƁA�{���̔z��̒������������`�F�b�N����
            if (arraysize != selectObj.arraySize)
            {
                selectObj.arraySize = arraysize; // �����̕ύX��K�p

                //������serializedObject�ւ̕ύX��K�p���A�ĂэX�V����
                serializedObject.ApplyModifiedProperties();
                serializedObject.Update();
            }
            else 
            {
                //�ꎞ�I�ɕۑ������z��̒����ƁA�{���̔z��̒����������ꍇ�́@�z��̗v�f��`�悷��
                for (int num = 0; num < selectObj.arraySize; num++)
                {
                    GUILayout.BeginVertical(GUI.skin.box);
                    EditorGUILayout.LabelField("Button " + (num + 1));
                    select.selectData[num].buttonObj = (GameObject)EditorGUILayout.ObjectField("button obj:", select.selectData[num].buttonObj, typeof(GameObject), true);
                    select.selectData[num].buttonImage = (GameObject)EditorGUILayout.ObjectField("button image:", select.selectData[num].buttonImage, typeof(GameObject), true);
                    GUILayout.EndVertical();

                    EditorGUILayout.Space(); //�X�y�[�X��`��
                }
            }
            GUILayout.BeginVertical(GUI.skin.box);
            select.ExitButton = EditorGUILayout.Toggle("Use Exit Button ", select.ExitButton);
            if (select.ExitButton)
            {
                select.exitData.exitButton = (GameObject)EditorGUILayout.ObjectField("Exit button:", select.exitData.exitButton, typeof(GameObject), true);
                select.exitData.exitImage = (GameObject)EditorGUILayout.ObjectField("Exit button image:", select.exitData.exitImage, typeof(GameObject), true);

                EditorGUILayout.Space();
            }
            EditorGUILayout.PropertyField(events);
            GUILayout.EndVertical();
            EditorGUILayout.Space(); //�X�y�[�X��`��
        }
        if (select.mode == SelectButton_Maneger.ModeType.image)
        {
            arraysize = EditorGUILayout.IntField("Number of buttons", arraysize); //�ꎞ�I�ɕۑ������������J�X�^���C���X�^���X�ɕ`��i���������\�j

            EditorGUILayout.Space(); //�X�y�[�X��`��

            select._pushBool = EditorGUILayout.Toggle("Push Other No Stop", select._pushBool);

            EditorGUILayout.Space();

            //�ꎞ�I�ɕۑ������z��̒����ƁA�{���̔z��̒������������`�F�b�N����
            if (arraysize != selectObj.arraySize)
            {
                selectObj.arraySize = arraysize; // �����̕ύX��K�p

                //������serializedObject�ւ̕ύX��K�p���A�ĂэX�V����
                serializedObject.ApplyModifiedProperties();
                serializedObject.Update();
            }
            else
            {
                //�ꎞ�I�ɕۑ������z��̒����ƁA�{���̔z��̒����������ꍇ�́@�z��̗v�f��`�悷��
                for (int num = 0; num < selectObj.arraySize; num++)
                {
                    GUILayout.BeginVertical(GUI.skin.box);
                    EditorGUILayout.LabelField("Button "+(num+1));
                    select.selectData[num].buttonObj = (GameObject)EditorGUILayout.ObjectField("button obj:", select.selectData[num].buttonObj, typeof(GameObject), true);
                    select.selectData[num].buttonImage = (GameObject)EditorGUILayout.ObjectField("button image:", select.selectData[num].buttonImage, typeof(GameObject), true);
                    GUILayout.EndVertical();

                    EditorGUILayout.Space(); //�X�y�[�X��`��
                }
            }
            GUILayout.BeginVertical(GUI.skin.box);
            select.ExitButton = EditorGUILayout.Toggle("Use Exit Button ", select.ExitButton);
            if (select.ExitButton)
            {
                select.exitData.exitButton = (GameObject)EditorGUILayout.ObjectField("Exit button:", select.exitData.exitButton, typeof(GameObject), true);
                select.exitData.exitImage = (GameObject)EditorGUILayout.ObjectField("Exit button image:", select.exitData.exitImage, typeof(GameObject), true);
                EditorGUILayout.Space(); //�X�y�[�X��`��

                select.scallSpeed = EditorGUILayout.FloatField("�ω����鑬��", select.scallSpeed);
                select.maxTime = EditorGUILayout.FloatField("�؂�ւ�鎞��", select.maxTime);

                EditorGUILayout.Space();
            }
            EditorGUILayout.PropertyField(events);
            GUILayout.EndVertical();
        }
        if (select.mode == SelectButton_Maneger.ModeType.normal)
        {
            arraysize = EditorGUILayout.IntField("Number of buttons", arraysize); //�ꎞ�I�ɕۑ������������J�X�^���C���X�^���X�ɕ`��i���������\�j

            EditorGUILayout.Space(); //�X�y�[�X��`��

            //�ꎞ�I�ɕۑ������z��̒����ƁA�{���̔z��̒������������`�F�b�N����
            if (arraysize != selectObj.arraySize)
            {
                selectObj.arraySize = arraysize; // �����̕ύX��K�p

                //������serializedObject�ւ̕ύX��K�p���A�ĂэX�V����
                serializedObject.ApplyModifiedProperties();
                serializedObject.Update();
            }
            else
            {
                //�ꎞ�I�ɕۑ������z��̒����ƁA�{���̔z��̒����������ꍇ�́@�z��̗v�f��`�悷��
                for (int num = 0; num < selectObj.arraySize; num++)
                {
                    GUILayout.BeginVertical(GUI.skin.box);
                    EditorGUILayout.LabelField("Button " + (num + 1));
                    select.selectData[num].buttonObj = (GameObject)EditorGUILayout.ObjectField("button obj:", select.selectData[num].buttonObj, typeof(GameObject), true);
                    GUILayout.EndVertical();
                    EditorGUILayout.Space(); //�X�y�[�X��`��
                }
            }
            GUILayout.BeginVertical(GUI.skin.box);
            select.ExitButton = EditorGUILayout.Toggle("Use Exit Button ", select.ExitButton);
            if (select.ExitButton)
            {
                EditorGUILayout.LabelField("Exit Button");
                select.exitData.exitButton = (GameObject)EditorGUILayout.ObjectField("Exit button:", select.exitData.exitButton, typeof(GameObject), true);
                select.exitData.exitImage = (GameObject)EditorGUILayout.ObjectField("Exit button image:", select.exitData.exitImage, typeof(GameObject), true);
                EditorGUILayout.Space(); //�X�y�[�X��`��

                select.scallSpeed = EditorGUILayout.FloatField("�ω����鑬��", select.scallSpeed);
                select.maxTime = EditorGUILayout.FloatField("�؂�ւ�鎞��", select.maxTime);

                EditorGUILayout.Space();
            }
            EditorGUILayout.PropertyField(events);
            GUILayout.EndVertical();
        }
        serializedObject.ApplyModifiedProperties(); //serializedObject�ւ̕ύX��K�p
        EditorUtility.SetDirty(select);
    }
}
#endif