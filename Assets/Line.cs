using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Line : MonoBehaviour
{

    public GameObject start_point;
    public GameObject end_point;
    public float Length;
    public float Scale;

    

    void Update()
    {
        float x;
        float y;

        //position
        if (start_point.transform.position.x <= end_point.transform.position.x) {
            x = start_point.transform.position.x + 0.5f * (end_point.transform.position.x - start_point.transform.position.x);
        } else
        {
            x = end_point.transform.position.x + 0.5f * (start_point.transform.position.x - end_point.transform.position.x);
        }

        if (start_point.transform.position.y <= end_point.transform.position.y)
        {
            y = start_point.transform.position.y + 0.5f * (end_point.transform.position.y - start_point.transform.position.y);
        }
        else
        {
            y = end_point.transform.position.y + 0.5f * (start_point.transform.position.y - end_point.transform.position.y);
        }

        //rotation
        Vector3 targ = start_point.transform.position;
        targ.z = 0f;

        Vector3 objectPos = transform.position;
        targ.x = targ.x - objectPos.x;
        targ.y = targ.y - objectPos.y;

        float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg + 180;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        transform.position = new Vector3(x, y, 0.0f);

        //scale
        Scale = Mathf.Sqrt(Mathf.Pow((start_point.transform.position.x - end_point.transform.position.x), 2) + Mathf.Pow((start_point.transform.position.y - end_point.transform.position.y), 2));
        transform.localScale = new Vector3(Scale-1, 1.0f, 1.0f);
    }
}