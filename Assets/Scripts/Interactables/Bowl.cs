using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bowl : MonoBehaviour, IInteractable
{
    [SerializeField] private IngredientManager ingredientManager;
    [SerializeField] private OrderManager orderManager;

    public void OnClick()
    {
        orderManager.AddIngredientToBowl(ingredientManager.GetActiveIngredient());
    }
}
