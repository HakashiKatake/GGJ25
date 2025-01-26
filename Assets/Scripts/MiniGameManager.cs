using UnityEngine;

public class MiniGameManager : MonoBehaviour
{
    public static Recipe activeOrder;
    public static bool gameStarted = false;
    private void Start()
    {
        StartMiniGame(GameManager.instance.curActive);
    }
    public void StartMiniGame(Recipe order)
    {
        activeOrder = order; 
        Debug.Log("Mini-game started for: " + activeOrder.rName);
        gameStarted = true;
    }

    public void CompleteMiniGame(int orderIndex)
    {
        Debug.Log("Mini-game completed for: " + activeOrder.rName);

       
        GameManager.instance.CompleteOrder(orderIndex);
    }
}
