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
				.choice ("Take it?", (dlg) => {
					Debug.Log ("Took it");
					dlg.StartConversation(new MessageChain().msg("Well... you took it."));
				})
				.choice ("Leave it.", (dlg) => {
					Debug.Log ("Left it");
					dlg.StartConversation(new MessageChain().msg("You left it."));
				});

		return null;
	}
}
