using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour {

	public static Collector Instance = null;

	public List<string> Inventory = new List<string>();

	void OnEnable() {
		Instance = this;
	}

	void OnDisable() {
		Instance = null;
	}

	void OnTriggerEnter2D(Collider2D collision) {
		TryCollectItem(collision.gameObject);
	}

	void TryCollectItem(GameObject go) {
		var item = go.GetComponent<Item>();
		if( item ) {
			Inventory.Add(item.Name);
			go.SetActive(false);
		}
	}

	public bool Has(string itemName) {
		return Inventory.Contains(itemName);
	}
}
