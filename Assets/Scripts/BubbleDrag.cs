using UnityEngine;

public class BubbleDrag : MonoBehaviour
{
    public Rigidbody rb;

    private void FixedUpdate()
    {
        rb.linearDamping = 6*Mathf.PI*0.0000181f*transform.localScale.x*rb.linearVelocity.y;
    }
}
