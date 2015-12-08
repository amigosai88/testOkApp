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

		public static bool IsPaused;
		public LevelController levelController;

		void Awake()
		{
			m_instance = this;
		}

		void Start()
		{
			levelController.StartNewLevel();
		}

		public void RestartLevel()
		{
			GameController.IsPaused = false;
			levelController.StartNewLevel();
		}

		public void LoadMainMenu()
		{
			GameController.IsPaused = false;
			Application.LoadLevel("Menu");
		}

		public void FinishLevel(bool win)
		{
			UIController.Instance.FinishLevel(win);
		}
	}
}
