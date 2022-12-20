//#if UNITY_EDITOR
//using UnityEditor;
//[CustomEditor(typeof(SelectButton_Script))]
//public class HogeObjectEditor : Editor
//{
//    private SelectButton_Script _check;

//    private void Awake()
//    {
//        _check = target as SelectButton_Script;
//    }

//    public override void OnInspectorGUI()
//    {
//        EditorGUI.BeginChangeCheck();

//        _check.enbleCheck = EditorGUILayout.ToggleLeft("enbleCheck", _check.enbleCheck);
//        if (_check.enbleCheck)
//        {
//            EditorGUILayout.LabelField("buttonÇÃê›íË");
//            _check.button.buttonButton = EditorGUILayout.ObjectField("Button Object", _check.button.buttonButton,typeof(GameObjectUtility), true);
//            _check.button.buttonImage = EditorGUILayout.PropertyField("ãóó£", _check.button.buttonImage);
//            _check.button.buttonImage = EditorGUILayout.Vector3Field("ìßâﬂ", _check.button.buttonImage);
//        }

//        // GUIÇÃçXêVÇ™Ç†Ç¡ÇΩÇÁé¿çs
//        if (EditorGUI.EndChangeCheck())
//        {
//            EditorUtility.SetDirty(_check);
//        }
//    }
//}
//#endif