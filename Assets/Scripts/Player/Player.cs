using UnityEngine;
using UnityEngine.InputSystem;


public class Player : Bubble
{
    public float startRadius;
    public float maxRadius;
    [SerializeField]
    private PlayerInteractor _interactor;

    [SerializeField]
    private BubbleMatHelper _matHelper;
    override public void merge(Bubble other)
    {
        Destroy(other.gameObject);
        radius = Mathf.Min(Mathf.Sqrt((other.radius * other.radius) + (radius * radius)),maxRadius);
        updateSize();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        radius = startRadius;
        updateSize();
    }
    protected override void updateSize()
    {
        base.updateSize();
        _matHelper.updateTexScale();
    }
    // Update is called once per frame
    void Update()
    {

    }

  
}
