using System;
using System.Collections.Generic;

namespace IteratorEx
{
    // Iterator 패턴 
    // 컨테이너의 종류 상관없이 모든 컨테이너 요소에 접근하는 공통 인터페이스 정의
    abstract class Iterator<T>
    {
        public abstract T Next();

        public abstract bool HasNext();

        public abstract void Remove();
    }

    // 리스트 Iterator
    class ListIterator<T> : Iterator<T>
    {
        List<T> container;
        int position = 0;

        public ListIterator(List<T> other)
        {
            container = other;
            this.position = 0;
        }

        // 다음 요소가 있는지 체크.
        public override bool HasNext()
        {
            if (position >= container.Count || container == null || container.Count == 0)
                return false;

            return true;
        }

        // 현재 요소 반환. Postion 다음 으로 이동.
        public override T Next()
        {
            // 컨테이너 넘치면 더 이상 반환하지 않음.
            if (position > container.Count - 1)
            {
                return default(T);
            }

            T current = container[position];
            position++;

            // 현재 요소 반환
            return current;
        }

        // 현재 위치 요소 제거. 잘 쓸지는 모르겠당
        public override void Remove()
        {
            if (position >= container.Count || container == null || container.Count == 0 || position < 0)
                return;

            // 현재 위치 요소 제거 후 컨테이너 재정렬.
            container.RemoveAt(position);
            container.TrimExcess();

            // 지운 후 현재 위치가 컨테이너 범위 밖이면 위치 이동.
            if (position > container.Count - 1)
            {
                position--;
            }
        }
    }

    // Dictionary Iterator
    class DictionaryIterator<K, V> : Iterator<V>
    {
        Dictionary<K, V> container;

        // Dictionary는 index 접근이 불가하므로 열거자 인터페이스를 멤버변수에 저장해둔다.
        Dictionary<K, V>.Enumerator enumerator;

        // 반복 횟수 저장
        int iterCount = 0;

        public DictionaryIterator(Dictionary<K, V> dictionary)
        {
            container = dictionary;
            enumerator = dictionary.GetEnumerator();
            iterCount = 0;
        }

        public override bool HasNext()
        {
            if (container.Count == 0 || container == null || iterCount > container.Count - 1)
                return false;

            return true;
        }

        public override V Next()
        {
            // 다음 요소 접근 가능 한지 확인.
            enumerator.MoveNext();

            // 현재 값 가져옴
            V current = enumerator.Current.Value;

            // 반복 횟수 증가.
            iterCount++;

            return current;
        }

        public override void Remove()
        {
            // 현재 요소 키를 가져옴.
            K currentKey = enumerator.Current.Key;
            container.Remove(currentKey);
        }
    }
}
