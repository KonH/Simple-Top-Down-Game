using UnityEngine;

public class EnemyTrap : MonoBehaviour, IStateHolder {

	public float Timeout = 0;

	public State State { get; private set; }

	void Awake() {
		State = State.Idle;
	}

	void Start() {
		Resume();
	}

	void OnTriggerEnter2D(Collider2D collision) {
		var go = collision.gameObject;
		if ( go.CompareTag(GameManager.EnemyTag) ) {
			var enemy = go.GetComponent<Enemy>();
			if ( enemy ) {
				enemy.Sleep();
				Sleep();
				Invoke("Resume", Timeout);
			}
		}
	}

	void Sleep() {
		State = State.Sleep;
		enabled = false;
	}

	void Resume() {
		State = State.Idle;
		enabled = true;
	}
}
