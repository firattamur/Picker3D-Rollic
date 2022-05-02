using TMPro;
using UnityEngine;
using UnityEngine.UI;


// control all menu elements via this class
public class MenuController : MonoBehaviour
{   

    [SerializeField] RectTransform gameTitleRT;  
    [SerializeField] RectTransform handGuideRT;
    [SerializeField] RectTransform restartButtonRT;
    [SerializeField] RectTransform levelNumberTitleRT;

    [SerializeField] TextMeshProUGUI levelNumberText;

    void Start()
    {

        levelNumberText.text = "Level: " + DBController.instance.GetLevelNumber().ToString();

    }

    public void DisplayMenuElements()
    {

        LeanTween.moveY(gameTitleRT, -320, 1.0f).setEaseOutExpo();
        LeanTween.moveY(handGuideRT, 164, 1.0f).setEaseOutExpo();
        LeanTween.moveY(levelNumberTitleRT, -500, 1.0f).setEaseOutExpo();

    }

    public void UnDisplayMenuElements()
    {

        LeanTween.moveY(gameTitleRT, 320, 1.0f).setEaseOutExpo();
        LeanTween.moveY(handGuideRT, -164, 1.0f).setEaseOutExpo();
        LeanTween.moveY(levelNumberTitleRT, -128, 1.0f).setEaseOutExpo();

    }

    public void UpdateLevelNumberText()
    {

        levelNumberText.text = "Level: " + DBController.instance.GetLevelNumber().ToString();

    }

}
