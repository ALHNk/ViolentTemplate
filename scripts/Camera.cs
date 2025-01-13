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

    // Start is called before the first frame update
    void Start()
    {
	    UnityEngine.Cursor.lockState = CursorLockMode.Locked;
	    Cursor.visible = false;

    }

    // Update is called once per frame
    void Update()
	{
		if(weapon == null)
		{
			weapon = GameObject.FindGameObjectWithTag("Weapon");
		}
	    CameraMotion();
    }
    
	public void CameraMotion()
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

}
