using UnityEngine;
using System.Collections;

namespace OAT
{
	public class UnitStopper : MonoBehaviour 
	{
		void OnTriggerEnter(Collider other) 
		{
			UnitController unit = other.gameObject.GetComponent<UnitController>();
			if(unit != null)
				unit.unitModel.UnitStopped();
		}
	}
}