using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour {

	private Rigidbody rbody;

	public GameObject interactionText;

	private GameObject sockel;

	public float moveSpeed = 0.2f;

	public float rotateSpeed = 0.4f;

	// Use this for initialization
	void Start () {
		sockel = transform.parent.gameObject;

		rbody = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update () {
		bool canRotate = false;
		float v = Input.GetAxis("Vertical");
		float h = Input.GetAxis("Horizontal");

		if (v > 0) {
			if (transform.localRotation.x > -20) {
				canRotate = true;
			}
		} else {
			if(transform.localRotation.x < 20){
				canRotate = true;
			}
		}

		sockel.GetComponent<Rigidbody>().transform.Rotate (new Vector3(0,0,1), moveSpeed * h, Space.Self);

		if(canRotate){
			//transform.parent = null;
			rbody.transform.Rotate (new Vector3(0,1,0), rotateSpeed * v, Space.Self);
			//collider.transform.Rotate (new Vector3(0,1,0), moveSpeed * v, Space.Self);
		}
	}
}
