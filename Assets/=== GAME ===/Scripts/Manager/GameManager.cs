using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        CardUI.OnClickCard = SelectCard;
    }

    public bool IsSelectCard = false;
    public int CurrentIdCard = -1;

    [SerializeField] CursorHandle Cursor;

    public void SelectCard(CardSO cardSO)
    {
        if (IsSelectCard) return;
        IsSelectCard = true;
        CurrentIdCard = cardSO.id;
        StartPlacePlant();
    }   
    public void StartPlacePlant()
    {
        Cursor.ActivePlant(CurrentIdCard);
    }

    public void PlacePlant()
    {
        Debug.Log($"Place plant {CurrentIdCard}");
        IsSelectCard = false;
        CurrentIdCard = -1;
        Cursor.ActivePlant();
    }

}
