using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Node : MonoBehaviour
{

    public string Name;
    public float Number;
    public bool Processed = false;

    private Text[] nameText;
    
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1) && Name != "A")
        {
            GameObject[] Lines;
            Lines = GameObject.FindGameObjectsWithTag("Line");
            foreach (GameObject line in Lines)
            {
                if ((line.GetComponent<Line>().start_point.GetComponent<Node>().Name == Name)|| (line.GetComponent<Line>().end_point.GetComponent<Node>().Name == Name))
                {
                    line.GetComponent<DestroyLine>().OnMouseOver();
                }
            }
            Destroy(gameObject);
        }
    }
}
