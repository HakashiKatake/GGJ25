using UnityEngine;
using UnityEngine.InputSystem;


public class Player : Bubble
{
    public float startRadius;
    [SerializeField]
    private PlayerInteractor _interactor;

    [SerializeField]
    private float _baseSpeed;
    override public void merge(Bubble other)
    {
        Destroy(other.gameObject);
        radius = Mathf.Sqrt((other.radius * other.radius) + (radius * radius));
        updateSize();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        radius = startRadius;
        updateSize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMove(InputValue ctx) {
        
    }
}
