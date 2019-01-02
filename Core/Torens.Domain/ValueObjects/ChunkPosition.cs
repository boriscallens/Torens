namespace Torens.Domain.ValueObjects
{
    public struct ChunkPosition
    {
        public static ChunkPosition Zero => new ChunkPosition(0, 0, 0);

        public readonly int Column;
        public readonly int Layer;
        public readonly int Row;

        public ChunkPosition(int column, int layer, int row)
        {
            Column = column;
            Layer = layer;
            Row = row;
        }

        public ChunkPosition Left()
        {
            return new ChunkPosition(Column+1, Layer, Row);
        }
        public ChunkPosition Right()
        {
            return new ChunkPosition(Column-1, Layer, Row);
        }
        public ChunkPosition Front()
        {
            return new ChunkPosition(Column, Layer, Row+1);
        }
        public ChunkPosition Back()
        {
            return new ChunkPosition(Column, Layer, Row-1);
        }
        public ChunkPosition Above()
        {
            return new ChunkPosition(Column, Layer+1, Row);
        }
        public ChunkPosition Below()
        {
            return new ChunkPosition(Column, Layer-1, Row);
        }
    }
}