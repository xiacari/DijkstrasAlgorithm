using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLine : MonoBehaviour
{
    public GameObject DestroyNumber;

    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Destroy(DestroyNumber);
            Destroy(gameObject);
        }
    }
}
