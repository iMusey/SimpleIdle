using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class TilecardScript : MonoBehaviour
{
    public bool movable = true;
    public bool held = false;
    public Vector3 startingPos;
    public Vector3 currentPos;

    public GameObject textContainer;
    public TextMeshProUGUI title;
    public TextMeshProUGUI number;

    public LineRenderer lineRenderer;
    public TilecardScript[] parents;
    public TilecardScript[] kids;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (held)
        {
            if (Input.GetKeyUp(KeyCode.LeftControl))
            {
                held = false;
            }

            HoldCard();
        }

        TextFollowsCard(transform.position);
    }

    public void RaycastHitScript()
    {
        Debug.Log("yes.");


        if (Input.GetKey(KeyCode.LeftControl) && Input.GetMouseButtonDown(0))
        {
            held = true;
            startingPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        }

    }

    public void HoldCard()
    {
        currentPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        currentPos -= startingPos;
        currentPos.z = 0;
        transform.position = currentPos;
    }
    
    public void TextFollowsCard(Vector3 vec)
    {
        Vector3 newPos = vec;

        textContainer.transform.position = newPos;
    }

    public void UpdateLines()
    {

    }
}
