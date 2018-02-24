using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueScript : MonoBehaviour {
	public GameObject myPanel;
	public Text myText;

	private bool isShowing;
	private ConversationNode conversation;
	private ConversationNode convToStart;
	private bool scheduledToClose;

	// Use this for initialization
	void Start () {
		scheduledToClose = false;
		HideUI ();
	}
	
	// Update is called once per frame
	void Update () {
		if (isShowing) {
			if (scheduledToClose) {
				HideUI ();
				scheduledToClose = false;
			} else {
				if (Input.GetKeyDown (KeyCode.Space)) {
					if (this.conversation.next != null) {
						UpdateConversation (this.conversation.next);
					} else {
						scheduledToClose = true;
					}
				}
			}
		} else {
			if (convToStart != null) {
				UpdateConversation (convToStart);
				ShowUI ();
				convToStart = null;
			}
		}
	}

	public bool IsShowing() {
		return isShowing;
	}

	private void ShowUI() {
		isShowing = true;
		myPanel.SetActive (true);
	}

	private void HideUI() {
		isShowing = false;
		myPanel.SetActive (false);
		myText.text = "";
	}

	public void StartConversation(ConversationNode conversation) {
		convToStart = conversation;
	}

	void UpdateConversation(ConversationNode conversation) {
		this.conversation = conversation;
		if (conversation.type == ConversationNode.Type.MESSAGE) {
			myText.text = ((Message)conversation).text;
		}
	}
}
