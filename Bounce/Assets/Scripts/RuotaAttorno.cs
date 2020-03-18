using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuotaAttorno : MonoBehaviour
{
    //inside class
    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;
    public GameObject target;

    private void Start()
    {
        
    }

    private void Update()
    {
        Swipe();
    }

    public void Swipe()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //save began touch 2d point
            firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }

        if (Input.GetMouseButtonUp(0))
        {
            //save ended touch 2d point
            secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            //create vector from the two points
            currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

            //normalize the 2d vector
            currentSwipe.Normalize();

            //swipe left
            if (currentSwipe.x < 0 && currentSwipe.y > -0.5f  && currentSwipe.y < 0.5f)
            {
                Debug.Log("left swipe");
                //transform.RotateAround(target.transform.position, -target.transform.forward, 5.0f);

                transform.rotation = Quaternion.Lerp(transform.rotation, transform.rotation, 5.0f * Time.deltaTime);
            }
            //swipe right
            if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
            {
                Debug.Log("right swipe");
                //transform.RotateAround(target.transform.position, target.transform.forward, 5.0f);

                transform.rotation = Quaternion.Lerp(transform.rotation, transform.rotation, 5.0f * Time.deltaTime);
            }
        }
    }
}
