using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace OAT
{
	public class LevelController : MonoBehaviour 
	{
		float m_timeToEnd;
		float m_timeToGeneration;
		int m_lives;
		int m_scores;
		int m_bombs;

		bool m_sessionStarted;
		List<UnitModel> activeUnits = new List<UnitModel>();
		public BombEffect bombEffectPrefab;


		void ResetLevel()
		{
			m_timeToEnd = GameConfig.LEVEL_TIME_SECONDS;
			m_lives = GameConfig.PLAYER_LIVES;
			m_timeToGeneration = GenerationTime();
			m_scores = 0;
			m_sessionStarted = true;
			m_bombs = GameConfig.BOMBS_COUNT;

			UIController.Instance.UpdateLives(m_lives);
			UIController.Instance.UpdateBombs(m_bombs);
		}

		public void ClearActiveUnits()
		{
			foreach(UnitModel unit in activeUnits)
				Destroy(unit.gameObject);

			activeUnits.Clear();
		}

		public void StartNewLevel()
		{
			ResetLevel();
		}

		void EndLevel()
		{
			m_sessionStarted = false;
			GameController.Instance.FinishLevel(m_lives > 0);
		}

		void Update()
		{
			if(!m_sessionStarted || GameController.IsPaused)
				return;

			TryGenerateUnity();
			UIController.Instance.UpdateTime((int)m_timeToEnd);
			m_timeToEnd -= Time.deltaTime;
			if(m_timeToEnd <= 0f)
				EndLevel();
		}

		float GenerationTime()
		{
			return Random.Range(GameConfig.GENERATION_RATE_MIN, GameConfig.GENERATION_RATE_MAX);
		}

		void TryGenerateUnity()
		{
			m_timeToGeneration -= Time.deltaTime;
			if(m_timeToGeneration <= 0f)
			{
				m_timeToGeneration = GenerationTime();
				UnitType type = GetTypeByChance();
				UnitInfo info = new UnitInfo(type);
				UnitModel unit = UnitFactory.Instance.GenerateUnit(info);
				activeUnits.Add(unit);
			}
		}

		public void RemoveUnitFromActive(UnitModel unit)
		{
			activeUnits.Remove(unit);
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
				if(summChance >= rnd)
					break;
			}

			return result;
		}

		public void DemagePlayer()
		{
			--m_lives;
			UIController.Instance.UpdateLives(m_lives);
			if(m_lives < 1)
				EndLevel();
		}

		public int GetBombsCount()
		{
			return m_bombs;
		}

		public void UseBomb(Vector3 position)
		{
			BombEffect bombEffect = Instantiate<BombEffect>(bombEffectPrefab);
			bombEffect.transform.position = position;

			--m_bombs;
			UIController.Instance.UpdateBombs(m_bombs);
		}
	}
}