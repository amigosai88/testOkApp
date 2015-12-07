using UnityEngine;
using System.Collections;


namespace OAT
{
	public class MenuController : MonoBehaviour 
	{
		public void StartGame()
		{
			Application.LoadLevel("Game");
		}
	}
}