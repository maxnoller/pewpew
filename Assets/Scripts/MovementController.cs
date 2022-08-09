using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour {
    
    [SerializeField]Animator animator;
    MainInput input;
    Vector2 currentMovement;
    bool movementPressed;
    bool runPressed;

    void Awake(){
        input = new MainInput();

        input.Foot.Movement.performed += ctx => {
            currentMovement = ctx.ReadValue<Vector2>();
            movementPressed = currentMovement.x != 0 || currentMovement.y != 0;
        };
        input.Foot.Run.performed += ctx => runPressed = ctx.ReadValueAsButton();
        input.Foot.Movement.canceled += ctx => currentMovement = Vector2.zero;
    }

    void Update(){
        handleMovement();
    }
    void OnEnable(){
        input.Foot.Enable();
    }

    void handleMovement(){
        float y = currentMovement.y/2;
        if(runPressed){
            y = y*2;
        }
        animator.SetFloat("speed_y", y, 0.05f, Time.deltaTime);
        animator.SetFloat("speed_x", currentMovement.x, 0.05f, Time.deltaTime);
    }
}