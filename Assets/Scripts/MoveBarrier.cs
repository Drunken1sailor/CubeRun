using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBarrier : MonoBehaviour
{
	private Vector3 _movement = new Vector3(0f, 0f, -3f);
	void FixedUpdate(){
		if(!Player.IsDead) Movement();
	}
	
	void Movement(){
		
		transform.Translate(_movement* GameParameters.SpeedOfBarriers * Time.fixedDeltaTime);
	}
	
}
