using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlantBar : MonoBehaviour
{
    [SerializeField] TMP_Text txtSun;
    [SerializeField] List<CardUI> cards;

    public void UpdateTextSun(int val) => txtSun.text = val.ToString();
}
