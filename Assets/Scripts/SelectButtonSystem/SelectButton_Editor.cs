using UnityEngine;
#if UNITY_EDITOR 
using UnityEditor;

[CustomEditor(typeof(SelectButton_Maneger))]
public class SelectButton_Editor : Editor
{
    // �z��̒������ꎞ�I�ɕۑ����邽�߂̕ϐ�
    private int arraysize = 0;
    public override void OnInspectorGUI()
    {
        // serializedObject���ŐV�ɕύX
        serializedObject.Update();

        // S_3_Select�N���X�̔z�� SelectData���擾
        var selectObj = serializedObject.FindProperty("selectData");
        var events = serializedObject.FindProperty("events");

        // S_3_Select�N���X�̃C���X�^���X���擾
        SelectButton_Maneger select = target as SelectButton_Maneger;

        EditorGUI.BeginChangeCheck();

        // �z��SelectData�̒������ꎞ�I�ɕϐ��ɕۑ����Ă���
        arraysize = selectObj.arraySize;

        // �I����Ԃ̃��[�h�̐ݒ�
        select.mode = (SelectButton_Maneger.ModeType)EditorGUILayout.EnumPopup("�I�𒆂̉��o���[�h", select.mode);

        // �ꎞ�I�ɕۑ������������J�X�^���C���X�^���X�ɕ`��i���������\�j
        arraysize = EditorGUILayout.IntField("�{�^���̌�", arraysize);

        // �X�y�[�X��`��
        EditorGUILayout.Space();

        // ����̃��[�h�̎��ɕ\�����鍀��
        if (select.mode == SelectButton_Maneger.ModeType.none)
        {
            // Inspector�ɉ����\�����Ȃ�
        }
        if (select.mode == SelectButton_Maneger.ModeType.size)
        {
            // �ω����鑬����ݒ肷��t�B�[���h��\��
            select.scallSpeed = EditorGUILayout.FloatField("�ω����鑬��", select.scallSpeed);
            // �؂�ւ��܂ł̎��Ԃ�ݒ肷��t�B�[���h��\��
            select.maxTime = EditorGUILayout.FloatField("�؂�ւ�鎞��", select.maxTime);

            // �X�y�[�X��`��
            EditorGUILayout.Space();

            // �ꎞ�I�ɕۑ������z��̒����ƁA�{���̔z��̒������������`�F�b�N����
            if (arraysize != selectObj.arraySize)
            {
                // �����̕ύX��K�p
                selectObj.arraySize = arraysize;

                //������serializedObject�ւ̕ύX��K�p���A�ĂэX�V����
                serializedObject.ApplyModifiedProperties();
                serializedObject.Update();
            }
            else
            {
                // �ꎞ�I�ɕۑ������z��̒����ƁA�{���̔z��̒����������ꍇ�͔z��̗v�f��`�悷��
                for (int num = 0; num < selectObj.arraySize; num++)
                {
                    // �g�g�݂����
                    GUILayout.BeginVertical(GUI.skin.box);

                    // �{�^���̌��o����\������
                    EditorGUILayout.LabelField("Button " + (num + 1));
                    // �{�^���̃I�u�W�F�N�g���擾����t�B�[���h��\��
                    select.selectData[num].buttonObj = (GameObject)EditorGUILayout.ObjectField("�@�{�^���̃I�u�W�F�N�g", select.selectData[num].buttonObj, typeof(GameObject), true);
                    // �{�^����UI�摜���I�u�W�F�N�g�Ƃ��Ď擾����t�B�[���h��\��
                    select.selectData[num].buttonImage = (GameObject)EditorGUILayout.ObjectField("�@�{�^����UI�摜", select.selectData[num].buttonImage, typeof(GameObject), true);

                    // �g�g�݂̍Ō��ݒ肷��
                    GUILayout.EndVertical();

                    //�X�y�[�X��`��
                    EditorGUILayout.Space();
                }
            }

            // �{�^��B�̃{�^���I����L���ɂ��邩�̃g�O����\��
            select.ExitButton = EditorGUILayout.Toggle("�{�^��B��L���ɂ��邩", select.ExitButton);

            if (select.ExitButton)
            {
                // �g�g�݂����
                GUILayout.BeginVertical(GUI.skin.box);

                // �{�^���̃I�u�W�F�N�g���擾����t�B�[���h��\��
                select.exitData.exitButton = (GameObject)EditorGUILayout.ObjectField("�@�{�^���̃I�u�W�F�N�g", select.exitData.exitButton, typeof(GameObject), true);
                // �{�^����UI�摜���I�u�W�F�N�g�Ƃ��Ď擾����t�B�[���h��\��
                select.exitData.exitImage = (GameObject)EditorGUILayout.ObjectField("�@�{�^����UI�摜", select.exitData.exitImage, typeof(GameObject), true);

                // �X�y�[�X��`��
                EditorGUILayout.Space();

                // �C�x���g�֐��̏�����\������
                EditorGUILayout.PropertyField(events);

                // �g�g�݂̍Ō��ݒ肷��
                GUILayout.EndVertical();

            }
        }
        if (select.mode == SelectButton_Maneger.ModeType.image)
        {
            //�ꎞ�I�ɕۑ������z��̒����ƁA�{���̔z��̒������������`�F�b�N����
            if (arraysize != selectObj.arraySize)
            {
                // �����̕ύX��K�p
                selectObj.arraySize = arraysize;

                //������serializedObject�ւ̕ύX��K�p���A�ĂэX�V����
                serializedObject.ApplyModifiedProperties();
                serializedObject.Update();
            }
            else
            {
                //�ꎞ�I�ɕۑ������z��̒����ƁA�{���̔z��̒����������ꍇ�͔z��̗v�f��`�悷��
                for (int num = 0; num < selectObj.arraySize; num++)
                {
                    // �g�g�݂����
                    GUILayout.BeginVertical(GUI.skin.box);

                    // �{�^���̌��o����\������
                    EditorGUILayout.LabelField("Button " + (num + 1));
                    // �{�^���̃I�u�W�F�N�g���擾����t�B�[���h��\��
                    select.selectData[num].buttonObj = (GameObject)EditorGUILayout.ObjectField("�@�{�^���̃I�u�W�F�N�g", select.selectData[num].buttonObj, typeof(GameObject), true);
                    // �{�^����UI�摜���I�u�W�F�N�g�Ƃ��Ď擾����t�B�[���h��\��
                    select.selectData[num].buttonImage = (GameObject)EditorGUILayout.ObjectField("�@�{�^����UI�摜", select.selectData[num].buttonImage, typeof(GameObject), true);

                    // �g�g�݂̍Ō��ݒ肷��
                    GUILayout.EndVertical();

                    //�X�y�[�X��`��
                    EditorGUILayout.Space();
                }
            }

            // �{�^��B�̃{�^���I����L���ɂ��邩�̃g�O����\��
            select.ExitButton = EditorGUILayout.Toggle("�{�^��B��L���ɂ��邩", select.ExitButton);

            if (select.ExitButton)
            {
                // �g�g�݂����
                GUILayout.BeginVertical(GUI.skin.box);

                // �{�^���̃I�u�W�F�N�g���擾����t�B�[���h��\��
                select.exitData.exitButton = (GameObject)EditorGUILayout.ObjectField("�@�{�^���̃I�u�W�F�N�g", select.exitData.exitButton, typeof(GameObject), true);
                // �{�^����UI�摜���I�u�W�F�N�g�Ƃ��Ď擾����t�B�[���h��\��
                select.exitData.exitImage = (GameObject)EditorGUILayout.ObjectField("�@�{�^����UI�摜", select.exitData.exitImage, typeof(GameObject), true);

                // �X�y�[�X��`��
                EditorGUILayout.Space();

                // �ω����鑬����ݒ肷��t�B�[���h��\��
                select.scallSpeed = EditorGUILayout.FloatField("�ω����鑬��", select.scallSpeed);
                // �؂�ւ��܂ł̎��Ԃ�ݒ肷��t�B�[���h��\��
                select.maxTime = EditorGUILayout.FloatField("�؂�ւ�鎞��", select.maxTime);

                // �X�y�[�X��`��
                EditorGUILayout.Space();

                // �C�x���g�֐��̏�����\������
                EditorGUILayout.PropertyField(events);

                // �g�g�݂̍Ō��ݒ肷��
                GUILayout.EndVertical();
            }
        }
        if (select.mode == SelectButton_Maneger.ModeType.normal)
        {
            //�ꎞ�I�ɕۑ������z��̒����ƁA�{���̔z��̒������������`�F�b�N����
            if (arraysize != selectObj.arraySize)
            {
                // �����̕ύX��K�p
                selectObj.arraySize = arraysize;

                //������serializedObject�ւ̕ύX��K�p���A�ĂэX�V����
                serializedObject.ApplyModifiedProperties();
                serializedObject.Update();
            }
            else
            {
                //�ꎞ�I�ɕۑ������z��̒����ƁA�{���̔z��̒����������ꍇ�͔z��̗v�f��`�悷��
                for (int num = 0; num < selectObj.arraySize; num++)
                {
                    // �g�g�݂����
                    GUILayout.BeginVertical(GUI.skin.box);

                    // �{�^���̌��o����\������
                    EditorGUILayout.LabelField("Button " + (num + 1));
                    // �{�^���̃I�u�W�F�N�g���擾����t�B�[���h��\��
                    select.selectData[num].buttonObj = (GameObject)EditorGUILayout.ObjectField("�@�{�^���̃I�u�W�F�N�g", select.selectData[num].buttonObj, typeof(GameObject), true);

                    // �g�g�݂̍Ō��ݒ肷��
                    GUILayout.EndVertical();

                    //�X�y�[�X��`��
                    EditorGUILayout.Space();
                }
            }

            // �{�^��B�̃{�^���I����L���ɂ��邩�̃g�O����\��
            select.ExitButton = EditorGUILayout.Toggle("�{�^��B��L���ɂ��邩", select.ExitButton);

            if (select.ExitButton)
            {
                // �g�g�݂����
                GUILayout.BeginVertical(GUI.skin.box);

                // �{�^���̃I�u�W�F�N�g���擾����t�B�[���h��\��
                select.exitData.exitButton = (GameObject)EditorGUILayout.ObjectField("�@�{�^���̃I�u�W�F�N�g", select.exitData.exitButton, typeof(GameObject), true);
                // �{�^����UI�摜���I�u�W�F�N�g�Ƃ��Ď擾����t�B�[���h��\��
                select.exitData.exitImage = (GameObject)EditorGUILayout.ObjectField("�@�{�^����UI�摜", select.exitData.exitImage, typeof(GameObject), true);

                // �X�y�[�X��`��
                EditorGUILayout.Space();

                // �ω����鑬����ݒ肷��t�B�[���h��\��
                select.scallSpeed = EditorGUILayout.FloatField("�ω����鑬��", select.scallSpeed);
                // �؂�ւ��܂ł̎��Ԃ�ݒ肷��t�B�[���h��\��
                select.maxTime = EditorGUILayout.FloatField("�؂�ւ�鎞��", select.maxTime);

                // �X�y�[�X��`��
                EditorGUILayout.Space();

                // �C�x���g�֐��̏�����\������
                EditorGUILayout.PropertyField(events);

                // �g�g�݂̍Ō��ݒ肷��
                GUILayout.EndVertical();
            }
        }

        //serializedObject�ւ̕ύX��K�p
        serializedObject.ApplyModifiedProperties();
        EditorUtility.SetDirty(select);
    }
}
#endif