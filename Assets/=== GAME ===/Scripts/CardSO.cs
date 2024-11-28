using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Create Data Card", fileName = "New Card")]
public class CardSO : ScriptableObject
{
    public int id;
    public Sprite previewCard;
    public string nameCard;
    public int cost;
    public int timeCountdown;
}
