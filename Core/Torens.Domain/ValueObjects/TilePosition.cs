namespace Torens.Domain.ValueObjects
{
    public struct TilePosition
    {
        public static TilePosition Zero => new TilePosition(0, 0, 0);

        public readonly int Column;
        public readonly int Layer;
        public readonly int Row;

        public TilePosition(int column, int layer, int row)
        {
            Column = column;
            Layer = layer;
            Row = row;
        }

        public TilePosition Left()
        {
            return new TilePosition(Column+1, Layer, Row);
        }
        public TilePosition Right()
        {
            return new TilePosition(Column-1, Layer, Row);
        }
        public TilePosition Front()
        {
            return new TilePosition(Column, Layer, Row+1);
        }
        public TilePosition Back()
        {
            return new TilePosition(Column, Layer, Row-1);
        }
        public TilePosition Above()
        {
            return new TilePosition(Column, Layer+1, Row);
        }
        public TilePosition Below()
        {
            return new TilePosition(Column, Layer-1, Row);
        }
    }
}