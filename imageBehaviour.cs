using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class imageBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    private bool slideState = false;

    private Vector3 topEnd = new Vector3(0f, 2.58f, 0f);
    private Vector3 bottomEnd = new Vector3(0f, -2.55f, 0f);

    private Vector3 topStart = new Vector3(-4.8f, 2.58f, 0f);
    private Vector3 bottomStart = new Vector3(4.8f, -2.55f, 0f);

    private float animationTime = 1.5f;
    private float elapsedTime = 0f;
    private float percent = 0f;
    void Start()
    {

        setUp();
    }


    private void setUp()
    {
        if (tag == "top")
        {
            transform.position = topStart;
        } else
        {
            transform.position = bottomStart;
        }

    }



    public void slideOut()
    {
        slideState = false;

    }

    public void slideIn()
    {
        slideState = true;


    }

    

    void FixedUpdate()
    {
        if (slideState) {
            if (tag == "top")
            {


                elapsedTime += Time.deltaTime;

                percent = elapsedTime / animationTime;

                transform.position = Vector3.Lerp(topStart, topEnd, Mathf.SmoothStep(0f, 1f, percent));

            }
            else
            {


                elapsedTime += Time.deltaTime;

                percent = elapsedTime / animationTime;

                transform.position = Vector3.Lerp(bottomStart, bottomEnd, Mathf.SmoothStep(0f, 1f, percent));
            }
        } else {
            if (tag == "top")
            {
            // Debug.Log("workingTop");

                elapsedTime += Time.deltaTime;

                percent = elapsedTime / animationTime;

                transform.position = Vector3.Lerp(topEnd, topStart, Mathf.SmoothStep(0f, 1f, percent));

            }
            else
            {
            //  Debug.Log("workingBottom");

                elapsedTime += Time.deltaTime;

                percent = elapsedTime / animationTime;

                transform.position = Vector3.Lerp(bottomEnd, bottomStart, Mathf.SmoothStep(0f, 1f, percent));
            }
        }
    }
}
