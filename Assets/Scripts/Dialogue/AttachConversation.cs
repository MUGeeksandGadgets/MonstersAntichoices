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

	public void Use() {
		if (!dialogueUI.IsShowing ()) {
			dialogueUI.StartConversation (DialogueDefs.getConversation (conversationName));
		}
	}
}
