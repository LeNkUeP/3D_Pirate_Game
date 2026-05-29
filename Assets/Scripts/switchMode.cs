using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchMode : MonoBehaviour {

	public GameObject playerCamera;

	public GameObject ship;

	public GameObject shipCamera;

	public GameObject interactionText;

	private bool isDriving;
	private bool isShooting;

	// Use this for initialization
	void Start () {
		ship.GetComponent<Ship>().enabled = false;
		isDriving = false;
		if(Raycast.raycastedObj != null){
			Raycast.raycastedObj.GetComponent<Cannon> ().enabled = false;
		}
		isShooting = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("f") && interactionText.activeSelf) {
			if(Raycast.raycastedObj.name.Equals("Steering_wheel")){
				ship.GetComponent<Rigidbody>().isKinematic = false;
				ship.GetComponent<Ship>().enabled = true;
				shipCamera.SetActive (true);
				isDriving = true;
				playerCamera.SetActive(false);
			}
			if(Raycast.raycastedObj.name.Equals("Cannon")){
				Raycast.raycastedObj.GetComponent<Rigidbody>().isKinematic = false;
				Raycast.raycastedObj.GetComponent<Cannon>().enabled = true;
				Raycast.raycastedObj.transform.GetChild(0).gameObject.SetActive(true);
				Raycast.raycastedObj.transform.GetChild(2).gameObject.GetComponent<CannonShoot>().enabled = true;
				isShooting = true;
				playerCamera.SetActive(false);
			}
			interactionText.SetActive (false);
		}

		if (Input.GetKey ("e") && isDriving) {
			ship.GetComponent<Rigidbody>().isKinematic = true;
			ship.GetComponent<Ship>().enabled = false;
			shipCamera.SetActive (false);
			isDriving = false;
			playerCamera.SetActive(true);
			playerCamera.transform.position = ship.transform.GetChild(0).transform.position;
		}
		// Raycast.raycastedObj war vorher Cannon...genauso oben
		if (Input.GetKey ("e") && isShooting) {
			Raycast.raycastedObj.GetComponent<Rigidbody>().isKinematic = true;
			Raycast.raycastedObj.GetComponent<Cannon>().enabled = false;
			Raycast.raycastedObj.transform.GetChild(0).gameObject.SetActive(false);
			Raycast.raycastedObj.transform.GetChild(2).gameObject.GetComponent<CannonShoot>().enabled = false;
			isShooting = false;
			playerCamera.SetActive(true);
			playerCamera.transform.position = Raycast.raycastedObj.transform.GetChild(1).gameObject.transform.position;
		}
	}
}
