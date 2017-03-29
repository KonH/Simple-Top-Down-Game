using UnityEngine;

public class EnemyTarget : MonoBehaviour {

	public static EnemyTarget Instance = null;

	void OnEnable() {
		Instance = this;
	}

	void OnDisable() {
		Instance = null;
	}

}
