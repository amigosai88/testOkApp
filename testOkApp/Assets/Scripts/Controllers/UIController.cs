﻿using UnityEngine;
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

		void Awake()
		{
			m_instance = this;
		}
		public void UpdateLabel(int lives)
		{
			m_livesLabel.text = "Lives: " + lives.ToString();
		}
	}
}