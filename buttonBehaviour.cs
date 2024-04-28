using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class buttonBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    private Image buttonImg;
    private TextMeshProUGUI text;
    void Start()
    {
        buttonImg = gameObject.GetComponent<Image>();
        text = gameObject.GetComponentInChildren<TextMeshProUGUI>();

        hideButtons();

    }


    public void hideButtons()
    {
        gameObject.SetActive(false);
    }

    public void OnHighClick()
    {

    }

    public void OnLowClick()
    {

    }




    

}
