using Raylib_cs;


namespace HelloWorld
{
    class Score : GameObject{
        public int Points { get; set; }
        public Score(int points) {
            Points = points;
        }

     // create costome draw method 
     override public void Draw() {
        string CurrentScore = Points.ToString();
        Raylib.DrawText(CurrentScore, 12, 12, 20, Color.WHITE);
    }
    }
    
}