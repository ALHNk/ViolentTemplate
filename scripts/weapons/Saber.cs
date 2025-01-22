using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saber : MonoBehaviour
{
	private Quaternion InitialRotation;
	private Vector3 InitialPosition;
	private Animator anim;
	public string animationOfBit, animationOfStay;
	// Start is called before the first frame update
	void Start()
	{
		InitialRotation = transform.localRotation;
		InitialPosition = transform.localPosition;
		
		anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	Quaternion TargetRotation = Quaternion.Euler(0,0,0);
	float TurningSpeed = 5f;
	
	Vector3 TargetPosition = new Vector3(0.1f, 0.2f, 0.3f);
	float MovingSpeed = 6f;
	

	
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Mouse0))
		{
			StartCoroutine(bit());
		}
		else if(Input.GetKey(KeyCode.Mouse1))
		{
			transform.localRotation = Quaternion.Lerp(transform.localRotation, TargetRotation, TurningSpeed * Time.deltaTime);
			transform.localPosition = Vector3.Lerp(transform.localPosition, TargetPosition, MovingSpeed * Time.deltaTime);
		}
		else
		{
			transform.localRotation = Quaternion.Lerp(transform.localRotation, InitialRotation, TurningSpeed * Time.deltaTime);
			transform.localPosition = Vector3.Lerp(transform.localPosition, InitialPosition, MovingSpeed * Time.deltaTime);
		}
	}
	
	IEnumerator bit()
	{
		anim.Play(animationOfBit);
		yield return new WaitForSeconds(0.45f);
		anim.Play(animationOfStay);
	}
	
}
