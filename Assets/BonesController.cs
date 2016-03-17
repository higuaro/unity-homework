using UnityEngine;
using System.Collections;

public class BonesController : MonoBehaviour {
    [SerializeField]
    private float speed = 1f;
	private Rigidbody2D rigidBody2d;
	private Animator animator;

	// Use this for initialization
	void Start () {
		rigidBody2d = GetComponent <Rigidbody2D> ();
		animator = GetComponent <Animator> ();
	}

	void FixedUpdate () {
		var currentAnimStateInfo = animator.GetCurrentAnimatorStateInfo (0);
		if (currentAnimStateInfo.IsName ("bones-standing")) { 
			if (Random.value < 1f / (60f)) {
				animator.SetTrigger ("walk");
			}
		} else if (currentAnimStateInfo.IsName("bones-walking")) {
			// Nope!
			Vector2 v = new Vector2 (speed, 0);
			rigidBody2d.velocity = v;
		}
	}

	void OnTriggerEnder2D(Collider2D other) {
		//StartAttackingAnimation ();
	}

	void StartAttackingAnimation() {
		animator.SetTrigger ("attack");
	}

	void Flip() {
		speed *= -1;
		var s = transform.localScale;
		s.x *= -1;
		transform.localScale = s;
	}
}
