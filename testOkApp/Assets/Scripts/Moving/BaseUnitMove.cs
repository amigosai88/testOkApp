using UnityEngine;
using System.Collections;


namespace OAT
{
	public class BaseUnitMove : MonoBehaviour 
	{
		protected float m_speed;
		bool canMove;

		public virtual void Init(UnitInfo info)
		{
			m_speed = info.m_speed;
			canMove = true;
		}

		public void StopMoving()
		{
			canMove = false;
		}

		void Update () 
		{
			if(!canMove || GameController.IsPaused)
				return;

			transform.Translate(transform.forward * -m_speed);
		}
	}
}
