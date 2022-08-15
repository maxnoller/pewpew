using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.InputSystem;

public class InputHandler : NetworkBehaviour
{

    CameraController cameraController;
    MovementController movementController;
    MainInput input;
    void Awake(){
        input = new MainInput();
        cameraController = GetComponent<CameraController>();
        movementController = GetComponent<MovementController>();

        setupListeners();
    }

    void setupListeners(){
    }

	public override void OnNetworkSpawn()
	{
		enabled = true;
	}

    void OnEnable(){
        Debug.Log("onenable");
        if(IsLocalPlayer){
            Debug.Log("test");
            input.Foot.Enable();
        }
    }

    void OnDisable(){
        if(IsLocalPlayer)
            input.Foot.Disable();
    }


}
