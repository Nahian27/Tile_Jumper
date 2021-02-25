using UnityEngine;
using UnityEngine.SceneManagement;

public class CubeBehavior : MonoBehaviour
{
    public Joystick joystick;
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
    void FixedUpdate()
    {
        if (Input.GetButtonDown("Jump"))
        {
            jump();
        }
        if (Input.GetKey(KeyCode.LeftArrow) || joystick.Horizontal <= -0.5f)
        {
            Hmovement(-HorizontalSpeed);
        }
        if (Input.GetKey(KeyCode.RightArrow) || joystick.Horizontal >= 0.5f)
        {
            Hmovement(HorizontalSpeed);
        }
    }
    void OnTriggerExit()
    {
        SceneManager.LoadScene(0);
    }

    public void jump()
    {
        rb.AddForce(0f, JumpForce * Time.fixedDeltaTime, 0f, ForceMode.Impulse);
    }

    public void Hmovement(float speed)
    {
        rb.AddForce(speed * Time.fixedDeltaTime, 0f, 0f, ForceMode.Impulse);
    }
}
