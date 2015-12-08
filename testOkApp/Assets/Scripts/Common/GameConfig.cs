using UnityEngine;
using System.Collections;

namespace OAT
{
	public static class GameConfig
	{
		public static float LEVEL_TIME_SECONDS = 60f;

		public static int PLAYER_LIVES = 3;

		public static float [] UNIT_SPEED = {0.05f, 0.052f, 0.055f};

		public static float GENERATION_RATE_MIN = 1f;
		public static float GENERATION_RATE_MAX = 3f;

		public static int[] GENERATE_CHANCE = {50, 35, 15};

		public static float DIAGONAL_MOVING_TIME = 1.2f;
		public static float DIAGONAL_MOVING_RATE = 1.5f;
		public static float DIAGONAL_MOVING_SPEED = 0.05f;

		public static float BOMB_SPEED = 0.08f;
		public static float BOMB_RADIUS = 3f;
		public static int BOMBS_COUNT = 3;
	}
}