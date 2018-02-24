using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageChain {
	private List<ConversationNode> list;

	public MessageChain() {
		list = new List<ConversationNode> ();
	}

	public MessageChain msg(string text) {
		list.Add (new Message (text));
		return this;
	}

	public ConversationNode Get(int index) {
		if (index < 0 || index >= list.Count)
			return null;
		
		return list [index];
	}
}
