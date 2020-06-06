using UnityEngine;

public class PlayerGrounded : MonoBehaviour {

	[SerializeField] private Transform groundPosition;
	[SerializeField] private float boxLength;
	[SerializeField] private float boxHeight;

	[SerializeField] private LayerMask whatIsGround;

	public float lastTimeGrounded;

	public bool isGrounded = false;

	private void OnDrawGizmos() {
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(groundPosition.position, new Vector2(boxLength, boxHeight));
	}

	private void Update() {
		isGrounded = Physics2D.OverlapBox(groundPosition.position, new Vector2(boxLength, boxHeight), 0, whatIsGround);

		if (isGrounded) lastTimeGrounded = Time.time;
	}
}
