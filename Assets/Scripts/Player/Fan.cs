using UnityEngine;

public class Fan : MonoBehaviour
{
    public LayerMask fanInteractible;
    public float distance;
    public float force;
    public float fanRad;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] hits = Physics.OverlapBox(this.transform.position,new Vector3(fanRad,distance,fanRad),Quaternion.identity, fanInteractible,QueryTriggerInteraction.Collide);
        foreach (Collider hit in hits)
        {
            hit.GetComponent<Rigidbody>().AddForce((force * Vector3.Normalize(hit.transform.position - this.transform.position))/Mathf.Abs(Vector3.Magnitude(hit.transform.position - this.transform.position)), ForceMode.Force);
        }
    }
}
