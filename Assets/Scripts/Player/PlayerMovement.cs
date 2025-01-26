using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private float _baseSpeed;
    public Rigidbody rb;
    public void OnMove(InputValue ctx)
    {
        rb.linearVelocity = _baseSpeed * new Vector3(ctx.Get<Vector2>().x,0, 0);
    }

}
