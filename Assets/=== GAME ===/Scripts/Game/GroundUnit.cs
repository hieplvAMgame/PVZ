using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundUnit : MonoBehaviour
{
    [SerializeField] Transform plantPos;
    // TODO
    [SerializeField] GameObject plants;
    Collider2D col;
    GameObject p;
    private void Awake()
    {
        if (plantPos == null) plantPos = transform.GetChild(0);
        p = Instantiate(plants, plantPos);
        p.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
    }
    public void CreatePlant(int idPlant = -1)
    {
        if (idPlant < 0) return;
        for (int i = 0; i < p.transform.childCount; i++)
        {
            int index = i;
            if (index == idPlant)   
                p.transform.GetChild(index).gameObject.SetActive(true);
            else p.transform.GetChild(index).gameObject.SetActive(false);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        col = GetComponent<Collider2D>();
        Gizmos.DrawWireCube(transform.position, col.bounds.size);
    }
}
