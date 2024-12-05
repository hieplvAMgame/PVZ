using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardUI : MonoBehaviour
{
    [SerializeField] CardSO data;

    [Header("Reference")]
    [SerializeField] Image img;
    [SerializeField] Text txtCost = default;
    [SerializeField] Text txtNameCard = default;
    [SerializeField] Button selfButton;
    [Header("Overlay")]
    [SerializeField] Image fillOverlay;

    public static Action<CardSO> OnClickCard = null;
    private void Awake()
    {
        selfButton = GetComponent<Button>();
        selfButton.onClick.AddListener(() =>
        {
            if (GameManager.Instance.IsSelectCard || GameManager.Instance.TotalSun < data.cost) return;
            OnClickCard?.Invoke(data);
            StartCountdown();
        });
        SetUpUiCard();
    }
    public int IDCard => data.id;
    [ContextMenu("Setup data")]
    public void SetUpUiCard()
    {
        if (data == null)
        {
            Debug.Log("Data card not assign!!!");
        }
        else
        {
            img.sprite = data.previewCard;
            txtNameCard.text = data.nameCard;
            if (txtCost) txtCost.text = data.cost.ToString();
        }
    }
    public void StartCountdown()
    {
        StartCoroutine(IECountdownCard());
    }

    IEnumerator IECountdownCard()
    {
        if (data.timeCountdown <= 0) yield break;
        fillOverlay.gameObject.SetActive(true);
        selfButton.interactable = false;
        float time = data.timeCountdown;
        fillOverlay.fillAmount = 1;
        while (time >= 0)
        {
            fillOverlay.DOFillAmount(time / data.timeCountdown, .2f);
            yield return new WaitForEndOfFrame();
            time -= Time.deltaTime;
        }
        time = 0;
        fillOverlay.fillAmount = 0;
        fillOverlay.gameObject.SetActive(false);
        selfButton.interactable = true;
    }
}
