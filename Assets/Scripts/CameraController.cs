using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using Cinemachine;

public class CameraController : NetworkBehaviour
{
    [Header("Camera")]
    [SerializeField]
    private CinemachineVirtualCamera virtualCamera;
    [SerializeField]private Vector2 maxFollowOffset = new Vector2(-1f, 6f);
    [SerializeField]private Vector2 cameraVelocity = new Vector2(4f, 0.25f);
    [SerializeField]private Transform playerTransform;
    private CinemachineTransposer transposer;

    private MainInput input;
    private MainInput Input {
        get {
            if(input != null) {return input;}
            return input = new MainInput();
        }
    }

    public override void OnNetworkSpawn(){
        transposer = virtualCamera.GetCinemachineComponent<CinemachineTransposer>();
        virtualCamera.gameObject.SetActive(true);

        enabled = true;
        Input.Foot.Look.performed += ctx => Look(ctx.ReadValue<Vector2>());
    }  
    void OnEnable(){
        if(IsLocalPlayer)
            Input.Enable();
    }
    void OnDisable(){
        if(IsLocalPlayer)
            Input.Disable();
    }

    private void Look(Vector2 lookAxis){
        float deltaTime = Time.deltaTime;
        float followOffset = Mathf.Clamp(
            transposer.m_FollowOffset.y - (lookAxis.y * cameraVelocity.y * deltaTime),
            maxFollowOffset.x,
            maxFollowOffset.y
        );

        transposer.m_FollowOffset.y = followOffset;
        playerTransform.Rotate(0f, lookAxis.x * cameraVelocity.x * deltaTime, 0f);
        

    }
}
