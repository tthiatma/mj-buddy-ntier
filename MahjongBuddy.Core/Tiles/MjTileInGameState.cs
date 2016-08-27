namespace MahjongBuddy.Tiles
{
    public enum MjTileInGameState : byte
    {
        //Tile belongs to the board
        Unrevealed = 1,
        //Tile just picked from the board
        JustPicked = 2,
        //Tile that is on player's hand
        UserActive = 3,
        //Tile is kept by player
        UserGraveyard = 4,
        //Tile is open and thrown to the board
        BoardGraveyard = 5
    }
}
