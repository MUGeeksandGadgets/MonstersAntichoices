using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueDefs {
	public static MessageChain getConversation(string name) {
		// Things we need:
		//   Rotate Camera
		//   Pan Camera
		//   Change sprite animation
		//   Start move
		//   Delay
		//   Change scene (with transition)


		if (name.Equals ("OakHello")) {
			return new MessageChain ()
				.freeze_player ()
				.msg ("Oh, my nephew has arrived.")
				.sound ("intro")
				.wait_seconds (8.0f)
				.msg ("Finally!")
				.unfreeze_player ();
			
		}

		return null;
	}
}
