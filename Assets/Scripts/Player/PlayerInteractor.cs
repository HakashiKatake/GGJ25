using UnityEngine;
using UnityEngine.Rendering;

public class PlayerInteractor : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    int _frameCD;
    [SerializeField]
    private float _forgivenessRadius;
    [SerializeField]
    LayerMask _interactionLayers;
    int _frameCounter = 0;
    Player _player;
    // Update is called once per frame
    private void Start()
    {
        _player = GetComponent<Player>();
    }
    void Update()
    {
        if (_frameCounter == _frameCD) {
            Collider[] hits = Physics.OverlapSphere(transform.position, (transform.localScale.x /2)+ _forgivenessRadius, _interactionLayers, QueryTriggerInteraction.Collide);
            foreach (Collider hit in hits) {
                if (hit.tag == "Bubble") {
                    
                    _player.merge(hit.gameObject.GetComponent<Bubble>());
                }

            }
            _frameCounter = 0;
        }
        _frameCounter++;
    }
}
