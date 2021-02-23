using UnityEngine;

public class CubeBehavior : MonoBehaviour
{
    public Rigidbody rb;
    public float JumpForce;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            jump();
        }
    }

    void OnMouseDown()
    {
        jump();
    }

    void jump()
    {
        rb.AddForce(0f, JumpForce * Time.fixedDeltaTime, 0f);
    }
}
