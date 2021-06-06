using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Dijkstras_algorithm : MonoBehaviour
{

    public GameObject i1;
    public GameObject i2;
    public GameObject i3;
    public GameObject i4;
    public GameObject i5;
    public GameObject i6;
    public GameObject i7;
    public GameObject i8;
    public GameObject i9;
    public GameObject i10;
    public GameObject i11;

    public bool DirTog = false;

    private GameObject[] Nodes;
    private GameObject[] Lines;

    private Text[] nameText;

    public void OnButtonPressStart()
    {
        i1.SetActive(false);
        i2.SetActive(false);
        i3.SetActive(false);
        i4.SetActive(false);
        i5.SetActive(false);
        i6.SetActive(false);
        i7.SetActive(false);
        i8.SetActive(false);
        i9.SetActive(false);
        i10.SetActive(true);

        Nodes = GameObject.FindGameObjectsWithTag("Node");
        Lines = GameObject.FindGameObjectsWithTag("Line");

    }


    public void OnButtonPressNext()
    {
        float min = 999;
        int it = 0;
        int pr = -1;
        foreach (GameObject node in Nodes)
        {
            if ((node.GetComponent<Node>().Number < min) && (node.GetComponent<Node>().Processed == false))
            {
                pr = it;
                min = node.GetComponent<Node>().Number;
            }
            if (node.GetComponent<Node>().Name != "A")
            {
                node.GetComponent<SpriteRenderer>().color = Color.white;
            }
            it++;
        }
        if (pr != -1)
        {
            if (Nodes[pr].GetComponent<Node>().Name != "A")
            {
                Nodes[pr].GetComponent<SpriteRenderer>().color = Color.green;
            }
            foreach (GameObject line in Lines)
            {
                if (line.GetComponent<Line>().start_point.GetComponent<Node>().Name == Nodes[pr].GetComponent<Node>().Name)
                {
                    if ((line.GetComponent<Line>().end_point.GetComponent<Node>().Processed == false) &&
                        (Nodes[pr].GetComponent<Node>().Number + line.GetComponent<Line>().Length < line.GetComponent<Line>().end_point.GetComponent<Node>().Number))
                    {
                        line.GetComponent<Line>().end_point.GetComponent<Node>().Number = Nodes[pr].GetComponent<Node>().Number + line.GetComponent<Line>().Length;
                        nameText = line.GetComponent<Line>().end_point.GetComponentsInChildren<Text>();
                        nameText[1].text = line.GetComponent<Line>().end_point.GetComponent<Node>().Number.ToString();

                        line.GetComponent<SpriteRenderer>().color = Color.green;
                    }
                    else
                    {
                        line.GetComponent<SpriteRenderer>().color = Color.white;
                    }
                }
                else if (line.GetComponent<Line>().end_point.GetComponent<Node>().Name == Nodes[pr].GetComponent<Node>().Name)
                {
                    if ((line.GetComponent<Line>().start_point.GetComponent<Node>().Processed == false) &&
                        (Nodes[pr].GetComponent<Node>().Number + line.GetComponent<Line>().Length < line.GetComponent<Line>().start_point.GetComponent<Node>().Number))
                    {
                        line.GetComponent<Line>().start_point.GetComponent<Node>().Number = Nodes[pr].GetComponent<Node>().Number + line.GetComponent<Line>().Length;
                        nameText = line.GetComponent<Line>().start_point.GetComponentsInChildren<Text>();
                        nameText[1].text = line.GetComponent<Line>().start_point.GetComponent<Node>().Number.ToString();

                        line.GetComponent<SpriteRenderer>().color = Color.green;
                    }
                    else
                    {
                        line.GetComponent<SpriteRenderer>().color = Color.white;
                    }
                }
                else
                {
                    line.GetComponent<SpriteRenderer>().color = Color.white;
                }
            }
            Nodes[pr].GetComponent<Node>().Processed = true;
        }
        else
        {
            i10.SetActive(false);
            i11.SetActive(true);
        }
    }

    public void OnButtonPressFinish()
    {
        i1.SetActive(true);
        i2.SetActive(true);
        i3.SetActive(true);
        i4.SetActive(true);
        i5.SetActive(true);
        i6.SetActive(true);
        i7.SetActive(true);
        i8.SetActive(true);
        i9.SetActive(true);
        i11.SetActive(false);
        foreach (GameObject node in Nodes)
        {
            if (node.GetComponent<Node>().Name != "A")
            {
                node.GetComponent<Node>().Number = 999f;
                nameText = node.GetComponentsInChildren<Text>();
                nameText[1].text = node.GetComponent<Node>().Number.ToString();
                node.GetComponent<SpriteRenderer>().color = Color.white;
            }
            node.GetComponent<Node>().Processed = false;
        }
        foreach (GameObject line in Lines)
        {
            line.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

}
