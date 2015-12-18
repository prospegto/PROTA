using UnityEngine;
using System.Collections;

public class ReactionBurn : MonoBehaviour {


	public ManejarPJ pj;

	void OnSelect(string command){
		if(command == "Quemar")
			pj.SendMessage("AttackFire", transform.position);
	}
}
