using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHandler : MonoBehaviour
{
    public GameObject Obj;
    private Touch touch;
    public float speed = 0.01f;
    public bool CanMove,canEdit = false;
    bool posSet = false;
    public float timer = 2;
    Vector3 initialTransform, initialRotation;
    public GameObject EditPanel;

    private void Start()
    {
        EditPanel.SetActive(false);

    }
    private void Update()
    {
       
        if (canEdit)
        {
            EditPanel.SetActive(true);
        }
        else
        {
            EditPanel.SetActive(false);
        }
       
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
         
                Debug.Log("FS");
                if (touch.phase == TouchPhase.Began)
                {

                    Ray ray = Camera.main.ScreenPointToRay(touch.position);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit))
                    {
                        if (hit.collider.tag == "Obstacle")
                        {
                            Debug.Log(hit.collider.name);
                            Obj = hit.collider.gameObject;
                            //Obj.transform.rotation = Quaternion.Euler(0, 90, 0);
                        }
                    }
                }

                if (Obj != null)
                {
                  if (CanMove)
                  {
                    //EditPanel.SetActive(true);
                    if (touch.phase == TouchPhase.Moved)
                    {
                        Debug.Log("SS");

                        Obj.transform.position = new Vector3(
                             Obj.transform.position.x + touch.deltaPosition.x + speed,
                             Obj.transform.position.y,
                            Obj.transform.position.z + touch.deltaPosition.y + speed
                            );
                    }
                }
            }
        }
         
         
        
    }
    private void LateUpdate()
    {
        touch = Input.GetTouch(0);


        if (Input.touchCount > 0)
        {
            if (timer >= 0)
            {
                timer -= Time.deltaTime;

            }
            else if(timer < 0)
            {

                if (!posSet)
                {
                    initialTransform = Obj.transform.position;
                    initialRotation = Obj.transform.eulerAngles;
                    posSet = true;
                }
                CanMove = true;
                canEdit = true;
            }
            if (touch.phase == TouchPhase.Ended)
            {
                timer = 1;
                CanMove = false;
            }
        }
    }
    public void Rotate()
    {
        Vector3 ro;
        ro = new Vector3(Obj.transform.eulerAngles.x, Obj.transform.eulerAngles.y + 90, Obj.transform.eulerAngles.z);
        Obj.transform.eulerAngles = ro;
    }
    public void Done()
    {
        canEdit = false;
        posSet = false;
    }
    public void Cancel()
    {
        canEdit = false;
        Obj.transform.eulerAngles = initialRotation;
        Obj.transform.position = initialTransform;
        posSet = false;
    }
}
