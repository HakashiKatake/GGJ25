using UnityEngine;

public class BubbleMatHelper : MonoBehaviour
{
    public MeshRenderer matRenderer;
    private Material mat;

    private void Start()
    {
        mat = new Material(matRenderer.material);
        matRenderer.material = mat;
        updateTexScale();
    }
    public void updateTexScale()
    {
        mat.SetVector("_tiling", Vector2.one / ((Mathf.Approximately(transform.lossyScale.x, 0)) ? 1 : transform.lossyScale.x));
    }
}
