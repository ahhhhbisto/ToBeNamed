using System;
using System.Collections.Generic;
using ToBeNamed.Core.Algorithms;
using ToBeNamed.Core.Interfaces;

namespace ToBeNamed.Core
{
    public static class AlgorithmFactory
    {
        #region Member Variables 

        #endregion



        #region Properties
        
        public static Type ActiveAlgorithmType { get; set; }

        public static Type AvailableAlgorithmTypes { get; private set; }
            
        #endregion
        
        #region Constructors



        #endregion

        #region Events

        #region Handlers



        #endregion

        #region Invocators



        #endregion

        #endregion

        #region Internal Methods



        #endregion

        #region Public Methods

        public static void SetupAvailableAgorithmTypes()
        {
            throw new NotImplementedException("SetupAvailableAlgorithmTypes is not currently implemented.");
        }

        public static IPricingAlgorithm GetPricingAlgorithm()
        {
            if (ActiveAlgorithmType == null)
            {
                return new LinearStockBasedPricingAlgorithm();
            }
            return new LinearStockBasedPricingAlgorithm();
        }

        #endregion
    }
}
