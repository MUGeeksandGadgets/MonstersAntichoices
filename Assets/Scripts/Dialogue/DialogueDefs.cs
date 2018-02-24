using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueDefs {
	public static MessageChain getConversation(string name) {
		if (name.Equals ("OakHello")) {
			return new MessageChain ()
				.freeze_player ()
				.msg ("Oh, my nephew has arrived.")
				.msg ("Finally!")
				.msg ("I was wondering,\nyou know?")
				.msg ("You didn't come\nto your cousin's\nbirthday.")
				.msg ("Indeed. Do try\nto be friends,\nall right?")
				.msg ("Well, anyway.\nLet's get to it.")
				.msg ("You just turned 10!\nThat means you need a Nomekop!")
				.msg ("Come over here to this table.")
				.choice ("Yes", "OakYes")
				.choice ("No", "OakNo");
			
		} else if (name.Equals ("OakYes")) {
			return new MessageChain ()
				.msg ("I'll give you a\nchoice of three.")
				.unfreeze_player ();
			
		} else if (name.Equals ("OakNo")) {
			return new MessageChain ()
				.msg ("No?")
				.unfreeze_player ();
			
		}

		return null;
	}
}
