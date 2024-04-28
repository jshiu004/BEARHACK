using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    // Start is called before the first frame update
    private Food[] foodData;
    private main mainClass;


    private Food currFood;
    private Food nextFood;
    void Start()
    {
        mainClass = new main();
        foodData = mainClass.readFiles();


        startGame();
    }

    private void startGame()
    {
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
        } else
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




}
