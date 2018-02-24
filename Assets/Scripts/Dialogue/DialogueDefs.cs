using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueDefs {
	public static MessageChain getConversation(string name) {
		if (name.Equals ("hello world"))
			return new MessageChain ()
				.msg ("Hello world!")
			    .msg ("Hi?")
			    .msg ("Who's there?")
			    .msg ("IT'S PIKACHU")
				.choice ("Take it?", () => {
					Debug.Log ("Took it");
				})
				.choice ("Leave it.", () => {
					Debug.Log ("Left it");
				});

		return null;
	}
}
