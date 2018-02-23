using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Message : ConversationNode {
	public string text;

	public Message(string text, ConversationNode parent = null) : base(ConversationNode.Type.MESSAGE, parent) {
		this.text = text;
	}
}
