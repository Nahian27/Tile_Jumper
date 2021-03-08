using UnityEngine;
using FMODUnity;

public class CubeBehavior : MonoBehaviour
{
    public Joystick joystick;
    public GameObject DeathParticle;
    private Rigidbody CubeRigidbody;
    public StudioEventEmitter BackgroundMusic, ExplosionSFX, CollideSFX;
    public bool Froce60fps;
    public float JumpForce, HorizontalSpeed, CubeColForce;
    private bool isGrounded = true;

    void Awake()
    {
        CubeRigidbody = GetComponent<Rigidbody>();
    }
    void Start()
    {

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

        CollideSFX.SetParameter("Impact", CubeColForce);
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

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isGrounded = true;
            CubeColForce = col.impulse.magnitude;
        }
        if (CollideSFX.isActiveAndEnabled) CollideSFX.Play();
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
        if (gameObject.GetComponentInChildren<Light>().enabled)
        {
            BackgroundMusic.Stop();
            gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
            gameObject.GetComponentInChildren<Light>().enabled = false;
        }
        else if (!gameObject.GetComponentInChildren<Light>().enabled)
        {
            BackgroundMusic.Play();
            gameObject.GetComponentInChildren<MeshRenderer>().enabled = true;
            gameObject.GetComponentInChildren<Light>().enabled = true;
        }

        Instantiate(DeathParticle, transform.position, transform.rotation);

        if (ExplosionSFX.isActiveAndEnabled) ExplosionSFX.Play();
    }
}