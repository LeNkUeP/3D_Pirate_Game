using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ship : MonoBehaviour {

	public GameObject steeringWheel;

	//public CharacterController player;

	private Collider collider;

	public float turnSpeed;
	public float accellerateSpeed;

	private Rigidbody rbody;

	// Use this for initialization
	void Start () {
		rbody = GetComponent<Rigidbody>();

		collider = GetComponent<BoxCollider>();
	}
	
	// Update is called once per frame
	void Update () {
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");

		if(h != 0){
			steeringWheel.transform.Rotate (0, 0, h);
		}

		rbody.AddTorque (0f, h * turnSpeed * Time.deltaTime, 0f);
		rbody.AddForce(transform.forward*v*accellerateSpeed*Time.deltaTime);
		//player.attachedRigidbody.AddForce(transform.forward*v*accellerateSpeed*Time.deltaTime);

		//collider.transform.Rotate(0, h * turnSpeed, 0, Space.Self);

		//collider.attachedRigidbody.AddTorque (0f, h * turnSpeed * Time.deltaTime, 0f);
		//collider.attachedRigidbody.AddForce(transform.forward*v*accellerateSpeed*Time.deltaTime);

		//Vector3 vector = new Vector3 (transform.position.x,transform.position.y,transform.position.z + 1);
		//collider.transform.RotateAround(vector, new Vector3(0,1,0), h*turnSpeed);
		collider.transform.Rotate (Vector3.up, turnSpeed * h, Space.Self);
		//collider.transform.RotateAround(new Vector3(0,1,0), h*turnSpeed);

		//collider.attachedRigidbody.AddTorque (transform.forward*v*accellerateSpeed*Time.deltaTime);
		//collider.transform.Rotate(0, h * turnSpeed * Time.deltaTime, 0, Space.World);
	}
}
