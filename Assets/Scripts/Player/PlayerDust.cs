using UnityEngine;

public class PlayerDust : MonoBehaviour {

	[SerializeField] Rigidbody2D rb;

	public ParticleSystem dust;

	private void Update() {
		if (rb.velocity.x > 0)
			dust.Play();

		else
			dust.Stop();
	}
}
