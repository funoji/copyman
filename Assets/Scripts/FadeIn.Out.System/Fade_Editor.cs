using UnityEngine;
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;

// Fade�p�J�X�^��Editor
[CustomEditor(typeof(Fade_Manager))]
public class Fade_Editor : Editor
{
    // �z��̒������ꎞ�I�ɕۑ����邽�߂̕ϐ�
    private int _fadesize = 0;
    // �܂肽���݋@�\�̔���
    private bool _fadeFold = false;

    public override void OnInspectorGUI()
    {
        // Fade_Manager�N���X�̃C���X�^���X���擾
        Fade_Manager fade = target as Fade_Manager;

        // serializedObject���ŐV�ɕύX
        serializedObject.Update();

        // Fade_Manager�N���X�̔z�� fadeSystem ���擾
        var fadeObj = serializedObject.FindProperty("fadeSystem");
        //Fade_Manager�N���X�̔z�� audioSource ���擾
        var soundObj = serializedObject.FindProperty("audioSource");

        EditorGUI.BeginChangeCheck();

        // �z��̒�����ۑ�
        _fadesize = fadeObj.arraySize;

        // Fade
        // ���x����\��
        EditorGUILayout.LabelField("Fade�̐ݒ�", EditorStyles.boldLabel);
        //EditorGUILayout.PropertyField(fadeObj);

        // �X�y�[�X���m��
        EditorGUILayout.Space();

        // ���ɕ\������
        EditorGUILayout.BeginHorizontal();
        // �܂肽���݋@�\��\��
        _fadeFold = EditorGUILayout.Foldout(_fadeFold, "�@Fade�ݒ荀�� ");
        // Int�^�̃t�B�[���h��\��
        _fadesize = EditorGUILayout.IntField(_fadesize, GUILayout.Width(30));
        // ���ɕ\�����镨��ݒ�
        EditorGUILayout.EndHorizontal();

        if (_fadeFold)
        {
            if (_fadesize != fadeObj.arraySize)
            {
                // ���̃T�C�Y����
                fadeObj.arraySize = _fadesize;

                // serializedObject�ւ̕ύX��K�p
                serializedObject.ApplyModifiedProperties();
                // �\�����X�V
                serializedObject.Update();
            }
            else
            {
                for (int num = 0; num < fadeObj.arraySize; num++)
                {
                    // �c�ɕ\���ƈ݂͂�\��
                    GUILayout.BeginVertical(GUI.skin.box);

                    // Toggle��\��
                    fade.fadeSystem[num]._textObj = EditorGUILayout.Toggle("Text�I�u�W�F�N�g", fade.fadeSystem[num]._textObj);

                    if (fade.fadeSystem[num]._textObj)
                    {
                        // Text�p���x���\��
                        EditorGUILayout.LabelField("Text Object " + num);

                        // Object�p�̃t�B�[���h��\��
                        fade.fadeSystem[num].textObj = (TextMeshProUGUI)EditorGUILayout.ObjectField("  Text Object ", fade.fadeSystem[num].textObj, typeof(TextMeshProUGUI), true);
                        // Float�^�̃t�B�[���h��\��
                        fade.fadeSystem[num].fadeTime = EditorGUILayout.FloatField("�@�@Fade Change Time ", fade.fadeSystem[num].fadeTime);
                        // FadeIn�p��Toggle��\��
                        fade.fadeSystem[num].fadeIn = EditorGUILayout.Toggle("�@�@Fade In  ", fade.fadeSystem[num].fadeIn);
                        // FadeOut�p��Toggle��\��
                        fade.fadeSystem[num].fadeOut = EditorGUILayout.Toggle("�@�@Fade Out  ", fade.fadeSystem[num].fadeOut);
                    }
                    else
                    {
                        // Image�p���x���\��
                        EditorGUILayout.LabelField("Image Object " + num);

                        // Object�p�̃t�B�[���h��\��
                        fade.fadeSystem[num].imageObj = (Image)EditorGUILayout.ObjectField("�@Fade Image " + num, fade.fadeSystem[num].imageObj, typeof(Image), true);
                        // Float�^�̃t�B�[���h��\��
                        fade.fadeSystem[num].fadeTime = EditorGUILayout.FloatField("�@�@Fade Change Time ", fade.fadeSystem[num].fadeTime);
                        // FadeIn�p��Toggle��\��
                        fade.fadeSystem[num].fadeIn = EditorGUILayout.Toggle("�@�@Fade In  ", fade.fadeSystem[num].fadeIn);
                        // FadeOut�p��Toggle��\��
                        fade.fadeSystem[num].fadeOut = EditorGUILayout.Toggle("�@�@Fade Out  ", fade.fadeSystem[num].fadeOut);
                    }
                    GUILayout.EndVertical();

                    // �X�y�[�X���m��
                    EditorGUILayout.Space();
                }
            }
        }

        // �X�y�[�X���m��
        EditorGUILayout.Space();

        // Sound
        // ���x����\��
        EditorGUILayout.LabelField("Sound Setting", EditorStyles.boldLabel);

        // �c�ɕ\���ƈ݂͂�\��
        GUILayout.BeginVertical(GUI.skin.box);

        // Toggle��\��
        fade._soundBool = EditorGUILayout.Toggle("Use Sound Setting ", fade._soundBool);

        if (fade._soundBool)
        {
            // AudioSource�p�̃t�B�[���h��\��
            EditorGUILayout.PropertyField(soundObj);

            // Sound��FadeIn�p��Toggle��\��
            fade.sound_fadeIn = EditorGUILayout.Toggle("�@Sound Fade In ", fade.sound_fadeIn);
            // Sound��FadeOut�p��Toggle��\��
            fade.sound_fadeOut = EditorGUILayout.Toggle("�@Sound Fade Out ", fade.sound_fadeOut);

            // Float�^�̃t�B�[���h��\��
            fade.soundfadeIn_Time = EditorGUILayout.FloatField("�@Sound Fade In Time ", fade.soundfadeIn_Time);
            // Float�^�̃t�B�[���h��\��
            fade.soudfadeOut_Time = EditorGUILayout.FloatField("�@Sound Fade Out Time ", fade.soudfadeOut_Time);
            // Float�^�̃t�B�[���h��\��
            fade.soundVolume = EditorGUILayout.FloatField("�@Sound Volume ", fade.soundVolume);

            // ���ӏ�����\��
            EditorGUILayout.HelpBox("���[�h��ʏI����̃��C��BGM�̉��ʂ�ݒ肵�Ă��������B", MessageType.Warning, true);
        }
        GUILayout.EndVertical();

        // serializedObject�ւ̕ύX��K�p
        serializedObject.ApplyModifiedProperties();
        EditorUtility.SetDirty(fade);
    }
}
#endif