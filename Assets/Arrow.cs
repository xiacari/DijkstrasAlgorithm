using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public GameObject Line;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Line.transform.rotation;
        float angle = transform.rotation.eulerAngles.z * Mathf.Deg2Rad;
        float scale = Line.GetComponent<Line>().Scale / 2 - 0.5f;
        Vector3 pos = new Vector3(Line.transform.position.x + scale * Mathf.Cos(angle), Line.transform.position.y + scale * Mathf.Sin(angle), 0.0f);
        transform.position = pos;

        GetComponent<SpriteRenderer>().color = Line.GetComponent<SpriteRenderer>().color;
    }
}
