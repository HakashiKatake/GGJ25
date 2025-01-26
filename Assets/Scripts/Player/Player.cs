using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using System.Linq;

public class Player : Bubble
{
    public float startRadius;
    public float maxRadius;
    [SerializeField]
    private PlayerInteractor _interactor;
    [SerializeField]
    private AudioRandomiser _ar;
    [SerializeField]
    private BubbleMatHelper _matHelper;
    private int ingredientCount;
    private List<Ingredient> _ingredients = new List<Ingredient>();
    override public void merge(Bubble other)
    {
        _ingredients.Add(other.gameObject.GetComponent<BubbleWithIngredient>().i);
        Destroy(other.gameObject);
        radius = Mathf.Min(Mathf.Sqrt((other.radius * other.radius) + (radius * radius)),maxRadius);
        _ar.PlayRandom();
        updateSize();

        if (_ingredients.Count == ingredientCount) {
            MiniGameManager.gameManager.CompleteMiniGame(verify());
        }
    }

    public bool verify() {
        foreach (Ingredient i in MiniGameManager.activeOrder.Ingredients) {
            bool hit = false;
            for (int j = 0; j < _ingredients.Count; j++) {
                if (i.iName == _ingredients[j].iName) {
                    hit = true;
                    break;
                }
            }
            if (!hit) { return false; }
        }
        return true;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ingredientCount = MiniGameManager.activeOrder.Ingredients.Length;
        radius = startRadius;
        updateSize();
    }
    protected override void updateSize()
    {
        base.updateSize();
        _matHelper.updateTexScale();
    }

  
}
