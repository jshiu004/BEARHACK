using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class imageBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isTop = false;
    private Vector3 topEnd = new Vector3(0f, 2.58f, 0f);
    private Vector3 bottomEnd = new Vector3(0f, -2.55f, 0f);

    private Vector3 topStart = new Vector3(-4.8f, 2.58f, 0f);
    private Vector3 bottomStart = new Vector3(4.8f, -2.55f, 0f);

    private float animationTime = 1.5f;
    private float elapsedTime = 0f;
    private float percent = 0f;
    void Start()
    {
        this.enabled = false;
        if (this.tag == "top")
        {
            isTop = true;
        } else
        {
            isTop = false;
        }
        Debug.Log("working");
        setUp();
    }


    private void setUp()
    {
        if (isTop)
        {
            transform.position = topStart;
        } else
        {
            transform.position = bottomStart;
        }
        Debug.Log("working 2");


        //testing
        slideIn();
    }


    public void slideOut()
    {

    }

    public void slideIn()
    {
        this.enabled = true;
    }
    void FixedUpdate()
    {
        if (isTop)
        {
           // Debug.Log("workingTop");

            elapsedTime += Time.deltaTime;

            percent = elapsedTime / animationTime;

            transform.position = Vector3.Lerp(topStart, topEnd, Mathf.SmoothStep(0f, 1f, percent));

        }
        else
        {
          //  Debug.Log("workingBottom");

            elapsedTime += Time.deltaTime;

            percent = elapsedTime / animationTime;

            transform.position = Vector3.Lerp(bottomStart, bottomEnd, Mathf.SmoothStep(0f, 1f, percent));
        }
    }
}
