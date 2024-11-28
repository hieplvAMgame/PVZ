using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="SO/Create Data Plant",fileName = "Data Plant")]
public class PlantData : ScriptableObject
{
    public List<Sprite> previewPlant = new List<Sprite>();
}
