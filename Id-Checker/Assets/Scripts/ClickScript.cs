
using UnityEngine;

public class ClickScript : MonoBehaviour
{

    Vector3 mousePosition;
    RaycastHit2D raycastHit2D;
    Transform clickObject;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Input.mousePosition;
        Ray mouseray = Camera.main.ScreenPointToRay(mousePosition);

        if (Input.GetMouseButton(0))
        {
            raycastHit2D = Physics2D.Raycast(mouseray.origin, mouseray.direction);
            clickObject = raycastHit2D ? raycastHit2D.collider.transform : null; 
            if(clickObject)
            {

                clickObject.GetComponent<SpriteRenderer>().color = Color.white;

            }
           
        }
    }
}
