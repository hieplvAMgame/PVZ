using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlantBar uiBar;
    int sunVal;
    public int TotalSun
    {
        get => sunVal;
        set
        {
            sunVal = value;
            if (sunVal <= 0) sunVal = 0;
            uiBar.UpdateTextSun(sunVal);
        }
    }
    public static GameManager Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        CardUI.OnClickCard = SelectCard;
        TotalSun = 50;
    }

    public bool IsSelectCard = false;
    public int CurrentIdCard = -1;

    [SerializeField] CursorHandle Cursor;

    public void SelectCard(CardSO cardSO)
    {
        if (IsSelectCard) return;
        if (TotalSun < cardSO.cost) return;
        TotalSun -= cardSO.cost;
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
    public void AddSun(int value) => TotalSun += value;
}
public static class DebugHelper
{
    public static void Log(object ctx, string color)
    {
        if (string.IsNullOrEmpty(color)) color = "white";
        Debug.Log($"<color={color}>" + ctx + "</color>");
    }
}