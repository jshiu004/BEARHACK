using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class player : MonoBehaviour
{
    // Start is called before the first frame update
    private Food[] foodData;
    private main mainClass;
    public string folderPath = "Assets/Resources/foodpics"; // Relative path to the folder containing sprites
    public Sprite[] foodSprites = new Sprite[50]; // Array to hold the loaded sprites


    private int currFood;
    private int nextFood;

    private GameObject loseScreen;
    private GameObject topSlider;
    private GameObject bottomSlider;
    private GameObject highButton;
    private GameObject lowButton;
    public GameObject topBox;
    public GameObject bottomBox;

    void Start()
    {
        mainClass = new main();
        foodData = mainClass.readFiles();

        topBox = GameObject.FindGameObjectWithTag("top");
        bottomBox = GameObject.FindGameObjectWithTag("bottom");

        topSlider = GameObject.FindGameObjectWithTag("topImage");
        bottomSlider = GameObject.FindGameObjectWithTag("bottomImage");

        loseScreen = GameObject.FindGameObjectWithTag("loseScreen");

        highButton = GameObject.FindGameObjectWithTag("high");
        lowButton = GameObject.FindGameObjectWithTag("low");

        



        loseScreen.SetActive(false);



        highButton.GetComponent<buttonBehaviour>().hideButtons();
        lowButton.GetComponent<buttonBehaviour>().hideButtons();

        startGame();
    }

    private void startGame()
    {
        currFood = mainClass.randomFood();

        nextFood = mainClass.randomFood();

        while (currFood == nextFood)
        {
            nextFood = mainClass.randomFood();
        }

        StartCoroutine(setImages());


    }

    private IEnumerator setImages()
    {
        
        topSlider.GetComponent<SpriteRenderer>().sprite = foodSprites[currFood];

        bottomSlider.GetComponent<SpriteRenderer>().sprite = foodSprites[nextFood];

        topBox.GetComponent<imageBehaviour>().slideIn();
        bottomBox.GetComponent<imageBehaviour>().slideIn();

        yield return new WaitForSeconds(1f);

        highButton.GetComponent<buttonBehaviour>().showButtons();
        lowButton.GetComponent<buttonBehaviour>().showButtons();

        Debug.Log(foodData[currFood].getCalories());
        Debug.Log(foodData[nextFood].getCalories());
    }

    public void highClick()
    {
        if (foodData[nextFood].getCalories() >= foodData[currFood].getCalories())
        {
            correct();
        }
        else
        {
            lose();
        }
    }

    public void lowClick()
    {
        if (foodData[nextFood].getCalories() <= foodData[currFood].getCalories())
        {
            StartCoroutine(correct());
        }
        else
        {
            lose();
        }
    }

    public IEnumerator correct()
    {

        yield return new WaitForSeconds(2f);
        topBox.GetComponent<imageBehaviour>().slideOut();
        bottomBox.GetComponent<imageBehaviour>().slideOut();
        yield return new WaitForSeconds(3f);

        currFood = nextFood;
        nextFood = mainClass.randomFood();

        while (currFood == nextFood)
        {
            nextFood = mainClass.randomFood();
        }

        StartCoroutine(setImages());
    }

    public void lose()
    {
        StartCoroutine(loseDelay());
    }

    private IEnumerator loseDelay()
    {
        yield return new WaitForSeconds(5f);

        loseScreen.SetActive(true);
    }




}
