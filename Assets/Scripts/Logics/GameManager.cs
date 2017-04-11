using UnityEngine.SceneManagement;

public class GameManager {
	public const string PlayerTag = "Player";
	public const string WallTag   = "Wall";
	public const string EnemyTag  = "Enemy";
	public const string TrapTag   = "Trap";

	static GameManager _instance = null;

	public static GameManager Instance {
		get {
			if ( _instance == null ) {
				_instance = new GameManager();
			}
			return _instance;
		}
	}

	public void OnCatch() {
		Restart();
	}

	void Restart() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
