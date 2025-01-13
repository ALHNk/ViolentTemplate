using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : MonoBehaviour
{
	[SerializeField] GameObject Rocket;
	public Transform ShootPosition;
	public GameObject bullet;
	
	private Quaternion InitialRotation;
	private Vector3 InitialPosition;
    // Start is called before the first frame update
    void Start()
    {
	    InitialRotation = transform.localRotation;
	    InitialPosition = transform.localPosition;
    }

	// Update is called once per frame
	Quaternion TargetRotation = Quaternion.Euler(-10,0,0);
	float TurningSpeed = 5f;
	
	Vector3 TargetPosition = new Vector3(-0.1f, 0.2f, 0f);
	float MovingSpeed = 6f;
	
    void Update()
    {
	    if(Input.GetKey(KeyCode.Mouse1))
	    {
		    transform.localRotation = Quaternion.Lerp(transform.localRotation, TargetRotation, TurningSpeed * Time.deltaTime);
		    transform.localPosition = Vector3.Lerp(transform.localPosition, TargetPosition, MovingSpeed * Time.deltaTime);
		    if(Input.GetKeyDown(KeyCode.Mouse0))
		    {
		    	Instantiate(bullet, ShootPosition.position, ShootPosition.rotation);
		    }
	    }
	    else
	    {
	    	transform.localRotation = Quaternion.Lerp(transform.localRotation, InitialRotation, TurningSpeed * Time.deltaTime);
	    	transform.localPosition = Vector3.Lerp(transform.localPosition, InitialPosition, MovingSpeed * Time.deltaTime);
	    }
    }
    
	public void Launch()
	{
		Instantiate(Rocket, ShootPosition.transform.position, ShootPosition.transform.rotation);
	}
    
}
