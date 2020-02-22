using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utilities
{
    public static class Invertir
    {
        public static void InvertirObjetos<T> (ref T a, ref T b)
        {
            T c = b;
            b = a;
            a = c;
        }
    }
}