using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKeys : MonoBehaviour
{
    public GameObject[] UIBlankKeys;
    public GameObject[] UIAKeys;
    public GameObject[] UISKeys;
    public GameObject[] UIDKeys;
    
    private PlayerController playerController;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();

        foreach(GameObject key in UIAKeys)
        {
            key.SetActive(false);
        }

        foreach (GameObject key in UISKeys)
        {
            key.SetActive(false);
        }

        foreach (GameObject key in UIDKeys)
        {
            key.SetActive(false);
        }
    }

    private void Update()
    {
        Monitor0Keys();
        Monitor1Keys();
        Monitor2Keys();

    }

    private void Monitor0Keys()
    {
        if (playerController.key0 == KeyCode.None)
        {
            UIBlankKeys[0].SetActive(true);
            UIAKeys[0].SetActive(false);
            UISKeys[0].SetActive(false);
            UIDKeys[0].SetActive(false);
        }
        if (playerController.key0 == KeyCode.A)
        {
            UIBlankKeys[0].SetActive(false);
            UIAKeys[0].SetActive(true);
            UISKeys[0].SetActive(false);
            UIDKeys[0].SetActive(false);
        }
        if (playerController.key0 == KeyCode.S)
        {
            UIBlankKeys[0].SetActive(false);
            UIAKeys[0].SetActive(false);
            UISKeys[0].SetActive(true);
            UIDKeys[0].SetActive(false);
        }
        if (playerController.key0 == KeyCode.D)
        {
            UIBlankKeys[0].SetActive(false);
            UIAKeys[0].SetActive(false);
            UISKeys[0].SetActive(false);
            UIDKeys[0].SetActive(true);
        }
    }

    private void Monitor1Keys()
    {
        if (playerController.key1 == KeyCode.None)
        {
            UIBlankKeys[1].SetActive(true);
            UIAKeys[1].SetActive(false);
            UISKeys[1].SetActive(false);
            UIDKeys[1].SetActive(false);
        }
        if (playerController.key1 == KeyCode.A)
        {
            UIBlankKeys[1].SetActive(false);
            UIAKeys[1].SetActive(true);
            UISKeys[1].SetActive(false);
            UIDKeys[1].SetActive(false);
        }
        if (playerController.key1 == KeyCode.S)
        {
            UIBlankKeys[1].SetActive(false);
            UIAKeys[1].SetActive(false);
            UISKeys[1].SetActive(true);
            UIDKeys[1].SetActive(false);
        }
        if (playerController.key1 == KeyCode.D)
        {
            UIBlankKeys[1].SetActive(false);
            UIAKeys[1].SetActive(false);
            UISKeys[1].SetActive(false);
            UIDKeys[1].SetActive(true);
        }
    }

    private void Monitor2Keys()
    {
        if (playerController.key2 == KeyCode.None)
        {
            UIBlankKeys[2].SetActive(true);
            UIAKeys[2].SetActive(false);
            UISKeys[2].SetActive(false);
            UIDKeys[2].SetActive(false);
        }
        if (playerController.key2 == KeyCode.A)
        {
            UIBlankKeys[2].SetActive(false);
            UIAKeys[2].SetActive(true);
            UISKeys[2].SetActive(false);
            UIDKeys[2].SetActive(false);
        }
        if (playerController.key2 == KeyCode.S)
        {
            UIBlankKeys[2].SetActive(false);
            UIAKeys[2].SetActive(false);
            UISKeys[2].SetActive(true);
            UIDKeys[2].SetActive(false);
        }
        if (playerController.key2 == KeyCode.D)
        {
            UIBlankKeys[2].SetActive(false);
            UIAKeys[2].SetActive(false);
            UISKeys[2].SetActive(false);
            UIDKeys[2].SetActive(true);
        }
    }
}
