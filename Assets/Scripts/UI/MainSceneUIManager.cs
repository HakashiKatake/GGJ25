using TMPro;
using UnityEngine;

public class MainSceneUIManager : MonoBehaviour
{
    public static MainSceneUIManager Instance;
    public TMP_Text dayText;
    public TMP_Text orderStatusText;
    public TMP_Text order1Text;
    public TMP_Text order2Text;

    // Win/Lose Panels
    public GameObject winPanel;
    public GameObject losePanel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void cook() {
        GameManager.instance.SelectOrder();
    }
}
