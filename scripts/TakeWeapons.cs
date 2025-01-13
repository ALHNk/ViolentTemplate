using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeWeapons : MonoBehaviour
{
	[SerializeField] GameObject RocketShooter;
	
	private GameObject TakenWeapon;
	private bool IsTaken = false;
	Dictionary<string, GameObject> weapons;
	private string ActiveWeapon;
    // Start is called before the first frame update
    void Start()
	{
		weapons = new Dictionary<string, GameObject>();
		RocketShooter.SetActive(false);
		weapons.Add("rocket", RocketShooter);
    }

	// OnTriggerEnter is called when the Collider other enters the trigger.
	protected void OnTriggerEnter(Collider other)
	{
		if(other.tag == "RocketShooter")
		{
			ActiveWeapon = "rocket";
			weapons[ActiveWeapon].SetActive(true);
			other.gameObject.SetActive(false);
			TakenWeapon = other.gameObject;
			TakenWeapon.transform.SetParent(transform);
			TakenWeapon.transform.localPosition = Vector3.zero;
			IsTaken = true;
			
			
		}
	}
	
	protected void Update()
	{
		if(IsTaken && Input.GetKey(KeyCode.Q))
		{
			TakenWeapon.SetActive(true);
			TakenWeapon.transform.SetParent(null);
			TakenWeapon.transform.position = transform.position + new Vector3(0,0,5);
			IsTaken = false;
			TakenWeapon = null;
			weapons[ActiveWeapon].SetActive(false);
		}
	}
	
}
