using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shutters : MonoBehaviour {
	private Animator ani;
	bool cutscene1;
	// Use this for initialization
	void Start () {
		ani = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > 3) {
			ani.SetBool ("cutscene1", true);
		}
	}
}
