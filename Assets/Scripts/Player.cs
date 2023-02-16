using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _ObjectOld;
    [SerializeField] private GameObject _ObjectNew;
    [SerializeField] private AudioSource _CollisionAudioSource;
    [SerializeField] private AudioSource _MovingAudioSource;

    public static bool IsDead = false;
    private float _scoreTime1 = 1f;
    private float _LivingTime = 2f;
    private float _ExplosionRadius = 5f;
    private float _ExplosionForce = 100f;

    private void Awake()
    {
        _CollisionAudioSource.volume = 0.3f;
    }

    private void Update()
    {
        if (!IsDead)
        {
            
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                MoveRight();
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                MoveLeft();
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                MoveDown();
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                MoveUp();
            }
            
        }
        
        if (IsDead)
        {
            
            Explode();
            //GameOver();
            if (_LivingTime < 0)
            {
                Destroy(gameObject);

                
            }
            _LivingTime -= Time.deltaTime;
            
        }
        
    }

    private void FixedUpdate()
    {
        if (!IsDead)
        {
            if (_scoreTime1 < 0)
            {
                Score.InstanceScore.AddScore();
                if (_scoreTime1 > 0.5f)
                    _scoreTime1 = 1f;
            }
        }
        _scoreTime1 -= Time.fixedDeltaTime;
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.collider.CompareTag("Barrier"))
        //{
            IsDead = true;
            _ObjectOld.SetActive(false);
            _ObjectNew.SetActive(true);
            OnCollisionSound();
        //}
        
        
    }



    private void MoveRight() 
    {
        if (transform.position.x < 0.8f)
        {
            transform.position = new Vector3(transform.position.x + 0.8f, transform.position.y, transform.position.z);
            _MovingAudioSource.Play();
        }
    }

    private void MoveLeft()
    {
        if (transform.position.x > -0.8f)
        {
            transform.position = new Vector3(transform.position.x - 0.8f, transform.position.y, transform.position.z);
            _MovingAudioSource.Play();
        }
    }
    private void MoveDown()
    {
        if (transform.position.y > 0.5f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.8f, transform.position.z);
            _MovingAudioSource.Play();
        }
    }
    private void MoveUp()
    {
        if (transform.position.y < 2.1f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.8f, transform.position.z);
            _MovingAudioSource.Play();
        }
    }

    
    public void Explode()
    {
        Collider[] overlappedColliders = Physics.OverlapSphere(transform.position, _ExplosionRadius);
        for (int i = 0; i < overlappedColliders.Length; i++)
        {
            if (overlappedColliders[i].CompareTag("Piece"))
            {
                overlappedColliders[i].attachedRigidbody.AddExplosionForce(_ExplosionForce, transform.position, _ExplosionRadius);
            };
        }
    }

    public void OnCollisionSound()
    {
        
        _CollisionAudioSource.Play();
    }

}
