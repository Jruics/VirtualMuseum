using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowInfo : MonoBehaviour
{
    public GameObject simpleInfo;
    public GameObject moreInfo;

    public GameObject yearInfo;
    public GameObject yearGroup;

    public GameObject materialsInfo;
    public GameObject materialsGroup;

    public GameObject symbolismInfo;
    public GameObject symbolismGroup;

    public GameObject interpretationsInfo;
    public GameObject interpretationsGroup;

    public GameObject creatorInfo;
    public GameObject creatorGroup;

    public bool isShowing = false;
    public bool playerInZone = false;


    // Start is called before the first frame update
    void Start()
    {
        simpleInfo.SetActive(false);
        moreInfo.SetActive(false);

        yearInfo.SetActive(false);
        yearGroup.SetActive(false);

        materialsInfo.SetActive(false);
        materialsGroup.SetActive(false);

        symbolismInfo.SetActive(false);
        symbolismGroup.SetActive(false);

        interpretationsInfo.SetActive(false);
        interpretationsGroup.SetActive(false);

        
    }
    
   public void Update()
    {
        if (isShowing && Input.GetKeyDown("e"))
        {
            moreInfo.SetActive(false);

            yearGroup.SetActive(false);
            materialsGroup.SetActive(false);
            symbolismGroup.SetActive(false);
            interpretationsGroup.SetActive(false);
            creatorGroup.SetActive(false);

            isShowing = false;

            foreach (Camera c in Camera.allCameras)
            {
                foreach (Camera d in Camera.allCameras)
                {
                    if (c.gameObject.name == "Main Camera" && d.gameObject.name == "Support Camera")
                    {
                        c.depth = -1;
                        d.depth = -2;
                    }
                }
            }
        }
        else if (!isShowing && Input.GetKeyDown("e") && playerInZone)
        {
            moreInfo.SetActive(true);

            yearGroup.SetActive(true);
            materialsGroup.SetActive(true);
            symbolismGroup.SetActive(true);
            interpretationsGroup.SetActive(true);
            creatorGroup.SetActive(true);

            isShowing = true;

            foreach (Camera c in Camera.allCameras)
            {
                foreach (Camera d in Camera.allCameras)
                {
                    if (c.gameObject.name == "Main Camera" && d.gameObject.name == "Support Camera")
                    {
                        d.depth = -1;
                        c.depth = -2;
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider player)
    {
        Cursor.lockState = CursorLockMode.Confined;
        playerInZone = true;

        if (player.gameObject.tag == "Player")
        {
            simpleInfo.SetActive(true);
        }
    }

    
    void OnTriggerStay(Collider player)
    {
        playerInZone = true;
    }
    

    void OnTriggerExit(Collider player)
    {
        Cursor.lockState = CursorLockMode.Locked;

        if (player.gameObject.tag == "Player")
        {
            simpleInfo.SetActive(false);
            moreInfo.SetActive(false);

            yearInfo.SetActive(false);
            yearGroup.SetActive(false);

            materialsInfo.SetActive(false);
            materialsGroup.SetActive(false);

            symbolismInfo.SetActive(false);
            symbolismGroup.SetActive(false);

            interpretationsInfo.SetActive(false);
            interpretationsGroup.SetActive(false);

            creatorInfo.SetActive(false);
            creatorGroup.SetActive(false);
        }
        foreach (Camera c in Camera.allCameras)
        {
            foreach (Camera d in Camera.allCameras)
            {
                if (c.gameObject.name == "Main Camera" && d.gameObject.name == "Support Camera")
                {
                    c.depth = -1;
                    d.depth = -2;
                }
            }
        }

        playerInZone = false;
    }
}
