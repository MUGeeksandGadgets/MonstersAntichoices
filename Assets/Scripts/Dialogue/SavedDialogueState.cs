using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavedDialogueState {
	public MessageChain conversation;
	public int index;

	public SavedDialogueState(MessageChain conversation, int index) {
		this.conversation = conversation;
		this.index = index;
	}
}
