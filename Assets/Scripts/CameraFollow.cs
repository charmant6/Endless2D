using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float _followSpeed;
    [SerializeField] private Vector2 _clampValue;
    [SerializeField] private Vector2 _clampValueX;
    [SerializeField] private Transform _followPos;
    [SerializeField] private Vector3 _offSet;

    private Transform _transformRef;

    private void Awake()
    {
        _transformRef = transform; 
    }
    private void FixedUpdate()
    {
        var movePos = _followPos.position + _offSet;
        movePos.z = -5f;

        movePos.y = Mathf.Clamp(movePos.y, _clampValue.x, _clampValue.y);
        movePos.x = Mathf.Clamp(movePos.x,_clampValueX.x, _clampValueX.y);



        _transformRef.position = Vector3.Lerp(_transformRef.position, movePos, _followSpeed * Time.fixedDeltaTime);

    }
}
