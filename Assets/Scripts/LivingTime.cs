using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingTime : MonoBehaviour
{
    private void Update()
    {
        if (transform.position.z < -45f) Destroy(gameObject);
    }
}
