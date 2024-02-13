using Raylib_cs;
using System.Numerics;

namespace W2C
{
	class Program
	{
		public static void Main()
		{
			Image icon = Raylib.LoadImage("hammer.png");
			Raylib.SetWindowState(ConfigFlags.ResizableWindow);
			Raylib.InitWindow(800, 480, "Worbench 2D Creator");
			Raylib.SetWindowIcon(icon);
			Camera2D camera = new Camera2D() { Target = Vector2.Zero, Offset = Vector2.Zero, Rotation = 0, Zoom = 2 };
			while (!Raylib.WindowShouldClose())
			{
				Vector2 render = new(Raylib.GetRenderWidth(), Raylib.GetRenderHeight());
				Vector2 mouseLocation = (Raylib.GetMousePosition() - render / 2) / camera.Zoom;
				camera.Offset = new Vector2(render.X / 2, render.Y / 2);
				Raylib.BeginDrawing();
				Raylib.ClearBackground(Color.Black);
				Raylib.BeginMode2D(camera);
				MapManager.DrawMap();
				Vector2 need = new Vector2((int)MathF.Round(mouseLocation.X / 32), (int)MathF.Round(mouseLocation.Y / 32));
				MapManager.DrawPreview(need);
				MapManager.DrawCursor(need);
				MapManager.UserInput(need);
				Raylib.EndMode2D();
				Raylib.DrawFPS(10, 10);
				Raylib.EndDrawing();
			}
			Raylib.CloseWindow();
		}
	}
}