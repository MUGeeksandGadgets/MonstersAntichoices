using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueDefs {
	public static ConversationNode getConversation(string name) {
		if (name.Equals("hello world"))
			return new Message("Hello world!")
			         .thenMsg ("Hi?")
			         .thenMsg ("Who's there?")
			         .thenMsg ("IT'S PIKACHU")
			         .getRoot ();

		return null;
	}
}
