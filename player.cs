using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    // Start is called before the first frame update
    private Food[] foodData;
    private main mainClass;
    void Start()
    {
        mainClass = new main();
        foodData = mainClass.readFiles();


        startGame();
    }

    private void startGame()
    {

    }

}
