using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationNode {
	public enum Type { MESSAGE, CHOICE };

	public Type type;

	public ConversationNode(Type type) {
		this.type = type;
	}
}
