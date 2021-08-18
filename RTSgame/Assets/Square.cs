using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    private float _speed = 4f;
    private Vector3 _targetPosition;
    private bool _isMoving = false;

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            SetTargetPosition();
        }

        if (_isMoving)
        {
            Move();
        }
    }

    void SetTargetPosition()
    {
        _targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _targetPosition.z = transform.position.z;

        _isMoving = true;
    }

    void Move()
    {
        transform.rotation = Quaternion.LookRotation(Vector3.forward, _targetPosition);
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
        if (transform.position == _targetPosition)
        {
            _isMoving = false;
        }
    }
}
