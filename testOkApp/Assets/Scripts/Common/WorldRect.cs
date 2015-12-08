using UnityEngine;
using System.Collections;


namespace OAT
{
	public class WorldRect : MonoBehaviour 
	{
		private static WorldRect m_instance = null;
		public static WorldRect Instance
		{
			get { return m_instance; }
		}
			
		public float PLAY_FIELD_WIDTH;

		void Awake()
		{
			m_instance = this;
			PLAY_FIELD_WIDTH = transform.localScale.x;
		}
	}
}