using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;

[CustomEditor(typeof(GestureSaver))]
public class GestureSaverEditor : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GestureSaver gestureSaver = (GestureSaver)target;

        GUILayout.BeginHorizontal();

        gestureSaver.gestureName = EditorGUILayout.TextField("Gesture Name: ", gestureSaver.gestureName);

        if (GUILayout.Button("Save Gesture"))
        {
            gestureSaver.SaveGesture();
            //EditorUtility.DisplayDialog("Gesture Saved",
            //    "You can find your saved gesture at " + gestureController.GetSavedGestureLocation(), "Ok") ;
        }

        GUILayout.EndHorizontal();
    }
}
