using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorWay : MonoBehaviour {

	public GameObject doorwayTarget;
	public GameObject offsetObj;
	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Player") {
			coll.gameObject.transform.position = doorwayTarget.gameObject.transform.position;
			print ("Got here");
		}
		print ("Called Collision");
	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag == "Player") {
			coll.gameObject.transform.position = doorwayTarget.gameObject.transform.position + offsetObj.gameObject.transform.localPosition;
			print ("Got here");
		}
		print ("Called Collision");
	}

}
