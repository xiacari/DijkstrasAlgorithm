using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiveNames : MonoBehaviour
{
    private Text nameText;

    public void SetNames()
    {
        GameObject[] Nodes;
        Nodes = GameObject.FindGameObjectsWithTag("Node");
        int i = 65;
        foreach (GameObject node in Nodes)
        {
            nameText = node.GetComponentInChildren<Text>();
            nameText.text = "" + (char)i;
            node.GetComponent<Node>().Name = "" + (char)i;
            i++;
        }
    }
}
