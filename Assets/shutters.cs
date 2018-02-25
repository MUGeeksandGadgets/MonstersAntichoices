using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shutters : MonoBehaviour {
	private Animator ani;
	bool cutscene1;
	// Use this for initialization
	void Start () {
		ani = GetComponent<Animator> ();
		cutscene1 = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > 3 && cutscene1 == false) {
			//ani.SetBool ("cutscene1", true);
			ani.SetTrigger ("animTrig");
			cutscene1 = true;
		}
	}
}
