using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Movement : MonoBehaviour {

	//the transform components of the background layers
	public Transform frontClouds;
	public Transform farBackground;
	public Transform dust;

	//the transform component of the place where the player clicked
	public Transform nextPosition;

	//the transform component of the camera
	public Transform cameraTransform;
	private float constantCameraSpeed = 2;

	public Text score;//the score
	public int scorePerStepMax = 15;//the score range a player can get when he travels the step distance
	public int scorePerStepMin = 7;//the min. of the range
	public float scoreStep = 10;//the X distance the player has to travel in order to gain score;
	private float currentStep = 0;//a counter for the step
	
	private Transform current;//the transform of the player
	private Animator animator;//the animator component of the player

	public float speed = 28f;//the initial speed of the player as he starts a movement
	public float currentSpeed = 28f;//the speed of the player with applied aceleration
	public float acceleration = 0.46f;//the rate at witch the player's speed changes
	private float speedMultiplier = 1f;//the increase in speed depending on purchased upgrades
	private float minSpeed1;//the second lowest speed
	private float minSpeed2;//the lowest possible speed
	
	public float distance;//the distance between the players current position, and his destination

	//happens only at the start of the game
	void Start () {
		minSpeed1 = 3 * speed / 5;
		minSpeed2 = 2 * speed / 7;
		current = GetComponent<Transform>();//initialize the position
		animator = GetComponent<Animator>();//initialize the animator
		speedMultiplier = 1 + (5 - PlayerPrefs.GetFloat ("SpeedMultiplier"))*0.055f;//get the speedMultiplier value, as it is saved
	}

	// Update is called once per frame
	void Update () {
		distance = Vector2.Distance (current.position, nextPosition.position);//initialize the distance's value(happens every frame)

		//the part of the code there the movement of the player is conducted, if he hasn't yet reached his destination
		if (distance > 0.3 && currentSpeed > 0f)
		{
			float xBefore = current.position.x;//in order to evaluate the change in x we save the it beforehand

			if (currentSpeed > minSpeed1) {//depending on wether the second lowest speed is reached, the current speed is reduced
				currentSpeed -= acceleration;
			} else if (currentSpeed <= minSpeed1 && currentSpeed > minSpeed2) {//if the second lowest speed is riched, the speed gets decreased by less until it reaches the minimum speed
				currentSpeed -= 2*acceleration / 5;
			}
			float step = currentSpeed * Time.deltaTime * speedMultiplier;//the rate at witch the player is moving with every frame, it is proportional to the speed
			current.position = Vector2.MoveTowards (current.position, nextPosition.position, step);//the player is moved in a traight line in direction of the destination

			float dX = Mathf.Abs(xBefore - current.position.x);//the distance the player moved during the current frame
			//this part of the code grants score to the player
			int scoreNumber = int.Parse(score.text);//the score's value
			if(currentStep >= scoreStep)//the code activates once every step
			{
				currentStep = 0;//the current step is reset
				scoreNumber += Random.Range(scorePerStepMin,scorePerStepMax);//the score is increased 
				score.text = scoreNumber.ToString();//the score increase is applied to the text
			}
			else//if the step isn't reached yet no score is given, but the step increases
			{
				currentStep += dX;
			}

			//the player's rotation is changed so that he faces the destination
			float dx = current.position.x - nextPosition.position.x;
			float dy = current.position.y - nextPosition.position.y;
			float radians = Mathf.Atan2 (dy, dx);
			float rotateZ = radians * 180 / Mathf.PI - 270;
			current.eulerAngles = new Vector3 (current.rotation.x, current.rotation.y, rotateZ);
		}
		else if(currentSpeed > 0){//if the player has reached his destination, yet he hasn't stopped
			currentSpeed = 0f;//the player stops
			animator.SetBool("Stop", true);//the player idle animation is played
		}

		//the camera speed is adjusted depending on the player's position in relation to the camera
		//if the player is too far ahead the camera starts moving very fast, until the player's position is normalised
		//if the player is too far behind the camera stops moving until his position is normalised
		if (cameraTransform.position.x + 1< current.position.x)
						constantCameraSpeed = speed*5.7f/7f;
		if (cameraTransform.position.x - 11 > current.position.x)
						constantCameraSpeed = minSpeed1 - 0.5f;
		if (cameraTransform.position.x - 19 > current.position.x)
						constantCameraSpeed = 0;


		cameraTransform.Translate(Vector2.right*Time.deltaTime*constantCameraSpeed);//the camera is moved depending on it's speed

		//depending on their presumed distance to the camera, the background layers move with different speeds
		//to create a paralax effect, adding depth to the image
		farBackground.Translate (Vector2.right * Time.deltaTime * constantCameraSpeed / 3);
		frontClouds.Translate (-Vector2.right * Time.deltaTime * constantCameraSpeed / 4);

		//the dust above the player never changes position in relation to the camera
		dust.position = new Vector3 (cameraTransform.position.x, dust.position.y, dust.position.z);

		//while the player is not moving, his rotation is constantly adjusted to face the cursor
		if (currentSpeed == 0) {
			Vector3 mouse = Input.mousePosition;
			mouse.z = 0;
			Vector3 mouse1 = Camera.main.ScreenToWorldPoint (mouse);
			float dx = current.position.x - mouse1.x;
			float dy = current.position.y - mouse1.y;
			float radians = Mathf.Atan2 (dy, dx);
			float rotateZ = radians * 180 / Mathf.PI - 270;
			current.eulerAngles = new Vector3 (current.rotation.x, current.rotation.y, rotateZ);
				}

	}
}
