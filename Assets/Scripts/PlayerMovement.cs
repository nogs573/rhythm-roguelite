using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInputs defaultPlayersActions;
    private InputAction moveAction;
    private InputAction lookAction;
    private InputAction fireAction;

    private Rigidbody body;
    private float speed = 8f;

    private void Awake() {
        body = GetComponent<Rigidbody>();
        defaultPlayersActions = new PlayerInputs();
    }

    private void OnEnable() {
        moveAction = defaultPlayersActions.Player.Move;
        moveAction.Enable();

        lookAction = defaultPlayersActions.Player.Look;
        lookAction.Enable();

        fireAction = defaultPlayersActions.Player.Fire;
        fireAction.Enable();
    }

    private void OnDisable() {
        moveAction.Disable();
        lookAction.Disable();
        fireAction.Disable();
    }

    private void OnFire() {
        Debug.Log("Player fired!");
    }

    private void FixedUpdate() {

        Vector2 moveDir = moveAction.ReadValue<Vector2>();
        Vector3 vel = GetComponent<Rigidbody>().velocity;
        vel.x = speed * moveDir.x;
        vel.z = speed * moveDir.y;
        body.velocity = vel;
    }

    // private float _ClampAngle(float angle, float from, float to) {
    //     // from: https://answers.unity.com/questions/659932/how-do-i-clamp-my-rotation.html
    //     if (angle < 0f) angle = 360 + angle;
    //     if (angle > 180f) return Mathf.Max(angle, 360+from);
    //     return Mathf.Min(angle, to);
    // }
}