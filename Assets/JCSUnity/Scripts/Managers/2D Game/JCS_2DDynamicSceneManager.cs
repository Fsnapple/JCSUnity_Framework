﻿/**
 * $File: JCS_2DDynamicSceneManager.cs $
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

    /// <summary>
    /// 
    /// </summary>
    public class JCS_2DDynamicSceneManager
        : MonoBehaviour
    {

        //----------------------
        // Public Variables
        public static JCS_2DDynamicSceneManager instance = null;

        //----------------------
        // Private Variables
        [SerializeField] private JCS_OrderLayer[] mJCSOrderLayer = null;

        //----------------------
        // Protected Variables

        //========================================
        //      setter / getter
        //------------------------------

        //========================================
        //      Unity's function
        //------------------------------
        private void Awake()
        {
            instance = this;

            // get all the scene layer in the scene.
            // so it could be manage
            mJCSOrderLayer = (JCS_OrderLayer[])Resources.FindObjectsOfTypeAll(typeof(JCS_OrderLayer));
        }


        //========================================
        //      Self-Define
        //------------------------------
        //----------------------
        // Public Functions

        /// <summary>
        /// Function provide to return the targeting order layer, 
        /// in the scene.
        /// </summary>
        /// <param name="orderLayerIndex"> index of the order layer u want to target. </param>
        /// <returns></returns>
        public JCS_OrderLayer GetOrderLayerByOrderLayerIndex(int orderLayerIndex)
        {
            foreach (JCS_OrderLayer jcsol in mJCSOrderLayer)
            {
                // find the order layer with the index passed in!
                if (jcsol.GetOrderLayer() == orderLayerIndex)
                    return jcsol;
            }

            JCS_Debug.JcsErrors(
                "JCS_2DDynamicSceneManager",
                 
                "Does not found the order layer u want.");

            return null;
        }

        /// <summary>
        /// Set the object into the scene layer in the scene.
        /// </summary>
        /// <param name="jcsOlo"> this keyword does not pass through, use this function will do. </param>
        /// <param name="orderLayerIndex"> index of scene layer </param>
        public void SetObjectParentToOrderLayerByOrderLayerIndex(JCS_OrderLayerObject jcsOlo, int orderLayerIndex)
        {
            SetObjectParentToOrderLayerByOrderLayerIndex(ref jcsOlo, orderLayerIndex);
        }
        /// <summary>
        /// Set the object into the scene layer in the scene.
        /// </summary>
        /// <param name="jcsOlo"> object u want to set to that specific scene layer </param>
        /// <param name="orderLayerIndex"> index of scene layer </param>
        public void SetObjectParentToOrderLayerByOrderLayerIndex(ref JCS_OrderLayerObject jcsOlo, int orderLayerIndex)
        {
            // get the order layer by order layer index!
            JCS_OrderLayer jcsol = GetOrderLayerByOrderLayerIndex(orderLayerIndex);

            // set parent
            jcsOlo.transform.SetParent(jcsol.transform);

            // set order layer to the pass in object.
            jcsOlo.SetOrderLayer(orderLayerIndex);
        }

        //----------------------
        // Protected Functions

        //----------------------
        // Private Functions

    }
}
