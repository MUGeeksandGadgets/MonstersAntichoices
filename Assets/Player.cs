using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	Direction currentDir;
	Vector2 input;
	bool isMoving = false;
	Vector3 startPos;
	Vector3 endPos;
	Vector3 lastPos;
	float t;
	bool noBlock = false;
	bool frozen = false;

	public float walkSpeed = 3f;
	float dist = 0.5f;
	public Sprite northSprite;
	public Sprite eastSprite;
	public Sprite southSprite;
	public Sprite westSprite;

	Vector3 offset;
	bool interact = false;
	RaycastHit2D hit;	
	// Update is called once per frame
	void Update () {
		bool interact = false;
		if (!frozen && Input.GetButtonDown("Fire1")) {
			switch (currentDir) {
				 case Direction.North:
					offset.y = 0.70f;
					hit = Physics2D.Raycast (transform.position + offset, Vector2.up, dist);
					if (hit.collider == null) {
						
					}
					else if (hit.collider.tag == "NPC") {
						hit.collider.gameObject.GetComponent<AttachConversation> ().Use ();
						interact = true;
					}
					break;
				case Direction.East:
					offset.x = 0.65f;
					hit = Physics2D.Raycast (transform.position + offset, Vector2.right, dist);
					if (hit.collider == null) {
						
					}
					else if (hit.collider.tag == "NPC") {
						interact = true;
						hit.collider.gameObject.GetComponent<AttachConversation> ().Use ();
					}
					break;
				case Direction.South:
					offset.y = 0.7f;
				
					hit = Physics2D.Raycast (transform.position - offset, Vector2.down, dist);
					if (hit.collider == null) {
						
					}
					else if (hit.collider.tag == "NPC") {
						interact = false;
						hit.collider.gameObject.GetComponent<AttachConversation> ().Use ();
					} else {
						
					}
					break;
				case Direction.West:
					offset.x = 0.65f;
				
					hit = Physics2D.Raycast (transform.position - offset, Vector2.left, dist);
					if (hit.collider == null) {
						
					}
					else if (hit.collider.tag == "NPC") {
						interact = false;
						hit.collider.gameObject.GetComponent<AttachConversation> ().Use ();
					} else {
						noBlock = true;
					}
					break;
			}
		}
		if (!isMoving && !frozen) {
			offset.x = 0;
			offset.y = 0;
			input = new Vector2 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"));
			if (Mathf.Abs (input.x) > Mathf.Abs(input.y)) {
				input.y = 0;
			} else {
				input.x = 0;
			}
			if (input != Vector2.zero) {
				if (input.x < 0) {
					currentDir = Direction.West;
				}
				if (input.x > 0) {
					currentDir = Direction.East;
				}
				if (input.y > 0) {
					currentDir = Direction.North;
				}

				if (input.y < 0) {
					currentDir = Direction.South;
				}
				//	 = Physics2D.Raycast (transform.position, -Vector2.up);
				switch (currentDir) {
					case Direction.North:
						offset.y = 0.70f;
						gameObject.GetComponent<SpriteRenderer> ().sprite = northSprite;
						hit = Physics2D.Raycast (transform.position + offset, Vector2.up, dist);
						if (hit.collider == null) {
							noBlock = true;
						}
						else if (hit.collider.tag == "Wall" || hit.collider.tag == "NPC" ) {
							noBlock = false;
							print ("Hit Wall");
						} else {
							noBlock = true;
						}
						break;
					case Direction.East:
						offset.x = 0.65f;
						gameObject.GetComponent<SpriteRenderer> ().sprite = eastSprite;
						hit = Physics2D.Raycast (transform.position + offset, Vector2.right, dist);
						if (hit.collider == null) {
							noBlock = true;
						}
						else if (hit.collider.tag == "Wall" || hit.collider.tag == "NPC" ) {
							noBlock = false;
							print ("Hit Wall");
						} else {
							noBlock = true;
						}
						break;
					case Direction.South:
						offset.y = 0.7f;
						gameObject.GetComponent<SpriteRenderer> ().sprite = southSprite;
						hit = Physics2D.Raycast (transform.position - offset, Vector2.down, dist);
						if (hit.collider == null) {
							noBlock = true;
						}
						else if (hit.collider.tag == "Wall" || hit.collider.tag == "NPC" ) {
							noBlock = false;
							print ("Hit Wall");
						} else {
							noBlock = true;
						}
						break;
					case Direction.West:
						offset.x = 0.65f;
						gameObject.GetComponent<SpriteRenderer> ().sprite = westSprite;
						hit = Physics2D.Raycast (transform.position - offset, Vector2.left, dist);
						if (hit.collider == null) {
							noBlock = true;
						}
						else if (hit.collider.tag == "Wall" || hit.collider.tag == "NPC" ) {
							noBlock = false;
							print ("Hit Wall");
						} else {
							noBlock = true;
						}
						break;
				}

				if (noBlock == true) {
					StartCoroutine (Move (transform));
				}
			}
		}
	}
	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "wall") {
			transform.position = lastPos;
			print ("Hit Wall");
		}
	}
	public IEnumerator Move(Transform entity){
		isMoving = true;
		//Gets entity's current pos
		startPos = entity.position;
		t = 0;//Math.sign simply flattens the number to either 1 or -1
		endPos = new Vector3 (startPos.x + System.Math.Sign(input.x), startPos.y + System.Math.Sign (input.y), startPos.z);
		lastPos = entity.position;
		
		while (t < 1f) {
			//Gives the amount of time that it takes to move from block to block
			t += Time.deltaTime * walkSpeed;
			entity.position = Vector3.Lerp(startPos, endPos, t);
			yield return null;
		}

		isMoving = false;
		yield return 0;
	}

	public void Freeze() {
		frozen = true;
	}

	public void Unfreeze() {
		frozen = false;
	}
}

enum Direction{

	North,
	East,
	South,
	West
}
