//using UnityEngine;
//using UnityEngine.UI;
//using System.Collections;
//using UnityEditor;

//[CustomEditor(typeof(S_1_Fadeout_Script))]
//public class Fade_Editor : Editor
//{
//    public override void OnInspectorGUI()
//    {
//        S_1_Fadeout_Script fade = target as S_1_Fadeout_Script; //S_1_Fadeout_Scriptクラスのインスタンスを取得

//        //選択状態のモードの設定
//        fade.fadeMode = (S_1_Fadeout_Script.FadeMode)EditorGUILayout.EnumPopup("選択状態のモード", fade.fadeMode);

//        //特定のモードの時に表示する項目
//        if (fade.fadeMode == S_1_Fadeout_Script.FadeMode.fade)
//        {
//            fade.fadeTime= EditorGUILayout.FloatField("フェードの時間 : ", fade.fadeTime);
//            fade.fadeImage= (Image)EditorGUILayout.ObjectField("フェード用 Image : ", fade.fadeImage, typeof(Image), true);
//        }
//        if (fade.fadeMode == S_1_Fadeout_Script.FadeMode.load)
//        {
//            fade.load == (Loading_ReadIn)EditorGUILayout.ObjectField("ロード機能 Script : ", fade.load, typeof(Loading_ReadIn), true);
//        }
//    }
//}
