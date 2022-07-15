using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowDescription : MonoBehaviour
{

    public GameObject descriptionInfo;
    public bool descriptionShown;

    // Start is called before the first frame update
    void Start()
    {
        descriptionInfo.SetActive(false);
        descriptionShown = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showDescription()
    {
        if (descriptionShown == false)
        {
            descriptionInfo.SetActive(true);
            descriptionShown = true;
        }
        else
        {
            descriptionInfo.SetActive(false);
            descriptionShown = false;
        }
    }
}
