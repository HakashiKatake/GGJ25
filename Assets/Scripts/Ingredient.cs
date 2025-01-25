using UnityEngine;
[CreateAssetMenu(fileName = "Ingredient", menuName = "ScriptableObjects/Ingredient", order = 1)]

public class Ingredient : ScriptableObject
{
    public string Name;
    public Mesh model;
    public Texture tex;
}
