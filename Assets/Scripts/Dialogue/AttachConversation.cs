using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachConversation : MonoBehaviour {
	public string conversationName;
	
	private DialogueScript dialogueUI;

	public void Start() {
		dialogueUI = GameObject.Find ("DialogueCanvas").GetComponent<DialogueScript>();
	}

	public void Update() {
		if (!dialogueUI.IsShowing()) {
			if (Input.GetKeyDown (KeyCode.Space)) {
				dialogueUI.StartConversation (DialogueDefs.getConversation (conversationName));
			}
		}
	}
}
