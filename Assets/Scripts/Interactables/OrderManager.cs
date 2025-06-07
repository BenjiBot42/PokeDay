using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class OrderManager : MonoBehaviour
{
    public List<Ingredient> customerOrderItems;

    public List<Ingredient> currentBowlItems;

    [SerializeField] private TMP_Text customerOrderText;

    private string[] rices = { "white Rice" };
    private string[] proteins = { "Ahi-Tuna", "Salmon" };
    private string[] toppings = { "Edamame", "Inamona", "Furikake", "Cucumber" };

    private string currentRice;
    private string currentProtein;
    private string currentTopping;

    public void AddIngredientToBowl(Ingredient ingredient)
    {
        currentBowlItems.Add(ingredient);
    }

    public void TakeCustomerOrder()
    {
        if (customerOrderText == null) return;

        currentRice = GetRandRice();
        currentProtein = GetRandProtein();
        currentTopping = GetRandTopping();

        customerOrderText.text = "Hello! I would like a poke bowl with " + currentRice + ", " + currentProtein + ", and " + currentTopping;
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
