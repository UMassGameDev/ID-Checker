using UnityEngine;
using UnityEngine.InputSystem;

public class HoverObject : MonoBehaviour
{
    Vector3 mousePosition;
    RaycastHit2D raycastHit2D;
    Transform prevHover, NextHover;
    public GameObject gameobject; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Input.mousePosition;
        Ray mouseRay = Camera.main.ScreenPointToRay(mousePosition);
        prevHover = NextHover;
        raycastHit2D = Physics2D.Raycast(mouseRay.origin, mouseRay.direction);
        NextHover = raycastHit2D ? raycastHit2D.collider.transform : null; 
        if(NextHover)
        {
            NextHover.GetComponent<SpriteRenderer>().color = Color.orange; 
            if(prevHover && NextHover && prevHover.GetInstanceID() != NextHover.GetInstanceID())
            {
                prevHover.GetComponent<SpriteRenderer>().color = Color.white;
            }
   

        }
        else
        {
            if (prevHover)
                prevHover.GetComponent<SpriteRenderer>().color = Color.white; 
        }
    }
}
