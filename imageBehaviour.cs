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
    void Start()
    {
        if (this.tag == "top")
        {
            isTop = true;
        } else
        {
            isTop = false;
        }

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
    }


    public void slideOut()
    {

    }

    public void slideIn()
    {

    }
    void Update()
    {
        
    }
}
