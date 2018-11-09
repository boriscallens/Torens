namespace Torens.Domain.ValueObjects
{
    public struct Position
    {
        public int Column;
        public int Layer;
        public int Row;

        public Position(int column, int layer, int row)
        {
            Column = column;
            Layer = layer;
            Row = row;
        }
    }
}