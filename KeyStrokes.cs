using Raylib_cs;


namespace Greed
{
    class KeyStrokes{

    public Rectangle Move(Rectangle PlayerRectangle, int MovementSpeed){
        if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT)) {
            PlayerRectangle.x += MovementSpeed;
        }

        if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT)) {
            PlayerRectangle.x -= MovementSpeed;
        } 
        return PlayerRectangle;
    }}}