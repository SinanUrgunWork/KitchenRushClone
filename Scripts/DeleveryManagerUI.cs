using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleveryManagerUI : MonoBehaviour
{
    [SerializeField] private Transform container;
    [SerializeField] private Transform recipeTemplate;

    private void Awake()
    {
        recipeTemplate.gameObject.SetActive(false);
    }

    private void Start()
    {
        DeleveryManager.Instance.OnRecipeSpawned += Dilevery_OnRecipeSpawned;
        DeleveryManager.Instance.OnRecipeCompleted += Dilevery_OnRecipeCompleted;
        UpdateVisual();
    }
    private void Dilevery_OnRecipeCompleted(object sender, System.EventArgs e)
    {
        UpdateVisual();
    }
    private void Dilevery_OnRecipeSpawned(object sender, System.EventArgs e)
    {
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        foreach (Transform child in container)
        {
            if (child == recipeTemplate) continue;
            Destroy(child.gameObject);
        }
        foreach (RecipeSO recipeSO in DeleveryManager.Instance.GetWaitingRecipeSOList())
        {
            Transform recipeTransform = Instantiate(recipeTemplate, container);
            recipeTransform.gameObject.SetActive(true);
            recipeTemplate.GetComponent<DeleveryManagerSingleUI>().SetRecipeSO(recipeSO);
        }

    }


}
