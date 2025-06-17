using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class OrderManager : MonoBehaviour
{
    private Dictionary<Ingredient, string> ingredients = new Dictionary<Ingredient, string>();

    [SerializeField] private CustomerManager customerManager;

    //TO:DO Keep private
    [SerializeField] private Customer activeCustomer;

    public List<Ingredient> customerOrderItems;

    public List<Ingredient> currentBowlItems;

    [SerializeField] private TMP_Text customerOrderText;

    //debug texts
    [SerializeField] private TMP_Text _currentOrderText;
    [SerializeField] private TMP_Text _currentBowlText;

    private string[] rices = { "white Rice" };
    private string[] proteins = { "Ahi-Tuna", "Salmon" };
    private string[] toppings = { "Edamame", "Inamona", "Furikake", "Cucumber" };

    private string currentRice;
    private string currentProtein;
    private string currentTopping;

    [SerializeField] private bool orderInHand = false;

    private void Update()
    {
        activeCustomer = customerManager.GetActiveCustomer();   
    }

    public bool GetOrderInHand()
    {
        return orderInHand;
    }

    public void SetOrderInHand(bool value)
    {
        orderInHand = value;
    }

    public void AddIngredientToBowl(Ingredient ingredient)
    {
        currentBowlItems.Add(ingredient);
        
        _currentBowlText.text += ingredient.GetIngredientName() + " ";
    }

    public void ClearBowl()
    {
        currentBowlItems.Clear();
        _currentBowlText.text = "";
    }

    public void TakeCustomerOrder()
    {
        if (customerOrderText == null) return;

        currentRice = GetRandRice();
        currentProtein = GetRandProtein();
        currentTopping = GetRandTopping();

        customerOrderText.text = "Hello! I would like a poke bowl with " + currentRice + ", " + currentProtein + ", and " + currentTopping;
        _currentOrderText.text = currentRice + " " + currentProtein + " " + currentTopping;

        activeCustomer.OnOrderTaken();
    }

    public void FulfillCustomerOrder()
    {
        if (IsSame(currentBowlItems, customerOrderItems) == true)
        {
            customerOrderText.text = "Thank you!";
        }

        else if (IsSame(currentBowlItems, customerOrderItems) == false)
        {
            customerOrderText.text = "this isn't what I wanted...";
        }

        ClearBowl();
        SetOrderInHand(false);
        activeCustomer.OnOrderFulfilled();
    }

    private bool IsSame(List<Ingredient> bowlItems, List<Ingredient> orderItems)
    {
        if (bowlItems.Count != orderItems.Count)
        {
            return false;
        }

        List<Ingredient> bowlItemsSorted = bowlItems.ToList();
        bowlItemsSorted.Sort();
        List<Ingredient> orderItemsSorted = orderItems.ToList();
        orderItemsSorted.Sort();

        for (int i = 0; i < bowlItemsSorted.Count; i++)
        {
            if (bowlItemsSorted[i] != orderItemsSorted[i])
            {
                return false; // ingredients did not match
            }
        }

        return true; // all ingredients matched
    }

    #region Get Random Ingredients

    private String GetRandRice()
    {
        return rices[0];
    }

    private String GetRandProtein()
    {
        int random = Random.Range(0, 2);

        return proteins[random];
    }

    private String GetRandTopping()
    {
        int random = Random.Range(0, 4);

        return toppings[random];
    }
    
    #endregion
}
