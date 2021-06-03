using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class TeleportationManager : MonoBehaviour
{
    [SerializeField] private InputActionAsset actionAsset;
    [SerializeField] private XRRayInteractor rayInteractor;
    [SerializeField] private new Transform camera;

    private InputAction thumbstick;
    private bool isActive;
    private Vector2 thumbstickDirection;
    private TeleportationProvider teleportationProvider;

    void Start()
    {
        TurnOffTeleport();

        teleportationProvider = GetComponent<TeleportationProvider>();

        var activate = actionAsset.FindActionMap("XRI LeftHand").FindAction("Teleport Mode Activate");
        activate.Enable();
        activate.performed += OnTeleportActivate;

        var cancel = actionAsset.FindActionMap("XRI LeftHand").FindAction("Teleport Mode Cancel");
        activate.Enable();
        activate.performed += OnTeleportCancel;

        thumbstick = actionAsset.FindActionMap("XRI LeftHand").FindAction("Move");
        thumbstick.Enable();
    }

    void Update()
    {
        if (!isActive)
        {
            return;
        }

        if (thumbstick.triggered)
        {
            var thumbstickValue = thumbstick.ReadValue<Vector2>();
            // if the thumbstick is pushed far enough in any direction we'll
            // save it off for use in the rotation angle calculation.
            if (thumbstickValue.sqrMagnitude >= 1)
            {
                thumbstickDirection = thumbstickValue.normalized;
            }
            return;
        }

        if (!rayInteractor.TryGetCurrent3DRaycastHit(out var hit))
        {
            TurnOffTeleport();
            return;
        }

        var rotationAngle = CalculateTeleportRotationAngle();
        var request = new TeleportRequest()
        {
            destinationPosition = hit.point,
            destinationRotation = Quaternion.Euler(0,
                rotationAngle, 0),
            matchOrientation = MatchOrientation.TargetUpAndForward
        };

        teleportationProvider.QueueTeleportRequest(request);
        TurnOffTeleport();

    }
    private void OnTeleportActivate(InputAction.CallbackContext callbackContext)
    {
        rayInteractor.enabled = true;
        isActive = true;
    }

    private void OnTeleportCancel(InputAction.CallbackContext callbackContext)
    {
        TurnOffTeleport();
    }

    private void TurnOffTeleport()
    {
        rayInteractor.enabled = false;
        isActive = false;
        thumbstickDirection = Vector2.zero;
    }
    private float CalculateTeleportRotationAngle()
    {
        var thumbstickAngle = Mathf.Atan2(thumbstickDirection.x,
                                  thumbstickDirection.y)
                              * Mathf.Rad2Deg;
        return thumbstickAngle + camera.eulerAngles.y;
    }
}
