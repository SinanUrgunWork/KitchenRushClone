using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour
{
    [SerializeField] private BaseCounter clearCounter;
    [SerializeField] private GameObject[] visualGameObject;
    private void Start()
    {
        Player.Instance.OnSelectedCounterChanged += Player_OnSelectedCounterChanged;
    }

    private void Player_OnSelectedCounterChanged(object sender, Player.OnSelectedCounterChangedEventArgs e)
    {
        if (e.selectedCounter == clearCounter)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }
    private void Hide()
    {
        foreach (GameObject virsualGameObjects in visualGameObject)
        {
            virsualGameObjects.SetActive(false);
        }

    }
    private void Show()
    {
        foreach (GameObject virsualGameObjects in visualGameObject)
        {
            virsualGameObjects.SetActive(true);
        }

    }
}
