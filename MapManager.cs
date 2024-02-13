using Raylib_cs;
using System.Numerics;

namespace W2C
{
	public class MapManager
	{
		private static int selectedMaterial = 0;
		private static Dictionary<Vector2, int> placedBlocks = new();
		public static void DrawCursor(Vector2 location)
		{
			float thick = 2;
			Raylib.DrawLineEx(location * 32 + new Vector2(-16, -16), location * 32 + new Vector2(-16, -8), thick, Color.White);
			Raylib.DrawLineEx(location * 32 + new Vector2(-16, -16), location * 32 + new Vector2(-8, -16), thick, Color.White);
			Raylib.DrawLineEx(location * 32 + new Vector2(-16, 16), location * 32 + new Vector2(-16, 8), thick, Color.White);
			Raylib.DrawLineEx(location * 32 + new Vector2(-16, 16), location * 32 + new Vector2(-8, 16), thick, Color.White);
			Raylib.DrawLineEx(location * 32 + new Vector2(16, -16), location * 32 + new Vector2(8, -16), thick, Color.White);
			Raylib.DrawLineEx(location * 32 + new Vector2(16, -16), location * 32 + new Vector2(16, -8), thick, Color.White);
			Raylib.DrawLineEx(location * 32 + new Vector2(16, 16), location * 32 + new Vector2(8, 16), thick, Color.White);
			Raylib.DrawLineEx(location * 32 + new Vector2(16, 16), location * 32 + new Vector2(16, 8), thick, Color.White);
		}
		public static void DrawBlock(Vector2 location, int material, int alpha = 255)
		{
			if (material == 0)
			{
				Raylib.DrawLineEx(location * 32 + new Vector2(16, 16), location * 32 + new Vector2(-16, -16), 2, new Color(230, 41, 55, alpha));
				Raylib.DrawLineEx(location * 32 + new Vector2(16, -16), location * 32 + new Vector2(-16, 16), 2, new Color(230, 41, 55, alpha));
				Raylib.DrawLineEx(location * 32 + new Vector2(16, 16), location * 32 + new Vector2(-16, 16), 2, new Color(190, 33, 55, alpha));
				Raylib.DrawLineEx(location * 32 + new Vector2(16, 16), location * 32 + new Vector2(16, -16), 2, new Color(190, 33, 55, alpha));
				Raylib.DrawLineEx(location * 32 + new Vector2(-16, -16), location * 32 + new Vector2(-16, 16), 2, new Color(190, 33, 55, alpha));
				Raylib.DrawLineEx(location * 32 + new Vector2(-16, -16), location * 32 + new Vector2(16, -16), 2, new Color(190, 33, 55, alpha));
			}
		}
		public static void DrawMap()
		{
			foreach (KeyValuePair<Vector2, int> keyValuePair in placedBlocks)
			{
				DrawBlock(keyValuePair.Key, keyValuePair.Value);
			}
		}
		public static void DrawPreview(Vector2 position)
		{
			DrawBlock(position, selectedMaterial, 100);
		}
		public static void UserInput(Vector2 position)
		{
			if (Raylib.IsMouseButtonDown(MouseButton.Left))
			{
				placedBlocks[position] = selectedMaterial;
			}
			else if (Raylib.IsMouseButtonDown(MouseButton.Right))
			{
				if (placedBlocks.ContainsKey(position))
				{
					placedBlocks.Remove(position);
				}
			}
		}
	}
}