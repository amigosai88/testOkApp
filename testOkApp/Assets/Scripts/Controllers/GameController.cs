using UnityEngine;
using System.Collections;


namespace OAT
{
	public class GameController : MonoBehaviour 
	{
		private static GameController m_instance = null;
		public static GameController Instance
		{
			get {return m_instance;}
		}

		public LevelController levelController;

		void Awake()
		{
			m_instance = this;
		}

		public void RestartLevel()
		{
			levelController.StartNewLevel();
		}

		public void LoadMainMenu()
		{
			Application.LoadLevel("Menu");
		}

		public void FinishLevel(bool win)
		{
			// TEMP
			Debug.Log((win) ? "WIN" : "LOSE");
		}
	}
}
