using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements.Experimental;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;

    [SerializeField] private PerspectiveManager perspectiveManager;

    public static Vector2 Movement;
    private InputAction moveAction;

    public static Vector2 BowlMovement;
    public static Vector2 MousePosition;
    private InputAction bowlMoveAction;
    private InputAction mouseMoveAction;

    private InputAction mouseInteract;

    private string currentActionMap = "ThirdPerson";
    private bool canSwitchPerspective = false;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        SetActionMap(currentActionMap);
    }

    private void OnEnable()
    {
        playerInput.actions["Interact"].performed += TryInteractSpace;
        playerInput.actions["ExitFirstPerson"].performed += TryInteractSpace;
        playerInput.actions["MouseInteract"].performed += TryInteractMouse;
    }

    private void OnDisable()
    {
        playerInput.actions["Interact"].performed -= TryInteractSpace;
        playerInput.actions["ExitFirstPerson"].performed -= TryInteractSpace;
        playerInput.actions["MouseInteract"].performed -= TryInteractMouse;
    }

    private void Update()
    {
        if(moveAction != null)
        {
            Movement = moveAction.ReadValue<Vector2>();
        }

        if(bowlMoveAction != null)
        {
            BowlMovement = bowlMoveAction.ReadValue<Vector2>();
        }

        if(mouseMoveAction != null)
        {
           MousePosition = mouseMoveAction.ReadValue<Vector2>(); 
        }
    }

    public void TryInteractSpace(InputAction.CallbackContext callbackContext)
    {
        if(!canSwitchPerspective)
            return;

        if(currentActionMap == "ThirdPerson")
        {
            perspectiveManager.SwitchToFirstPerson();
            SwitchToFirstPersonControls();
        }
        else if(currentActionMap == "FirstPerson")
        {
            perspectiveManager.SwitchToThirdPerson();
            SwitchToThirdPersonControls();
        }
    }

    public void TryInteractMouse(InputAction.CallbackContext callbackContext)
    {
        if(!callbackContext.performed) return;

        Vector3 worldPos = Camera.main.ScreenToWorldPoint(InputManager.MousePosition);
        Vector2 clickPos = worldPos;

        float clickRadius = 0.1f;
        int clickableLayerMask = LayerMask.GetMask("Clickable"); 

        Collider2D[] hits = Physics2D.OverlapCircleAll(clickPos, clickRadius, clickableLayerMask);

        foreach(Collider2D hit in hits)
        {
            IInteractable iinteractable = hit.GetComponent<IInteractable>();
            if (iinteractable != null)
            {
                iinteractable.OnClick();
                break;
            }
        }
    }

    public void SwitchToFirstPersonControls()
    {
        SetActionMap("FirstPerson");
    }

    public void SwitchToThirdPersonControls()
    {
        SetActionMap("ThirdPerson");
    }

    public void SetActionMap(string mapName)
    {
        playerInput.SwitchCurrentActionMap(mapName);
        currentActionMap = mapName;

        moveAction = playerInput.actions["Move"];

        bowlMoveAction = playerInput.actions["BowlMove"];
        mouseMoveAction = playerInput.actions["MouseMove"];
        mouseInteract = playerInput.actions["MouseInteract"];
    }

    public void ViewCanSwitch(bool value)
    {
        canSwitchPerspective = value;
    }
}
