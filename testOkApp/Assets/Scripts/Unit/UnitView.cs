﻿using UnityEngine;
using System.Collections;


namespace OAT
{
	public class UnitView : MonoBehaviour 
	{
		public UnitModel unitModel;
		public MeshRenderer meshRenderer;

		// temp
		public void KillUnit()
		{
			transform.Rotate(20f, 30f, 40f);
		}
	}
}