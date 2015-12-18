using UnityEngine;
using System.Collections;

public class SpikesDamage : MonoBehaviour {

	public ManejarPJ pj;
	public Transform explosionPrefab;
	bool instantiate = true;
	
	void OnCollisionEnter(Collision collision) {

		if(collision.transform.tag == "Player"){
			collision.transform.GetComponent<Rigidbody>().AddForce(Vector3.forward * 5, ForceMode.Impulse);
			if(instantiate){
				pj.SendMessage("ApplyDamage", 1);
				ContactPoint contact = collision.contacts[0];
				Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
				Vector3 pos = contact.point;
				Instantiate(explosionPrefab, pos, rot);
			}
			instantiate = false;
		}
	}
}
