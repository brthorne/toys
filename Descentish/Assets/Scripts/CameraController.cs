using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	public float translateSpeed = 5;
	public float rotateSpeed = 30;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//TODO lerp
		if(Input.GetButtonDown(Inputs.CameraForward.ToString())){
			//Debug.Log("forward HO!");
			transform.position = transform.position + 
				new Vector3(transform.forward.x * translateSpeed, 0, transform.forward.z * translateSpeed);
		}
		if(Input.GetButtonDown(Inputs.CameraBackward.ToString())){
			//Debug.Log("sound the retreat!!!");
			transform.position = transform.position - 
				new Vector3(transform.forward.x * translateSpeed, 0, transform.forward.z * translateSpeed);
		}
		if(Input.GetButtonDown(Inputs.CameraLeft.ToString())){
			transform.position = transform.position -  
				new Vector3(transform.right.x * translateSpeed, 0, transform.right.z * translateSpeed);
		}
		if(Input.GetButtonDown(Inputs.CameraRight.ToString())){
			transform.position = transform.position + 
				new Vector3(transform.right.x * translateSpeed, 0, transform.right.z * translateSpeed);
		}
		if(Input.GetButtonDown(Inputs.CameraClockwise.ToString())){
			Vector3 targetRotation = new Vector3(transform.eulerAngles.x,
			                                     transform.eulerAngles.y + rotateSpeed,
			                                     transform.eulerAngles.z);
			transform.eulerAngles = targetRotation;
		}
		if(Input.GetButtonDown(Inputs.CameraCounterClockwise.ToString())){
			Vector3 targetRotation = new Vector3(transform.eulerAngles.x,
			                                     transform.eulerAngles.y - rotateSpeed,
			                                     transform.eulerAngles.z);
			transform.eulerAngles = targetRotation;
		}
	}
}
