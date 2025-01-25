using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private float _baseSpeed;
    public Rigidbody rb;
    public void OnMove(InputValue ctx)
    {
        rb.linearVelocity = Vector2.right * _baseSpeed * ctx.Get<Vector2>().x;
    }

}
