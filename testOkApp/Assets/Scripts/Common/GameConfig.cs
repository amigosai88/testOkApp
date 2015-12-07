using UnityEngine;
using System.Collections;

namespace OAT
{
	public static class GameConfig
	{
		public static float LEVEL_TIME_SECONDS = 60f;
		public static int PLAYER_LIVES = 3;
		public static float GENERATION_RATE = 1f;
		public static float [] UNIT_SPEED = {1f, 1.2f, 1.5f};
		public static int[] GENERATE_CHANCE = {50, 35, 15};

	}
}