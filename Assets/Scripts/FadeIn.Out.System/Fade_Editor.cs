using UnityEngine;
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;

//Fade�p�J�X�^��Editor
[CustomEditor(typeof(Fade_Manager))]
public class Fade_Editor : Editor
{
    private int _fadesize = 0; //�z��̒������ꎞ�I�ɕۑ����邽�߂̕ϐ�
    private bool _fadeFold = false;�@//�܂肽���݋@�\�̔���

    public override void OnInspectorGUI()
    {
        Fade_Manager fade = target as Fade_Manager; //Fade_Manager�N���X�̃C���X�^���X���擾

        serializedObject.Update(); //serializedObject���ŐV�ɕύX

        var fadeObj = serializedObject.FindProperty("fadeSystem");�@//Fade_Manager�N���X�̔z�� fadeSystem ���擾
        var soundObj = serializedObject.FindProperty("audioSource"); //Fade_Manager�N���X�̔z�� audioSource ���擾

        EditorGUI.BeginChangeCheck();

        _fadesize = fadeObj.arraySize; //�z��̒�����ۑ�

        //Fade
        EditorGUILayout.LabelField("Fade Setting", EditorStyles.boldLabel);  //���x����\��
        //EditorGUILayout.PropertyField(fadeObj);

        EditorGUILayout.Space();  //�X�y�[�X���m��

        EditorGUILayout.BeginHorizontal(); //���ɕ\������
        _fadeFold = EditorGUILayout.Foldout(_fadeFold, "�@Fade Setting "); //�܂肽���݋@�\��\��
        _fadesize = EditorGUILayout.IntField(_fadesize, GUILayout.Width(30));  //Int�^�̃t�B�[���h��\��
        EditorGUILayout.EndHorizontal();
        if (_fadeFold)
        {
            if (_fadesize != fadeObj.arraySize)
            {
                fadeObj.arraySize = _fadesize; //���̃T�C�Y����

                serializedObject.ApplyModifiedProperties(); //serializedObject�ւ̕ύX��K�p
                serializedObject.Update(); //�\�����X�V
            }
            else
            {
                for (int num = 0; num < fadeObj.arraySize; num++)
                {
                    GUILayout.BeginVertical(GUI.skin.box); //�c�ɕ\���ƈ݂͂�\��
                    fade.fadeSystem[num]._textObj = EditorGUILayout.Toggle("Use Other Object ", fade.fadeSystem[num]._textObj); //Toggle��\��
                    if (fade.fadeSystem[num]._textObj)
                    {
                        EditorGUILayout.LabelField("Text Object " + num);  //Text�p���x���\��
                        fade.fadeSystem[num].textObj = (TextMeshProUGUI)EditorGUILayout.ObjectField("  Text Object ", fade.fadeSystem[num].textObj, typeof(TextMeshProUGUI), true);  //Object�p�̃t�B�[���h��\��
                        fade.fadeSystem[num].fadeTime = EditorGUILayout.FloatField("�@�@Fade Change Time ", fade.fadeSystem[num].fadeTime);  //Float�^�̃t�B�[���h��\��
                        fade.fadeSystem[num].fadeIn = EditorGUILayout.Toggle("�@�@Fade In  ", fade.fadeSystem[num].fadeIn);  //FadeIn�p��Toggle��\��
                        fade.fadeSystem[num].fadeOut = EditorGUILayout.Toggle("�@�@Fade Out  ", fade.fadeSystem[num].fadeOut);  //FadeOut�p��Toggle��\��
                    }
                    else
                    {
                        EditorGUILayout.LabelField("Image Object " + num);  //Image�p���x���\��
                        fade.fadeSystem[num].imageObj = (Image)EditorGUILayout.ObjectField("�@Fade Image " + num, fade.fadeSystem[num].imageObj, typeof(Image), true);  //Object�p�̃t�B�[���h��\��
                        fade.fadeSystem[num].fadeTime = EditorGUILayout.FloatField("�@�@Fade Change Time ", fade.fadeSystem[num].fadeTime);  //Float�^�̃t�B�[���h��\��
                        fade.fadeSystem[num].fadeIn = EditorGUILayout.Toggle("�@�@Fade In  ", fade.fadeSystem[num].fadeIn);  //FadeIn�p��Toggle��\��
                        fade.fadeSystem[num].fadeOut = EditorGUILayout.Toggle("�@�@Fade Out  ", fade.fadeSystem[num].fadeOut);  //FadeOut�p��Toggle��\��
                    }
                    GUILayout.EndVertical();

                    EditorGUILayout.Space();
                }
            }
        }

        EditorGUILayout.Space();  //�X�y�[�X���m��

        //Sound
        EditorGUILayout.LabelField("Sound Setting", EditorStyles.boldLabel);  //���x����\��

        GUILayout.BeginVertical(GUI.skin.box);  //�c�ɕ\���ƈ݂͂�\��
        fade._soundBool = EditorGUILayout.Toggle("Use Sound Setting ", fade._soundBool);  ////Toggle��\��
        if (fade._soundBool)
        {
            EditorGUILayout.PropertyField(soundObj);  //AudioSource�p�̃t�B�[���h��\��

            fade.sound_fadeIn= EditorGUILayout.Toggle("�@Sound Fade In ", fade.sound_fadeIn);  //Sound��FadeIn�p��Toggle��\��
            fade.sound_fadeOut= EditorGUILayout.Toggle("�@Sound Fade Out ", fade.sound_fadeOut);  //Sound��FadeOut�p��Toggle��\��

            fade.soundfadeIn_Time = EditorGUILayout.FloatField("�@Sound Fade In Time ", fade.soundfadeIn_Time);  //Float�^�̃t�B�[���h��\��
            fade.soudfadeOut_Time = EditorGUILayout.FloatField("�@Sound Fade Out Time ", fade.soudfadeOut_Time);  //Float�^�̃t�B�[���h��\��
            fade.soundVolume = EditorGUILayout.FloatField("�@Sound Volume ", fade.soundVolume);  //Float�^�̃t�B�[���h��\��

            EditorGUILayout.HelpBox("���[�h��ʏI����̃��C��BGM�̉��ʂ�ݒ肵�Ă��������B", MessageType.Warning, true);  //���ӏ�����\��
        }
        GUILayout.EndVertical();

        serializedObject.ApplyModifiedProperties(); //serializedObject�ւ̕ύX��K�p
        EditorUtility.SetDirty(fade);
    }
}
#endif