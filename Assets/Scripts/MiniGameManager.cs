using System;
using UnityEngine;
using TMPro;
public class MiniGameManager : MonoBehaviour
{
    public static Recipe activeOrder;
    public static bool gameStarted = false;
    public static MiniGameManager gameManager;
    public TMP_Text text;
    private void Awake()
    {
        gameManager = this;
        StartMiniGame(GameManager.instance.curActive);
    }
    public void StartMiniGame(Recipe order)
    {
        activeOrder = order;
        String t = activeOrder.rName + ":";
        foreach (Ingredient i in activeOrder.Ingredients) {
            t += "\n  -" + i.iName;
        }
        text.text = t;
        Debug.Log("Mini-game started for: " + activeOrder.rName);
        gameStarted = true;
    }

    public void CompleteMiniGame(bool success)
    {
        Debug.Log("Mini-game completed for: " + activeOrder.rName);
        GameManager.instance.CompleteOrder(success);
    }
}
