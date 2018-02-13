using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Text countText;
    public Text winText;

    private int count;

    public float speed;

    private Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;

        SetText();
        winText.text = string.Empty;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        float moveVertical = Input.GetAxis("Vertical") * speed;
        float moveHorizontal = Input.GetAxis("Horizontal") * speed;

        rb.AddForce(new Vector3(moveHorizontal, 0.0f, moveVertical));
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("pickup"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetText();
        }
    }


    void SetText()
    {
        countText.text = "count: " + count.ToString();
        if(count >=12)
        {
            winText.text = "You Win!";
        }
    }

}
