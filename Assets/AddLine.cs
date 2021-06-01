using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class AddLine : MonoBehaviour
{

    public GameObject Line;
    public GameObject Length;
    public GameObject Arrow;

    public Text start_point;
    public Text end_point;
    public Text line_length;

    private Text nameText;

    public void OnButtonPress()
    {
        string s_p = start_point.text.ToUpper();
        string e_p = end_point.text.ToUpper();
        float len = float.Parse(line_length.text);


        //Adding line
        GameObject LineClone = Instantiate(Line);
        GameObject[] Nodes;
        Nodes = GameObject.FindGameObjectsWithTag("Node");
        foreach (GameObject node in Nodes)
        {
            nameText = node.GetComponentInChildren<Text>();
            if (nameText.text == s_p)
            {
                LineClone.GetComponent<Line>().start_point = node;
            }
            if (nameText.text == e_p)
            {
                LineClone.GetComponent<Line>().end_point = node;
            }
        }
        LineClone.GetComponent<Line>().Length = len;
        LineClone.tag = "Line";

        //Adding length text
        GameObject LengthClone = Instantiate(Length);
        LengthClone.GetComponent<Number>().Line = LineClone;
        LengthClone.GetComponentInChildren<Text>().text = "" + len;
        LengthClone.tag = "Length";

        //Adding arrow
        //GameObject ArrowClone = Instantiate(Arrow);
        //ArrowClone.GetComponent<Arrow>().Line = LineClone;
        //LengthClone.tag = "Arrow";
    }
}
