using UnityEngine;
using System.Collections;

public class LoadPuzzle : MonoBehaviour {

	void OnTriggerEnter(Collider coll){
		
		if(coll.gameObject.tag == "Player"){
			PlayerPrefs.SetInt("LevelPuzzle", 3);
			Application.LoadLevel("Puzzle");
		}
		

	}
}
