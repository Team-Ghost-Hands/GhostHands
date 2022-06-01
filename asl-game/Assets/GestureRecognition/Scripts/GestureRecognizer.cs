using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GestureRecognizer : MonoBehaviour
{

    [Tooltip("Drag the gesture you wish to track here")]
    public GestureSO gestureToRecognize;

    [Tooltip("Event that runs when we recognize a gesture")]
    public UnityEvent OnGestureRecognized;

    [SerializeField]
    [Tooltip("Is this gesture recognizer active right now?")]
    private bool shouldRecognize = true;

    [Tooltip("Minimum required wait time before firing another recogintion event")]
    public float timeBetweenRecognition = 5f;

    [Tooltip("Raising this value will result in more recognition at the cost of precision and accuracy")]
    public float recognitionThreshold = .04f;



    [Tooltip("Enabling this will only trigger recognition when we are certain we can see hands")]
    public bool waitForHighConfidenceData = true;



    //private variables

    private OVRSkeleton skeleton;
    private List<OVRBone> fingerBones;
    private float lastRecognition;
    private OVRHand hand;

    private void Start()
    {
        lastRecognition = timeBetweenRecognition;

        LoadSkeleton();
    }


    private void Update()
    {
        if (gestureToRecognize == null) return;

        lastRecognition += Time.deltaTime;

        if (lastRecognition < timeBetweenRecognition) return;

        if (CheckRecognition())
        {
            Debug.Log("Recognized Gesture" + gestureToRecognize.name);
            OnGestureRecognized?.Invoke();

            lastRecognition = 0f;
            return;
        }

    }

    bool CheckRecognition()
    {
        if(fingerBones.Count == 0) LoadSkeleton();

        if (fingerBones.Count == 0) return false;

        if (!hand.IsTracked) return false;

        if (!hand.IsDataHighConfidence && waitForHighConfidenceData) return false;

        float sumDistance = 0;
        bool isDiscarded = false;
        for (int i = 0; i < fingerBones.Count; i++)
        {
            Vector3 currentData = skeleton.transform.InverseTransformPoint(fingerBones[i].Transform.position);
            float distance = Vector3.Distance(gestureToRecognize.fingerPositions[i], currentData);
            if (distance > recognitionThreshold)
            {
                return false;
            }

            sumDistance = distance;
        }

        Debug.Log("Gesture recognized with sum distance of: " + sumDistance);
        return true;
    }



    void LoadSkeleton()
    {
        OVRSkeleton[] skeletons = FindObjectsOfType<OVRSkeleton>();
        foreach (OVRSkeleton _skeleton in skeletons)
        {
            if (gestureToRecognize.hand == GestureHand.RightHand && _skeleton.GetSkeletonType() == OVRSkeleton.SkeletonType.HandRight)
            {
                skeleton = _skeleton;
            }
            else if (gestureToRecognize.hand == GestureHand.LeftHand && _skeleton.GetSkeletonType() == OVRSkeleton.SkeletonType.HandLeft)
            {
                skeleton = _skeleton;
            }
        }

        fingerBones = new List<OVRBone>(skeleton.Bones);
        hand = skeleton.gameObject.GetComponent<OVRHand>();

        if (fingerBones == null || skeleton == null) Debug.LogWarning("Failed to find skeleton for " + gestureToRecognize.hand + ". Do you have an OVRHandPrefab in the scene and setup?");
    }


}
