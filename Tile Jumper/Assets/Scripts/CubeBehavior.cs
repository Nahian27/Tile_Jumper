using UnityEngine;
using FMODUnity;

public class CubeBehavior : MonoBehaviour
{
    public Joystick joystick;
    public GameObject[] DeathParticle;
    public StudioEventEmitter BackgroundMusic, CollideSFX, ExplosionSFX;
    public bool Froce60fps;
    public float JumpForce, HorizontalSpeed, CubeColForce;
    private Rigidbody CubeRigidbody;
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

        BackgroundMusic.Play();
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
            CollideSFX.Play();
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
        gameObject.SetActive(false);
        Instantiate(DeathParticle[Random.Range(0, DeathParticle.Length)], transform.position, transform.rotation);

        ExplosionSFX.Play();
        BackgroundMusic.Stop();
    }


}