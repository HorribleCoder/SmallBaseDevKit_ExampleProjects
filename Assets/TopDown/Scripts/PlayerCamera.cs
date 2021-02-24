using System;
using UnityEngine;

using SmallBaseDevKit;

using TD.Events;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset;

    private void Start()
    {
        Game.AddEventListner<CameraTargetEventArg>(SetCameraTarget);
    }

    private void LateUpdate()
    {
        transform.position = _target.position + _offset;
    }

    public void SetCameraTarget(object sender, EventArgs eventArgs) 
    {
        var convertEvent = eventArgs as CameraTargetEventArg;

        _target = convertEvent.targetTransform;
    }
}
