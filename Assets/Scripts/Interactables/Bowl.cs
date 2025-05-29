using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bowl : MonoBehaviour, IInteractable
{
    [SerializeField] private IngredientManager ingredientManager;



    public void OnClick()
    {
        AddIngredient();
    }

    private void AddIngredient()
    {
        print(ingredientManager.GetActiveIngredient());        
    }
}
