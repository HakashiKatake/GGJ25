using UnityEngine;
[CreateAssetMenu(fileName = "Recipe", menuName = "ScriptableObjects/Recipe", order = 1)]

public class Recipe : ScriptableObject
{
    public string rName;

    public Ingredient[] Ingredients;
    public Mesh model;
    public Texture tex;
}
