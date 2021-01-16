
using UnityEngine;

public class CameraControl : MonoBehaviour {

	// TODO : ADD MAP LIMITS, DEPENDS ON GAME SIZE
	//vector2 = exei x kai y values
	public Vector2 panLimit;


	public int scrollSpeed = 10;
	public float zoomSize;
	//move speed
	public float panSpeed = 20f;

	//gia mouse control, oxi scroll, move mouse on screen edge san RTS game
	//public float panBorderThickness = 10f;

	void Update(){
	Vector3 pos = transform.position;
		if (Input.GetKey("w") )
		//|| Input.mousePosition.y >= Screen.height - panBorderThickness
		{
			// gia na einai related me to time kai oxi me to framerate
			//deltatime = xronos pou mesolavei anamesa se 2 frames
			pos.x -= panSpeed * Time.deltaTime;
		}
		if (Input.GetKey("s") )
		// Input.mousePosition.y <= panBorderThickness)
		{
			// gia na einai related me to time kai oxi me to framerate
			//deltatime = xronos pou mesolavei anamesa se 2 frames
			pos.x += panSpeed * Time.deltaTime;
		}
		if (Input.GetKey("d") )
		//|| Input.mousePosition.y >= Screen.width - panBorderThickness)
		{
			// gia na einai related me to time kai oxi me to framerate
			//deltatime = xronos pou mesolavei anamesa se 2 frames
			pos.y += panSpeed * Time.deltaTime;
		}
		if (Input.GetKey("a"))
		// || Input.mousePosition.y <= panBorderThickness)
		{
			// gia na einai related me to time kai oxi me to framerate
			//deltatime = xronos pou mesolavei anamesa se 2 frames
			pos.y -= panSpeed * Time.deltaTime;
		}

	// gia zoomin kai zoomout
	if(zoomSize <=160){
    	if(Input.GetAxis("Mouse ScrollWheel") < 0) {
        zoomSize += scrollSpeed;
    	}
	}
	if(zoomSize >=60){
    	if(Input.GetAxis("Mouse ScrollWheel") > 0) {
        zoomSize -= scrollSpeed;
    	}
	}
	GetComponent<Camera> ().orthographicSize = zoomSize;
	

	

	// ma kleinei to cam movement mesa se auto to range
	pos.x = Mathf.Clamp(pos.x, -panLimit.x, panLimit.x);
	pos.y = Mathf.Clamp(pos.y, -panLimit.y, panLimit.y);

	transform.position = pos;


	}


}
