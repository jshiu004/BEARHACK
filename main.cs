using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main : MonoBehaviour
{
    public Food[] readFiles()
    {
        string caloriesString, name;

        int numFoods = 50;
        Food[] listOfFoods = new Food[numFoods];
        const string path = "assets/scripts/foods.txt";
        StreamReader reader = new StreamReader(path);

        for (int i = 0; i < numFoods; i++)
        {
            name = reader.ReadLine();
            caloriesString = reader.ReadLine();
            if (int.TryParse(caloriesString, out int calories))
            {
                listOfFoods[i] = new Food(name, calories);
            }
        }
        return listOfFoods;
    }


    public int randomFood()
    {
        
        int index = Random.Range(0, 50);
        return index;
    }



}

