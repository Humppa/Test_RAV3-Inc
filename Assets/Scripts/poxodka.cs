using UnityEngine;
using System.Collections;


public class poxodka : MonoBehaviour
{

	[FMODUnity.EventRef]
	public string m_EventPath;


	public float m_StepDistance = 2.0f;
	float m_StepRand;
	Vector3 m_PrevPos;
	float m_DistanceTravelled;


	public bool m_Debug;
	Vector3 m_LinePos;
	Vector3 m_TrianglePoint0;
	Vector3 m_TrianglePoint1;
	Vector3 m_TrianglePoint2;

	void Start()
	{
		//Initialise random, set seed
		Random.InitState(System.DateTime.Now.Second);

		//Initialise member variables
		m_StepRand = Random.Range(0.0f, 0.5f);
		m_PrevPos = transform.position;
		m_LinePos = transform.position;
	}

	void Update()
	{
		m_DistanceTravelled += (transform.position - m_PrevPos).magnitude;
		if (m_DistanceTravelled >= m_StepDistance + m_StepRand)//TODO: Play footstep sound based on position from headbob script
		{
			PlayFootstepSound();
			m_StepRand = Random.Range(0.0f, 0.5f);//Adding subtle random variation to the distance required before a step is taken - Re-randomise after each step.
			m_DistanceTravelled = 0.0f;
		}

		m_PrevPos = transform.position;

		if (m_Debug)
		{
			Debug.DrawLine(m_LinePos, m_LinePos + Vector3.down * 1000.0f);
			Debug.DrawLine(m_TrianglePoint0, m_TrianglePoint1);
			Debug.DrawLine(m_TrianglePoint1, m_TrianglePoint2);
			Debug.DrawLine(m_TrianglePoint2, m_TrianglePoint0);
		}
	}

	void PlayFootstepSound()
	{
		

		if (m_EventPath != null)
		{
			FMOD.Studio.EventInstance e = FMODUnity.RuntimeManager.CreateInstance(m_EventPath);
			e.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(transform.position));

			e.start();
			e.release();//Release each event instance immediately, there are fire and forget, one-shot instances. 
		}
	}

	
}
