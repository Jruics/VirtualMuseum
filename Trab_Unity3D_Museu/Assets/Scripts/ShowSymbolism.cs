using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowSymbolism : MonoBehaviour
{

    public GameObject symbolismInfo;
    public bool symbolismShown;

    // Start is called before the first frame update
    void Start()
    {
        symbolismInfo.SetActive(false);
        symbolismShown = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showSymbolism()
    {
        if (symbolismShown == false)
        {
            symbolismInfo.SetActive(true);
            symbolismShown = true;
        }
        else
        {
            symbolismInfo.SetActive(false);
            symbolismShown = false;
        }
    }
}
