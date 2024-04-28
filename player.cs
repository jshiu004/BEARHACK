using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    // Start is called before the first frame update
    private Food[] foodData;
    private main mainClass;
    public string folderPath = "Assets/foodpics"; // Relative path to the folder containing sprites
    private Sprite[] foodSprites; // Array to hold the loaded sprites


    private Food currFood;
    private Food nextFood;

    private GameObject loseScreen;

    void Start()
    {
        mainClass = new main();
        foodData = mainClass.readFiles();

        loseScreen = GameObject.FindGameObjectWithTag("loseScreen");

        loseScreen.SetActive(false);

        Object[] loadedAssets = AssetDatabase.LoadAllAssetsAtPath(folderPath);

        // Filter out sprites from the loaded assets
        List<Sprite> spriteList = new List<Sprite>();
        foreach (Object asset in loadedAssets)
        {
            if (asset is Sprite)
            {
                spriteList.Add((Sprite)asset);
            }
        }

        // Convert the list to an array
        foodSprites = spriteList.ToArray();
        startGame();
    }

    private void startGame()
    {
        lose();
        currFood = mainClass.randomFood(ref foodData);

        nextFood = mainClass.randomFood(ref foodData);

        while (currFood == nextFood)
        {
            nextFood = mainClass.randomFood(ref foodData);
        }


    }

    public void highClick()
    {
        if (nextFood.getCalories() >= currFood.getCalories())
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
        if (nextFood.getCalories() <= currFood.getCalories())
        {
            correct();
        }
        else
        {
            lose();
        }
    }

    public void correct()
    {
        currFood = nextFood;
        nextFood = mainClass.randomFood(ref foodData);

        while (currFood == nextFood)
        {
            nextFood = mainClass.randomFood(ref foodData);
        }       
    }

    public void lose()
    {
        StartCoroutine(loseFade());
    }

    private IEnumerator loseFade()
    {
        yield return new WaitForSeconds(5f);

        loseScreen.SetActive(true);
    }




}
