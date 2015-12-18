using UnityEngine;
using System.Collections;

public class TriggerDelete : MonoBehaviour {

	void OnTriggerEnter(Collider coll){

		Destroy(coll.gameObject);

	}
}
