using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInterpretations : MonoBehaviour
{

    public GameObject interpretationsInfo;
    public bool interpretationsShown;

    // Start is called before the first frame update
    void Start()
    {
        interpretationsInfo.SetActive(false);
        interpretationsShown = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showInterpretations()
    {
        if (interpretationsShown == false)
        {
            interpretationsInfo.SetActive(true);
            interpretationsShown = true;
        }
        else
        {
            interpretationsInfo.SetActive(false);
            interpretationsShown = false;
        }
    }
}
