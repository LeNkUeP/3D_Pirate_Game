using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour {

	public CharacterController player;

	public bool canClimb;

	public int speed;

	// Use this for initialization
	void Start () {
	}

	void OnCollisionEnter (Collision coll){
		print ("ENTERED");
		if(coll.gameObject.tag == "Player"){
			canClimb = true;
		}
	}

	void OnCollisionExit (Collision coll2){
		print ("EXITED");
		if(coll2.gameObject.tag == "Player"){
			canClimb = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(canClimb){
			print ("CANCLIMB");
			if(Input.GetKey(KeyCode.W)){
				player.transform.Translate (new Vector3(0,1,0) * Time.deltaTime * speed);
			}

			if(Input.GetKey(KeyCode.S)){
				player.transform.Translate (new Vector3(0,-1,0) * Time.deltaTime * speed);
			}
		}
	}
}
