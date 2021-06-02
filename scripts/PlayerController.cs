using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    float v;
    float h;
    Rigidbody rb;
    Transform tr;
    public GameObject healthbar;
    Slider slider;
    public Text textTime;
   



    int time = 120; //создаю переменную для времени
    int health = 0;

    void timeMinus()  //функция для минуса времени
    {
        time = time - 1;
        print(time);
        textTime.text = "время:" + time;
    }
    void Start()
    {
        InvokeRepeating("timeMinus", 1, 1); //функция запуска таймера
        rb = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();
        slider = healthbar.GetComponent<Slider>();

    }
   

    void Update()
    {
        v = Input.GetAxis("Vertical");
        h = Input.GetAxis("Horizontal");

        rb.velocity = tr.forward * v * 10f;
        rb.AddForce(tr.right * h * 700f);



    }

    public void Poluchatel(float arg)
    {
        transform.rotation = Quaternion.Euler(0, arg, 0);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "trash")
        {
            health = health + 1;
            slider.value = health;
            Destroy(collision.gameObject);
        }
        if (health == 6)
        {
            SceneManager.LoadScene("level 2");
        }


    }
   
        
   
}
