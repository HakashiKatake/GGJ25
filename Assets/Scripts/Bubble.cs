using UnityEngine;

public abstract class Bubble : MonoBehaviour
{
    public float radius;

    public virtual void merge(Bubble other) {
        if (other.radius > radius) {
            Destroy(this);
        }
        radius = Mathf.Sqrt((other.radius * other.radius) + (radius * radius));
        updateSize();
    }

    public virtual void deflate(Obstacle o) {
        radius -= o.damageRadius;
        updateSize();
    }

    protected virtual void updateSize()
    {
        transform.localScale = Vector3.one * radius;
    }
}
