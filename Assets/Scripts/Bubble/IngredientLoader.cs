using UnityEngine;

public class IngredientLoader : MonoBehaviour
{
    public MeshFilter ob;
    public MeshRenderer obTex;

    public Material refmat;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void LoadIngredientDisplay(Ingredient i) {
        ob.mesh = i.model;
        Material mat = new Material(refmat);
        mat.mainTexture = i.tex;
        obTex.material = mat;
    }

}
