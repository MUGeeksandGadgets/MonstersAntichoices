using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	private GameObject player;

	private Vector3 offset;

	void Start(){
		player = GameObject.FindWithTag("Player");
		offset = transform.position - player.transform.position;
	}
	// Update is called once per frame
	void Update () {
		transform.position = player.transform.position + offset;
	}
}
