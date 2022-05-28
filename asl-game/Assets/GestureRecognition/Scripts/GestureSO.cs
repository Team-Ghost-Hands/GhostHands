using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class GestureSO : ScriptableObject
{
    public string gestureName;
    public GestureHand hand;

    public List<Vector3> fingerPositions;
}
