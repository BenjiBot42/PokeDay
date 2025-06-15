using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegisterEnvironment : MonoBehaviour
{
    [SerializeField] private CustomerManager customerManager;
    private string customerName;

    private Dictionary<string, GameObject> customerGameObjects = new Dictionary<string, GameObject>();

    [SerializeField] private GameObject joeGO;
    [SerializeField] private GameObject gothGO;

    private void Awake()
    {
        RegisterCustomer("Joe", joeGO);
        RegisterCustomer("Goth", gothGO);
    }

    public void RegisterCustomer(string name, GameObject customerGameObject)
    {
        customerGameObjects[name] = customerGameObject;
    }

    private void EnableCustomerGameObject(string customerName)
    {
        foreach (var customer in customerGameObjects.Values)
        {
            customer.SetActive(false);
        }

        if (customerGameObjects.ContainsKey(customerName))
        {
            customerGameObjects[customerName].SetActive(true);
        }
    }
    
    private void OnEnable()
    {
        customerManager.SetActiveCustomer();

        if (customerManager.GetActiveCustomer() == null)
        {
            EnableCustomerGameObject("");
            return;
        }

        customerName = customerManager.GetActiveCustomer().GetCustomerName();

        switch (customerName)
        {
            case "Joe":
                EnableCustomerGameObject("Joe");
                break;
            case "Goth":
                EnableCustomerGameObject("Goth");
                break;
        }
    }
}
