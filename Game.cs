using Raylib_cs;
using System.Numerics;

namespace Greed
{
    class Game
    {
        public void Play()
        {

            var ScreenHeight = 480;
            var ScreenWidth = 800;

            var PlayerRectangle = new Rectangle(ScreenWidth/2 , ScreenHeight-20, 50, 10);
            var Objects = new List<GameObject>();
            var MovementSpeed = 4;
            var Random = new Random();
            var Count = 0;
            var Value = new Score(0);
            var KeyStrokes = new KeyStrokes();

            Raylib.InitWindow(ScreenWidth, ScreenHeight, "Ball");
            Raylib.SetTargetFPS(60);

            while (!Raylib.WindowShouldClose())
            {
                
                var RandomX = Random.Next(ScreenWidth);
                var position = new Vector2(RandomX, 0);


                if (Count == 100){
                    var square = new GameSquare(Color.YELLOW, 10, -1);
                    square.Position = position;
                    square.Velocity = new Vector2(0, 2);
                    Objects.Add(square);

                    Count = 0;
                }

                if (Count == 50){
                    var CirRandomX = Random.Next(ScreenWidth);
                    var Cirposition = new Vector2(CirRandomX, 0);

                    var circle = new GameCircle(Color.BLUE, 5, 1);
                    circle.Position = Cirposition;
                    circle.Velocity = new Vector2(0, 2);
                    Objects.Add(circle);
                }

                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.BLACK);
                Raylib.DrawText("Catch as many Circles as you can :)", ScreenWidth/3, 20, 20, Color.WHITE);
                Raylib.DrawText("But watch out for the squares :/", ScreenWidth/3, 40, 20, Color.WHITE);

                // HERE
                PlayerRectangle = KeyStrokes.Move(PlayerRectangle, MovementSpeed);          

                Raylib.DrawRectangleRec(PlayerRectangle, Color.RED);

                foreach (var obj in Objects) {
                    obj.Draw();
                }

                Raylib.EndDrawing(); {
                }

                foreach (var obj in Objects.ToList()){
                    var fresh = new Rectangle(obj.Position.X, obj.Position.Y, 10, 10);
                    if (Raylib.CheckCollisionRecs(PlayerRectangle, fresh)) {
                        if (obj is GameSquare){
                            GameSquare square = (GameSquare)obj;
                            Value.Points += square.Value; 
                        }
                        if (obj is GameCircle){
                            GameCircle circle = (GameCircle)obj;
                            Value.Points += circle.Value; 
                        }
                        Objects.Remove(obj);
                    }
                }

                foreach (var obj in Objects) {
                    obj.Move();
                }
                Value.Draw();
                Count++;

            
                
        }
        Raylib.CloseWindow();
    }
}}