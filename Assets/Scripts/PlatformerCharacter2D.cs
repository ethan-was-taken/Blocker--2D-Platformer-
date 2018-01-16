using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnitySampleAssets._2D
{

    public class PlatformerCharacter2D : MonoBehaviour {

        // temp
        public float speed = 0;

        // Variables related to animation
        private Animator anim;
        private bool facingRight = true;

        // Movement variables
        [SerializeField] private float maxSpeed = 10f;
        private Vector3 velocity;
        private float velocityXSmoothing;

        // Variables relating to jumping
        [SerializeField] private float jumpForce = 500f;
        public bool isOnBounceBox;

        // Movement related variables
        [SerializeField] public bool airControl = false;
        [SerializeField] private LayerMask whatIsGround;

        // Checking if on ground/hitting ceiling
        private Transform groundCheck; 
        private float groundedRadius = .2f; 
        public bool grounded = false; 

        // The Player
        public Rigidbody2D rigid;

        // Audio Stuff
        public AudioClip toPlay;
        AudioSource source;

        // BodyBlock Stuff
        public GameObject BodyBlock;
        private GameObject[] getCount;
        public bool bodyBlockCleared;

        private void Awake() {
            rigid = GetComponent<Rigidbody2D>();
            // Setting up references.
            groundCheck = transform.Find("GroundCheck");
            //ceilingCheck = transform.Find("CeilingCheck");
            anim = GetComponent<Animator>();
        }

        private void Start() {
            //isOnWall = false;
            isOnBounceBox = false;
            bodyBlockCleared = true;
            source = gameObject.GetComponent<AudioSource>();
        }

        private void FixedUpdate() {
            // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
            grounded = Physics2D.OverlapCircle(groundCheck.position, groundedRadius, whatIsGround);
            anim.SetBool("Ground", grounded);
            // Set the vertical animation
            anim.SetFloat("vSpeed", rigid.velocity.y);

            speed = rigid.velocity.magnitude;
        }

        private void Update() {
            // if they click the RMB
            if (Input.GetKeyDown(KeyCode.Mouse0)) {
                shootBodyBlock();
                HealthManager.hurtPlayer(33);
            }
            else if (Input.GetKeyDown(KeyCode.Escape)) {
                SceneManager.LoadScene("Main Menu");
            }
        }        

        public void Move(float move, bool crouch, bool jump) {
            //only control the player if grounded or airControl is turned on
            if (grounded || airControl) {
                airControl = true;
                // The Speed animator parameter is set to the absolute value of the horizontal input.
                anim.SetFloat("Speed", Mathf.Abs(move));
                // Move the character
                rigid.velocity = new Vector2(move * maxSpeed, rigid.velocity.y);
                // If the input is moving the player right and the player is facing left...
                if (move > 0 && !facingRight)
                    Flip();
                else if (move < 0 && facingRight)
                    Flip();
            }
            Jump(jump);
        }

        // Took this out of Move() because it started looking messy
        private void Jump(bool jump) {
            // If the player jumps on the ground
            if (grounded && jump && anim.GetBool("Ground")) {
                grounded = false;
                anim.SetBool("Ground", false);
                if (isOnBounceBox)
                    rigid.AddForce(new Vector2(0f, jumpForce/10));
                else
                    rigid.AddForce(new Vector2(0f, jumpForce));
                if (source.isPlaying)
                    source.Stop();
                source.Play();
            }
        }

        private void Flip() {
            // Switch the way the player is labelled as facing.
            facingRight = !facingRight;
            // Multiply the player's x local scale by -1.
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }

        private void shootBodyBlock() {
            getCount = GameObject.FindGameObjectsWithTag("BodyBlock");
            int numInstances = getCount.Length;

            if (numInstances >= 3)
                Destroy( getCount[0] );
            
            Vector2 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 myPos = rigid.position;

            Vector2 direction = target - myPos;
            direction.Normalize();

            Debug.Log(Input.mousePosition.x+"");

            //577 is about middle for mouse pos
            if(Input.mousePosition.x < Screen.width/2)
                myPos = new Vector2(myPos.x - .5f, myPos.y);
            else
                myPos = new Vector2(myPos.x + .5f, myPos.y);

            Debug.DrawLine(rigid.position, target, Color.magenta);

            myPos = new Vector2(myPos.x, myPos.y);
            GameObject projectile = (GameObject)Instantiate(BodyBlock, myPos, Quaternion.identity);
            projectile.GetComponent<Rigidbody2D>().velocity = direction * BodyBlockScript.speed;

        }

        void OnCollisionEnter2D(Collision2D coll) {
            // 13 = BodyBlock
            if (coll.gameObject.layer == 13)
                bodyBlockCleared = false;

            if (coll.transform.tag == "MovingPlatform")
                transform.parent = coll.transform;

            if (coll.gameObject.layer != 12)
                isOnBounceBox = false;
            else if (isOnBounceBox)
                return;
            else if (coll.gameObject.layer == 12) {
                isOnBounceBox = true;
                rigid.velocity = new Vector2(rigid.velocity.x, 0f);
                rigid.AddForce(new Vector2(0f, jumpForce*1.75f));
            }
        }

        void OnCollisionExit2D(Collision2D coll) {

            if (coll.transform.tag == "MovingPlatform")
                transform.parent = null;
            if (coll.gameObject.layer == 13)
                bodyBlockCleared = true;

        }
    }
}