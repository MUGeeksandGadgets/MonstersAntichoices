using UnityEngine;
using System.Collections;

public class NPC_Behavior : MonoBehaviour
{
	public const float TIME_TO_MOVE_ONCE = 0.4f;

	public Sprite northSprite;
	public Sprite eastSprite;
	public Sprite southSprite;
	public Sprite westSprite;

	public enum Direction { NORTH, EAST, SOUTH, WEST }
	public Direction facing;

	public bool wander;

	private bool frozen;

	private SpriteRenderer spriteRenderer;
	private Vector2 moveFromPos;
	private Vector2 moveToPos;
	private Direction moveDirection;
	private int moveSpaces;
	private float moveBeginTime;

	// Use this for initialization
	void Start ()
	{
		spriteRenderer = GetComponent<SpriteRenderer> ();
		moveSpaces = 0;
		frozen = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		spriteRenderer.sprite = GetSpriteForDirection (facing);

		if (moveSpaces > 0) {
			float now = Time.time;

			if (now >= moveBeginTime + TIME_TO_MOVE_ONCE * moveSpaces) {
				transform.localPosition = new Vector3 (moveToPos.x, moveToPos.y, transform.localPosition.z);
				moveSpaces = 0;
			} else {
				var pos = Vector2.Lerp (moveFromPos, moveToPos, (now - moveBeginTime) / ((float)moveSpaces * TIME_TO_MOVE_ONCE));
				transform.localPosition = new Vector3 (pos.x, pos.y, transform.localPosition.z);
			}
		} else if (wander && !frozen && Random.value > 0.99f) {
			float dirf = Random.value;
			Direction dir = Direction.WEST;
			if (dirf < 0.25) {
				dir = Direction.NORTH;
			} else if (dirf < 0.5) {
				dir = Direction.EAST;
			} else if (dirf < 0.75) {
				dir = Direction.SOUTH;
			}
			Move (dir, 1);
		}
	}

	private Sprite GetSpriteForDirection(Direction direction) {
		switch (direction) {
		case Direction.NORTH:
			return northSprite;
		case Direction.EAST:
			return eastSprite;
		case Direction.SOUTH:
			return southSprite;
		case Direction.WEST:
			return westSprite;
		}

		Debug.Log (direction);
		return null;
	}

	private Vector2 GetOffsetForDirection(Direction direction) {
		switch (direction) {
		case Direction.NORTH:
			return new Vector2 (0.0f, 1.0f);
		case Direction.EAST:
			return new Vector2 (1.0f, 0.0f);
		case Direction.SOUTH:
			return new Vector2 (0.0f, -1.0f);
		case Direction.WEST:
			return new Vector2 (-1.0f, 0.0f);
		}

		Debug.Log (direction);

		return new Vector2 (0.0f, 0.0f);
	}

	private Direction GetDirectionForString(string str) {
		if (str.Equals ("NORTH"))
			return Direction.NORTH;
		else if (str.Equals ("EAST"))
			return Direction.EAST;
		else if (str.Equals ("SOUTH"))
			return Direction.SOUTH;
		else if (str.Equals ("WEST"))
			return Direction.WEST;
		
		return Direction.NORTH;
	}

	public void SetDirection(Direction direction) {
		this.facing = direction;
	}

	public void SetDirection(string name) {
		SetDirection (GetDirectionForString(name));
	}

	public void Move(Direction direction, int numSpaces) {
		SetDirection (direction);

		moveFromPos = new Vector2 (transform.localPosition.x, transform.localPosition.y);
		Debug.Log (moveFromPos);

		var offset = GetOffsetForDirection (direction);

		for (int i = 1; i <= numSpaces; i++) {
			var hit = Physics2D.OverlapPoint (new Vector2(moveFromPos.x + offset.x*i, moveFromPos.y + offset.y*i));
			if (hit != null)
				break;
			moveToPos = new Vector2 (moveFromPos.x + offset.x * i, moveFromPos.y + offset.y * i);
			moveDirection = direction;
			moveSpaces = i;
			moveBeginTime = Time.time;
		}
	}

	public void Move(string direction, int numSpaces) {
		Move (GetDirectionForString(direction), numSpaces);
	}

	public void Freeze() {
		frozen = true;
	}

	public void Unfreeze() {
		frozen = false;
	}
}
