using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnBarriers : MonoBehaviour
{
	[SerializeField] private GameObject [] _barrierPrefab;
	//[SerializeField] private Text SpawnTime;
	public static float Time = 150f;
	public static float SeriesTime = 50f;
	private static float _coinPositionZ = 65f;
	private Vector3[] _strawBarrierPosition =  new Vector3[3];
	private Vector3[] _coinPosition = new Vector3 [9];
	
	
	public static float _time;
	private int _acTime;
	private int _rand;
	private int _rand2;
	private int _randPrefab;
	private int _randPos;
	private bool _isSeries = false;
	private float _seriesTime = 50f;


	void Start()
    {
		_acTime = GameParameters.AccelerationTime;
		_time = 0;

		_strawBarrierPosition[0] = new Vector3(-0.9f, 0f, 70f);
		_strawBarrierPosition[1] = new Vector3(0f, 0f, 70f);
		_strawBarrierPosition[2] = new Vector3(0.9f, 0f, 70f);

		_coinPosition[0] = new Vector3(-0.8f, 0.5f, _coinPositionZ);
		_coinPosition[1] = new Vector3(0f, 0.5f, _coinPositionZ);
		_coinPosition[2] = new Vector3(0.8f, 0.5f, _coinPositionZ);
		_coinPosition[3] = new Vector3(-0.8f, 1.3f, _coinPositionZ);
		_coinPosition[4] = new Vector3(0f, 1.3f, _coinPositionZ);
		_coinPosition[5] = new Vector3(0.8f, 1.3f, _coinPositionZ);
		_coinPosition[6] = new Vector3(-0.8f, 2.1f, _coinPositionZ);
		_coinPosition[7] = new Vector3(0f, 2.1f, _coinPositionZ);
		_coinPosition[8] = new Vector3(0.8f, 2.1f, _coinPositionZ);
}

    void FixedUpdate()
    {
		if (!GameParameters.Pause && !Player.IsDead)
		{
			
			_time--;
			_seriesTime--;
			if (_seriesTime<0)
            {
				_rand2 = Random.Range(0, 4);
				if (_rand2 == 0) _isSeries = true;
				else _isSeries = false;

				_seriesTime = SeriesTime;
			}
			if (_time < 0)
			{

				if (!_isSeries)
				{
					BigBarriersSpawn();

					_rand2 = Random.Range(0, 2);
					if (_rand2 == 1) StrawBarrierSpawn();

					_rand2 = Random.Range(0, 2);
					if (_rand2 == 1) CoinSpawn();
					_time = Time;
				}
				else
				{
					StrawBarrierSpawn();
					

					_rand2 = Random.Range(0, 2);
					if (_rand2 == 1) CoinSpawn();

					_time = Time/4;
				}
				
			}
			

            if (_acTime < 0)
            {
				if (Time > 70) Time *= 0.9f;
				_acTime = GameParameters.AccelerationTime;
			}
			_acTime--;
		}
	}
    

    private void BigBarriersSpawn(){
		_randPrefab = Random.Range(3, 14);
		Instantiate(_barrierPrefab[_randPrefab], _barrierPrefab[_randPrefab].transform.position, _barrierPrefab[_randPrefab].transform.rotation);
	}
	
	private void StrawBarrierSpawn(){
		_randPrefab = Random.Range(0, 3);
		
		if (_randPrefab == 0)
		{
			_randPos = Random.Range(0, 9);
			Instantiate(_barrierPrefab[_randPrefab], _coinPosition[_randPos] + new Vector3(0,0,5f), _barrierPrefab[_randPrefab].transform.rotation);
		}
        else
        {
			_randPos = Random.Range(0, 3);
			Instantiate(_barrierPrefab[_randPrefab], _strawBarrierPosition[_randPos], _barrierPrefab[_randPrefab].transform.rotation);
		}
	}
	private void CoinSpawn()
	{
		_randPos = Random.Range(0, 9);
		_randPrefab = 14;
		Instantiate(_barrierPrefab[_randPrefab], _coinPosition[_randPos], _barrierPrefab[_randPrefab].transform.rotation);

	}

	public static void ResetSpawnTime()
    {
		Time = 150f;
    }
}
