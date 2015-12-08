using UnityEngine;
using System.Collections;


namespace OAT
{
	public class DiagonalMove : BaseUnitMove
	{
		bool m_needDiagonalMoving;
		float m_timeToMoving;
		float m_diagonalMovingTime;
		float m_movingSign;

		void Start()
		{
			m_diagonalMovingTime = GameConfig.DIAGONAL_MOVING_TIME;
			m_timeToMoving = GameConfig.DIAGONAL_MOVING_RATE;
		}

		protected override void Moving()
		{
			base.Moving();
			if(m_needDiagonalMoving)
			{
				m_diagonalMovingTime -= Time.deltaTime;
				if(m_diagonalMovingTime < 0f)
				{
					m_diagonalMovingTime = GameConfig.DIAGONAL_MOVING_TIME;
					m_needDiagonalMoving = false;
				}
				
				CheckBounds();
				transform.position = new Vector3(transform.position.x + GameConfig.DIAGONAL_MOVING_SPEED * m_movingSign,
				                                 transform.position.y,
				                                 transform.position.z);
			}
			else
			{
				m_timeToMoving -= Time.deltaTime;
				if(m_timeToMoving < 0f)
				{
					m_timeToMoving = GameConfig.DIAGONAL_MOVING_RATE;
					m_needDiagonalMoving = true;
					m_movingSign = GetRandomSign();
				}
			}
		}

		float GetRandomSign()
		{
			return (Random.Range(0, 2) == 0) ? -1f : 1f;
		}

		void CheckBounds()
		{
			if(transform.position.x + GameConfig.DIAGONAL_MOVING_SPEED * m_movingSign > WorldRect.Instance.PLAY_FIELD_WIDTH ||
			   transform.position.x + GameConfig.DIAGONAL_MOVING_SPEED * m_movingSign < -WorldRect.Instance.PLAY_FIELD_WIDTH)
				m_movingSign *= -1;
		}
	}
}
