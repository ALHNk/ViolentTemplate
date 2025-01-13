using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDestroy : MonoBehaviour
{
	private float lifeTime = 2f;
    // Start is called before the first frame update
    void Start()
    {
	    Destroy(gameObject, lifeTime);
    }

}
