using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientManager : MonoBehaviour
{
    [SerializeField] private Animator spoonsAnimator;

    [SerializeField] private Ingredient activeIngredient;

    public Animator GetSpoonsAnimator()
    {
        return spoonsAnimator;
    }

    public void SetActiveIngredient(Ingredient newIngredient)
    {
        if (activeIngredient == newIngredient)
        {
            activeIngredient.PlaySetDownAnim();
            activeIngredient = null;
            return;
        }

        if (activeIngredient != null)
        {
            activeIngredient.PlaySetDownAnim();
        }

        activeIngredient = newIngredient;
        activeIngredient.PlayLiftAnim();
    }
}
