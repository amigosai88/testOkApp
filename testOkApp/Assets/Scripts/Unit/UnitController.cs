using UnityEngine;
using System.Collections;


namespace OAT
{
	public class UnitController : MonoBehaviour 
	{
		public UnitModel unitModel;

		void OnMouseDown()
		{
			unitModel.KillUnit();
			gameObject.SetActive(false);
		}
	}
}