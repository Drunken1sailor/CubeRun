using UnityEngine;



	public class CameraMove : MonoBehaviour {

		[SerializeField] private float _time = 10f;
		[SerializeField] private HingeJoint _movingCamera;

		public static bool _movementAccess = false;
		private bool _odd = true, _shopIsActive = false;
		private float _time2;
		private JointSpring jointSpring;


		void Start(){
			jointSpring = _movingCamera.spring;
			_time2 = 0;
		}

		
        void FixedUpdate() {
			//if (_movementAccess)
			//{
				if (_time2 < 0)
				{
					MoveCamera();
					_time2 = _time;
				}
				_time2 -= Time.fixedDeltaTime;
			//}
        }
		
		void MoveCamera (){
			if(_odd){
				jointSpring.targetPosition = -20f;
				_movingCamera.spring = jointSpring;
					_odd = false;
			}
			else {
				jointSpring.targetPosition = 20f;
				_movingCamera.spring = jointSpring;
				_odd = true;
			}
		}

		public void CameraShopView()
        {
			if (_shopIsActive)
		{
			_shopIsActive = false;
			jointSpring.targetPosition = 0f;
			_movingCamera.spring = jointSpring;
			jointSpring.spring = 15;
			jointSpring.damper = 80;
			_movingCamera.spring = jointSpring;
		}
			else
		{
			_shopIsActive = true;
			jointSpring.spring = 2000;
			jointSpring.damper = 1000;
			jointSpring.targetPosition = -80f;
			_movingCamera.spring = jointSpring;
		}
			Debug.Log("_shopIsActive = " + _shopIsActive);
		}
        

        

    }



