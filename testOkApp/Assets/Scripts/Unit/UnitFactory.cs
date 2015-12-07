using UnityEngine;
using System.Collections;


namespace OAT
{
	public class UnitFactory : MonoBehaviour 
	{
		private static UnitFactory m_instance = null;
		public static UnitFactory Instance
		{
			get { return m_instance; }
		}

		void Awake()
		{
			m_instance = this;
		}

		public void GenerateUnit(UnitInfo info)
		{

		}
	}
}