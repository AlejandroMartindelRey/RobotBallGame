using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotFreeAnim : MonoBehaviour {

	private bool startUp = true;
    public bool walking = false;
	Vector3 rot = Vector3.zero;
	float rotSpeed = 40f;
	Animator anim;
	private float time;

	// Use this for initialization
	void Awake()
	{
		anim = gameObject.GetComponent<Animator>();
		gameObject.transform.eulerAngles = rot;
	}

	// Update is called once per frame
	void Update()
	{
		if (startUp)
		{
			StartUpTimer();
		}
		CheckKey();
		gameObject.transform.eulerAngles = rot;
	}
	void StartUpTimer()
	{
		time += Time.deltaTime;
		if (time >= 3.5)
		{
			time = 0;
			startUp = false;
		}
	}
	void CheckKey()
	{
		// Walk
		if (Input.GetKey(KeyCode.W))
		{
			anim.SetBool("Walk_Anim", true);
			walking = true;
		}
		else if (Input.GetKeyUp(KeyCode.W))
		{
			anim.SetBool("Walk_Anim", false);
			walking = false;
		}

		// Rotate Left
		if (Input.GetKey(KeyCode.A))
		{
			rot[1] -= rotSpeed * Time.fixedDeltaTime;
		}

		// Rotate Right
		if (Input.GetKey(KeyCode.D))
		{
			rot[1] += rotSpeed * Time.fixedDeltaTime;
		}

		// Roll
		if (Input.GetKeyDown(KeyCode.Space) && walking != true && startUp == false)
		{
			if (anim.GetBool("Roll_Anim"))
			{
				anim.SetBool("Roll_Anim", false);
			}
			else
			{
				anim.SetBool("Roll_Anim", true);
			}
		}
	}

}
