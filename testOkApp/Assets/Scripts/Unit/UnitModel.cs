using UnityEngine;
using System.Collections;



namespace OAT
{
	public enum UnitState
	{
		Run = 0,
		Dead
	}

	public class UnitModel : MonoBehaviour 
	{
		public UnitView unitView;
		public UnitController unitController;
		public BaseUnitMove unitMove;
		public UnitInfo unitInfo;
		public UnitState unitState = UnitState.Run;

		public void KillUnit()
		{
			unitState = UnitState.Dead;
			unitView.KillUnit();
			StartCoroutine(PushAfterDelay(0.5f));
		}

		IEnumerator PushAfterDelay(float delay)
		{
			unitMove.StopMoving();
			yield return new WaitForSeconds(delay);
			GameController.Instance.levelController.RemoveUnitFromActive(this);

			UnitFactory.Instance.AddToPool(this);
			gameObject.SetActive(false);
		}

		public void UnitStopped()
		{
			if(unitInfo.m_unitType != UnitType.Alied)
				GameController.Instance.levelController.DemagePlayer();

			StartCoroutine(PushAfterDelay(0.5f));
		}
	}
}