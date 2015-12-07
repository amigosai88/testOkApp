using UnityEngine;
using System.Collections;


namespace OAT
{
	public enum UnitType
	{
		EnemyLinear = 0,
		EnemyDiagonal,
		Alied
	}

	public class UnitInfo
	{
		public UnitType m_unitType;
		public float m_speed;

		public UnitInfo(UnitType type, float speed)
		{
			m_unitType = type;
			m_speed = speed;
		}
	}
}