using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ObjectHandler : MonoBehaviour
{
    public static ObjectHandler instance;

    public GameObject Obj;
    private Touch touch;
    public float speed = 0.01f;
    public bool CanMove,canEdit = false;
    bool posSet = false;
    public float timer = 2;
    Vector3 initialTransform, initialRotation;
    public GameObject EditPanel;
    private Vector3 newPos;
    [SerializeField] Slider yAxisSlider;

    [SerializeField] Button shopBtn;
    [SerializeField] GameObject panel;
    public float totalTime = 0;
    public float spawnTime = 0;
    public TMP_Text timerText;
    public Image slider;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        EditPanel.SetActive(false);
        

    }
    //Call this function at the object instaniate to make this properties work fine.
    public void Spawn(GameObject a)
    {
        canEdit = true;
        Obj = a;

    }
    private void Update()
    {       
           if (Obj != null)
               Obj.transform.position = new Vector3(Obj.transform.position.x, yAxisSlider.value, Obj.transform.position.z);

            if (spawnTime > 0)
            {
                panel.SetActive(true);
                shopBtn.interactable = false;
                spawnTime -= Time.deltaTime;
                slider.fillAmount = spawnTime / totalTime;
                Timer(spawnTime);
            }
            else
            {
                panel.SetActive(false);
                shopBtn.interactable = true;
            }
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

                //   Debug.Log("FS");
                if (touch.phase == TouchPhase.Began)
                {

                    Ray ray = Camera.main.ScreenPointToRay(touch.position);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit))
                    {
                        if (hit.collider.tag == "Obstacle")
                        {
                            //Debug.Log(hit.collider.name);
                            Obj = hit.collider.gameObject;
                          //  yAxisSlider.value = transform.position.y;
                            //Obj.transform.rotation = Quaternion.Euler(0, 90, 0);
                        }
                    }
                }
                if(touch.phase == TouchPhase.Stationary)
                {
                    Ray ray = Camera.main.ScreenPointToRay(touch.position);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit))
                    {
                        if (hit.collider.tag == "Obstacle")
                        {
                            if (timer >= 0)
                            {
                                timer -= Time.deltaTime;

                            }
                            else if (timer < 0)
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
               
                }
                if (Obj != null)
                {
                    if (CanMove)
                    {
                   
                   
                        Plane plane = new Plane(Vector3.up, new Vector3(0, 0, 0));
                        RaycastHit hit;
                        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                        float distance;
                        if (Physics.Raycast(ray, out hit))
                        {
                            if (plane.Raycast(ray, out distance))
                            {
                                Vector3 pos = ray.GetPoint(distance);
                                pos.x = Mathf.Clamp(pos.x, Obj.GetComponent<ObjectBehaviour>().min, Obj.GetComponent<ObjectBehaviour>().max);
                                pos.y = ray.GetPoint(distance).y;
                                pos.z = Mathf.Clamp(pos.z, Obj.GetComponent<ObjectBehaviour>().min, Obj.GetComponent<ObjectBehaviour>().max);
                                Obj.transform.position = pos;
                            }
                        }
                    }
                }
            }  
    }
    private void LateUpdate()
    {

    }
    public void Timer(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
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
        ObjectBehaviour.instance.SavePos();
        Obj = null;
    }
    public void PutInInventory()
    {
        Obj.GetComponent<ObjectBehaviour>().Inventory();
        canEdit = false;
        posSet = false;
    }
    public void Cancel()
    {
       
        canEdit = false;
        Obj.transform.eulerAngles = initialRotation;
        Obj.transform.position = initialTransform;
        posSet = false;
        Obj = null;
    }
}
