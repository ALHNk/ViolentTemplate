using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public bulletType bulletT;
	public enum bulletType {Rocket, Bullet};
	public float Speed;
	public float damage;
	public float explosionForceForRocket, explosioRadius, upwardModifier, RadiusForDamage;
	public LayerMask whatIsSolid;
	public GameObject particles;
	
	
	public float LifeTime;
    // Start is called before the first frame update
    void Start()
    {
	    Destroy(gameObject, LifeTime);
    }

    // Update is called once per frame
    void Update()
    {
	    transform.Translate(Vector3.forward*Speed*Time.deltaTime);
	    RaycastHit hitInfo;
	    
	    if(Physics.Raycast(transform.position, transform.forward, out hitInfo, 1f, whatIsSolid))
	    {
	    	if(hitInfo.collider != null)
	    	{
	    		Instantiate(particles, transform.position, Quaternion.identity);
	    		Collider[] colliders = Physics.OverlapSphere(transform.position, RadiusForDamage);
	    		foreach(Collider coll in colliders)
	    		{
	    			if(bulletT == bulletType.Rocket);
	    			{
	    				if(coll.GetComponent<Rigidbody>() != null)
	    				{
	    					coll.GetComponent<Rigidbody>().AddExplosionForce(explosionForceForRocket, transform.position, explosioRadius, upwardModifier ,ForceMode.Impulse);
	    				}
	    			}
	    		}
	    		
	    		Destroy(gameObject);
	    	}
	    }
    }
}
