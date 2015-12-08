using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace OAT
{
	public class UIController : MonoBehaviour 
	{
		private static UIController m_instance = null;
		public static UIController Instance
		{
			get {return m_instance;}
		}

		public Text m_livesLabel; 
		public Text m_timeLabel;
		public GameObject m_summary;
		public GameObject m_resetBttn;
		public Text m_summaryLabel;

		const string WIN_LABEL = "LEVEL\nCOMPLETE";
		const string LOSE_LABEL = "LEVEL\nFAILED";

		void Awake()
		{
			m_instance = this;
		}

		public void UpdateTime(int time)
		{
			m_timeLabel.text = "Time: " + time.ToString();
		}

		public void UpdateLives(int lives)
		{
			m_livesLabel.text = "Lives: " + lives.ToString();
		}

		public void FinishLevel(bool win)
		{
			m_summaryLabel.text = (win) ? WIN_LABEL : LOSE_LABEL;
			m_resetBttn.SetActive(!win);
			m_summary.SetActive(true);
			GameController.IsPaused = true;
		}

		public void Restart()
		{
			m_summary.SetActive(false);
			GameController.Instance.RestartLevel();
		}

	}
}