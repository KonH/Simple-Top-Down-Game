using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Catchable : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D collision) {
		var go = collision.gameObject;
		if ( go.CompareTag(GameManager.EnemyTag) ) {
			var enemy = go.GetComponent<Enemy>();
			if ( enemy.enabled ) {
				GameManager.Instance.OnCatch();
				enabled = false;
			}
		}
	}
}
