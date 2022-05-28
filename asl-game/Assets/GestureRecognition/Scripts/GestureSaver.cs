using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.Events;


public enum GestureHand
{
    LeftHand,
    RightHand
};

public class GestureSaver : MonoBehaviour
{
    [HideInInspector]
    public OVRSkeleton skeleton = null;
    public List<OVRBone> fingerBones = null;


    [HideInInspector]
    public string gestureName;



    [Tooltip("Choose which hand to track")]
    public GestureHand handToSave;

    [Tooltip("Choose which key should save a gesture for chosen hand")]
    public KeyCode saveKey;



    private void Start()
    {
        LoadSkeleton();
    }

    private void Update()
    {
        if (Input.GetKeyDown(saveKey))
        {
            SaveGesture();
        }
    }

    public void SaveGesture()
    {
        if (!Application.isPlaying)
        {
            CreateGestureAsset();
            Debug.LogError("Must be in play mode to save gesture");
            return;
        }

        if (fingerBones.Count == 0) LoadSkeleton();

        List<Vector3> data = new List<Vector3>();
        foreach (var bone in fingerBones)
        {
            data.Add(skeleton.transform.InverseTransformPoint(bone.Transform.position));
        }

        //gestures.Add(g);
        CreateGestureAsset(data);
    }

    private void CreateGestureAsset(List<Vector3> data = null)
    {
#if UNITY_EDITOR
        GestureSO asset = ScriptableObject.CreateInstance<GestureSO>();

        asset.gestureName = gestureName;
        asset.fingerPositions = data;
        asset.hand = handToSave;

        AssetDatabase.CreateAsset(asset, "Assets/Resources/" + gestureName + ".asset");
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        EditorUtility.SetDirty(asset);
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
#endif

    }

    public string GetSavedGestureLocation()
    {
        return "Resources/" + gestureName + ".asset";
    }

    void LoadSkeleton()
    {
        OVRSkeleton[] skeletons = FindObjectsOfType<OVRSkeleton>();
        foreach (OVRSkeleton _skeleton in skeletons)
        {
            if (handToSave == GestureHand.RightHand && _skeleton.GetSkeletonType() == OVRSkeleton.SkeletonType.HandRight)
            {
                skeleton = _skeleton;
            }
            else if (handToSave == GestureHand.LeftHand && _skeleton.GetSkeletonType() == OVRSkeleton.SkeletonType.HandLeft)
            {
                skeleton = _skeleton;
            }
        }

        fingerBones = new List<OVRBone>(skeleton.Bones);
        Debug.Log("Skeleton bones = " + fingerBones.Count);

        if (fingerBones == null || skeleton == null) Debug.LogWarning("Failed to find skeleton for " + handToSave + ". Do you have an OVRHandPrefab in the scene and setup?");
    }

}

