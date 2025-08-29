using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TilecardScript : MonoBehaviour
{
    public bool movable = true;
    public bool held = false;
    public Vector3 startingPos;
    public Vector3 currentPos;

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
    }

    public void RaycastHitScript()
    {
        Debug.Log("yes.");


        if (Input.GetKey(KeyCode.LeftControl) && Input.GetMouseButtonDown(0))
        {
            held = true;
        }

    }

    public void HoldCard()
    {
        currentPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Camera.main.WorldToScreenPoint(currentPos + startingPos);
    }
}
