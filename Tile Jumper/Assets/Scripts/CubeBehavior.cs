using UnityEngine;
using UnityEngine.SceneManagement;

public class CubeBehavior : MonoBehaviour
{
    public Joystick joystick;
    public bool Froce60fps;
    public float JumpForce, HorizontalSpeed;
    private Rigidbody rb;
    private bool isGrounded = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (Froce60fps == true)
        {
            Application.targetFrameRate = 60;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump();
        }
    }
    void FixedUpdate()
    {
        if (joystick.Horizontal <= -0.2 || Input.GetKey(KeyCode.LeftArrow))
        {
            Hmovement(-HorizontalSpeed);
        }
        else if (joystick.Horizontal >= 0.2 || Input.GetKey(KeyCode.RightArrow))
        {
            Hmovement(HorizontalSpeed);
        }
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
    public void jump()
    {
        if (isGrounded == true)
        {
            rb.AddForce(0f, JumpForce, 0f, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void Hmovement(float x)
    {
        rb.velocity = new Vector3(x, rb.velocity.y, 0f);
    }

    void OnTriggerExit()
    {
        SceneManager.LoadScene(0);
    }
}
