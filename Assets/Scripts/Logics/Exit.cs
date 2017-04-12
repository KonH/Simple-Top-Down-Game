using UnityEngine;

public class Exit : MonoBehaviour {

	bool IsPlayer(Collider2D collider) {
		var go = collider.gameObject;
		return go.CompareTag(GameManager.PlayerTag);
	}

	void OnTriggerEnter2D(Collider2D collision) {
		if ( IsPlayer(collision) ) {
			GameManager.Instance.OnExit();
		}
	}
}
