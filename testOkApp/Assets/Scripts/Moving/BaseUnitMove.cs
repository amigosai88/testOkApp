using UnityEngine;
using System.Collections;


namespace OAT
{
	public class BaseUnitMove : MonoBehaviour 
	{
		protected float m_speed;
		bool inited;

		public virtual void Init(UnitInfo info)
		{
			m_speed = info.m_speed;
			inited = true;
		}

		void Update () 
		{
			if(!inited)
				return;

			transform.Translate(transform.forward * -m_speed);
		}
	}
}
