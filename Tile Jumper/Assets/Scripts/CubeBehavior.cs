using UnityEngine;

public class CubeBehavior : MonoBehaviour
{
    public Rigidbody rb;
    public bool Froce60fps;
    public float JumpForce, HorizontalSpeed;

    void Start()
    {
        if (Froce60fps == true)
        {
            Application.targetFrameRate = 60;
        }
    }
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            jump();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Hmovement(-HorizontalSpeed);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Hmovement(HorizontalSpeed);
        }
    }

    void OnMouseDown()
    {
        jump();
    }

    void jump()
    {
        rb.AddForce(0f, JumpForce * Time.fixedDeltaTime, 0f, ForceMode.Impulse);
    }

    void Hmovement(float speed)
    {
        rb.AddForce(speed * Time.fixedDeltaTime, 0f, 0f, ForceMode.Impulse);
    }
}
