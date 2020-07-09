
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] paddle paddle1;
    [SerializeField] AudioClip[] ballsounds;
    [SerializeField] float randomFactor = 0.2f;
    Level gsObj;
    Vector2 paddleToball;
    Rigidbody2D myRigidBody2D;
    
    bool act;

    void Start()
    {
        gsObj = FindObjectOfType<Level>();
        act = true;
        paddleToball = transform.position - paddle1.transform.position;
        myRigidBody2D = GetComponent<Rigidbody2D>();
        gsObj.gameSpeed = 0.8f;
       
    }

    // Update is called once per frame
    void Update()
    {
        LockBallToPaddle(act);
        LaunchBall();

    }

    private void LaunchBall()
    {

        if (Input.GetMouseButtonDown(0))
        {
            act = false;
            myRigidBody2D.velocity = new Vector2(2f, 15f);

        }
    }

    private void LockBallToPaddle(bool act)
    {
        if (act)
        {
            Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
            transform.position = paddlePos + paddleToball;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        var obj = collision.gameObject.name;
        AudioClip clip;
        float x = Random.Range(0f, randomFactor);
        float y = Random.Range(0f, randomFactor);
        Vector2 velocityTweak = new Vector2(x,y);
        if (!act)
        {
            if (obj == "Paddle")
            {
                clip = ballsounds[1];
                GetComponent<AudioSource>().PlayOneShot(clip);
            }

            if (obj == "Left Wall" ||  obj == "Right Wall" || obj == "Upper Wall")
            {
                clip = ballsounds[0];
                GetComponent<AudioSource>().PlayOneShot(clip);
            }

           
            myRigidBody2D.velocity += velocityTweak;
            gsObj.gameSpeed += 0.005f;

            
        }

    }

    public void PlayNeutralSnd()
    {
        AudioClip clip;
        clip = ballsounds[0];
        GetComponent<AudioSource>().PlayOneShot(clip);
    }

    public void PlayCrackingSnd()
    {
        AudioClip clip;
        clip = ballsounds[2];
        GetComponent<AudioSource>().PlayOneShot(clip);
    }
}