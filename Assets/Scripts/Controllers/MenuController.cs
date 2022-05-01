using TMPro;
using UnityEngine;
using UnityEngine.UI;


// control all menu elements via this class
public class MenuController : MonoBehaviour
{   

    [SerializeField] GameObject handGuide;
    [SerializeField] GameObject restartButton;
    [SerializeField] GameObject gameTitle;
    
    public void DisplayMenuElements()
    {

        gameTitle.SetActive(true);
        handGuide.SetActive(true);
        restartButton.SetActive(false);

    }

    public void UnDisplayMenuElements()
    {

        gameTitle.SetActive(false);
        handGuide.SetActive(false);

    }

}
