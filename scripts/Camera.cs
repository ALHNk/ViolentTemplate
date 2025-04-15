using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
	public float sensX, sensY;
	public Transform orientation;
	public GameObject player;
	float xRotation, yRotation;
	private GameObject weapon;
	private bool isThirdView;
	public Transform thirdViewPosition, firstViewPostition;
	private Vector3 offset;

    // Start is called before the first frame update
    void Start()
	{
		if(!PlayerPrefs.HasKey("View"))
		{
			PlayerPrefs.SetInt("View", 1);
		}
		if(PlayerPrefs.GetInt("View") == 3)
		{
			isThirdView = true;
			transform.position = thirdViewPosition.position;
		}
		else
		{
			isThirdView = false;
			transform.position = firstViewPostition.position;
		}
		
	    UnityEngine.Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		if(weapon == null)
		{
			weapon = GameObject.FindGameObjectWithTag("Weapon");
		}
		
		offset = new Vector3(-2,2, -5);

    }

    // Update is called once per frame
    void Update()
	{
		
		if(!isThirdView)
		{
			CameraFirstViewMotion();
		}
		else
		{
			CameraThirdViewMotion();
		}
		
		if(Input.GetKeyDown(KeyCode.C))
		{
			if(isThirdView == false)
			{
				isThirdView = true;
				PlayerPrefs.SetInt("View", 3);
				transform.position = thirdViewPosition.position;

			}
			else
			{
				isThirdView = false;
				PlayerPrefs.SetInt("View", 1);
				transform.position = firstViewPostition.position;

			}
			
		}
    }
    
	public void CameraFirstViewMotion()
	{
		float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
		float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensX;
	    
		yRotation += mouseX;
		xRotation -= mouseY;
		xRotation = Mathf.Clamp(xRotation, -90f, 90f);
	    
		transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
		player.transform.rotation = Quaternion.Euler(0, yRotation, 0);
		orientation.rotation = Quaternion.Euler(0, yRotation, 0);
		if(weapon != null)
		{
			weapon.transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
		}
	}
	
	public void CameraThirdViewMotion()
	{
		float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
		float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensX;
		
		yRotation += mouseX;
		xRotation -= mouseY;
		xRotation = Mathf.Clamp(xRotation, -30f, 10f);
		
		Quaternion rotation = Quaternion.Euler(xRotation, yRotation, 0);
		Vector3 direction = rotation * Vector3.back;

		transform.position = player.transform.position + direction * Mathf.Abs(offset.z) + Vector3.up * offset.y;
		transform.rotation = rotation;
		player.transform.rotation = Quaternion.Euler(0, yRotation, 0);
	}

}
