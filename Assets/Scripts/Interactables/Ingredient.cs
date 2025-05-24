using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour, IInteractable
{
    [SerializeField] private string ingredientName;
    [SerializeField] private string liftTrigger;
    [SerializeField] private string setDownTrigger;

    private IngredientManager ingredientManager;

    private void Awake()
    {
        ingredientManager = FindObjectOfType<IngredientManager>();
    }

    public void OnClick()
    {
        ingredientManager.SetActiveIngredient(this);
    }

    public void PlayLiftAnim()
    {
        ingredientManager.GetSpoonsAnimator().SetTrigger(liftTrigger);
    }

    public void PlaySetDownAnim()
    {
        ingredientManager.GetSpoonsAnimator().SetTrigger(setDownTrigger);
    }

    public string GetIngredientName() => ingredientName;
}
