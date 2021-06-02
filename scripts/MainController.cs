using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainController : MonoBehaviour
{
    Transform head_tr;

    float MouseX;
    float MouseY;
    public float sens = 3f;
    int check = 0;
    public GameObject FirstCamera;
    public GameObject ThirdCamera;
    public GameObject birdHouse;



    // Start is called before the first frame update
    void Start()

    {
        head_tr = GetComponent<Transform>();
        ThirdCamera.SetActive(false);
    }
    
    void Update()
    {
        MouseX = MouseX + Input.GetAxis("Mouse X") * sens;
        MouseY = MouseY - Input.GetAxis("Mouse Y") * sens;

        MouseY = Mathf.Clamp(MouseY, -90, 90);

        head_tr.rotation = Quaternion.Euler(MouseY, MouseX, 0);

        FindObjectOfType<BodyController>().Poluchatel(MouseX);
        Debug.DrawRay(head_tr.position, head_tr.forward * 3f);

      
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
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "birdHouse")
        {
            SceneManager.LoadScene("you win");
        }


    }


}
