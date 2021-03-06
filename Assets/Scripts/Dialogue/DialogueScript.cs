﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueScript : MonoBehaviour {
	public GameObject myPanel;
	public GameObject choicePanel;
	public Text choiceText;
	public Text myText;

	private bool isShowing;
	private MessageChain conversation;
	private int currentMessage;
	private MessageChain convToStart;
	private int convIndexToStart;
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
				if (Input.GetButtonDown ("Fire1")) {
					currentMessage++;

					while (this.conversation.Get (currentMessage) != null && this.conversation.Get (currentMessage).is_just_code) {
						this.conversation.Get (currentMessage).callback (this);
						if (this.conversation.Get (currentMessage).Continues ()) {
							currentMessage++;
						} else {
							break;
						}
					}

					if (this.conversation.Get(currentMessage) != null) {
						UpdateConversation (this.conversation.Get(currentMessage));
					} else {
						scheduledToClose = true;
					}
				}
			}
		}

		if (convToStart != null) {
			this.conversation = convToStart;
			currentMessage = convIndexToStart;

			while (this.conversation.Get (currentMessage) != null && this.conversation.Get (currentMessage).is_just_code) {
				this.conversation.Get (currentMessage).callback (this);
				if (this.conversation.Get (currentMessage).Continues ()) {
					currentMessage++;
				} else {
					break;
				}
			}

			if (this.conversation.Get (currentMessage) != null) {
				UpdateConversation (this.conversation.Get (currentMessage));
				ShowUI ();
			}

			convToStart = null;
		}
	}

	public bool IsShowing() {
		return isShowing;
	}

	private void ShowUI() {
		isShowing = true;
		if (!conversation.Get (currentMessage).is_just_code) {
			if (conversation.Get (currentMessage).choices.Count > 0) {
				choicePanel.GetComponent<ChoicePanelScript> ().cursor.text = ">";
				choicePanel.SetActive (true);
				choicePanel.GetComponent<ChoicePanelScript> ().UpdateChoices (conversation.Get (currentMessage).choices);
			}
			myPanel.SetActive (true);
		}
	}

	public void HideUI() {
		isShowing = false;
		choicePanel.GetComponent<ChoicePanelScript> ().cursor.text = "";
		choicePanel.SetActive (false);
		myPanel.SetActive (false);
		myText.text = "";
		choiceText.text = "";
	}

	public void StartConversation(MessageChain conversation) {
		convToStart = conversation;
		convIndexToStart = 0;
	}

	public void StartConversation(string name) {
		convToStart = DialogueDefs.getConversation (name);
		convIndexToStart = 0;
	}

	void UpdateConversation(Message node) {
		myText.text = node.text;
		if (isShowing) {
			if (node.choices.Count > 0) {
				choicePanel.GetComponent<ChoicePanelScript> ().cursor.text = ">";
				choicePanel.SetActive (true);
				choicePanel.GetComponent<ChoicePanelScript> ().UpdateChoices (node.choices);
			}
		}
	}

	public SavedDialogueState GetNextState() {
		return new SavedDialogueState (conversation, currentMessage + 1);
	}

	public void ResumeConversation(SavedDialogueState state) {
		convToStart = state.conversation;
		convIndexToStart = state.index;
	}
}
