using UnityEngine;
using System.Collections;

public class ActivateAllAnimations : MonoBehaviour {


	void Start(){
		Destroy(gameObject, 3f);
	}

	void OnCollisionEnter(Collision coll){
		
		if(coll.gameObject.tag == "Animacion" || coll.gameObject.tag == "Madera"){
			coll.gameObject.GetComponent<Animator>().SetTrigger("Activate");
		}
		
		
	}
}
