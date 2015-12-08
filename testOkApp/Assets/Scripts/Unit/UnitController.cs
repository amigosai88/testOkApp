using UnityEngine;
using System.Collections;


namespace OAT
{
	public class UnitController : MonoBehaviour 
	{
		public UnitModel unitModel;

		public void RemoveController()
		{
			unitModel.KillUnit();
			gameObject.SetActive(false);

			if(unitModel.unitInfo.m_unitType == UnitType.Alied)
				GameController.Instance.FinishLevel(false);
		}

		void OnMouseDown()
		{
			RemoveController();
		}
	}
}