using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateStartingNodes : MonoBehaviour
{

    public GameObject Node;

    private Text [] nameText;

    void Start()
    {
        GameObject NodeClone = Instantiate(Node);
        NodeClone.transform.position = new Vector3(-7.0f, 0.0f, 0.0f);
        NodeClone.GetComponent<SpriteRenderer>().color = Color.red;
        NodeClone.tag = "Node";

        GetComponent<GiveNames>().SetNames();
        NodeClone.GetComponent<Node>().Number = 0f;
        nameText = NodeClone.GetComponentsInChildren<Text>();
        nameText[1].text = NodeClone.GetComponent<Node>().Number.ToString();
    }

    
    void Update()
    {
        
    }
}
