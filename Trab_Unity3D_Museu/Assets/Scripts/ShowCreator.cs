using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCreator : MonoBehaviour
{

    public GameObject creatorInfo;
    public bool creatorShown;

    // Start is called before the first frame update
    void Start()
    {
        creatorInfo.SetActive(false);
        creatorShown = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showCreator()
    {
        if (creatorShown == false)
        {
            creatorInfo.SetActive(true);
            creatorShown = true;
        }
        else
        {
            creatorInfo.SetActive(false);
            creatorShown = false;
        }
    }
}
