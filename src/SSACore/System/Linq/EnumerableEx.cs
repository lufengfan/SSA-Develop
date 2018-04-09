using SamLu;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Linq
{
    public static class EnumerableEx
    {
        public static int FindIndex<TSource>(this IEnumerable<TSource> source, TSource element) => EnumerableEx.FindIndex(source, element, EqualityComparer<TSource>.Default);

        public static int FindIndex<TSource>(this IEnumerable<TSource> source, TSource element, IEqualityComparer<TSource> equalityComparer)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            if (equalityComparer is null) throw new ArgumentNullException(nameof(equalityComparer));

            return EnumerableEx.FindIndexInternal(
                source,
                t => equalityComparer.Equals(t, element)
            );
        }

        public static int FindIndex<TSource, TElement>(this IEnumerable<TSource> source, Func<TSource, TElement> sourceSelector, TElement element) => EnumerableEx.FindIndex(source, sourceSelector, element, EqualityComparer<TElement>.Default);

        public static int FindIndex<TSource, TElement>(this IEnumerable<TSource> source, Func<TSource, TElement> sourceSelector, TElement element, IEqualityComparer<TElement> equalityComparer)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            if (sourceSelector is null) throw new ArgumentNullException(nameof(sourceSelector));
            if (equalityComparer is null) throw new ArgumentNullException(nameof(equalityComparer));

            return EnumerableEx.FindIndexInternal(
                source,
                t => equalityComparer.Equals(sourceSelector(t), element)
            );
        }

        public static int FindIndex<TSource, TElement>(this IEnumerable<TSource> source, TElement element, Func<TElement, TSource> elementSelector) => EnumerableEx.FindIndex(source, element, elementSelector, EqualityComparer<TSource>.Default);

        public static int FindIndex<TSource, TElement>(this IEnumerable<TSource> source, TElement element, Func<TElement, TSource> elementSelector, IEqualityComparer<TSource> equalityComparer)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            if (elementSelector is null) throw new ArgumentNullException(nameof(elementSelector));
            if (equalityComparer is null) throw new ArgumentNullException(nameof(equalityComparer));

            return EnumerableEx.FindIndexInternal(
                source,
                t => equalityComparer.Equals(t, elementSelector(element))
            );
        }

        public static int FindIndex<TSource, TTemporary, TElement>(this IEnumerable<TSource> source, Func<TSource, TTemporary> sourceSelector, TElement element, Func<TElement, TTemporary> elementSelector) => EnumerableEx.FindIndex(source, sourceSelector, element, elementSelector, EqualityComparer<TTemporary>.Default);

        public static int FindIndex<TSource, TTemporary, TElement>(this IEnumerable<TSource> source, Func<TSource, TTemporary> sourceSelector, TElement element, Func<TElement, TTemporary> elementSelector, IEqualityComparer<TTemporary> equalityComparer)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            if (sourceSelector is null) throw new ArgumentNullException(nameof(sourceSelector));
            if (elementSelector is null) throw new ArgumentNullException(nameof(elementSelector));
            if (equalityComparer is null) throw new ArgumentNullException(nameof(equalityComparer));

            return EnumerableEx.FindIndexInternal(
                source,
                t => equalityComparer.Equals(sourceSelector(t), elementSelector(element))
            );
        }

        private static int FindIndexInternal<TSource>(IEnumerable<TSource> source, Predicate<TSource> predicate)
        {
            int index = 0;
            foreach (var item in source)
            {
                if (predicate(item))
                    return index;
                else
                    index++;
            }

            return -1;
        }

        public static void ForEach<TSource>(this IEnumerable<TSource> source, Action<TSource> action)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (action == null) throw new ArgumentNullException(nameof(action));

            foreach (var item in source)
                action(item);
        }

        public static void ForEach<TSource>(this IEnumerable<TSource> source, Action<TSource, int> action)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (action == null) throw new ArgumentNullException(nameof(action));

            int index = 0;
            foreach (var item in source)
                action(item, index++);
        }

        public static IEnumerable<IIndexing<TSource>> IndexItems<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return EnumerableEx.IndexItemsInternal(source);
        }

        public static IEnumerable<IIndexing<TSource>> IndexItems<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            
            return EnumerableEx.IndexItemsInternal(source.Where(predicate));
        }

        private static IEnumerable<IIndexing<TSource>> IndexItemsInternal<TSource>(IEnumerable<TSource> source)
        {
            int index = 0;
            foreach (var item in source)
                yield return new IndexedItem<TSource>(index++, item);
        }

        public static IEnumerable NotOfType<TType>(this IEnumerable source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return EnumerableEx.NotOfTypeInternal<object, TType>(source.Cast<object>());
        }

        public static IEnumerable<TSource> NotOfType<TSource, TType>(this IEnumerable<TSource> source)
            where TType : TSource
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return EnumerableEx.NotOfTypeInternal<TSource, TType>(source);
        }
        
        private static IEnumerable<TSource> NotOfTypeInternal<TSource, TType>(IEnumerable<TSource> source)
           where TType : TSource
        {
            foreach (var obj in source)
            {
                if (obj is TType) continue;

                yield return obj;
            }
        }

        public static IEnumerable<object[]> MakeGroupWhile(this IEnumerable<IEnumerable> collections, Func<object[], bool> predicate)
        {
            IEnumerator[] enumerators = collections.Select(collection => collection.GetEnumerator()).ToArray();
            while (enumerators.Select(enumerator => enumerator.MoveNext()).All(hasNext => hasNext))
            {
                yield return enumerators.Select(enumerator => enumerator.Current).ToArray();
            }
        }

        public static IEnumerable<TSource[]> MakeGroupWhile<TSource>(this IEnumerable<IEnumerable<TSource>> collections, Func<TSource[], bool> predicate)
        {
            IEnumerator<TSource>[] enumerators = collections.Select(collection => collection.GetEnumerator()).ToArray();
            while (enumerators.Select(enumerator => enumerator.MoveNext()).All(hasNext => hasNext))
            {
                yield return enumerators.Select(enumerator => enumerator.Current).ToArray();
            }
        }

        public class Argument<TSource>
        {
            public ValueBox<TSource>[] Group { get; private set; }
            public bool[] MoveNext { get; private set; }
            public bool[] Skip { get; private set; }
            public bool Cancel { get; set; }

            internal Argument(ValueBox<TSource>[] group) : this(group, Enumerable.Repeat(true, group.Length).ToArray(), new bool[group.Length], false) { }
            internal Argument(ValueBox<TSource>[] group, bool[] moveNext) : this(group, moveNext, new bool[group.Length], false) { }
            internal Argument(ValueBox<TSource>[] group, bool[] moveNext, bool[] skip, bool cancel)
            {
                this.Group = group;
                this.MoveNext = moveNext;
                this.Skip = skip;
                this.Cancel = cancel;
            }
        }

        public static IEnumerable<ValueBox<TSource>[]> MakeGroupWhile<TSource>(this IEnumerable<IEnumerable<TSource>> collections, Func<Argument<TSource>, bool> controlCallback)
        {
            IEnumerator<TSource>[] enumerators = collections.Select(collection => collection.GetEnumerator()).ToArray();

            Argument<TSource> argument = new Argument<TSource>(
                new ValueBox<TSource>[enumerators.Length],
                Enumerable.Repeat(true, enumerators.Length).ToArray()
            );
            bool[] hasNexts = Enumerable.Repeat(true, enumerators.Length).ToArray();
            while (
                enumerators.Select((enumerator, index) =>
                {
                    bool hasNext;
                    if (hasNexts[index])
                    {
                        if (argument.MoveNext[index])
                            hasNext = enumerator.MoveNext();
                        else
                            hasNext = hasNexts[index];
                    }
                    else hasNext = false;

                    hasNexts[index] = hasNext;
                    return hasNext;
                }).ToArray().Any(hasNext => hasNext)
            )
            {
                argument = new Argument<TSource>(
                    enumerators.Select((enumerator, index) =>
                    {
                        if (hasNexts[index] && !argument.Skip[index])
                            return enumerator.Current;
                        else
                            return ValueBox<TSource>.Empty;
                    }).ToArray(),
                    hasNexts.ToArray()
                );
                bool acceptable = controlCallback(argument);
                if (argument.Cancel)
                    yield break;
                else
                {
                    ValueBox<TSource>[] group = enumerators.Select((enumerator, index) =>
                    {
                        if (hasNexts[index] && argument.MoveNext[index] && !argument.Skip[index])
                            return enumerator.Current;
                        else
                            return ValueBox<TSource>.Empty;
                    }).ToArray();

                    if (acceptable && group.Any(item => item.HasValue))
                        yield return group;
                    else
                        continue;
                }
            }
        }

        public static IEnumerable<TSource[]> MakeGroupWhile<TSource, TEnumerable>(this IEnumerable<TEnumerable> collections, Func<TSource[], bool> predicate)
            where TEnumerable : IEnumerable<TSource>
        {
            IEnumerator<TSource>[] enumerators = collections.Select(collection => collection.GetEnumerator()).ToArray();
            while (enumerators.Select(enumerator => enumerator.MoveNext()).All(hasNext => hasNext))
            {
                yield return enumerators.Select(enumerator => enumerator.Current).ToArray();
            }
        }

        public static IEnumerable<TSource> Join<TSource, TEnumerable>(this IEnumerable<TEnumerable> collections, TSource separator)
            where TEnumerable : IEnumerable<TSource>
        {
            return collections.Join<TSource, TEnumerable>(new[] { separator });
        }

        public static IEnumerable<TSource> Join<TSource, TEnumerable>(this IEnumerable<TEnumerable> collections, IEnumerable<TSource> separator)
            where TEnumerable : IEnumerable<TSource>
        {
            bool flag = false;
            foreach (var collection in collections)
            {
                if (flag)
                {
                    foreach (var item in separator) yield return item;
                }
                else flag = true;

                foreach (var item in collection) yield return item;
            }
        }

        public static bool SameAll<TSource>(this IEnumerable<TSource> source) =>
            source.SameAll(EqualityComparer<TSource>.Default.Equals);

        public static bool SameAll<TSource>(this IEnumerable<TSource> source, EqualityComparison<TSource> equalityComparison)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (equalityComparison == null) throw new ArgumentNullException(nameof(equalityComparison));

            TSource first = source.First();
            return source.All(item => equalityComparison(first, item));
        }

        public static bool SameAll<TSource>(this IEnumerable<TSource> source, IEqualityComparer<TSource> equalityComparer)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (equalityComparer == null) throw new ArgumentNullException(nameof(equalityComparer));

            return source.SameAll(equalityComparer.Equals);
        }
    }
}
