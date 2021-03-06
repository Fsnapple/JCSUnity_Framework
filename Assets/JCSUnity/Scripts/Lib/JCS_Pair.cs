﻿/**
 * $File: JCS_Pair.cs $
 * $Date: $
 * $Revision: $
 * $Creator: Jen-Chieh Shen $
 * $Notice: See LICENSE.txt for modification and distribution information 
 *                   Copyright (c) 2016 by Shen, Jen-Chieh $
 */
using UnityEngine;
using System.Collections;


namespace JCSUnity
{
    public class JCS_Pair<T, U>
    {

        //----------------------
        // Public Variables

        //----------------------
        // Private Variables
        public T pair1 = default(T);
        public U pair2 = default(U);

        //----------------------
        // Protected Variables

        //========================================
        //      setter / getter
        //------------------------------

        //========================================
        //      Constructor
        //------------------------------
        public JCS_Pair()
        {

        }

        public JCS_Pair(T pair1, U pair2)
        {
            Set(pair1, pair2);
        }

        //========================================
        //      Self-Define
        //------------------------------
        //----------------------
        // Public Functions

        /// <summary>
        /// Set the pair value.
        /// </summary>
        /// <param name="pair1"></param>
        /// <param name="pair2"></param>
        public void Set(T pair1, U pair2)
        {
            this.pair1 = pair1;
            this.pair2 = pair2;
        }

        //----------------------
        // Protected Functions

        //----------------------
        // Private Functions

    }
}
