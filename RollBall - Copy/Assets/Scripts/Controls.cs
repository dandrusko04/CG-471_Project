using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
public class Controls : MonoBehaviour
{
    public float speed;

    private Rigidbody rb;

    private float movementX;
    private float movementY;

    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    private int count;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText ();
        winTextObject.SetActive(false);
    }

    private void OnMove(InputValue value)
    {
        Vector2 v = value.Get<Vector2>();

        movementX = v.x;
        movementY = v.y;
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }

     private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp")) 
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText ();
        }
    }
     void SetCountText()
	{
		countText.text = "Count: " + count.ToString();

		if (count >= 12) 
		{
                    // Set the text value of your 'winText'
                    winTextObject.SetActive(true);
		}
	}
}
