﻿using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20250218
{
    class DynamicArray
    {
        public DynamicArray()
        {

        }

        ~DynamicArray()
        {

        }

        //objects
        //[1][2][3]
        // ^  ^  ^  ^
        //newObjects
        //[1][2][3][][][]
        //          ^
        //objects <- newObjects 
        //[1][2][3][4][][]
        //          ^
        public void Add(Object inObject)
        {
            if (count >= objects.Length)
            {
                ExtendSpace();
            }
            objects[count] = inObject;
            count++;
            count = count;
        }

        protected void ExtendSpace()
        {
            //배열 늘이기
            //이전 정보 옮기기
            Object[] newObject = new Object[objects.Length * 2];
            //이전값 이동
            for (int i = 0; i < objects.Length; ++i)
            {
                newObject[i] = objects[i];
            }
            objects = null;
            objects = newObject;
        }

        //[][][][][]
        public bool Remove(Object removObject)
        {
            //removObject를 찾아내 지우기
            for(int i=0; i<objects.Length; ++i)
            {
                if(removObject == objects[i])
                {
                    return RemoveAt(i);
                   
                }
            }
            return false;
        }

        //[][][][][]
        public bool RemoveAt(int index)
        {
            //index번째 항목을 지우기
            if (index >= 0 && index < Count)
            {
                for(int i = index+1;i<Count-1;i++)
                {
                    objects[i] = objects[i+1];
                }
                count--;

                return true;
            }
            return false;
        }

        //[1][2][3][4]
        //insert(2,5);
        //[1][2][3][5][4]
        public void Insert(int insertIndex, Object value)
        {
            //insertIndex번 인덱스 바로 뒤에 value를 추가
            //object.length == count일 때 확장 후 추가
            //object.length < count일 때 확장 없이 추가
            if(objects.Length == count)
            {
                ExtendSpace();
            }
            for(int i = count; i > insertIndex; i--)
            {
                objects[i] = objects[i-1];
            }
            objects[insertIndex + 1] = value;
            count++;
        }

        protected Object[] objects = new Object[3];


        protected int count = 0;  //맨 뒷자리 지시

        public int Count
        {
            get
            {
                return count;
            }
        }

        public Object this[int index]
        {
            get
            {
                return objects[index];
            }
            set
            {
                if (index < objects.Length)
                {
                    objects[index] = value;
                }
            }
        }
    }


    class Program
    {
        static void PrintDynamicArray(DynamicArray a)
        {
            for (int i = 0; i < a.Count; ++i)
            {
                Console.Write(a[i] + ", ");
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            //[] ->                  variable
            //[][][][][]             array -> Array
            //[][][][][][][][][][]   DynamicArray
            //DataStructure          자료구조
            //


            DynamicArray a = new DynamicArray();
            for (int i = 0; i < 10; ++i)
            {
                a.Add(i);
            }

            PrintDynamicArray(a);

            a[1] = 11;
            a[9] = 29;

            PrintDynamicArray(a);

            a.RemoveAt(9);
            PrintDynamicArray(a);

            a.RemoveAt(1);
            PrintDynamicArray(a);

            a.RemoveAt(3);
            PrintDynamicArray(a);

            a.Insert(1, 2);
            PrintDynamicArray(a);

        }
    }
}