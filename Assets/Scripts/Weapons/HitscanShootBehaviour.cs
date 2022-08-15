using UnityEngine;
using Unity.Netcode;

public class HitscanShootBehaviour : NetworkBehaviour {
	[SerializeField]int damage;
	[SerializeField]float hitForce;
	[SerializeField]int fireRate;
	[SerializeField]FireMode fireMode;
	public enum FireMode {semi,full,single};

	MainInput input;

	void Awake(){
		input = new MainInput();

		input.Foot.PrimaryMouse.performed += ctx => {
			Debug.Log("pressed");
		};
		input.Foot.PrimaryMouse.canceled += ctx => {
			Debug.Log("unrpessed");
		};
	}

	void OnEnable(){
		if(IsOwner)
			Debug.Log("enabled and owned");
			input.Foot.Enable();
	}

	void OnDisable(){
		if(IsOwner)
			input.Foot.Disable();
	}
}