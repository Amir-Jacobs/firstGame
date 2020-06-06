using UnityEngine;

public class PlayerDust : MonoBehaviour {

	[SerializeField] Rigidbody2D rb;

	public ParticleSystem dust;

	private bool isMoving = false;

	private void Update() {
		if (!dust.isPlaying && (rb.velocity.x > 0 || rb.velocity.x < 0))
			dust.Play();
	}
}
