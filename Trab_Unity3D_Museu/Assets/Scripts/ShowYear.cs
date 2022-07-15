using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowYear : MonoBehaviour
{

    public GameObject yearInfo;
    public GameObject yearPanel;
    public bool yearsShown;

    // Start is called before the first frame update
    void Start()
    {
        yearInfo.SetActive(false);
        yearPanel.SetActive(false);
        yearsShown = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showYear()
    {
        if (yearsShown == false)
        {
            yearInfo.SetActive(true);
            yearPanel.SetActive(true);
            yearsShown = true;
        }
        else
        {
            yearInfo.SetActive(false);
            yearPanel.SetActive(false);
            yearsShown = false;
        }
    }
}
