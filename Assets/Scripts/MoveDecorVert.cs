using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDecorVert : MonoBehaviour
{
	private Vector3 _movementUp = new Vector3(0f, 3f, 0f);
	private Vector3 _movementDown = new Vector3(0f, -3f, 0f);
	private float _speed = 1f;
	private bool _isUp;

    
    private void FixedUpdate()
	{
		if (transform.position.y > 14f) _isUp = true;
		if (transform.position.y < -16f) _isUp = false;

		if (_isUp) MovementDown();
		else MovementUp();
	}

	private void MovementUp()
	{
		transform.Translate(_movementUp * _speed * Time.fixedDeltaTime);
	}
	private void MovementDown()
	{
		transform.Translate(_movementDown * _speed * Time.fixedDeltaTime);
	}
}
