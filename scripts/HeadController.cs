using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadController : MonoBehaviour
{
    Transform head_tr;

    float MouseX;
    float MouseY;
    public float sens = 3f;
    int check = 0;
    public GameObject FirstCamera;
    public GameObject ThirdCamera;

    public GameObject infoPanel;
    public GameObject Trash;
    public GameObject example;
    

    void Start()
    {
        head_tr = GetComponent<Transform>();
        ThirdCamera.SetActive(false);
       
    }


    void Update()
    {
        infoPanel.SetActive(false);
        MouseX = MouseX + Input.GetAxis("Mouse X") * sens;
        MouseY = MouseY - Input.GetAxis("Mouse Y") * sens;

        MouseY = Mathf.Clamp(MouseY, -90, 90);

        head_tr.rotation = Quaternion.Euler(MouseY, MouseX, 0);

        FindObjectOfType<PlayerController>().Poluchatel(MouseX);
        Debug.DrawRay(head_tr.position, head_tr.forward * 3f);


        RaycastHit hit_Object;
        if (Input.GetKeyDown("q"))
        {
            Trash.transform.SetParent(null);
      

        }
        if (Physics.Raycast(head_tr.position, head_tr.forward, out hit_Object, 100f))
        {
           
            if (hit_Object.collider.gameObject.tag == "trash")
            {
                infoPanel.SetActive(true);
                if(Input.GetKeyDown("e"))
                {
                  print("Есть нажатие");
                  Trash.transform.position = example.transform.position;
                  Trash.transform.SetParent(example.transform);

                }

            }
        }
            ;

        if (Input.GetKeyDown("c"))
        {
            if (check == 0)
            {
                check = 1;
                ThirdCamera.SetActive(true);
                FirstCamera.SetActive(false);

            }
            else
            {

                check = 0;
                ThirdCamera.SetActive(false);
                FirstCamera.SetActive(true);

            }
        }

    }
}
