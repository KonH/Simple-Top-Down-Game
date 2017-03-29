using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Catchable : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D collision) {
		if ( collision.transform.CompareTag(GameManager.EnemyTag) ) {
			GameManager.Instance.OnCatch();
			enabled = false;
		}
	}
}
