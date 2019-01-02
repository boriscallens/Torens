using System.Collections;
using System.Collections.Generic;

namespace Torens.Application.Tiles.Queries
{
    public class TileSet : IList<Tile>
    {
        private readonly IList<Tile> _listImplementation;

        public TileSet(IEnumerable<Tile> tileInfos)
        {
            _listImplementation = new List<Tile>(tileInfos);
        }

        public IEnumerator<Tile> GetEnumerator()
        {
            return _listImplementation.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_listImplementation).GetEnumerator();
        }

        public void Add(Tile item)
        {
            _listImplementation.Add(item);
        }

        public void Clear()
        {
            _listImplementation.Clear();
        }

        public bool Contains(Tile item)
        {
            return _listImplementation.Contains(item);
        }

        public void CopyTo(Tile[] array, int arrayIndex)
        {
            _listImplementation.CopyTo(array, arrayIndex);
        }

        public bool Remove(Tile item)
        {
            return _listImplementation.Remove(item);
        }

        public int Count => _listImplementation.Count;

        public bool IsReadOnly => _listImplementation.IsReadOnly;

        public int IndexOf(Tile item)
        {
            return _listImplementation.IndexOf(item);
        }

        public void Insert(int index, Tile item)
        {
            _listImplementation.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            _listImplementation.RemoveAt(index);
        }

        public Tile this[int index]
        {
            get => _listImplementation[index];
            set => _listImplementation[index] = value;
        }
    }
}