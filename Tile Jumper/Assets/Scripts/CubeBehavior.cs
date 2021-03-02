using UnityEngine;

public class CubeBehavior : MonoBehaviour
{
    public Joystick joystick;
    public GameObject[] DeathParticle;
    public bool Froce60fps;
    public float JumpForce, HorizontalSpeed;
    private Rigidbody CubeRigidbody;
    private bool isGrounded = true;

    private void Start()
    {
        CubeRigidbody = GetComponent<Rigidbody>();

        if (Froce60fps == true)
        {
            Application.targetFrameRate = 60;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump();
        }
    }

    private void FixedUpdate()
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

    private void OnCollisionEnter(Collision col)
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
            CubeRigidbody.AddForce(0f, JumpForce, 0f, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void Hmovement(float x)
    {
        CubeRigidbody.velocity = new Vector3(x, CubeRigidbody.velocity.y, 0f);
    }

    private void OnTriggerExit()
    {
        //SceneManager.LoadScene(0);
        gameObject.SetActive(false);
        Instantiate(DeathParticle[Random.Range(0, DeathParticle.Length)], transform.position, transform.rotation);
    }


}