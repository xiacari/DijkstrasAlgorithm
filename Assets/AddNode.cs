using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddNode : MonoBehaviour
{
    public GameObject Node;

    private Text[] nameText;

    public void OnButtonPress()
    {
        GameObject NodeClone = Instantiate(Node);
        NodeClone.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
        NodeClone.tag = "Node";

        GetComponent<GiveNames>().SetNames();
        NodeClone.GetComponent<Node>().Number = 999f;
        nameText = NodeClone.GetComponentsInChildren<Text>();
        nameText[1].text = NodeClone.GetComponent<Node>().Number.ToString();
    }   
}
