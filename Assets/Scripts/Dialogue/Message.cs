using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Message : ConversationNode {
	public string text;

	public Message(string text) : base(ConversationNode.Type.MESSAGE) {
		this.text = text;
	}
}
