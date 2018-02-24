using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueDefs {
	public static MessageChain getConversation(string name) {
		if (name.Equals ("OakHello")) {
			return new MessageChain ()
				.msg ("Oh, my nephew has arrived.")
				.msg ("Finally!")
				.msg ("I was wondering,\nyou know?")
				.msg ("You didn't come\nto your cousin's\nbirthday.")
				.msg ("Indeed. Do try\nto be friends,\nall right?")
				.msg ("Well, anyway.\nLet's get to it.")
				.msg ("You just turned 10!\nThat means you need a Nomekop!")
				.msg ("Come over here to this table.");
		} else if (name.Equals ("OakTable")) {
			return new MessageChain ()
				.msg ("Hmmm.");
		}

		return null;
	}
}
