using UnityEngine;
using System.Collections;



namespace OAT
{
	public class LevelController : MonoBehaviour 
	{
		float m_timeToEnd;
		float m_timeToGeneration;
		int m_lives;
		int m_scores;

		bool m_sessionFinished;

		void ResetLevel()
		{
			m_timeToEnd = GameConfig.LEVEL_TIME_SECONDS;
			m_lives = GameConfig.PLAYER_LIVES;
			m_timeToGeneration = GameConfig.GENERATION_RATE;
			m_scores = 0;
			m_sessionFinished = false;
		}

		public void StartNewLevel()
		{
			ResetLevel();
		}

		void EndLevel()
		{
			GameController.Instance.FinishLevel(m_lives > 0);
		}

		void Update()
		{
			if(m_sessionFinished)
				return;

			TryGenerateUnity();

			m_timeToEnd -= Time.deltaTime;
			if(m_timeToEnd <= 0f)
				EndLevel();
		}

		void TryGenerateUnity()
		{
			m_timeToGeneration -= Time.deltaTime;
			if(m_timeToGeneration <= 0f)
			{
				UnitType type = GetTypeByChance();
				UnitInfo info = new UnitInfo(type, GameConfig.UNIT_SPEED[(int)type]);
				UnitFactory.Instance.GenerateUnit(info);
			}
		}

		UnitType GetTypeByChance()
		{
			int rnd = Random.Range(0, 100);
			UnitType result = UnitType.EnemyLinear;
			int summChance = 0;

			int[] chances = GameConfig.GENERATE_CHANCE;
			for(int i = 0; i < chances.Length; ++i)
			{
				result = (UnitType)i;
				summChance += chances[i];
				if(summChance > rnd)
					break;
			}

			return result;
		}

		public void DemagePlayer()
		{
			--m_lives;
			if(m_lives < 1)
				EndLevel();
		}
	}
}