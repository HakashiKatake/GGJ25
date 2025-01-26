using System.Collections;
using UnityEngine;

public class BubbleWithIngredient : Bubble
{
    public Transform parent;
    public Ingredient i;
    public float LifeTIme;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instantiate(i.model, parent);
        StartCoroutine(die());
    }
    public override void merge(Bubble other)
    {
        //Do Nothing
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator die() { 
        yield return new WaitForSeconds(LifeTIme);
        Destroy(this.gameObject);
    }
}
