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
				transform.postion = new Vector3(transform.postion.x + GameConfig.DIAGONAL_MOVING_SPEED * m_movingSign);
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
			if(transform.postion.x + GameConfig.DIAGONAL_MOVING_SPEED * m_movingSign > WorldRect.Instance.PLAY_FIELD_WIDTH/2f ||
			   transform.postion.x + GameConfig.DIAGONAL_MOVING_SPEED * m_movingSign < -WorldRect.Instance.PLAY_FIELD_WIDTH/2f)
				m_movingSign *= -1;
		}
	}
}
