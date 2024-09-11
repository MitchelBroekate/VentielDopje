using UnityEngine;

public class Movement : MonoBehaviour
{
    Control controls;
    Rigidbody rb;

    [SerializeField] float moveSpeed;
    [SerializeField] Vector2 movementInput;

    private void Start()
    {
        controls = new Control();
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        movementInput = controls.Player.Movement.ReadValue<Vector2>();

        rb.velocity = movementInput * moveSpeed;

    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

}
