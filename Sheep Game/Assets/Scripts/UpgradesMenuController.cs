using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesMenuController : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject WeaponsPanel;
    public GameObject BasePanel;
    public GameObject NPCPanel;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void ShowWeaponsPanel()
    {
        WeaponsPanel.SetActive(true);
        BasePanel.SetActive(false);
        NPCPanel.SetActive(false);
    }

    public void ShowBasePanel()
    {
        WeaponsPanel.SetActive(false);
        BasePanel.SetActive(true);
        NPCPanel.SetActive(false);
    }

    public void ShowNPCPanel()
    {
        WeaponsPanel.SetActive(false);
        BasePanel.SetActive(false);
        NPCPanel.SetActive(true);
    }
}
