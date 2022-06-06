
using UnityEngine;
using UnityEngine.EventSystems;

public class HandPointerLike : MonoBehaviour
{
 
    public OVRInputModule _OVRInputModule;
 
    public OVRRaycaster _OVRRaycaster;
 
    public OVRHand _OVRHand;
 
 
    void Start(){
 
        _OVRInputModule.rayTransform = _OVRHand.PointerPose;
        _OVRRaycaster.pointer = _OVRHand.PointerPose.gameObject;
     
    }
 
    void Update(){
            _OVRInputModule.rayTransform = _OVRHand.PointerPose;
            _OVRRaycaster.pointer = _OVRHand.PointerPose.gameObject;
    }
 
}