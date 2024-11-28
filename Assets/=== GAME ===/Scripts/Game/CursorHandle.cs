using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorHandle : MonoBehaviour
{
    [SerializeField] List<GameObject> plants = new List<GameObject>();
    public bool isActive = false;
    [SerializeField] LayerMask whatIsGroundUnit;
    public void ActivePlant(int id = -1)
    {
        isActive = false;
        if (id < 0) plants.ForEach(p => p.SetActive(false));
        else
        {
            try
            {
                isActive = true;
                for (int i = 0; i < plants.Count; i++)
                {
                    if (i == id) plants[i].gameObject.SetActive(true);
                    else plants[i].gameObject.SetActive(false);
                }
            }
            catch
            {
                Debug.LogError("index not available!");
            }
        }
    }
    Collider2D hit;
    Ray ray;

    private void Update()
    {
        if (!isActive) return;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        transform.position = mousePos;

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 origin = new Vector3(mousePos.x, mousePos.y);
            hit = Physics2D.OverlapCircle(origin,.1f,whatIsGroundUnit);
            if (hit != null)
            {
                hit.TryGetComponent(out GroundUnit groundUnit);
                if (groundUnit != null)
                {
                    groundUnit.CreatePlant(GameManager.Instance.CurrentIdCard);
                    GameManager.Instance.PlacePlant();
                }
                return;
            }
        }
    }

}
