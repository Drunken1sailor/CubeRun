using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDecorHor : MonoBehaviour
{
	private Vector3 _movementLeft = new Vector3(-3f, 0f, 0f);
	private Vector3 _movementRight = new Vector3(3f, 0f, 0f);
	private float _speed = 0.625f;
	private bool _isLeft;


	private void FixedUpdate()
	{
		if (transform.position.x > 9f) _isLeft = false;
		if (transform.position.x < -9f) _isLeft = true;

		if (_isLeft) MovementRight();
		else MovementLeft();
	}

	private void MovementRight()
	{
		transform.Translate(_movementRight * _speed * Time.fixedDeltaTime);
	}
	private void MovementLeft()
	{
		transform.Translate(_movementLeft * _speed * Time.fixedDeltaTime);
	}
}
