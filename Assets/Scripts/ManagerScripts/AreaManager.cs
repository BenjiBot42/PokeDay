using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class AreaManager : MonoBehaviour
{
    private Dictionary<string, GameObject> areas = new Dictionary<string, GameObject>();

    [SerializeField] private GameObject restaurant;
    [SerializeField] private GameObject counter;
    [SerializeField] private GameObject register;
    [SerializeField] private GameObject fridge;

    private void Awake()
    {
        RegisterArea("Restaurant", restaurant);
        RegisterArea("Counter", counter);
        RegisterArea("Register", register);
        RegisterArea("Fridge", fridge);
    }

    private void RegisterArea(string name, GameObject area)
    {
        areas[name] = area;
    }

    public void ShowArea(string areaName)
    {
        foreach(var area in areas.Values)
        {
            area.SetActive(false);
        }

        if(areas.ContainsKey(areaName))
        {
            areas[areaName].SetActive(true);
        }
    }
    
}
