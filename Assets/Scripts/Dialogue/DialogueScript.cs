using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueScript : MonoBehaviour {
	public GameObject myPanel;
	public Text myText;

	private bool isShowing;
	private MessageChain conversation;
	private int currentMessage;
	private MessageChain convToStart;
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
					if (this.conversation.Get(currentMessage + 1) != null) {
						UpdateConversation (this.conversation.Get(currentMessage + 1));
						currentMessage += 1;
					} else {
						scheduledToClose = true;
					}
				}
			}
		} else {
			if (convToStart != null) {
				this.conversation = convToStart;
				currentMessage = 0;
				UpdateConversation (this.conversation.Get(0));
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

	public void StartConversation(MessageChain conversation) {
		convToStart = conversation;
	}

	void UpdateConversation(ConversationNode node) {
		if (node.type == ConversationNode.Type.MESSAGE) {
			myText.text = ((Message)node).text;
		}
	}
}
