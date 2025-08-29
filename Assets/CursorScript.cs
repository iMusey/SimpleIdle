using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CursorScript : MonoBehaviour
{
    public GameObject cursor;
    private RectTransform canvasRect;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        cursor.transform.position = (mousePos);

        if (Input.GetMouseButtonDown(0))
        {
            Click();
        }
    }

    public void Click()
    {
        Vector2 screenPos = cursor.transform.position;

        Ray ray = Camera.main.ScreenPointToRay(screenPos);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 999))
        {
            Interactable interactable = hit.collider.GetComponent<Interactable>();
            if (interactable != null)
            {
                interactable.OnRaycastHit();
            }
        }
    }
}



/*if (Physics.Raycast(ray, out hit, 999))
        {
                
            if (hit.transform.GetComponent<BallScript>() != null)
            {
                BallScript temp = hit.transform.GetComponentInChildren<BallScript>();

                // Target the ball if left click
                if (Input.GetMouseButtonDown(0))
                {
                    // if its a different ball change the target
                    if (!temp.Equals(target))
                    {
                        target = null;
                    }
                    target = temp;
                    target.targeted = true;

                    // when you target a ball, look towards it

                    // radius based on distance to ball
                    radius = Vector3.Distance(target.transform.position, transform.position);

                    // tilt based on y position
                    tilt = -Mathf.Asin((target.transform.position.y - transform.position.y)/radius);

                    // theta based on
                    theta = Mathf.Atan2((transform.position.z - target.transform.position.z), (transform.position.x - target.transform.position.x));
                    center = target.transform.position;
                }
                else // otherwise hover it
                {
                    hover = temp;
                    hover.hovered = true;
                }
            }
            else if (Input.GetMouseButtonDown(0) && target != null)
            {
                target.targeted = false;
                target = null;
            }
        }*/