using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour {


	// Use this for initialization
	public Text livesText;	

	public Text countText;
	public Text winText;
	public float speed; 
	// Shows up in inspector as an editable property
	private Rigidbody rb;
	private int count;

	private int lives;
	private GameObject player;


	public Text timerText;
	private float starttime;

	void Start () 
	{
		//All of the code in the start() is called on the first function that the script is active
		//This is how i get access to the rigidbody component of the the Player Object 
		rb = GetComponent<Rigidbody>();
		count =0 ;
		lives = 3;
		SetCountText();
		ShowLives();
		winText.text = "";

		player = GameObject.FindGameObjectWithTag("Player");

		starttime = Time.time;
	}

	void Update() // called before rendering a frame 
	{

		Stop_Timer(true);
	}

	void Stop_Timer(bool val)
	{
		if(val == true)
		{
			float t = Time.time - starttime;

			string minutes = ((int) t/60).ToString();
			string seconds = (t%60).ToString("f2");
			timerText.text = "Timer : " + minutes+" : "+seconds;
		}
	}

	void FixedUpdate() // called before any Physics Calculation
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(moveHorizontal,0.0F,moveVertical);

		rb.AddForce(movement*speed,ForceMode.Force);


	}

	void OnTriggerEnter(Collider other) // we get the other game objects collider
	{
        //Destroy(other.gameObject);
        if(other.gameObject.CompareTag("Pick Up"))
        {
			other.gameObject.SetActive(false);
			count = count + 1 ; 
			SetCountText();
        }


		if(other.gameObject.CompareTag("DangerCapsule"))
        {
			
			lives = lives -1 ;
			ShowLives();
        }

		if(other.gameObject.CompareTag("walls"))
        {
			
			lives = lives - 1 ;
			ShowLives();
        }

    }


    void SetCountText()
    {
		countText.text = "Score : "+count.ToString();
		if(count >=13)
		{
			winText.text = "You Win !!! ";
			player.SetActive(false);
		}
    }

	void ShowLives()
    {
		livesText.text = "Lives : "+ lives.ToString();
		if(lives <= 0)
		{
			winText.text = "Game Over";
			Stop_Timer(false);
			player.SetActive(false);
		}
    }
}
