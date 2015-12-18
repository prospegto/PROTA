using UnityEngine;
using System.Collections;

public class TriggerModify : MonoBehaviour {


	public ManejarPJ pj;
	bool instantiate = true;

	void OnTriggerEnter(Collider coll){
		
		if(coll.gameObject.tag == "Player"){
			if(instantiate)
			pj.SendMessage("ApplyDamage", 1);
			instantiate = false;
		}

	}
}
