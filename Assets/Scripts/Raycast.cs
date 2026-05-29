using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Raycast : MonoBehaviour {

	public static GameObject raycastedObj;

	[SerializeField] private float rayLength = 1.4f;
	[SerializeField] private LayerMask LayerMask;

	[SerializeField] private Text interactionText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		Vector3 fwd = transform.TransformDirection(Vector3.forward);

		Debug.DrawRay(transform.position, fwd, Color.cyan);

		if (Physics.Raycast (transform.position, fwd, out hit, rayLength, LayerMask.value)) {
			if (hit.collider.CompareTag ("interactionObject")) {
				interactionText.gameObject.SetActive (true);
				raycastedObj = hit.rigidbody.gameObject;
			}
		} else {
			interactionText.gameObject.SetActive (false);
		}
	}
}
