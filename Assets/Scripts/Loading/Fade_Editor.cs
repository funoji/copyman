//using UnityEngine;
//using UnityEngine.UI;
//using System.Collections;
//using UnityEditor;

//[CustomEditor(typeof(S_1_Fadeout_Script))]
//public class Fade_Editor : Editor
//{
//    public override void OnInspectorGUI()
//    {
//        S_1_Fadeout_Script fade = target as S_1_Fadeout_Script; //S_1_Fadeout_Script�N���X�̃C���X�^���X���擾

//        //�I����Ԃ̃��[�h�̐ݒ�
//        fade.fadeMode = (S_1_Fadeout_Script.FadeMode)EditorGUILayout.EnumPopup("�I����Ԃ̃��[�h", fade.fadeMode);

//        //����̃��[�h�̎��ɕ\�����鍀��
//        if (fade.fadeMode == S_1_Fadeout_Script.FadeMode.fade)
//        {
//            fade.fadeTime= EditorGUILayout.FloatField("�t�F�[�h�̎��� : ", fade.fadeTime);
//            fade.fadeImage= (Image)EditorGUILayout.ObjectField("�t�F�[�h�p Image : ", fade.fadeImage, typeof(Image), true);
//        }
//        if (fade.fadeMode == S_1_Fadeout_Script.FadeMode.load)
//        {
//            fade.load == (Loading_ReadIn)EditorGUILayout.ObjectField("���[�h�@�\ Script : ", fade.load, typeof(Loading_ReadIn), true);
//        }
//    }
//}
