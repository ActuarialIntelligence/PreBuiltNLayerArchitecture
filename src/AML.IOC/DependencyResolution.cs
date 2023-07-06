﻿using SKF.Domain;
using SKF.Infrastructure.Readers;
using SKF.Infrastructure.Readers.Interfaces;
using System.Collections.Generic;
using Unity;

namespace SKF.IOC ///Inversion of control
{
    /// <summary>
    /// Service Locator
    /// </summary>
    public static class DependencyResolution
    {
        // Factory Pattern 
        public static UnityContainer container { get; private set; }
        public static void ConstructContainerAndRegisterTypes()
        {
            container = new UnityContainer();
            container.RegisterType<IDataReader<IList<DJListRow>>, DJExcelFileReader>();
        }
        /// <summary>
        /// For example purposes.
        /// </summary>
        /// <returns></returns>
        public static IDataReader<IList<DJListRow>> GetDJExcelFileReader()
        {
            var reader = container.Resolve<DJExcelFileReader>();// Resolving using constructor DI.
            return reader;
        }



    }
}
