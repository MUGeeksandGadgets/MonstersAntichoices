using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationNode {
	public enum Type { MESSAGE, CHOICE };

	public Type type;
	public ConversationNode parent, next;

	public ConversationNode(Type type, ConversationNode parent) {
		this.type = type;
		this.parent = parent;
	}

	public ConversationNode getRoot() {
		if (parent == null) {
			return this;
		} else {
			return parent.getRoot ();
		}
	}

	public ConversationNode thenMsg(string text) {
		this.next = new Message (text, this);
		return this.next;
	}
}
