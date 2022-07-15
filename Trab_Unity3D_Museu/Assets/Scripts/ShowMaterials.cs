using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMaterials : MonoBehaviour
{

    public GameObject materialsInfo;
    public GameObject materialsPanel;
    public bool materialsShown;

    // Start is called before the first frame update
    void Start()
    {
        materialsInfo.SetActive(false);
        materialsPanel.SetActive(false);
        materialsShown = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showMaterials()
    {
        if (materialsShown == false)
        {
            materialsInfo.SetActive(true);
            materialsPanel.SetActive(true);
            materialsShown = true;
        }
        else
        {
            materialsInfo.SetActive(false);
            materialsPanel.SetActive(false);
            materialsShown = false;
        }
    }
}
