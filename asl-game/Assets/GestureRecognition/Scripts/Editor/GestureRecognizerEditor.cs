using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Events;

[CustomEditor(typeof(GestureRecognizer))]
public class GestureRecognizerEditor : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        //GestureRecognizer gestureRecognizer = (GestureRecognizer)target;


        //foreach(GestureSO gesture in gestureRecognizer.gesturesToRecognize)
        //{
        //    if (GUILayout.Button("Remove Gesture"))
        //    {
        //        gestureRecognizer.RemoveGesture(gesture);
        //    }
        //    foreach (UnityEvent unityEvent in gestureRecognizer.unityEvents)
        //        EditorGUILayout.PropertyField(sprop);

        //}

    }
}
