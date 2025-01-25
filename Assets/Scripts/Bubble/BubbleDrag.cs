using UnityEngine;

public class BubbleDrag : MonoBehaviour
{
    public Rigidbody rb;
    public float dynamicViscosityOfAir = 0.0181f;
    private void FixedUpdate()
    {
        rb.linearDamping = Mathf.Max(0,-6*Mathf.PI* dynamicViscosityOfAir * transform.localScale.x*rb.linearVelocity.y);
    }
}
