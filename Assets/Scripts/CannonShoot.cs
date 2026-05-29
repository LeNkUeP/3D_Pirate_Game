using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShoot : MonoBehaviour {

	public GameObject cannonBall;

	public GameObject shootSound;

	public float firePower;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			ShootCannon ();
		}
	}

	public void ShootCannon(){
		GameObject thisCannonBall = Instantiate (cannonBall, transform.position, transform.rotation);
		thisCannonBall.GetComponent<Rigidbody> ().AddRelativeForce (0, 0, firePower, ForceMode.Impulse);
		shootSound.GetComponent<AudioSource> ().enabled = true;
		shootSound.GetComponent<AudioSource> ().Play(0);
	}
}
