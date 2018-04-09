using SamLu;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace TimelineComposite.CommandLine
{
    [DebuggerDisplay("Count = {Count}")]
    public class NamedFileCollection : ICollection<string>, IDictionary<string, string>
    {
        private IDictionary<ValueBox<string>, string> innerDictionary;

        internal NamedFileCollection(IDictionary<ValueBox<string>, string> dictionary) =>
            this.innerDictionary = dictionary ?? throw new ArgumentNullException(nameof(dictionary));

        public int Count => this.innerDictionary.Count;

        public bool IsReadOnly => this.innerDictionary.IsReadOnly;

        public ICollection<string> Names =>
            new ReadOnlyCollection<string>(
                (from valueBox in this.innerDictionary.Keys where valueBox.HasValue select valueBox.Value).ToList()
            );
        ICollection<string> IDictionary<string, string>.Keys => this.Names;

        public ICollection<string> FileNames => this.innerDictionary.Values;
        ICollection<string> IDictionary<string, string>.Values => this.FileNames;

        public string this[string name]
        {
            get
            {
                if (this.ContainsName(name))
                    return this.innerDictionary[name];
                else throw new KeyNotFoundException();
            }
            set
            {
                if (this.ContainsName(name))
                    this.innerDictionary[name] = value;
                else throw new KeyNotFoundException();
            }
        }

        public void Add(string fileName) => this.Add(ValueBox<string>.Empty, fileName);

        public void Add(string name, string fileName) => this.Add(new ValueBox<string>(name), fileName);

        private void Add(ValueBox<string> name, string fileName)
        {
            if (fileName == null) throw new ArgumentNullException(nameof(fileName));
            if (!File.Exists(fileName)) throw new FileNotFoundException("文件不存在。", fileName);

            this.innerDictionary.Add(name, fileName);
        }

        void ICollection<KeyValuePair<string, string>>.Add(KeyValuePair<string, string> item) => this.innerDictionary.Add(new KeyValuePair<ValueBox<string>, string>(item.Key, item.Value));

        public void Clear() => this.innerDictionary.Clear();

        public bool Contains(string item) => this.innerDictionary.Values.Contains(item);
        bool ICollection<KeyValuePair<string, string>>.Contains(KeyValuePair<string, string> item) => this.innerDictionary.Contains(new KeyValuePair<ValueBox<string>, string>(item.Key, item.Value));

        public bool ContainsName(string name) => this.Names.Contains(name);
        bool IDictionary<string, string>.ContainsKey(string key) => this.ContainsName(key);

        public void CopyTo(string[] array, int arrayIndex) => this.innerDictionary.Values.CopyTo(array, arrayIndex);
        void ICollection<KeyValuePair<string, string>>.CopyTo(KeyValuePair<string, string>[] array, int arrayIndex)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));

            (from pair in this.innerDictionary where pair.Key.HasValue select new KeyValuePair<string, string>(pair.Key.Value, pair.Value)).ToArray().CopyTo(array, arrayIndex);
        }

        IEnumerator<string> IEnumerable<string>.GetEnumerator() => this.innerDictionary.Values.GetEnumerator();
        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            foreach (var pair in this.innerDictionary)
            {
                if (pair.Key.HasValue)
                    yield return new KeyValuePair<string, string>(pair.Key.Value, pair.Value);
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        public bool Remove(string item) => this.innerDictionary.Remove(item);
        bool ICollection<KeyValuePair<string, string>>.Remove(KeyValuePair<string, string> item) => this.innerDictionary.Remove(new KeyValuePair<ValueBox<string>, string>(item.Key, item.Value));

        bool IDictionary<string, string>.TryGetValue(string key, out string value) => this.innerDictionary.TryGetValue(key, out value);
    }
}
