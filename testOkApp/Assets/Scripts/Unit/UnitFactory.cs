﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace OAT
{
	public class UnitFactory : MonoBehaviour 
	{
		private static UnitFactory m_instance = null;
		public static UnitFactory Instance
		{
			get { return m_instance; }
		}

		public Material[] unitMaterials;
		public UnitModel unitModelPrefab;
		List<UnitModel> objectsPool = new List<UnitModel>();

		void Awake()
		{
			m_instance = this;
		}

		public UnitModel GenerateUnit(UnitInfo info)
		{
			UnitModel unit = GetFromPool(info);

			if(unit != null)
			{
				unit.unitState = UnitState.Run;
				unit.gameObject.SetActive(true);
				unit.unitView.gameObject.SetActive(true);
				unit.unitController.gameObject.SetActive(true);
			}
			else
			{
				unit = Instantiate<UnitModel>(unitModelPrefab);
				unit.unitInfo = info;
				unit.unitMove = AddMove(unit, info);
				unit.unitView.meshRenderer.material = unitMaterials[(int)info.m_unitType];
			}
			
			unit.transform.position = GetStartPosition();
			unit.unitMove.Init(info);
			return unit;
		}

		BaseUnitMove AddMove(UnitModel unit, UnitInfo info)
		{
			switch (info.m_unitType)
			{
				case UnitType.EnemyLinear:
				     return unit.gameObject.AddComponent<BaseUnitMove>();

				default:
					 return unit.gameObject.AddComponent<DiagonalMove>();
			}
		}

		Vector3 GetStartPosition()
		{
			return new Vector3(Random.Range(-WorldRect.Instance.PLAY_FIELD_WIDTH, WorldRect.Instance.PLAY_FIELD_WIDTH), 0f, 0f);
		}

		public void AddToPool(UnitModel unit)
		{
			objectsPool.Add(unit);
		}

		public UnitModel GetFromPool(UnitInfo info)
		{
			UnitModel result = null;

			foreach(UnitModel unit in objectsPool)
			{
				if(unit.unitInfo.m_unitType == info.m_unitType)
				{
					result = unit;
					break;
				}
			}

			if(result != null)
				objectsPool.Remove(result);

			return result;
		}

	}
}