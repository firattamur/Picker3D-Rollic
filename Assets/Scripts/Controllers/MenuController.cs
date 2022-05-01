using TMPro;
using UnityEngine;
using UnityEngine.UI;


// control all menu elements via this class
public class MenuController : MonoBehaviour
{   

    [SerializeField] RectTransform gameTitle;  
    [SerializeField] RectTransform handGuide;
    [SerializeField] RectTransform restartButton;
    [SerializeField] RectTransform levelNumberTitle;


    public void DisplayMenuElements()
    {

        LeanTween.moveY(gameTitle, -320, 1.0f).setEaseOutExpo();
        LeanTween.moveY(handGuide, 164, 1.0f).setEaseOutExpo();
        LeanTween.moveY(levelNumberTitle, -500, 1.0f).setEaseOutExpo();

    }

    public void UnDisplayMenuElements()
    {

        LeanTween.moveY(gameTitle, 320, 1.0f).setEaseOutExpo();
        LeanTween.moveY(handGuide, -164, 1.0f).setEaseOutExpo();
        LeanTween.moveY(levelNumberTitle, -128, 1.0f).setEaseOutExpo();

    }

}
