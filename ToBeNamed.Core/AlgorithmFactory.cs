using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using ToBeNamed.Core.Algorithms;
using ToBeNamed.Core.Interfaces;

namespace ToBeNamed.Core
{
    public static class AlgorithmFactory
    {
        #region Member Variables 

        private static Type[] _availableAlgorithmTypes = new Type[0];

        #endregion
        
        #region Properties
        
        public static Type ActiveAlgorithmType { get; set; }

        public static Type[] AvailableAlgorithmTypes { get { return _availableAlgorithmTypes; } }
            
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

        private static Type[] GetAlgorithmTypesFromAssembly(Assembly assembly)
        {
            return assembly.GetTypes().Where(t => t.IsClass && typeof (IPricingAlgorithm).IsAssignableFrom(t)).ToArray();
        }

        #endregion

        #region Public Methods

        public static void SetupAvailableAgorithmTypes()
        {
            var types = new List<Type>();
            foreach (var a in AppDomain.CurrentDomain.GetAssemblies())
            {
                types.AddRange(GetAlgorithmTypesFromAssembly(a));
            }
            var dir = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)??string.Empty,"Algorithms");
            if (!Directory.Exists(dir))
            {
                try
                {
                    Directory.CreateDirectory(dir);
                }
                catch (Exception)
                {
                    _availableAlgorithmTypes = types.ToArray();
                    return;
                }
            }
            foreach (var s in Directory.GetFiles(dir, "*.dll"))
            {
                try
                {
                    var assembly = Assembly.LoadFile(s);
                    if (assembly != null)
                    {
                        types.AddRange(GetAlgorithmTypesFromAssembly(assembly));
                    }
                }
                catch (MissingMethodException)
                {
                }
                catch (NullReferenceException)
                {
                }
            }
            _availableAlgorithmTypes = types.ToArray();
        }

        public static IPricingAlgorithm GetPricingAlgorithm()
        {
            var defaultAlgorithm = new LinearStockBasedPricingAlgorithm();
            if (ActiveAlgorithmType == null)
            {
                return defaultAlgorithm;
            }
            if (typeof (IPricingAlgorithm).IsAssignableFrom(ActiveAlgorithmType) && ActiveAlgorithmType.IsClass)
            {
                IPricingAlgorithm obj = null;
                try
                {
                    obj = ((IPricingAlgorithm) Activator.CreateInstance(ActiveAlgorithmType, true)) ?? defaultAlgorithm;
                }
                catch
                {
                    return defaultAlgorithm;
                }
                return obj;
            }
            return defaultAlgorithm;
        }

        #endregion
    }
}
