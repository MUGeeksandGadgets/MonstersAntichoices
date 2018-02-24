using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachConversation : MonoBehaviour {
	public string conversationName;

	private GameObject player;
	private DialogueScript dialogueUI;

	public void Start() {
		player = GameObject.Find ("Player");
		dialogueUI = GameObject.Find ("DialogueCanvas").GetComponent<DialogueScript>();
	}

	public void Update() {
		if (!dialogueUI.IsShowing()) {
			// If the player hits SPACE while close to this object, activate the dialogue
			float distX = player.transform.localPosition.x - transform.localPosition.x;
			float distY = player.transform.localPosition.y - transform.localPosition.y;
			if (Input.GetKeyDown (KeyCode.Space) && Mathf.Sqrt(distX*distX + distY*distY) < 1.8f) {
				dialogueUI.StartConversation (DialogueDefs.getConversation (conversationName));
			}
		}
	}
}
