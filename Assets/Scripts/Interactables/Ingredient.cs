using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour, IInteractable
{
    [SerializeField] private string ingredientName;
    [SerializeField] private string boolIsLiftedName;

    [SerializeField] private IngredientManager ingredientManager;

    public void OnClick()
    {
        ingredientManager.SetActiveIngredient(this);
    }

    public void PlayLiftAnim()
    {
        ingredientManager.GetSpoonsAnimator().SetBool(boolIsLiftedName, true);
    }

    public void PlaySetDownAnim()
    {
        ingredientManager.GetSpoonsAnimator().SetBool(boolIsLiftedName, false);
    }

    public string GetIngredientName() => ingredientName;
}
